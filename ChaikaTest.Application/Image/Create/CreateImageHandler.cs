using ChaikaTest.Domain.Constants;
using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using ChaikaTest.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Image.Create
{
    public class CreateImageHandler : IRequestHandler<CreateImageRequestDTO, CreateImageResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;
        private readonly IMD5ChecksumService _mD5ChecksumService;
        public string GUID { get; set; }

        public CreateImageHandler(Context context, IMediator mediator,IMD5ChecksumService mD5ChecksumService)
        {
            _context = context;
            _mediator = mediator;
            _mD5ChecksumService = mD5ChecksumService;
            var guidPath = Path.Combine(Directory.GetCurrentDirectory(), "server-GUID");
            GUID = System.IO.File.ReadAllText(guidPath);
        }

        public async Task<CreateImageResponseDTO> Handle(CreateImageRequestDTO request, CancellationToken cancellationToken)
        {

            var file = request.Files.FirstOrDefault();

            var buffer = DataExtractor.FileToBytes(file);
            var fileExt = file.FileName.Split('.').Last();
            var hash = _mD5ChecksumService.MD5Checksum(buffer);

            var image = new Domain.Image()
            {
                ContentType = file.ContentType,
                FileName = $"{hash}.{fileExt}",
                Length = file.Length,
                ImageType = ImageType.Icon
            };


            image.FileName = $"{GUID}-{hash}.{fileExt}";
            _context.Images.Add(image);
            await _context.SaveChangesAsync(cancellationToken);

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == request.TransactionId, cancellationToken);
            if(transaction is null)
            {
                throw new Exception("Transaction don't found");
            }
            else
            {
                transaction.Images.Add(image);
            }

             _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateImageResponseDTO(image.Id);
        }
    }
}

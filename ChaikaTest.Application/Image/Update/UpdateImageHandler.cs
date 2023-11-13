using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using ChaikaTest.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Image.Update
{
    public class UpdateImageHandler : IRequestHandler<UpdateImageRequestDTO, UpdateImageResponseDTO>
    {
        private readonly Context _context;
        private readonly IMD5ChecksumService _mD5ChecksumService;
        private readonly IMediator _mediator;

        public UpdateImageHandler(Context context, IMD5ChecksumService mD5ChecksumService, IMediator mediator)
        {
            _context = context;
            _mD5ChecksumService = mD5ChecksumService;
            _mediator = mediator;
        }

        public async Task<UpdateImageResponseDTO> Handle(UpdateImageRequestDTO request, CancellationToken cancellationToken)
        {
            var file = request.Files.FirstOrDefault();

            var buffer = DataExtractor.FileToBytes(file);
            var fileExt = file.FileName.Split('.').Last();
            var hash = _mD5ChecksumService.MD5Checksum(buffer);

            var result = await _context.Images.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(result);

            result.ContentType = file.ContentType;
            result.FileName = $"{hash}.{fileExt}";
            result.Length = file.Length;

            _context.Images.Update(result);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateImageResponseDTO { Success = true };
        }
    }
}

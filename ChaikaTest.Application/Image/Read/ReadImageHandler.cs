using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Image.Read
{
    public class ReadImageHandler : IRequestHandler<ReadImageRequestDTO, ReadImageResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public ReadImageHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ReadImageResponseDTO> Handle(ReadImageRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _context.Images
                .FirstOrDefaultAsync(e => e.Id == request.ImageId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(result);

            return new ReadImageResponseDTO()
            {
                FileName = result.FileName,
                ContentType = result.ContentType,
                Content = result.Content,
            };
        }
    }
}


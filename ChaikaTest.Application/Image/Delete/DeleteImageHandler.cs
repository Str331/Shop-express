using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Image.Delete
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageRequestDTO, Unit>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public DeleteImageHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteImageRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _context.Images
               .FirstOrDefaultAsync(e => e.Id == request.ImageId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(result);

            _context.Images.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}

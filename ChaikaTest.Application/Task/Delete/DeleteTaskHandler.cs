using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopTest.View.Task.Delete
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequestDTO>
    {
        private readonly Context _context;
        public DeleteTaskHandler(Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTaskRequestDTO request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(task);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

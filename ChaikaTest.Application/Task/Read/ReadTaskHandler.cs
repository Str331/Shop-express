using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopTest.View.Task.Read
{
    public class ReadTaskHandler : IRequestHandler<ReadTaskRequestDTO, ReadTaskResponseDTO>
    {
        private readonly Context _context;

        public ReadTaskHandler(Context context)
        {
            _context = context;
        }
        public async Task<ReadTaskResponseDTO> Handle(ReadTaskRequestDTO request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(task);

            var result = new ReadTaskResponseDTO
            {
                TaskId = task.Id,
                TaskName = task.TaskName,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DeadLine = task.DeadLine,
                Done = task.Done,
            };

            return result;
        }
    }
}

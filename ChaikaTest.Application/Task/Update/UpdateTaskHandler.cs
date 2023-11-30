using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopTest.View.Task.Update
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequestDTO, int>
    {
        private readonly Context _context;

        public UpdateTaskHandler(Context context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTaskRequestDTO request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(task);

            task.TaskName = request.TaskName ?? task.TaskName;
            task.Description = request.Description ?? task.Description;
            task.Done = request.Done;
            task.DeadLine = request.DeadLine ?? task.DeadLine;

            return task.Id;
        }
    }
}

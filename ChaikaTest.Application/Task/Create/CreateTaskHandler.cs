using ChaikaTest.Domain;
using ChaikaTest.Infrastructure.Database;
using MediatR;

namespace ShopTest.View.Task.Create
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskRequestDTO, int>
    {
        private readonly Context _context;

        public CreateTaskHandler(Context context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTaskRequestDTO request, CancellationToken cancellationToken)
        {
            var task = new Tasks
            {
                TaskName = request.TaskName,
                Description = request.Description,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd"),
                DeadLine = request.DeadLine,
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}

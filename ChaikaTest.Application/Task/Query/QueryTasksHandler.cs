using ChaikaTest.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopTest.View.Task.Read;

namespace ShopTest.View.Task.Query
{
    public class QueryTasksHandler : IRequestHandler<QueryTasksRequestDTO, QueryTasksResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public QueryTasksHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<QueryTasksResponseDTO> Handle(QueryTasksRequestDTO request, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks
                .ToListAsync(cancellationToken);

            List<ReadTaskResponseDTO> readTasks = new();

            foreach (var task in tasks)
            {
                var result = await _mediator.Send(new ReadTaskRequestDTO(task.Id), cancellationToken);
                readTasks.Add(result);
            }

            return new QueryTasksResponseDTO { Tasks = readTasks };
        }
    }
}

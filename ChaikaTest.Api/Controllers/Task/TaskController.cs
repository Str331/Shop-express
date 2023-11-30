using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTest.Api.Controllers.Task.Create;
using ShopTest.Api.Controllers.Task.Query;
using ShopTest.Api.Controllers.Task.Read;
using ShopTest.Api.Controllers.Task.Update;
using ShopTest.View.Task.Delete;
using ShopTest.View.Task.Query;
using ShopTest.View.Task.Read;

namespace ShopTest.Api.Controllers.Task
{
    [Route("Task")]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> CreateTask([FromBody] CreateTaskRequest request)
        {
            return await _mediator.Send(request.GetDTO());
        }

        [HttpDelete("{taskId}")]
        public async Task<Unit> DeleteTask(int taskId)
        {
            return await _mediator.Send(new DeleteTaskRequestDTO(taskId));
        }

        [HttpPut("{taskId}")]
        public async Task<int> UpdateTask(int taskId, [FromBody] UpdateTaskRequest request)
        {
            return await _mediator.Send(request.GetDTO(taskId));
        }

        [HttpGet("{taskId}")]
        public async Task<ReadTaskResponse> ReadTask(int taskId)
        {
            var result = await _mediator.Send(new ReadTaskRequestDTO(taskId));

            return new ReadTaskResponse(result);
        }

        [HttpGet("All-Tasks")]
        public async Task<QueryTasksResponse> AllTasks()
        {
            var result = await _mediator.Send(new QueryTasksRequestDTO());

            return new QueryTasksResponse(result);
        }
    }
}

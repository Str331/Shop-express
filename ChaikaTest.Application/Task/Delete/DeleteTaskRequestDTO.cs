using MediatR;

namespace ShopTest.View.Task.Delete
{
    public class DeleteTaskRequestDTO : IRequest
    {
        public int TaskId { get; set; }

        public DeleteTaskRequestDTO(int taskId)
        {
            TaskId = taskId;
        }
    }
}

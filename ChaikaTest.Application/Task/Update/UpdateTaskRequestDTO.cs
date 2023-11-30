using MediatR;

namespace ShopTest.View.Task.Update
{
    public class UpdateTaskRequestDTO : IRequest<int>
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public DateTime? DeadLine { get; set; }

        public UpdateTaskRequestDTO(int taskId)
        {
            TaskId = taskId;
        }
    }
}

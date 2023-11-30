using ShopTest.View.Task.Update;

namespace ShopTest.Api.Controllers.Task.Update
{
    public class UpdateTaskRequest
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public DateTime? DeadLine { get; set; }

        public UpdateTaskRequestDTO GetDTO(int taskId)
        {
            return new UpdateTaskRequestDTO(taskId)
            {
                TaskId = taskId,
                TaskName = TaskName,
                Description = Description,
                Done = Done,
                DeadLine = DeadLine,
            };
        }
    }
}

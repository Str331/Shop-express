using ShopTest.View.Task.Create;

namespace ShopTest.Api.Controllers.Task.Create
{
    public class CreateTaskRequest
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime? DeadLine { get; set; }

        public CreateTaskRequestDTO GetDTO()
        {
            return new CreateTaskRequestDTO
            {
                TaskName = TaskName,
                DeadLine = DeadLine,
                Description = Description,
            };
        }
    }
}

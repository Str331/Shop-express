using ShopTest.View.Task.Read;

namespace ShopTest.Api.Controllers.Task.Read
{
    public class ReadTaskResponse
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public string CreatedAt { get; set; }

        public bool Done { get; set; }

        public DateTime? DeadLine { get; set; }

        public ReadTaskResponse(ReadTaskResponseDTO dTO)
        {
            TaskId = dTO.TaskId;
            TaskName = dTO.TaskName;
            Description = dTO.Description;
            CreatedAt = dTO.CreatedAt;
            Done = dTO.Done;
            DeadLine = dTO.DeadLine;
        }
    }
}

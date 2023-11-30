namespace ShopTest.View.Task.Read
{
    public class ReadTaskResponseDTO
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public string CreatedAt { get; set; }

        public bool Done { get; set; }

        public DateTime? DeadLine { get; set; }
    }
}

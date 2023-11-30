namespace ChaikaTest.Domain
{
    public class Tasks
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public string CreatedAt { get; set; }

        public DateTime? DeadLine { get; set; }

        public Tasks()
        {
            Done = false;
        }
    }
}

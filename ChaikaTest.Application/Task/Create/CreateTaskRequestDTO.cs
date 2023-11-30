using MediatR;

namespace ShopTest.View.Task.Create
{
    public class CreateTaskRequestDTO : IRequest<int>
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime? DeadLine { get; set; }
    }
}

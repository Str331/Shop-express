using MediatR;

namespace ShopTest.View.Task.Read
{
    public class ReadTaskRequestDTO : IRequest<ReadTaskResponseDTO>
    {
        public int TaskId { get; set; }

        public ReadTaskRequestDTO(int taskId)
        {
            TaskId = taskId;
        }
    }
}

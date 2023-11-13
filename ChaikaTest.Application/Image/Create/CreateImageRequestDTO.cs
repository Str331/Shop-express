using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChaikaTest.Application.Image.Create
{
    public class CreateImageRequestDTO : IRequest<CreateImageResponseDTO>
    {
        public int TransactionId { get; set; }

        public IFormFileCollection Files { get; set; }

        public CreateImageRequestDTO(int transactionId,IFormFileCollection files)
        {
            Files = files;
            TransactionId = transactionId;
        }
    }
}

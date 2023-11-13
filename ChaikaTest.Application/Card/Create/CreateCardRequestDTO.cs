using MediatR;

namespace ChaikaTest.Application.Card.Create
{
    public class CreateCardRequestDTO : IRequest<CreateCardResponseDTO>
    {
        public string BankName { get; set; }

        public CreateCardRequestDTO(string bankName)
        {
            BankName = bankName;
        }
    }
}

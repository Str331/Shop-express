using ChaikaTest.Application.Transaction.Create;
using ChaikaTest.Domain.Constants;

namespace ChaikaTest.Api.Controllers.Transaction.Create
{
    public class CreateTransactionRequest
    {
        public int CardId { get; set; }

        public TransactionType TransactionType { get; set; }

        public int Sum { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Pending { get; set; }

        public string AuthorizedUser { get; set; }


        public CreateTransactionRequestDTO GetDTO()
        {
            return new CreateTransactionRequestDTO()
            {
                CardId = CardId,
                AuthorizedUser = AuthorizedUser,
                Description = Description,
                Name = Name,
                Pending = Pending,
                Sum = Sum,
                TransactionType = TransactionType,
            };
        }
    }
}

using MediatR;

namespace ChaikaTest.Application.Transaction.Read
{
    public class ReadTransactionRequestDTO : IRequest<ReadTransactionResponseDTO>
    {
        public int TransactionId { get; set; }

        public ReadTransactionRequestDTO(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}

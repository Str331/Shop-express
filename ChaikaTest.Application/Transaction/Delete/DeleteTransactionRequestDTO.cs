using MediatR;

namespace ChaikaTest.Application.Transaction.Delete
{
    public class DeleteTransactionRequestDTO : IRequest<Unit>
    {
        public int TransactionId { get; set; }

        public DeleteTransactionRequestDTO(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}

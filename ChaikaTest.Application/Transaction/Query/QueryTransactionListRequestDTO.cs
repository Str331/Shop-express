using MediatR;

namespace ChaikaTest.Application.Transaction.Query
{
    public class QueryTransactionListRequestDTO : IRequest<QueryTransactionListResponseDTO>
    {
        public int CardId { get; set; }

        public QueryTransactionListRequestDTO(int cardId)
        {
            CardId = cardId;
        }
    }
}

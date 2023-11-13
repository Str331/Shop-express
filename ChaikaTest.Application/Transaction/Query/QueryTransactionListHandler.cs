using ChaikaTest.Application.Transaction.Read;
using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Transaction.Query
{
    public class QueryTransactionListHandler : IRequestHandler<QueryTransactionListRequestDTO, QueryTransactionListResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public QueryTransactionListHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<QueryTransactionListResponseDTO> Handle(QueryTransactionListRequestDTO request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.Id == request.CardId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(card);

            var latestTransactions = await _context.Transactions
                .Where(t => t.CardId == card.Id)
                .ToListAsync(cancellationToken);

            List<ReadTransactionResponseDTO> transactions = new();
            foreach (var transaction in latestTransactions)
            {
                    var res = await _mediator.Send(new ReadTransactionRequestDTO(transaction.Id), cancellationToken);
                    transactions.Add(res);
            }

            return new QueryTransactionListResponseDTO
            {
                CardBalance = card.CardBalance,
                LatestTransaction = transactions,
                NoPaymentDue = $"You’ve paid your {DateTime.Today.Month} balance."
            };
        }
    }
}

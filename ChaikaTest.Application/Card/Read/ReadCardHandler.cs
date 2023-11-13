using ChaikaTest.Application.Transaction.Read;
using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Card.Read
{
    public class ReadCardHandler : IRequestHandler<ReadCardRequestDTO, ReadCardResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public ReadCardHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ReadCardResponseDTO> Handle(ReadCardRequestDTO request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.Id == request.CardId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(card);

            List<ReadTransactionResponseDTO> transactions = new();
            if (card.Transactions is not null)
            {
                foreach (var transaction in card.Transactions)
                {
                    var result = await _mediator.Send(new ReadTransactionRequestDTO(transaction.Id), cancellationToken);
                    transactions.Add(result);
                }
            }

            var cardResult = new ReadCardResponseDTO
            {
                Available = card.Available,
                BankName = card.BankName,
                CardBalance = card.CardBalance,
                Transactions = transactions,
                //DailyPoints = 
            };

            return cardResult;
        }
    }
}

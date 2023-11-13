using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Transaction.Create
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionRequestDTO, CreateTransactionResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public CreateTransactionHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<CreateTransactionResponseDTO> Handle(CreateTransactionRequestDTO request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.Id == request.CardId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(card);

            int newBalance = card.CardBalance - request.Sum;
            if (newBalance < 0)
                throw new Exception("You dont have enough money");
            else
                card.CardBalance = newBalance;

            string description;
            if (request.Pending)
            {
                description = "Pending - " + request.Description;
            }
            else
            {
                description = request.Description;
            }

            var paymentDue = $"You’ve paid your {DateTime.Today.Month} balance.";

            var transaction = new Domain.Transaction()
            {
                AuthorizedUser = request.AuthorizedUser,
                Date = DateTime.Now,
                Description = description,
                Name = request.Name,
                Sum = request.Sum,
                NoPaymentDue = paymentDue,
                CardId = card.Id,
                TransactionType = request.TransactionType,
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync(cancellationToken);

            card.Transactions.Add(transaction);
            _context.Cards.Update(card);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateTransactionResponseDTO { Id = transaction.Id };
        }
    }
}

using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Transaction.Read
{
    public class ReadTransactionHandler : IRequestHandler<ReadTransactionRequestDTO, ReadTransactionResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public ReadTransactionHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ReadTransactionResponseDTO> Handle(ReadTransactionRequestDTO request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == request.TransactionId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(transaction);

            string date = transaction.Date.ToShortDateString() + "" + transaction.Date.ToShortTimeString();

            var result = new ReadTransactionResponseDTO
            {
                BankName = "Some bank",
                Status = "Some sum status",
                BigSum = transaction.Sum,
                Date = date,
                Total = "Total:" + transaction.Sum,
            };

            return result;
        }
    }
}

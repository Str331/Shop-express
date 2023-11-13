using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTest.Application.Transaction.Delete
{
    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionRequestDTO, Unit>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public DeleteTransactionHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteTransactionRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == request.TransactionId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(result);

            _context.Transactions.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

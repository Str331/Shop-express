using ChaikaTest.Infrastructure.Database;
using ChaikaTest.Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Card.Delete
{
    public class DeleteCardHandler : IRequestHandler<DeleteCardRequestDTO, Unit>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public DeleteCardHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteCardRequestDTO request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards
                .FirstOrDefaultAsync(c => c.Id == request.CardId, cancellationToken);
            PropertyChecker.CheckNullAndThrow404(card);

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

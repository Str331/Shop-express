using ChaikaTest.Domain;
using ChaikaTest.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Card.Create
{
    public class CreateCardHandler : IRequestHandler<CreateCardRequestDTO, CreateCardResponseDTO>
    {
        private readonly Context _context;
        private readonly IMediator _mediator;

        public CreateCardHandler(Context context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<CreateCardResponseDTO> Handle(CreateCardRequestDTO request, CancellationToken cancellationToken)
        {
            Random rnd = new Random();
            var cardBalance = rnd.Next(0, 1501);


            var card = new Domain.Card()
            {
                BankName = request.BankName,
                CardBalance = cardBalance,
                Available = 1500 - cardBalance,
            };

            _context.Cards.Add(card);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCardResponseDTO { Id = card.Id };
        }
    }
}

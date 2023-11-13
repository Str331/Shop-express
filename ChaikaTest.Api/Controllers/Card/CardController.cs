using ChaikaTest.Api.Controllers.Card.Read;
using ChaikaTest.Application.Card.Create;
using ChaikaTest.Application.Card.Delete;
using ChaikaTest.Application.Card.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChaikaTest.Api.Controllers.Card
{
    [Route("Card")]
    public class CardController : Controller
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{bankName}")]
        public async Task<CreateCardResponseDTO> CreateCard(string bankName)
        {
            var result = await _mediator.Send(new CreateCardRequestDTO(bankName));

            return new CreateCardResponseDTO { Id = result.Id };
        }

        [HttpDelete("DeleteCard/{cardId}")]
        public async Task<Unit> DeleteCard(int cardId)
        {
            var result = await _mediator.Send(new DeleteCardRequestDTO(cardId));

            return result;
        }

        [HttpGet("CardInfo/{cardId}")]
        public async Task<ReadCardResponse> ReadCard(int cardId)
        {
            var result = await _mediator.Send(new ReadCardRequestDTO(cardId));

            return new ReadCardResponse(result);
        }
    }
}

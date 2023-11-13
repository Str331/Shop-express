using MediatR;

namespace ChaikaTest.Application.Card.Delete
{
    public class DeleteCardRequestDTO : IRequest<Unit>
    {
        public int CardId { get; set; }

        public DeleteCardRequestDTO(int cardId)
        {
            CardId = cardId;
        }
    }
}

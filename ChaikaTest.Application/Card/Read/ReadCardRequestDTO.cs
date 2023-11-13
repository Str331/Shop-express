using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Card.Read
{
    public class ReadCardRequestDTO:IRequest<ReadCardResponseDTO>
    {
        public int CardId { get; set; }

        public ReadCardRequestDTO(int cardId)
        {
            CardId = cardId;
        }
    }
}

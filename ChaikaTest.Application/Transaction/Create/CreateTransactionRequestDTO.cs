using ChaikaTest.Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Transaction.Create
{
    public class CreateTransactionRequestDTO:IRequest<CreateTransactionResponseDTO>
    {
        public int CardId { get; set; }

        public TransactionType TransactionType { get; set; }

        public int Sum { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Pending { get; set; }

        public string AuthorizedUser { get; set; }
    }
}

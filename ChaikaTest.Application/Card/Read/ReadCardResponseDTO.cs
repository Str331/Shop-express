using ChaikaTest.Application.Transaction.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Card.Read
{
    public class ReadCardResponseDTO
    {
        public string BankName { get; set; }

        public int CardBalance { get; set; }

        public int Available { get; set; }

        public int DailyPoints { get; set; }

        public List<ReadTransactionResponseDTO> Transactions { get; set; }
    }
}

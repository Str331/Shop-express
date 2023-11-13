using ChaikaTest.Application.Transaction.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Application.Transaction.Query
{
    public class QueryTransactionListResponseDTO
    {
        public int CardBalance { get; set; }

        public string NoPaymentDue { get; set; }

        public List<ReadTransactionResponseDTO> LatestTransaction { get; set; }
    }
}

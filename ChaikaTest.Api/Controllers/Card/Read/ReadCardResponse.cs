using ChaikaTest.Application.Card.Read;
using ChaikaTest.Application.Transaction.Read;

namespace ChaikaTest.Api.Controllers.Card.Read
{
    public class ReadCardResponse
    {
        public string BankName { get; set; }

        public int CardBalance { get; set; }

        public int Available { get; set; }

        public int DailyPoints { get; set; }

        public List<ReadTransactionResponseDTO> Transactions { get; set; }

        public ReadCardResponse(ReadCardResponseDTO dTO)
        {
            BankName = dTO.BankName;
            CardBalance = dTO.CardBalance;
            Available = dTO.Available;
            Transactions = dTO.Transactions;
            DailyPoints = dTO.DailyPoints;
        }
    }
}

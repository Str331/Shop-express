using ChaikaTest.Domain.Constants;

namespace ChaikaTest.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public int Sum { get; set; }

        public string NoPaymentDue { get; set; }

        public int TransactionListId { get; set; }

        public int CardId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? AuthorizedUser { get; set; }

        public DateTime Date { get; set; }

        public bool Pending { get; set; }

        public TransactionType TransactionType { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual Card Card { get; set; }
    }
}

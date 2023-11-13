using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Domain
{
    public class Card
    {
        public int Id { get; set; }

        public string BankName { get; set; }

        public int CardBalance { get; set; }

        public int Available { get; set; }

        public int DailyPoints { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

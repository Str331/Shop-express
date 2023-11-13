using ChaikaTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaikaTest.Infrastructure.Database
{
    public partial class Context
    {
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<Card> Cards { get; set; }
    }
}

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
        public virtual DbSet<Tasks> Tasks { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Data
{
    public class MMSContext : DbContext
    {
        public MMSContext(DbContextOptions<MMSContext> options)
            : base(options)
        {
        }

        public DbSet<MMS.Models.Machines> MMS { get; set; }
    }
}
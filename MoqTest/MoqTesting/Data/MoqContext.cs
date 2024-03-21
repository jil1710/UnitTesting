using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoqTesting.Models;

namespace MoqTesting.Data
{
    public class MoqContext : DbContext
    {
        public MoqContext (DbContextOptions<MoqContext> options)
            : base(options)
        {
        }

        public DbSet<MoqTesting.Models.Employee> Employee { get; set; } = default!;
    }
}

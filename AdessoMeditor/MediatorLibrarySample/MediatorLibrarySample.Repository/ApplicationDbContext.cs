using MediatorLibrarySample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=TR-ADN-HBBXVL3\\SQLEXPRESS;Database=Db;Trusted_Connection=True;");
        }
    }
}

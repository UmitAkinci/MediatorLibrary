using MediatorLibrarySample.Domain.Entities;
using MediatorLibrarySample.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.Repository.Repository
{
    public class MoneyTransferRepository : RepositoryBase<ApplicationDbContext, MoneyTransfer>, IMoneyTransferRepository
    {
        public MoneyTransferRepository(ApplicationDbContext context) : base(context)
        {
        }

        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
    }
}

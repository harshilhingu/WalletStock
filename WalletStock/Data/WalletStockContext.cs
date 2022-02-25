using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletStock.Models;

namespace WalletStock.Data
{
    public class WalletStockContext : DbContext
    {
        public WalletStockContext (DbContextOptions<WalletStockContext> options)
            : base(options)
        {
        }

        public DbSet<WalletStock.Models.Wallets> Wallets { get; set; }
    }
}

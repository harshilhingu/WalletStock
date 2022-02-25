using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WalletStock.Models
{
    public class WalletsGenreViewModel
    {
        public List<Wallets> Company { get; set; }
        public SelectList Color { get; set; }
        public string Shape { get; set; }
        public string SearchString { get; set; }
    }
}
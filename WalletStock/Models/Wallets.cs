using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletStock.Models
{
    public class Wallets
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Company { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Color { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Leather { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Shape { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public decimal Rating { get; set; }
    }
} 
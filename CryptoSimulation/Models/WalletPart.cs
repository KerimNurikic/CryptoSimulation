using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public class WalletPart
    {
        [Key]
        public int WalletPartID { get; set; }
        [ForeignKey("Wallet")]
        [Required]
        public int WalletID { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public double Amount { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}

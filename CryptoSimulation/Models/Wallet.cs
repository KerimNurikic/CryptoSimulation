using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public class Wallet
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public virtual ICollection<WalletPart> WalletParts { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

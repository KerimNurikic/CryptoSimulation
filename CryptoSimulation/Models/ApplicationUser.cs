using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Wallet")]
        public int WalletID { get; set; }
        [ForeignKey("Portfolio")]
        public int PortfolioID { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}

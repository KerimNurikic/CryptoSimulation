using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public class Portfolio
    {       
        [Display(Name = "ID")]
        public int PortfolioID { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoSimulation.Models
{
    public class Transaction
    {
        [Key]      
        public int TransactionID { get; set; }
        [DisplayFormat(NullDisplayText = "No Sender")]
        [ForeignKey("WalletSender")]
        public int? WalletIDSender { get; set; }
        [ForeignKey("WalletReciever")]
        public int WalletIDReciever { get; set; }
        [Required]
        public TransactionType Type { get; set; }
        public int PortfolioID { get; set; }
        [Required(ErrorMessage ="Currency is required")]
        public string Currency { get; set; }
        public double Value { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        
        public virtual Portfolio Portfolio { get; set; }
        public virtual Wallet? WalletSender { get; set; }
        public virtual Wallet WalletReciever { get; set; }
        public static string TransactionDisplay(int recieverID, TransactionType type)
        {
            switch (type)
            {
                case TransactionType.Buy:
                    return "Bought";
                case TransactionType.Sell:
                    return "Sold";
                case TransactionType.Transfer:
                    return "Transfered to" + recieverID;
                default:
                    return "Error";
            }
        }

    }

    
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionApp.DAL.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TransactionId { get; set; }

        [Required]
        [ForeignKey("Account")]
        public long AccountId { get; set; }

        public long MerchandAccountId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(1)]
        public string TransactionType { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}

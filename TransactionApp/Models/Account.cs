using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransactionApp.DAL.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountId { get; set; }

        [Required]
        [ForeignKey("Client")]
        public long ClientId { get; set; }

        [Required]
        public decimal CurrentAmount { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}

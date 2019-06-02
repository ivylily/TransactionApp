using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionApp.DAL.Models
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BankId { get; set; }

        [Required]
        [MaxLength(150)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        //public virtual ICollection<Client> Clients { get; set; }
    }
}

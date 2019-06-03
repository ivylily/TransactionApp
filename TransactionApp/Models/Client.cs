using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionApp.DAL.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(1)]
        public string Status { get; set; }

        /// <summary>
        /// Use UTC datetime
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }
        //public virtual ICollection<Transaction> Transaction { get; set; }

        [Required]
        public long BankId { get; set; }
        public virtual Bank Bank { get; set; }
    }
}

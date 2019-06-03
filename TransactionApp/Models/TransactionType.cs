using System.ComponentModel.DataAnnotations;

namespace TransactionApp.DAL.Models
{
    public class TransactionType
    {
        [Key]
        [MaxLength(1)]
        public string TransactionTypeCode { get; set; }
        public string Description { get; set; }
    }
}

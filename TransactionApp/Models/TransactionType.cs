using System.ComponentModel.DataAnnotations;

namespace TransactionApp.DAL.Models
{
    public class TransactionType
    {
        [Key]
        public string TransactionTypeCode { get; set; }
        public string Description { get; set; }
    }
}

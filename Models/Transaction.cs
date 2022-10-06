using ExpensesManagementApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesManagementApi.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Column("id")]
        public int Id { get; set; } 

        [Column("description")]
        public string Description { get; set; }
        
        [Column("value")]
        public double Value { get; set; }
        
        [Column("transaction_type")]
        public TransactionType Type {get;set;}
        
        [Column("person_id")]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}

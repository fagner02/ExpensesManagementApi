using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesManagementApi.Models
{
    [Table("persons")]
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("person_name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

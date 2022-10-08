using System.ComponentModel.DataAnnotations;

namespace ExpensesManagementApi.DataTransferObjects
{
    public class PersonPutRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}

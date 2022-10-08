namespace ExpensesManagementApi.DataTransferObjects
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}

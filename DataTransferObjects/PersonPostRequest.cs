namespace ExpensesManagementApi.DataTransferObjects
{
    public class PersonPostRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}

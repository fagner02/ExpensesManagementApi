namespace ExpensesManagementApi.DataTransferObjects
{
    public class TotalBalanceInfoResponse
    {
        public double TotalRevenue { get; set; }
        public double TotalExpenses { get; set; }
        public double TotalBalance { get; set; }
        public IEnumerable<PersonTotalBalanceResponse> People { get; set; }
       
    }

    public record PersonTotalBalanceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalExpenses { get; set; }
        public double TotalBalance { get; set; }
    }
}

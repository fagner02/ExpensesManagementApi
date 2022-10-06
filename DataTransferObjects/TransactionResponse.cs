using ExpensesManagementApi.Enums;

namespace ExpensesManagementApi.DataTransferObjects
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public TransactionType Type { get; set; }
        public int PersonId { get; set; }
    }
}

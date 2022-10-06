namespace ExpensesManagementApi.DataTransferObjects
{
    public class PersonDeleteRequest
    {
        public IEnumerable<int> IdsToDelete { get; set; }
    }
}

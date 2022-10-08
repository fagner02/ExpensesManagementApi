namespace ExpensesManagementApi.Exceptions
{
    public class NotFoundException : BaseDisplayException
    {
        public NotFoundException(string message, params object[] messageArgs) : base(message, messageArgs) { }
    }
}

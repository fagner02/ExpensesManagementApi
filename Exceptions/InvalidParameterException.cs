namespace ExpensesManagementApi.Exceptions
{
    public class InvalidParameterException : BaseDisplayException
    {
        public InvalidParameterException(string message, params object[] messageArgs) : base(message, messageArgs) { }
    }
}
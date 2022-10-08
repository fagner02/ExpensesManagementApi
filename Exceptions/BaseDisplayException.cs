namespace ExpensesManagementApi.Exceptions
{
    public class BaseDisplayException : Exception
    {
        private readonly string _message;
        public BaseDisplayException(string message, params object[] messageArgs)
        {
            _message = string.Format(message, messageArgs);
        }

        public BaseDisplayException(Exception innerException, string message, params object[] messageArgs)
            : base(default, innerException)
        {
            _message = string.Format(message, messageArgs);
        }

        public override string Message => _message;
        public override string? StackTrace => "";
    }
}

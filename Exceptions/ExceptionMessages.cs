namespace ExpensesManagementApi.Exceptions
{
    public static class ExceptionMessages
    {
        public static string PersonNotFound ="Person not found for id(s): {0}.";
        public static string RevenueForMinor => "TransactionType.Revenue for person under 18 with id: {0}.";
    }
}

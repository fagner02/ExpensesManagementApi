using ExpensesManagementApi.DataTransferObjects;

namespace ExpensesManagementApi.Services
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionPostRequest transaction);
        IEnumerable<TransactionResponse> GetAllTransactions();
        int GetTransactionsCount();
    }
}
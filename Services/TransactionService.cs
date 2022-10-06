using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Models;
using ExpensesManagementApi.Repositories;

namespace ExpensesManagementApi.Services
{
    public class TransactionService
    {
        private readonly Repository<Transaction> _repository;
        private readonly IMapper _mapper;
        
        public TransactionService(Repository<Transaction> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateTransaction(TransactionPostRequest transaction)
        {
            _repository.Add(_mapper.Map<Transaction>(transaction));
            _repository.SaveChanges();
        }

        public IEnumerable<TransactionResponse> GetAllTransactions()
        {
            var result = _repository.Query();
            return _mapper.Map<IEnumerable<TransactionResponse>>(result.AsEnumerable());
        }
    }
}

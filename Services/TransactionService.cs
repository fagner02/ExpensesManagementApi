using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Enums;
using ExpensesManagementApi.Exceptions;
using ExpensesManagementApi.Models;
using ExpensesManagementApi.Repositories;

namespace ExpensesManagementApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly Repository<Transaction> _repository;
        private readonly Repository<Person> _personRepository;
        private readonly IMapper _mapper;

        public TransactionService(Repository<Transaction> repository, Repository<Person> personRepository, IMapper mapper)
        {
            _repository = repository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public void CreateTransaction(TransactionPostRequest transaction)
        {
            var person = _personRepository.Query().FirstOrDefault(x => x.Id == transaction.PersonId);

            if (person == null)
                throw new NotFoundException(ExceptionMessages.PersonNotFound, transaction.PersonId);

            if (person.Age < 18 && transaction.Type != TransactionType.Expense)
                throw new InvalidParameterException(ExceptionMessages.RevenueForMinor, transaction.PersonId);

            _repository.Add(_mapper.Map<Transaction>(transaction));
            _repository.SaveChanges();
        }

        public IEnumerable<TransactionResponse> GetAllTransactions()
        {
            var result = _repository.Query();
            return _mapper.Map<IEnumerable<TransactionResponse>>(result.AsEnumerable());
        }

        public int GetTransactionsCount()
        {
            return _repository.Query().Count();
        }
    }
}

using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Enums;
using ExpensesManagementApi.Exceptions;
using ExpensesManagementApi.Models;
using ExpensesManagementApi.Repositories;

namespace ExpensesManagementApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly Repository<Person> _repository;
        private readonly IMapper _mapper;
        public PersonService(Repository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreatePerson(PersonPostRequest person)
        {
            _repository.Add(_mapper.Map<Person>(person));
            _repository.SaveChanges();
        }

        public IEnumerable<PersonResponse> GetAllPeople()
        {
            var result = _repository.Query();
            return _mapper.Map<IEnumerable<PersonResponse>>(result);
        }

        public PersonResponse GetPersonById(int id)
        {
            var result = _repository.Query().FirstOrDefault(x => x.Id == id);

            if (result == null)
                throw new NotFoundException(ExceptionMessages.PersonNotFound, id);

            return _mapper.Map<PersonResponse>(result);
        }

        public void Update(PersonPutRequest request)
        {
            var person = _repository.Query().FirstOrDefault(x => x.Id == request.Id);

            if (person == null)
                throw new NotFoundException(ExceptionMessages.PersonNotFound, request.Id);

            person.Age = request.Age ?? person.Age;
            person.Name = request.Name ?? person.Name;
            person.Phone = request.Phone ?? person.Phone;
            person.Email = request.Email ?? person.Email;

            _repository.Update(person);
            _repository.SaveChanges();
        }

        public void DeleteRange(PersonDeleteRequest request)
        {
            var people = _repository.Query().Where(x => request.IdsToDelete.Contains(x.Id)).ToList();

            if (request.IdsToDelete.Count() != people.Count())
                throw new NotFoundException(ExceptionMessages.PersonNotFound,
                    string.Join(",", request.IdsToDelete.Except(people.Select(x => x.Id))));

            _repository.RemoveRange(people);
            _repository.SaveChanges();
        }

        public TotalBalanceInfoResponse GetTotalBalance()
        {
            var people = _repository.Query(x => x.Transactions);

            var balances = new List<PersonTotalBalanceResponse>() { };

            var result = new TotalBalanceInfoResponse()
            {
                TotalBalance = 0,
                TotalExpenses = 0,
                TotalRevenue = 0,
                People = balances
            };
            foreach (var p in people)
            {
                var transactions = p.Transactions.Select(t => new { t.Type, t.Value }).GroupBy(y => y.Type, (transactionType, value) => new
                {
                    Type = transactionType,
                    Value = value.Sum(x => x.Value)
                }).ToDictionary(y => y.Type, y => y.Value);
                var revenue = transactions.ContainsKey(TransactionType.Revenue) ? transactions[TransactionType.Revenue] : 0.0;
                var expenses = transactions.ContainsKey(TransactionType.Expense) ? transactions[TransactionType.Expense] : 0.0;
                balances.Add(new PersonTotalBalanceResponse
                {
                    Id = p.Id,
                    Age = p.Age,
                    Name = p.Name,
                    Phone = p.Phone,
                    Email = p.Email,
                    TotalRevenue = revenue,
                    TotalExpenses = expenses,
                    TotalBalance = revenue - expenses
                });
                result.TotalBalance += revenue - expenses;
                result.TotalRevenue += revenue;
                result.TotalExpenses += expenses;
            }

            return result;
        }
    }
}

using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Models;
using ExpensesManagementApi.Repositories;
using System.Linq.Expressions;

namespace ExpensesManagementApi.Services
{
    public class PersonService
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

        public IEnumerable<PersonResponse> GetAllPersons()
        {
            var result = _repository.Query();
            return _mapper.Map<IEnumerable<PersonResponse>>(result);
        }

        public void UpdateRange(PersonPutRequest requests)
        {
            _repository.UpdateRange(_mapper.Map<IEnumerable<Person>>(requests));
        }

        public void DeleteRange(PersonDeleteRequest request)
        {
            var persons = _repository.Query().Where(x => request.IdsToDelete.Contains(x.Id));
            _repository.RemoveRange(persons);
            _repository.SaveChanges();
        }
    }
}

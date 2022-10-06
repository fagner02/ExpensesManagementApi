using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Models;

namespace ExpensesManagementApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonPostRequest, Person>();
            CreateMap<Person, PersonResponse>();
        }
    }
}

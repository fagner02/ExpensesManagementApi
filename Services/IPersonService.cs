using ExpensesManagementApi.DataTransferObjects;

namespace ExpensesManagementApi.Services
{
    public interface IPersonService
    {
        void CreatePerson(PersonPostRequest person);
        void DeleteRange(PersonDeleteRequest request);
        IEnumerable<PersonResponse> GetAllPeople();
        PersonResponse GetPersonById(int id);
        TotalBalanceInfoResponse GetTotalBalance();
        void Update(PersonPutRequest request);
    }
}
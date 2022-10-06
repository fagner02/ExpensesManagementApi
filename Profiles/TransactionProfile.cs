using AutoMapper;
using ExpensesManagementApi.DataTransferObjects;
using ExpensesManagementApi.Models;

namespace ExpensesManagementApi.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionPostRequest, Transaction>();
            CreateMap<Transaction, TransactionResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type));
        }
    }
}
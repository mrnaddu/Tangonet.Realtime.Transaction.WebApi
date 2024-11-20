using AutoMapper;
using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Entities;

namespace Tangonet.Realtime.Transaction.WebApi;

public class AutoMapperProfile
    : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TransactionEntities, TransactionDto>().ReverseMap();
    }     
}

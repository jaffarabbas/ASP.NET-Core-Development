using AutoMapper;
using SalesOrderApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TblCustomer, CustomerEntity>().ForMember(item => item.StatusName, item => item.MapFrom(c => c.IsActive == true ? "Active" : "In Active"));
    }
}
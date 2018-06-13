using AutoMapper;
using DDD.Domain.EmployeeAggregate;
using DDD.Domain.IssueAggregate;
using DDD.Services.Dtos;

namespace DDD.Services
{
    public class DtosProfile : Profile
    {
        public DtosProfile()
        {
            CreateMap<InitiatorInfo, InitiatorInfoDto>();
            CreateMap<Issue, IssueDto>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}

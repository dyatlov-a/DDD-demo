using AutoMapper;
using DDD.Domain.IssueAggregate;
using DDD.Domain.PersonAggregate;
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

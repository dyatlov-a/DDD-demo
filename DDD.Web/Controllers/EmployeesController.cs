using System;
using System.Collections.Generic;
using System.Web.Http;
using DDD.Services.Contracts;
using DDD.Services.Dtos;
using DDD.Web.WebInfrastructure;

namespace DDD.Web.Controllers
{
    [RoutePrefix(WebApiConfig.ApiPrefix + "Employees")]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            if (employeeService == null)
                throw new ArgumentNullException(nameof(employeeService));

            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            return _employeeService.GetHeads();
        }

        [Route("{employeeId}"), HttpGet]
        public EmployeeDto Get(Guid employeeId)
        {
            return _employeeService.GetById(employeeId);
        }

        [HttpPost]
        public Guid Create([FromBody]EmployeeCreateDto employeeCreateDto)
        {
            return _employeeService.Create(employeeCreateDto);
        }

        [Route("AddEmployee/{headId}"), HttpPatch]
        public IHttpActionResult AddEmployee(Guid headId, [FromBody]Guid employeeId)
        {
            _employeeService.AddEmployee(headId, employeeId);
            return Ok();
        }

        [Route("ChangePosition/{employeeId}"), HttpPatch]
        public IHttpActionResult ChangePosition(Guid employeeId, [FromBody]string position)
        {
            _employeeService.ChangePosition(employeeId, position);
            return Ok();
        }
    }
}
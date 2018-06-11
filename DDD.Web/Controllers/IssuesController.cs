using System;
using System.Collections.Generic;
using System.Web.Http;
using DDD.Domain.IssueAggregate;
using DDD.Services.Contracts;
using DDD.Services.Dtos;
using DDD.Web.WebInfrastructure;

namespace DDD.Web.Controllers
{
    [RoutePrefix(WebApiConfig.ApiPrefix + "Issues")]
    public class IssuesController : BaseController
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            if (issueService == null)
                throw new ArgumentNullException(nameof(issueService));

            _issueService = issueService;
        }

        [HttpGet]
        public IEnumerable<IssueDto> Get()
        {
            return _issueService.GetAll();
        }

        [Route("{issueId}"), HttpGet]
        public IssueDto Get(Guid issueId)
        {
            return _issueService.GetById(issueId);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]IssueCreateDto issueCreateDto)
        {
            var id = _issueService.Create(issueCreateDto, CurrentUser());
            return Ok(id);
        }

        [Route("AppointTo/{issueId}"), HttpPatch]
        public IHttpActionResult AppointTo(Guid issueId, [FromBody]Guid newResponsibleId)
        {
            _issueService.AppointTo(issueId, newResponsibleId);
            return Ok();
        }

        [Route("ChangeStatus/{issueId}"), HttpPatch]
        public IHttpActionResult ChangeStatus(Guid issueId, [FromBody]IssueStatus status)
        {
            _issueService.ChangeStatus(issueId, status);
            return Ok();
        }

        [Route("Escalation/{issueId}"), HttpPatch]
        public IHttpActionResult Escalation(Guid issueId)
        {
            _issueService.Escalation(issueId);
            return Ok();
        }

        [Route("Delete/{issueId}"), HttpDelete]
        public IHttpActionResult Delete(Guid issueId)
        {
            _issueService.Remove(issueId);
            return Ok();
        }
    }
}
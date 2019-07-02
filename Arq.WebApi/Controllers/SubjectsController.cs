using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.Data;
using Arq.Domain;
using Arq.WebApi.Services;
using Arq.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Arq.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ApiControllerBase
    {
        private SubjectsService _subjectService;

        public SubjectsController(SubjectsService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectViewModel>> GetSubjectAsync(Guid id)
        {
            var subject = await _subjectService.GetSubjectAsync(id);

            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        [HttpGet("{id}/dependencies")]
        public async Task<ActionResult<IEnumerable<RequirementViewModel>>> GetDependenciesAsync(Guid id)
        {
            var requirements = await _subjectService.GetDependenciesAsync(id);

            if (requirements == null)
                return NotFound();

            if (!requirements.Any())
                return NoContent();

            return Ok(requirements);
        }
    }
}
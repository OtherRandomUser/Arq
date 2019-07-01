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
        private GenericRepository<Subject> _subjectsRepository;

        public SubjectsController(GenericRepository<Subject> subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectViewModel>> GetSubject(Guid id)
        {
            var subject = (SubjectViewModel) await _subjectsRepository.GetByIdAsync(id, null);

            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        [HttpGet("{id}/dependencies")]
        public async Task<ActionResult<IEnumerable<RequirementViewModel>>> GetSubject(Guid id, [FromServices] SubjectsService subjectService)
        {
            var requirements = await subjectService.GetRequirementsAsync(id);

            if (requirements == null)
                return NotFound();

            if (!requirements.Any())
                return NoContent();

            return Ok(requirements);
        }
    }
}
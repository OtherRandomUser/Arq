using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.WebApi.Services;
using Arq.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arq.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurriculumsController : ApiControllerBase
    {
        private CurriculumService _curriculumService;

        public CurriculumsController(CurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<CurriculumViewModel>> GetCurriculum(Guid id)
            => ExecuteAsync<CurriculumViewModel>(async () =>
            {
                var curriculum = await _curriculumService.GetCurriculumAsync(id);
                
                if (curriculum == null)
                    return NotFound();

                return Ok(curriculum);
            });

        [HttpGet("{id}/subjects")]
        public Task<ActionResult<IEnumerable<SubjectViewModel>>> GetSubjects(Guid id)
            => ExecuteAsync<IEnumerable<SubjectViewModel>>(async () =>
            {
                var subjects = await _curriculumService.GetSubjects(id);
                
                if (subjects == null)
                    return NotFound();

                if (!subjects.Any())
                    return NoContent();

                return Ok(subjects);
            });
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.Data;
using Arq.Domain;
using Arq.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arq.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurriculumsController : ApiControllerBase
    {
        private GenericRepository<Curriculum> _curriculumsRepository;

        public CurriculumsController(GenericRepository<Curriculum> curriculumsRepository)
        {
            _curriculumsRepository = curriculumsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurriculumViewModel>> GetCurriculum(Guid id)
        {
            var curriculum = (CurriculumViewModel) await _curriculumsRepository.GetByIdAsync(id, null);
            
            if (curriculum == null)
                return NotFound();

            return Ok(curriculum);
        }

        [HttpGet("{id}/subjects")]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetSubjects(Guid id)
        {
            var curriculum = await _curriculumsRepository.GetByIdAsync(id, c => c.Include(i => i.Subjects));
            
            if (curriculum == null)
                return NotFound();

            if (!curriculum.Subjects.Any())
                return NoContent();

            return Ok(curriculum.Subjects.Select(s => (SubjectViewModel) s));
        }
    }
}
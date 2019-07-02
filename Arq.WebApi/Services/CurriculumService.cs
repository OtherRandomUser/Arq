using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.Data;
using Arq.Domain;
using Arq.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Arq.WebApi.Services
{
    public class CurriculumService
    {
        private GenericRepository<Curriculum> _curriculumsRepository;

        public CurriculumService(GenericRepository<Curriculum> curriculumsRepository)
        {
            _curriculumsRepository = curriculumsRepository;
        }

        public async Task<CurriculumViewModel> GetCurriculumAsync(Guid id)
            => (CurriculumViewModel) await _curriculumsRepository.GetByIdAsync(id, null);

        public async Task<IEnumerable<SubjectViewModel>> GetSubjects(Guid id)
        {
            var curriculum = await _curriculumsRepository.GetByIdAsync(id, c => c.Include(i => i.Subjects));

            if (curriculum == null)
                return null;

            return curriculum.Subjects.OrderBy(s => s.TargetSemester).Select(s => (SubjectViewModel) s);
        }
    }
}
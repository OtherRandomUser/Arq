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
    public class SubjectsService
    {
        private GenericRepository<Subject> _subjectsRepository;

        public SubjectsService(GenericRepository<Subject> subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }

        public async Task<SubjectViewModel> GetSubjectAsync(Guid id)
            => (SubjectViewModel) await _subjectsRepository.GetByIdAsync(id, null);

        public async Task<IEnumerable<RequirementViewModel>> GetDependenciesAsync(Guid id)
        {
            // var subject = await _subjectsRepository.GetByIdAsync(id, i => i.Include(s => s.Prerequisites).Include(s => s.CoRequirements));
            var subject = _subjectsRepository.GetQueryable()
                .Include(s => s.Prerequisites)
                    .ThenInclude(p => p.Requirement)
                .Include(s => s.CoRequirements)
                    .ThenInclude(c => c.Requirement)
                .FirstOrDefault(e => e.Id == id);

            if (subject == null)
                return null;

            return subject.Prerequisites.Select(s => new RequirementViewModel(s.Requirement, RequirementType.PreRequisite))
                .Concat(subject.CoRequirements.Select(s => new RequirementViewModel(s.Requirement, RequirementType.CoRequirement)));
        }
    }
}
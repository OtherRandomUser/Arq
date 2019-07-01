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

        public async Task<IEnumerable<RequirementViewModel>> GetRequirementsAsync(Guid id)
        {
            var subject = await _subjectsRepository.GetByIdAsync(id, i => i.Include(s => s.Prerequisites).Include(s => s.CoRequirements));

            if (subject == null)
                return null;

            return subject.Prerequisites.Select(s => new RequirementViewModel(s.Requirement, RequirementType.PreRequisite))
                .Concat(subject.CoRequirements.Select(s => new RequirementViewModel(s.Requirement, RequirementType.PreRequisite)));
        }
    }
}
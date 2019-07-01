using System;
using Arq.Domain;

namespace Arq.WebApi.ViewModels
{
    public class CurriculumViewModel
    {
        public Guid Id { get; set; }
        public Guid Course { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public static implicit operator CurriculumViewModel(Curriculum curriculum)
            => curriculum == null ? null : new CurriculumViewModel
            {
                Id = curriculum.Id,
                Course = curriculum.CourseId,
                Code = curriculum.Code,
                Description = curriculum.Description,
                Active = curriculum.Active
            };
    }
}
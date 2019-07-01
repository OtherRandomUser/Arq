using System;
using Arq.Domain;

namespace Arq.WebApi.ViewModels
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }
        public Guid Curriculum { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int MinimumGrade { get; set; }

        public static implicit operator SubjectViewModel(Subject subject)
            => subject == null ? null : new SubjectViewModel
            {
                Id = subject.Id,
                Curriculum = subject.CurriculumId,
                Code = subject.Code,
                Description = subject.Description,
                MinimumGrade = subject.MinimumGrade
            };
    }
}
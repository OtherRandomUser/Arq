using Arq.Domain;

namespace Arq.WebApi.ViewModels
{
    public enum RequirementType
    {
        PreRequisite,
        CoRequirement
    }

    public class RequirementViewModel : SubjectViewModel
    {
        public RequirementType Type { get; set; }

        public RequirementViewModel(Subject subject, RequirementType type)
        {
            if (subject is null)
                throw new System.ArgumentNullException(nameof(subject));

            Id = subject.Id;
            Curriculum = subject.CurriculumId;
            Code = subject.Code;
            Description = subject.Description;
            MinimumGrade = subject.MinimumGrade;
            Type = type;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace Arq.Domain
{
    public class Subject : Entity
    {
        public Guid CurriculumId { get; private set; }
        public Curriculum Curriculum { get; private set; }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public int MinimumGrade { get; private set; }
        public int TargetSemester { get; private set;}

        public virtual ICollection<Prerequisite> Prerequisites { get; private set; }
        public virtual ICollection<Prerequisite> RequiredBy { get; private set; }

        public virtual ICollection<CoRequirement> CoRequirements { get; private set; }
        public virtual ICollection<CoRequirement> CoRequiredBy { get; private set; }

        public virtual ICollection<Equivalence> Equivalences { get; private set; }
        public virtual ICollection<Equivalence> EquivaleTo { get; private set; }

        public virtual ICollection<Semester> Semesters { get; private set; }

        public Subject()
        {
        }

        public Subject(Curriculum curriculum, string code, string description, int minimumGrade, int targetSemester)
        {
            Curriculum = curriculum ?? throw new ArgumentNullException(nameof(curriculum));
            CurriculumId = curriculum.Id;

            Code = code;
            Description = description;
            MinimumGrade = minimumGrade;
            TargetSemester = targetSemester;

            Prerequisites = new List<Prerequisite>();
            CoRequirements = new List<CoRequirement>();
            Equivalences = new List<Equivalence>();
            Semesters = new List<Semester>();
        }
    }
}
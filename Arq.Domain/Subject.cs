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

        public IList<Prerequisite> Prerequisites { get; private set; }
        public IList<CoRequirement> CoRequirements { get; private set; }
        public IList<Equivalence> Equivalences { get; private set; }
        public IList<Semester> Semesters { get; private set; }

        public Subject()
        {
        }

        public Subject(Curriculum curriculum, string code, string description, int minimumGrade)
        {
            Curriculum = curriculum ?? throw new ArgumentNullException(nameof(curriculum));
            CurriculumId = curriculum.Id;

            Code = code;
            Description = description;
            MinimumGrade = minimumGrade;

            Prerequisites = new List<Prerequisite>();
            CoRequirements = new List<CoRequirement>();
            Equivalences = new List<Equivalence>();
            Semesters = new List<Semester>();
        }
    }
}
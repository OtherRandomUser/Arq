using System;

namespace Arq.Domain
{
    public class Prerequisite : Entity
    {
        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public Guid RequirementId { get; private set; }
        public Subject Requirement { get; private set; }

        public Prerequisite()
        {
        }

        public Prerequisite(Subject subject, Subject prerequisite)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            SubjectId = subject.Id;
            Requirement = prerequisite ?? throw new ArgumentNullException(nameof(prerequisite));
            RequirementId = prerequisite.Id;
        }
    }
}
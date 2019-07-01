using System;

namespace Arq.Domain
{
    public class CoRequirement : Entity
    {
        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public Guid RequirementId { get; private set; }
        public Subject Requirement { get; private set; }

        public CoRequirement()
        {
        }

        public CoRequirement(Subject subject, Subject requirement)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            SubjectId = subject.Id;
            Requirement = requirement ?? throw new ArgumentNullException(nameof(requirement));
            RequirementId = requirement.Id;
        }
    }
}
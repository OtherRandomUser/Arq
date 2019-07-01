using System;

namespace Arq.Domain
{
    public class Equivalence : Entity
    {
        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public Guid EquivalentId { get; private set; }
        public Subject Equivalent { get; private set; }

        public Equivalence()
        {
        }

        public Equivalence(Subject subject, Subject equivalence)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            SubjectId = subject.Id;
            Equivalent = equivalence ?? throw new ArgumentNullException(nameof(equivalence));
            EquivalentId = equivalence.Id;
        }
    }
}
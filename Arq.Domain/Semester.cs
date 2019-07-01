using System;

namespace Arq.Domain
{
    public enum SemesterStatus
    {
        Current,
        Approved,
        Failed
    }

    public class Semester : Entity
    {
        public int Year { get; private set; }
        public int Period { get; private set; }
        public int? Score { get; private set; }
        public float? Grade { get; private set; }
        public float? Frequency { get; private set; }
        public SemesterStatus Status { get; private set; }

        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public Guid StudentId { get; private set; }
        public Student Student { get; private set; }

        public Semester()
        {
        }

        public Semester(int year, int period, Subject subject, Student student)
        {
            Year = year;
            Period = period;
            Status = SemesterStatus.Current;

            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            SubjectId = subject.Id;
            Student = student ?? throw new ArgumentNullException(nameof(student));
            StudentId = student.Id;
        }
    }
}
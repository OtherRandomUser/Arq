using System;
using System.Collections;
using System.Collections.Generic;

namespace Arq.Domain
{
    public class Curriculum : Entity
    {
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }

        public virtual ICollection<Subject> Subjects { get; private set; }

        public Curriculum()
        {
        }

        public Curriculum(Course course, string code, string description)
        {
            Course = course ?? throw new ArgumentNullException(nameof(course));
            CourseId = course.Id;

            Code = code;
            Description = description;
            Active = true;

            Subjects = new List<Subject>();
        }
    }
}
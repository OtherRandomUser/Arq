using System;
using System.Collections;
using System.Collections.Generic;

namespace Arq.Domain
{
    public class Course : Entity
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<Curriculum> Curriculums { get; private set; }
        public virtual ICollection<Student> Students { get; private set; }

        public Course()
        {
        }

        public Course(string code, string description)
        {
            Code = code;
            Description = description;

            Curriculums = new List<Curriculum>();
            Students = new List<Student>();
        }
    }
}
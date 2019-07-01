using System;
using System.Collections;
using System.Collections.Generic;

namespace Arq.Domain
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string RegistrationNumber { get; private set; }

        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }

        public IList<Semester> Semesters { get; private set; }

        public Student()
        {
        }

        public Student(string name, string password, string registrationNumber, Course course)
        {
            Name = name;
            Password = password;
            RegistrationNumber = registrationNumber;

            Course = course ?? throw new ArgumentNullException(nameof(course));
            CourseId = course.Id;

            Semesters = new List<Semester>();
        }
    }
}
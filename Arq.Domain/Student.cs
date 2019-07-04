using System;
using System.Collections;
using System.Collections.Generic;

namespace Arq.Domain
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string RegistrationNumber { get; private set; }

        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }

        public virtual ICollection<Semester> Semesters { get; private set; }

        public Student()
        {
        }

        public Student(string name, string username, string password, string registrationNumber, Course course)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(registrationNumber))
                throw new ArgumentNullException(nameof(registrationNumber));

            Name = name;
            Username = username;
            Password = password;
            RegistrationNumber = registrationNumber;

            Course = course ?? throw new ArgumentNullException(nameof(course));
            CourseId = course.Id;

            Semesters = new List<Semester>();
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }
}
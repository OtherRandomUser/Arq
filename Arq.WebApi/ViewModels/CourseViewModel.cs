using System;
using Arq.Domain;

namespace Arq.WebApi.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public static implicit operator CourseViewModel(Course course)
            => course == null ? null : new CourseViewModel
            {
                Id = course.Id,
                Code = course.Code,
                Description = course.Description
            };
    }
}
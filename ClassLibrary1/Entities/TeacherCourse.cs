using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class TeacherCourse
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public int TeacherId { set; get; }
        public string TeacherName { set; get; }
    }
}

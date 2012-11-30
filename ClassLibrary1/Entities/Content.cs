using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class Content
    {
        public int Id { set; get; }
        public string FileName { set; get; }
        public int SpecialtyId { set; get; }
        public string AcademicYear { set; get; }
        public string FileNamePath { set; get; }
        public int WriterId { set; get; }
        public DateTime PublishDate { set; get; }
        public int Semester { set; get; }
        public int Type { set; get; }
        public int DownloadCount { set; get; }
        public int CourseId { set; get; }
        public int LevelId { set; get; } 
    }
}

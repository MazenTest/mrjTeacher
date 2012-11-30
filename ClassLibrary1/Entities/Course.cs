using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class Course
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int? SpecialtyId { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class Banner
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string RedirectUrl { set; get; }
        public string ImageName { set; get; }
        public int Position { set; get; }
        public bool IsActive { set; get; }
    }
}

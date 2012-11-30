using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class News
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public DateTime PublishDate { set; get; }
        public string ImageName { set; get; }
    }
}

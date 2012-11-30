using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class Comment
    {
        public int ID { set; get; }
        public string CommentBody { set; get; }
        public DateTime PublishDate { set; get; }
        public string WriterName { set; get; }
        public int TeacherId { set; get; }
        public bool IsActive { set; get; }
        public int ContentId { set; get; }
        public int NewsId { set; get; }
        public int ArticleId { set; get; }
        public int ArticleWriterId { set; get; }
        public int UsefulInfoId { set; get; }


    }
}

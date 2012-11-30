using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComponent.Entities
{
    public class User
    {
        public int ID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ImageName { set; get; }
        public int RoleId { set; get; }
        public string Cv { set; get; }
    }
}

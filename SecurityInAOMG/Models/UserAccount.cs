using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityInAOMG.Models
{
    public class UserAccount
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roles { get; set; }

       
    }
}
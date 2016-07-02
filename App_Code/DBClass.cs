using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Meetup.CustomMembership.App_Code
{
    public class tblUser
    {
        public int fldUserId { get; set; }
        public string fldUsername { get; set; }
        public string fldPassword { get; set; }
        public string fldRole { get; set; }
    }
}
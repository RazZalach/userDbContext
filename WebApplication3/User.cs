using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class User
    {
        public int UserId { get; set; }
        public string uName { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public User()
        {

        }
        public User(int userId, string Uname , string Fname , string Lname , string Uemail, string pass)
        {
            this.UserId = userId;
            this.uName = Uname;
            this.fName = Fname;
            this.lName = Lname;
            this.email = Uemail;
            this.password = pass;
        }
        public User( string Uname, string Fname, string Lname, string Uemail, string pass)
        {      
            this.uName = Uname;
            this.fName = Fname;
            this.lName = Lname;
            this.email = Uemail;
            this.password = pass;
        }

    }
}
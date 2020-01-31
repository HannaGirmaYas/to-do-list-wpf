using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morning_Bell;
using System.Threading.Tasks;

namespace to_do_list_wpf.Model
{
    public class User
    {
        public User() { }
        public User(string username, int password, int id, string email, Morning_Bell.Task task,bool loggedIn)
        {
            this.Username = username;
            this.Email = email;
            this.LoggedIn = loggedIn;
            this.Password = password;
            this.Tasks = task;
            this.ID=id;


        }
        public string Username { get; set; }
        public int Password { get; set; }
        public int ID { get; set; }
        public bool LoggedIn { get; set; }
        public string Email { get; set; }
        public Morning_Bell.Task Tasks { get; set; }
    }
   
}

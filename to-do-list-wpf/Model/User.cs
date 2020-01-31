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
        public User(string username, int password, string email, Morning_Bell.Task taskID)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.TasksId = taskID;


        }
        public string Username { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public Morning_Bell.Task TasksId { get; set; }
    }
    /* public class Users
     {
         public Array User { get; set; }
     }*/
}

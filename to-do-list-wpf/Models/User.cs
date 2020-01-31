using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morning_Bell;
using System.Threading.Tasks;

namespace to_do_list_wpf.Models
{
    public class User
    {
        public User() { }
        public User(string username, int password, string email,int ID, Morning_Bell.Task task) {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.TasksId = task;
            this.ID = ID;

        
        }
        public string Username { get; set; }
        public int Password { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public Morning_Bell.Task TasksId { get; set; }
    }
   /* public class Users
    {
        public Array User { get; set; }
    }*/
}

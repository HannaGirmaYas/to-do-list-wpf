using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_wpf.Models
{
    public class User
    {
        public User() { }
        public User(string username, int password, string email, string taskID) {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.TasksId = taskID;

        
        }
        public string Username { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string TasksId { get; set; }
    }
    public class Users
    {
        public Array User { get; set; }
    }
}

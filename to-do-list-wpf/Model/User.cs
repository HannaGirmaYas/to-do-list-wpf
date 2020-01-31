using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_wpf.Model
{
    public class User
    {
        public User() { }
        public User(string username, int password, int id, string email, to_doTask task)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Tasks = task;
            this.ID=id;

        }
        public string Username { get; set; }
        public int Password { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public to_doTask Tasks { get; set; }
    }
   
}

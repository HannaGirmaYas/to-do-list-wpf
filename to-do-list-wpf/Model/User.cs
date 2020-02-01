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
        public User(string username, int password, string email)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.TaskList = new List<to_doTask>();


        }
        //private List<to_doTask> taskList;
        public string Username { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public List<to_doTask> TaskList { get; set; } = new List<to_doTask>();
        
    }
   
}

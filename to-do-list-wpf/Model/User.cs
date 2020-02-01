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

        public User(string username, int password, int id, string email, TaskJ task,bool loggedIn)

   
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
        public TaskJ Tasks { get; set; }
    }
    public class TaskJ
    {
        public string Title;

        public string Description;

        public List<to_doTask.ChecklistItem> Items;
        public TaskJ(to_doTask t)
        {
            this.Title = t.Title;
            this.Description = t.Description;
            this.Items = t.Items.ToList();
        }
    }

}

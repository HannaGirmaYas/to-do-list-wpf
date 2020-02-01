using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using to_do_list_wpf.Model;

namespace to_do_list_wpf.Model
{
    class FBToDo
    {
        IFirebaseClient client;
        FirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0ZnJY5HInBGNHaMSJCgr0PvGmZbocKe3CCojYV7o",
            BasePath = "https://to-do-list-wpf.firebaseio.com/"
        };

        public bool Connect()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetUser(string username)
        {
            FirebaseResponse response = client.Get("ToDoList/Users/" + username);
            return response.ResultAs<User>();
        }

     
        public User AddUser(User u)
        {
            

            SetResponse response1 = client.Set("ToDoList/Users/" + u.Username, u);
            return response1.ResultAs<User>();


        }
        public List<to_doTask> getTasks()
        {
            List<to_doTask> t = new List<to_doTask>();
            t.Add(new to_doTask("task1"));
            t.Add(new to_doTask("task2"));
            t.Add(new to_doTask("task3"));
            t.Add(new to_doTask("task4"));
            t.Add(new to_doTask("task5"));
            return t;
        }

        public List<to_doTask> RetrieveTasks(string username)
        {
            FirebaseResponse response = client.Get("ToDoList/Users/" + username + "/TaskList");
            return response.ResultAs<List<to_doTask>>();
        }
        public List<User> GetUsers()
        {
            FirebaseResponse response = client.Get("ToDoList/Users");
            return response.ResultAs<List<User>>();
        }

        public to_doTask AddTask(string username, to_doTask t)
        {
            SetResponse response = client.Set("ToDoList/Users/" + username + "/TaskList/" + t.Title, t);
            return response.ResultAs<to_doTask>();
        }

        public to_doTask GetTask(string username, string title)
        {
            FirebaseResponse response = client.Get("ToDoList/Users/" + username + "/TaskList/" + title);
            return response.ResultAs<to_doTask>();
        }

        public to_doTask UpdateTask(string username, to_doTask t)
        {
            FirebaseResponse response = client.Update("ToDoList/Users/" + username + "/TaskList/" + t.Title, t);
            return response.ResultAs<to_doTask>();
        }

        public void DeleteTask(string username, string title)
        {
            FirebaseResponse response = client.Delete("ToDoList/Users/" + username + "/TaskList/" + title);

        }
        public void DeletAllTask(string username)
        {
            FirebaseResponse response = client.Delete("ToDoList/Users/" + username + "/TaskList");

        }

        public void DeleteAllUsers()
        {
            FirebaseResponse response = client.Delete("ToDoList/Users");

        }
        public void DeleteUser(string username)
        {
            FirebaseResponse response = client.Delete("ToDoList/Users"+username);

        }
        public bool LoginUser(User u) {
            u.LoggedIn = true;
            FirebaseResponse response = client.Update("ToDoList/Users/" + u.Username, u);
            User uUpdated = response.ResultAs<User>();
            if (uUpdated.LoggedIn == true) {
                return true;
            }
            return false;
        }
        public bool LogoutUser(User u)
        {
            u.LoggedIn = false;
            FirebaseResponse response = client.Update("ToDoList/Users/" + u.Username, u);
            User uUpdated = response.ResultAs<User>();
            if (uUpdated.LoggedIn == false)
            {
                return true;
            }
            return false;
        }

        //for checkItems...
        public to_doTask.ChecklistItem AddCheckListItem(int userId, string title, to_do_list_wpf.Model.to_doTask.ChecklistItem c)
        {
            SetResponse response = client.Set("ToDoList/Users/" + userId + "/TaskList/" + title + "/ChecklistItem/" + c.Text, c);
            return response.ResultAs<to_doTask.ChecklistItem>();
        }
        public List<to_doTask.ChecklistItem> GetCheckListItems(int userId, string title)
        {
            FirebaseResponse response = client.Get("ToDoList/Users/" + userId + "/TaskList/" + title + "/ChecklistItem");
            return response.ResultAs<List<to_doTask.ChecklistItem>>();
        }
        public void DeleteCheckListItem(string username, string title, string text)
        {
            FirebaseResponse response = client.Delete("ToDoList/Users/" + username + "/TaskList/" + title + "/ChecklistItem/" + text);


        }
    } }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace to_do_list_wpf.Model
{
     class FBToDo
        {
            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
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

           

            public  List<User> GetAllUsers()
            {
                int i;


                List<User> users = new List<User>();
                FirebaseResponse response = client.Get("ToDoList/Users/Count/node");
                Count count = response.ResultAs<Count>();
                Console.WriteLine(count.CountUsers);
                int countq = Convert.ToInt32(count.CountUsers);
                for (i=1; i<=countq;i++) {
                    response = client.Get("ToDoList/Users/" + i);
                    users.Add(response.ResultAs<User>());
                   
            }
                return users;
            }
            public async Task<User> AddUser(User u)
            {
                FirebaseResponse response =  client.Get("ToDoList/Users/Count/node");
                Count count = (response.ResultAs<Count>());
                Console.WriteLine(count.CountUsers);
                count.CountUsers += 1;
                u.ID = count.CountUsers ;
               SetResponse response0 = client.Set("ToDoList/Users/Count/node" , count);
                SetResponse response1 = client.Set("ToDoList/Users/" + u.ID, u);
                return response1.ResultAs<User>();


            }
        public bool LoginUser(User u) {
            u.LoggedIn = true;
            FirebaseResponse response = client.Update("ToDoList/Users/" + u.ID, u);
            User uUpdated= response.ResultAs<User>();
            if (uUpdated.LoggedIn == true) {
                return true;
            }
            return false;
        }
        public bool LogoutUser(User u)
        {
            u.LoggedIn = false;
            FirebaseResponse response = client.Update("ToDoList/Users/" + u.ID, u);
            User uUpdated = response.ResultAs<User>();
            if (uUpdated.LoggedIn == false)
            {
                return true;
            }
            return false;
        }


    }
    }



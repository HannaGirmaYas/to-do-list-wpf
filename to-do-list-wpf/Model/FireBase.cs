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
    

    namespace to_do_list_wpf.Models
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

            public User GetUser(string username)
            {
                FirebaseResponse response = client.Get("ToDoList/Users/" + username);
                return response.ResultAs<User>();
            }

            public List<User> GetAllUsers()
            {
                int i;
                List<User> users = new List<User>();
                FirebaseResponse response = client.Get("ToDoList/Users/Count");
                int count = int.Parse(response.ResultAs<String>());
                for (i=0; i<count;i++) {
                    response = client.Get("ToDoList/Users/" + count);
                    users.Add(response.ResultAs<User>());
                }
                return users;
            }
            public async Task<User> AddUser(User u)
            {
                FirebaseResponse response = client.Get("ToDoList/Users/Count");
                int count = int.Parse(response.ResultAs<String>());
                u.ID = count + 1;
                SetResponse response1 = await client.SetTaskAsync("ToDoList/Users/" + u.ID, u);
                return response1.ResultAs<User>();


            }


        }
    }

}

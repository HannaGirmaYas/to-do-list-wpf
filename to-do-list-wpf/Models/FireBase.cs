using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace to_do_list_wpf.Models
{
    class FBToDo
    {
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "0ZnJY5HInBGNHaMSJCgr0PvGmZbocKe3CCojYV7o",
            BasePath= "https://to-do-list-wpf.firebaseio.com/"
        };

        public bool Connect()
        {
            try {
                client = new FireSharp.FirebaseClient(config);
                return true;
            }
            catch {
                return false;
            }
        }

        public User GetUser(string username) {
            FirebaseResponse response = client.Get("ToDoList/Users/"+ username);
            return response.ResultAs<User>();
        }

        public Users GetAllUsers()
        {
           
            FirebaseResponse response = client.Get("ToDoList/Users" );
            return response.ResultAs<Users>();
        }
        public async Task<User> AddUser(User u) {
            SetResponse response = await client.SetAsync("ToDoList/Users/" + u.Username, u);
            return  response.ResultAs<User>();


        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using to_do_list_wpf.windows;
using to_do_list_wpf.Model;

namespace to_do_list_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<User> allusers;
        FBToDo fb = new FBToDo();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!fb.Connect())
            {
                MessageBox.Show("No connection");
            }
            allusers = fb.GetAllUsers();

            if (allusers != null)
            {
                foreach (var user in allusers)
                {
                    Console.WriteLine("here3");
                    if (user != null)
                    {
                        Console.WriteLine("here1");
                        if (user.LoggedIn == true)
                        {
                            Console.WriteLine("here3");

                            StartupUri = new Uri("/windows/settings.xaml",
                        UriKind.Relative);
                            return;

                        }

                    }

                }
            }
            StartupUri = new Uri("/windows/LoginAndSignUp.xaml",
                        UriKind.Relative);
            



        }
        }
    }


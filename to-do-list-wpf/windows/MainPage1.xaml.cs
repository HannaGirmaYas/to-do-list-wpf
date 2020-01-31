using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using to_do_list_wpf.Model;
namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for MainPage1.xaml
    /// </summary>
    public partial class MainPage1 : Page
    {
        public List<to_doTask> TaskList = new List<to_doTask>();

        public MainPage1()
        {

            this.DataContext = this;
            TaskList = getTask();
            InitializeComponent();
        }

        private List<to_doTask> getTask()
        {
            TaskList.Add(new to_doTask("task1"));
            TaskList.Add(new to_doTask("task2"));
            TaskList.Add(new to_doTask("task3"));
            TaskList.Add(new to_doTask("task4"));
            TaskList.Add(new to_doTask("task5"));
            return TaskList;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

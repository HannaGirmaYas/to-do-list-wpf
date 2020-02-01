using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using to_do_list_wpf.Model;

namespace to_do_list_wpf.windows
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
		public ObservableCollection<to_doTask> TaskList { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            //sth to commit
        }
    }
}

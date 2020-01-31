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
using System.Windows.Navigation;
using System.Windows.Shapes;
using to_do_list_wpf.Model;
using to_do_list_wpf.windows;

namespace to_do_list_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() {
			InitializeComponent();
			to_doTask t = new to_doTask("DOMINATE");
			t.AddNewItem("Get a pet");
			t.AddNewItem("Get a bombshell");
			t.AddNewItem("Get a black leather jacket");
			t.AddNewItem("Get a Harley");
			t.AddNewItem("Don't get a haircut");
			t.AddNewItem("Join the Serbian Special Forces");
			t.AddNewItem("Get a haircut");
			TaskViewWindow.OpenATaskViewWindow(t);
			TaskViewWindow.OpenATaskViewWindow(t);
			TaskViewWindow.OpenATaskViewWindow(t);
		}
	}
	

	
}

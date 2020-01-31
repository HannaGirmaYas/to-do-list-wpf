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

namespace to_do_list_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() {
			InitializeComponent();
			to_do_list_wpf.Model.to_doTask t = new to_do_list_wpf.Model.to_doTask("DOMINATE");
			t.Items.Add(new to_doTask.ChecklistItem("Get a pet"));
			t.Items.Add(new to_doTask.ChecklistItem("Get a bombshell"));
			t.Items.Add(new to_doTask.ChecklistItem("Get a black leather jacket"));
			t.Items.Add(new to_doTask.ChecklistItem("Get a Harley"));
			t.Items.Add(new to_doTask.ChecklistItem("Don't get a haircut"));
			t.Items.Add(new to_doTask.ChecklistItem("Join the Serbian Special Forces"));
			t.Items.Add(new to_doTask.ChecklistItem("Get a haircut"));
			MainFrame.Navigate(new TaskView(t));
		}
	}
	

	
}

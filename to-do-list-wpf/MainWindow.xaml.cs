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

namespace Morning_Bell
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() {
			InitializeComponent();
			Task t = new Task("DOMINATE");
			t.Items.Add(new Task.ChecklistItem("Get a pet"));
			t.Items.Add(new Task.ChecklistItem("Get a bombshell"));
			t.Items.Add(new Task.ChecklistItem("Get a black leather jacket"));
			t.Items.Add(new Task.ChecklistItem("Get a Harley"));
			t.Items.Add(new Task.ChecklistItem("Don't get a haircut"));
			t.Items.Add(new Task.ChecklistItem("Join the Serbian Special Forces"));
			t.Items.Add(new Task.ChecklistItem("Get a haircut"));
			MainFrame.Navigate(new TaskView(t));
		}
	}
	

	
}

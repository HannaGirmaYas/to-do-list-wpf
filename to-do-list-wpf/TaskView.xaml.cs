using System;
using System.Collections.Generic;
using System.Text;
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
	/// Interaction logic for TaskView.xaml
	/// </summary>
	public partial class TaskView : Page
	{
		private Task task;
		public TaskView(Task task) {
			this.task = task;
			this.DataContext = this.task;
			InitializeComponent();
			itemListBox.SelectionMode = SelectionMode.Single;
		}

		private void AddItem(object sender, RoutedEventArgs e) {
			this.task.AddNewItem();
		}
	}
}

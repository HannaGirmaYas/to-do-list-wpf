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
using to_do_list_wpf.Model;

namespace to_do_list_wpf
{
	/// <summary>
	/// Interaction logic for TaskView.xaml
	/// </summary>
	public partial class TaskView : Page
	{
		private to_doTask task;
		public TaskView(to_doTask task) {
			this.task = task;
			this.DataContext = this.task;
			InitializeComponent();
		}

		private void AddItem(object sender, RoutedEventArgs e) {
			this.task.AddNewItem();
		}

		private void RemoveItem(object sender, RoutedEventArgs e) {
			this.task.Items.Remove((sender as Button).DataContext as to_doTask.ChecklistItem);
		}
	}
}

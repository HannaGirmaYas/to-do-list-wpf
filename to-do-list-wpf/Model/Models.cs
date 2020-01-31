using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace to_do_list_wpf.Model
{
	public class to_doTask : INotifyPropertyChanged
	{
		private string title;
		public string Title {
			get { return title; }
			set {
				title = value;
				this.ModifiedAt = DateTime.Now;
				OnPropertyChanged();
			}
		}
		private string description;
		public string Description {
			get { return description; }
			set {
				description = value;
				this.ModifiedAt = DateTime.Now;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<ChecklistItem> Items { get; private set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		public to_doTask(string title = "", string description = "") {
			this.Items = new ObservableCollection<ChecklistItem>();
			this.CreatedAt = DateTime.Now;
			this.ModifiedAt = DateTime.Now;
			this.description = description;
			this.title = title;
		}

		private void OnPropertyChanged([CallerMemberName] string name = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public void AddNewItem(string text = "") {
			lock (Items) {
				foreach (var item in this.Items.ToList()) {
					if (item.Text.Trim().Equals("")) {
						this.Items.Remove(item);
					}
				}
				this.Items.Add(new ChecklistItem(text));
				OnPropertyChanged();
			}
		}
		public class ChecklistItem //: INotifyPropertyChanged
		{
			private string _text;

			public string Text {
				get { return _text; }
				set {
					_text = value;
					//OnPropertyChanged();
				}
			}
			private bool isChecked;

			public bool IsChecked {
				get { return isChecked; }
				set {
					isChecked = value;
					//OnPropertyChanged();
				}
			}

			public ChecklistItem(string text, bool isChecked = false) {
				this.Text = text;
				this.IsChecked = isChecked;
			}
			//public event PropertyChangedEventHandler PropertyChanged;
			//private void OnPropertyChanged([CallerMemberName] string name = null) {
			//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			//}
		}
	}


	/*abstract class Note
	{
		public abstract NoteType Type {
			get;
		}

	}
	enum NoteType { Checklist, Text }

	class Checklist : Note
	{
		public override NoteType Type { get { return NoteType.Checklist; } }


	}
	class Text : Note
	{
		public override NoteType Type { get { return NoteType.Text; } }

	}*/
	/*class Note
	{
		public ObservableCollection<IDrawer> elts {
			get;
		}
	}
	enum ElementType { Checklist, Text}

	interface IDrawer
	{
		ElementType Type { get; }
		void Draw();
	}
	class Checklist
	{
		public IDrawer drawInstructions { get; }
	}
	struct ChecklistDrawer : IDrawer
	{
		public ElementType Type {
			get { return ElementType.Checklist; }
		}
		private Checklist data;
		public void Draw() {
			// draw checklist
		}
	}
	class Text
	{
		public IDrawer drawInstructions { get; }
	}

	struct TextDrawer : IDrawer
	{
		public ElementType Type {
			get { return ElementType.Text; }
		}
		private Text data;
		public void Draw() {
			// draw text
		}
	}*/
}

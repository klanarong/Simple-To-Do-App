using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleToDoApp
{
    public partial class SimpleToDoApp : Form
    {
        private List<string> todos = new List<string>();
        private ListBox listBox;
        private TextBox inputBox;
        private Button addBtn, delBtn;

        public SimpleToDoApp()
        {
            InitializeComponent();
            listBox = new ListBox { Top = 10, Left = 10, Width = 260, Height = 180 };
            inputBox = new TextBox { Top = 200, Left = 10, Width = 180 };
            addBtn = new Button { Text = "Add", Top = 200, Left = 200 };
            delBtn = new Button { Text = "Delete", Top = 240, Left = 200 };

            addBtn.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(inputBox.Text))
                {
                    todos.Add(inputBox.Text);
                    listBox.Items.Add(inputBox.Text);
                    inputBox.Text = "";
                }
            };
            delBtn.Click += (s, e) =>
            {
                if (listBox.SelectedIndex != -1)
                {
                    todos.RemoveAt(listBox.SelectedIndex);
                    listBox.Items.RemoveAt(listBox.SelectedIndex);
                }
            };

            Controls.Add(listBox);
            Controls.Add(inputBox);
            Controls.Add(addBtn);
            Controls.Add(delBtn);
            Width = 320; Height = 320;
            Text = "Simple To-Do App";
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new SimpleToDoApp());
        }
    }
}
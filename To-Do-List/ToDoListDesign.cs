using System;
using System.Data;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class ToDoList : Form
    {

        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            ToDoListView.DataSource = todoList;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Title.Text = "";
            Description.Text = "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            Title.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            Description.Text = todoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Title"] = Title.Text;
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = Description.Text;
            }
            else
            {
                todoList.Rows.Add(Title.Text, Description.Text);
            }

            Title.Text = "";
            Description.Text = "";
            isEditing = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex);
            }
        }


    }
}

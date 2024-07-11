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

        DataTable toDoList = new DataTable();

        bool isEditing = false;



        private void ToDoList_Load(object sender, EventArgs e)
        {
            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Description");

            ToDoListView.DataSource = toDoList;

            Instantiate_StrecthRowDescription();
            Instantiate_ObjectScaleWindowSize();
        }

        private void Instantiate_StrecthRowDescription()
        {

        }

        private void Instantiate_ObjectScaleWindowSize()
        {
            //This represent the location and size of a rectangle and set them equal to the working area of the primary display.
            System.Drawing.Rectangle workingRetactangle = Screen.PrimaryScreen.WorkingArea;

            //The Size of the form is equal to 50% of the Height and of the width
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.75 * workingRetactangle.Width), Convert.ToInt32(0.5 * workingRetactangle.Width));

            //The location of the form set to be 10,10 from upper left corner of display. 
            this.Location = new System.Drawing.Point(10, 10);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Title.Text = "";
            Description.Text = "";

            string sent = Description.Text;

            Description.AppendText(sent);
            Description.AppendText(Environment.NewLine);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            Title.Text = toDoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            Description.Text = toDoList.Rows[ToDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                toDoList.Rows[ToDoListView.CurrentCell.RowIndex]["Title"] = Title.Text;
                toDoList.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = Description.Text;
            }
            else
            {
                toDoList.Rows.Add(Title.Text, Description.Text);
            }

            Title.Text = "";
            Description.Text = "";
            isEditing = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex);
            }
        }
    }
}

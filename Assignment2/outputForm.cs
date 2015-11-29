using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
    public partial class outputForm : Form
    {
        private const double HOURLY_WAGE_CONST = 10.50; 
        // Declare Class-level variable
        private int FieldCountInteger = 0;
        private string[] FieldString;
        public outputForm()
        {
            InitializeComponent();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DisplayData()
        {
            // Custom method to display records in a set of TextBoxes
            string FirstFieldString, SecondFieldString, thirdFieldString;

            FirstFieldString = FieldString[FieldCountInteger];
            SecondFieldString = FieldString[FieldCountInteger + 1];
            thirdFieldString = FieldString[FieldCountInteger + 2];
            textBoxName.Text = FirstFieldString;
            textBoxNumber.Text = SecondFieldString;
            textBoxHours.Text = thirdFieldString;
            textBoxPay.Text = (Double.Parse(textBoxHours.Text) * HOURLY_WAGE_CONST).ToString("c");
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                // Move the index forward and Display the Records
                FieldCountInteger += 3;
                DisplayData();
            } // end try
            catch
            {
                MessageBox.Show("No more records to display.", "End of Data");
                FieldCountInteger -= 3;
            }
        }

        private void inputFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new inputForm()).Show();
        }

        private void outputForm_Load(object sender, EventArgs e)
        {
            // Declare method-level variables
            string FileName = "Employees.txt";

            try
            {
                // Read entire file into a single string.
                string fileString = File.ReadAllText(FileName);
                // Split the string into individual fields of a string array.
                FieldString = fileString.Split('\n');
                // Display the array in a list box.
                textBoxName.Text = FieldString[FieldCountInteger];
                textBoxNumber.Text = FieldString[FieldCountInteger + 1];
                textBoxHours.Text = FieldString[FieldCountInteger + 2];
                textBoxPay.Text = (Double.Parse(textBoxHours.Text) * HOURLY_WAGE_CONST).ToString("c");
                
            } // end try
            catch
            {
                MessageBox.Show("Unable to access the file: " +
                    FileName, "File Error");
                this.Close();
            } // end catch
        }
        

    }
}

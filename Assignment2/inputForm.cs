/*
 * Developers: Akhil Thakkar & Tyler Hollmann
 * Created: Nov 28, 2015
 * Version: 1.0.0
 * Purpose: Print employee information to a text file for the user to be able to
 * iterate and read through it at a later date / in another form.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class inputForm : Form
    {
        public inputForm()
        {
            InitializeComponent();
            
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxNumber.Clear();
            textBoxHours.Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Check to see if name text box is empty
            if (textBoxName.Text != "")
            {
                // Check to see if employee number text box is empty
                if (textBoxNumber.Text != "")
                {
                    // Try to parse the textbox for hours worked to a double,
                    // if it fails display the appropriate message
                    try
                    {
                        Double hoursWorked = Double.Parse(textBoxHours.Text);
                        // Check to see if the employee has worked between 0 - 40 hours.
                        // If all conditions are met, save the employee to the text file
                        if (hoursWorked <= 40 && hoursWorked > 0)
                        {
                            // Save the record to the end of the File.
                            string FileName = "Employees.txt";
                            string StringToWrite = textBoxName.Text + Environment.NewLine + textBoxNumber.Text + Environment.NewLine + textBoxHours.Text + Environment.NewLine;

                            // This line opens the file, appends to the end of the file and closes it.
                            File.AppendAllText(FileName, StringToWrite);


                            // Call the ResetForm method
                            ResetForm();
                        }
                        else
                        {
                            MessageBox.Show("Employee must work only between 0-40 hours", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxHours.SelectAll();
                            textBoxHours.Focus();
                        }
                    }
                    catch (FormatException error)
                    {
                        MessageBox.Show("Please enter a valid number for hours worked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxHours.SelectAll();
                        textBoxHours.Focus();
                    }
                }
                else
                {
                    // number is missing
                    MessageBox.Show("Phone number is required", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxNumber.SelectAll();
                    textBoxNumber.Focus();
                }
            }
            else
            {
               // Name is missing
                MessageBox.Show("Name is required", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.SelectAll();
                textBoxName.Focus();

            }


        }
        private void ResetForm()
        {
            // This is a custom method that resets the form fields
            // Reset the form
            textBoxNumber.Clear();
            textBoxName.Clear();
            textBoxHours.Clear();
            textBoxName.Focus();
        }

        private void outputFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the current form and initialize an output form and then show it.
            (new outputForm()).Show();
            this.Hide();   
        }

      

        

        
    }
}

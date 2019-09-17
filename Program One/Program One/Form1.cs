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
using System.Drawing.Printing;
using System.Diagnostics;

namespace Program_One
{
    public partial class Form1 : Form
    {
        double tax;
        string state;
        private Font font;
        private StreamReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Save entry to tax file.
        public void AppendText()
        {
            // Get state.
            state = stateTextBox.Text;

            // Get tax rate and validate input.
            if (double.TryParse(taxTextBox.Text, out tax))
            {
                // Declare a StreamWriter variable.
                StreamWriter myFile;

                // Append file and get a StreamWriter object.
                myFile = File.AppendText("Tax.txt");

                // Write the state and tax rate to the file
                myFile.WriteLine(state + "          " + tax.ToString("n2"));

                // Close the file.
                myFile.Close();

                // Let user know operation completed successfully.
                MessageBox.Show("Done!");
            }
            else
            {
                // Display error message.
                MessageBox.Show("Error! Invalid tax rate input!");
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Call AppendText method when Save Button is clicked.
            AppendText();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // Create StreamReader object.
            reader = new StreamReader("Tax.txt");
            //Create font and size
            font = new Font("Courier New", 14);

            // Preview Document to print
            printPreviewDialog.ShowDialog();

            // Create new PrintDialog object
            PrintDialog printDialog = new PrintDialog();

            // Create PrintDocument Object 
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box

            printDocument.PrintPage += new PrintPageEventHandler(this.TaxListing); // Use and Event Handler that execute the method 

            //Capture Where to Print the Document
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        public void TaxListing(object sender, PrintPageEventArgs e)
        {
            //Get the Graphics object
            Graphics g = e.Graphics;

            // Create new font and brush objects.
            Font font = new Font("Courier New", 14);
            Brush brush = new SolidBrush(Color.Black);
            float fontHeight = font.GetHeight();

            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            int offset = 20;

            //Read margins from PrintPageEventArgs
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            string line = null;

            //Calculate the lines per page on the basis of the height of the page and the height of the font
            linesPerPage = e.MarginBounds.Height / font.GetHeight(g);

            // Create  Header of the Report
            Image header = Image.FromFile("Hoodies.png");

            g.DrawImage(header, leftMargin + 45, topMargin, header.Width, header.Height);
            topMargin = topMargin + header.Height + 20;
            g.DrawString(("Date: " + (DateTime.Now).ToString()).PadLeft(85), new Font("Verdana", 12, FontStyle.Bold), new SolidBrush(Color.Black), leftMargin, topMargin);
            topMargin = topMargin + (int)fontHeight;
            g.DrawString("_________________________________________________", font, brush, leftMargin, topMargin);
            g.DrawString("Audit Listing of Sales Tax Table and Rates", new Font("Verdana", 12, FontStyle.Bold), brush, leftMargin, topMargin + (int)fontHeight);
            topMargin = topMargin + (int)fontHeight;
            g.DrawString("_________________________________________________", font, brush, leftMargin, topMargin);
            topMargin = topMargin + (int)fontHeight + offset;
            g.DrawString("State" + "Tax Rate".PadLeft(13), new Font(font, FontStyle.Bold), new SolidBrush(Color.Black), leftMargin, topMargin);
            topMargin = topMargin + (int)fontHeight;

            while (count < linesPerPage && ((line = reader.ReadLine()) != null))
            {
                //Calculate the starting position
                yPos = topMargin + (count * font.GetHeight(g)) + 10;
                //Draw text
                g.DrawString(line + "%", font, brush, leftMargin, yPos, new StringFormat());
                //Move to next line
                count++;
            }
            //If PrintPageEventArgs has more pages to print
            if (line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        // Update tax rate for specific state.
        private void updateButton_Click(object sender, EventArgs e)
        {
            StringBuilder newFile = new StringBuilder();
            string update;      // hold updated tax rate
            string[] line;      // hold each line of the tax file

            // Read all lines from tax file.
            line = File.ReadAllLines("Tax.txt");

            // Loop through each line.
            foreach (var tax in line)
            {
                string state = tax.Substring(0, 2);                 // Trim state.
                string taxRate = tax.Substring(12, 4);              // Trim tax rate.          

                // Check if state entered matches previous state entry.
                if(state == stateTextBox.Text)
                {
                    // Replace previous tax rate with new tax rate.
                    update = tax.Replace(taxRate, taxTextBox.Text);
                    newFile.Append(update + "\r\n");
                    continue;
                    
                }

                newFile.Append(tax + "\r\n");

            }

            // Write new entry to tax file.
            File.WriteAllText("Tax.txt", newFile.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Link for valid tax rate information.
            Process.Start("http://taxfoundation.org/article/state-and-local-sales-tax-rates-2015");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear textboxes.
            stateTextBox.Text = "";
            taxTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Closes the program.
            this.Close();
        }
    }

  }

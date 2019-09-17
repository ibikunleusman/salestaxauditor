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

namespace Program_Two
{
    public partial class Form1 : Form
    {
        private string state;

        public Form1()
        {
            InitializeComponent();
        }

        private void readTaxButton_Click(object sender, EventArgs e)
        {
            string line; // Hold each for Tax rate file
            int number;  // Hold Tax Rate list count

            // Declare a StreamReader variable.
            StreamReader taxFile;

            // Open the file and get a StreamReader object. 
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                taxFile = File.OpenText(openFile.FileName);

                // Read the tax file's contents.
                while (!taxFile.EndOfStream)
                {
                    // Get a tax rate entry.
                    line = taxFile.ReadLine();

                    // Add the tax rate to a ListBox.
                    listTaxRate.Items.Add(line);

                    // Count the number of items in the ListBox.
                    number = listTaxRate.Items.Count;

                }
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Operation was cancelled!");
            }
        }

        private void readSalesButton_Click(object sender, EventArgs e)
        {
            string line;   // Declare a variable to hold a sales entry.
            int number;    // Declare a variable to hold list count.

            // Declare a StreamReader variable.
            StreamReader salesFile;

            // Open the file and get a StreamReader object.
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                salesFile = File.OpenText(openFile.FileName);

                // Read the sales file contents.
                while (!salesFile.EndOfStream)
                {
                    // Get a sales entry
                    line = salesFile.ReadLine();
                    
                    // Add sales entry to a list box.
                    listSales.Items.Add(line);

                    // Count items in list Box.
                    number = listSales.Items.Count;
                }
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Operation was cancelled!");
            }
        }

        public void selectState()
        {
            int i = 0;                              // Hold loop counter.
            string state;                           // Variable to hold a state.
            state = stateComboBox.Text;             

            // Clear all List boxes.
            listSales.SelectedItems.Clear();
            listTaxRate.SelectedItems.Clear();

            // Select e-commerce sales entry for state chosen in ComboBox. 
            for (i = 0; i < listSales.Items.Count; i++)
            {
                if (listSales.Items[i].ToString().Contains(state) && listSales.Items[i].ToString().Contains("E"))
                {
                    listSales.SetSelected(i, true);
                }
            }

            // Select tax rate entry for state chosen in ComboBox. 
            for (i = 0; i < listTaxRate.Items.Count; i++)
            {
                if (listTaxRate.Items[i].ToString().Contains(state))
                {
                    listTaxRate.SetSelected(i, true);
                }
            }                
         }

        private void stateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call selectState, and taxFileDefinition Methods.
            selectState();
            taxFileDefinition();
        }  

        public void taxFileDefinition()
        {
            int i = 0;

            string line;
            string state;
            string taxrate;

            double dblTaxRate;

            // Collect state tax rate based on state choice using substring.
            for (i = 0; i < listTaxRate.SelectedItems.Count; i++)
            {
                foreach (object rate in listTaxRate.SelectedItems)
                {
                    line = listTaxRate.SelectedItems[i].ToString();

                    state = line.Substring(0, 2);
                    taxrate = line.Substring(12,4);

                    dblTaxRate = Convert.ToDouble(taxrate);

                    taxRateLabel.Text = dblTaxRate.ToString("n2");                
                }
            }

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // Preview Document to print
            printPreviewDialog.ShowDialog();

            // Create new PrintDialog object
            PrintDialog printDialog = new PrintDialog();

            // Create PrintDocument Object 
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box
                   
            printDocument.PrintPage += new PrintPageEventHandler(this.CreateListing); // Use and Event Handler that execute the method 
            
            //Capture Where to Print the Document
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        public void CreateListing(object sender, PrintPageEventArgs e)
        {
            // Create Graphics object.
            Graphics g = e.Graphics;

            Font font = new Font("Courier New", 14); // Declare new Font to use.

            float fontHeight = font.GetHeight();

            int i = 0;
            string line = null;

            int totalOrderLine = 0;
            double totalOrderAmt = 0;                                           // Total Order Amount, initialized to 0.
            double totalSalesAmt = 0;                                           // Total Sales Amount, initialized to 0.
            double taxRate = Convert.ToDouble(taxRateLabel.Text) / 100;         // State Tax Rate.

            int X = 20;
            int Y = 10;
            int offset = 40;

            // Create  Header of the Report
            Image header = Image.FromFile("Hoodies.png");

            e.Graphics.DrawImage(header, X + 95, Y, header.Width, header.Height);
            Y = Y + header.Height + 20;
            e.Graphics.DrawString(("Date: " + (DateTime.Now).ToString()).PadLeft(115), new Font("Verdana", 12, FontStyle.Bold), new SolidBrush(Color.Black), X, Y);
            Y = Y + (int)fontHeight;
            e.Graphics.DrawString("_______________________________________________________________", font, new SolidBrush(Color.Black), X, Y);
            e.Graphics.DrawString("Sales order with Sales Tax Listing", new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, new Point(X, Y + (int)fontHeight));
            e.Graphics.DrawString("_______________________________________________________________", font, new SolidBrush(Color.Black), X, Y + (int)fontHeight);
            Y = Y + (int)fontHeight;
            e.Graphics.DrawString("Order No" + "Sold to State".PadLeft(16) + "Order Amount".PadLeft(15) + "Sales Tax Amount".PadLeft(20) + "Order Type".PadLeft(20), new Font("Verdana", 12, FontStyle.Bold), Brushes.Black, X, Y + offset);
            Y = Y + (int)fontHeight;

            //Info to Print on the body of the Report.  
            for (i = 0; i < listSales.SelectedItems.Count; i++)
            {
                foreach (object item in listSales.SelectedItems)
                {
                    line = listSales.SelectedItems[i].ToString();
                    
                    // Sales File Definition
                    string ordernumber = line.Substring(0, 5);
                    string state = line.Substring(6, 2);
                    string orderamount = line.Substring(9, 8);
                    string salestaxamount = line.Substring(18, 8);
                    string ordertype = line.Substring(27, 1);

                    double dblOrderAmt = Convert.ToDouble(orderamount) / 100;
                    double dblsalesTaxAmt = (dblOrderAmt * taxRate);

                    string forOrder;
                    forOrder = dblOrderAmt.ToString();

                    totalOrderAmt += dblOrderAmt;
                    totalSalesAmt += dblsalesTaxAmt;
                    totalOrderLine = line.Count();

                    offset = offset + (int)fontHeight;
                    e.Graphics.DrawString(ordernumber + state.PadLeft(10) + String.Format("{0:c}", dblOrderAmt).PadLeft(15) + String.Format("{0:c}", dblsalesTaxAmt).PadLeft(15) + ordertype.PadLeft(15), font, Brushes.Black, X, Y + offset);
                    i++;
                }
                
            }
            Y = Y + (int)fontHeight + offset; // Control Spacing.

            // Print the Totals.
            e.Graphics.DrawString("__________________________________________________________________", font, new SolidBrush(Color.Black), X, Y);
            Y = Y + (int)fontHeight + 10;
            e.Graphics.DrawString("Total Order Lines: " + totalOrderLine.ToString().PadLeft(26), font, Brushes.Red, X, Y);
            Y = Y + (int)fontHeight;
            e.Graphics.DrawString("Total Sales Order Amount: " + String.Format("{0:c}", totalOrderAmt).PadLeft(20), font, Brushes.Red, X, Y);
            Y = Y + (int)fontHeight;
            e.Graphics.DrawString("Total Sales Tax Amount: " + String.Format("{0:c}", totalSalesAmt).PadLeft(22), font, Brushes.Red, X, Y);

            offset = 20;

            Y = Y + (int)fontHeight + offset;
            e.Graphics.DrawString("Total Sales Order Lines by State: " + totalOrderLine.ToString().PadLeft(13), font, Brushes.Red, X, Y);
            Y = Y + (int)fontHeight;
            e.Graphics.DrawString("Total by State: " + state + String.Format("{0:c}", totalOrderAmt).PadLeft(30), font, Brushes.Red, X, Y);
            Y = Y + (int)fontHeight + offset;

            // Print end of report.
            e.Graphics.DrawString("_____________________End of Sales Tax Listing______________________", font, new SolidBrush(Color.Black), X, Y);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Close the program.
            this.Close();
        }
    }
}

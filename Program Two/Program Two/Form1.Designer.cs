namespace Program_Two
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listTaxRate = new System.Windows.Forms.ListBox();
            this.listSales = new System.Windows.Forms.ListBox();
            this.readTaxButton = new System.Windows.Forms.Button();
            this.readSalesButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.taxRateLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTaxRate
            // 
            this.listTaxRate.FormattingEnabled = true;
            this.listTaxRate.Location = new System.Drawing.Point(12, 12);
            this.listTaxRate.Name = "listTaxRate";
            this.listTaxRate.Size = new System.Drawing.Size(196, 225);
            this.listTaxRate.TabIndex = 0;
            // 
            // listSales
            // 
            this.listSales.FormattingEnabled = true;
            this.listSales.Location = new System.Drawing.Point(232, 12);
            this.listSales.Name = "listSales";
            this.listSales.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listSales.Size = new System.Drawing.Size(319, 225);
            this.listSales.TabIndex = 1;
            // 
            // readTaxButton
            // 
            this.readTaxButton.Location = new System.Drawing.Point(52, 257);
            this.readTaxButton.Name = "readTaxButton";
            this.readTaxButton.Size = new System.Drawing.Size(106, 42);
            this.readTaxButton.TabIndex = 2;
            this.readTaxButton.Text = "Read Tax Rates File";
            this.readTaxButton.UseVisualStyleBackColor = true;
            this.readTaxButton.Click += new System.EventHandler(this.readTaxButton_Click);
            // 
            // readSalesButton
            // 
            this.readSalesButton.Location = new System.Drawing.Point(315, 257);
            this.readSalesButton.Name = "readSalesButton";
            this.readSalesButton.Size = new System.Drawing.Size(128, 42);
            this.readSalesButton.TabIndex = 3;
            this.readSalesButton.Text = "Get Sales File";
            this.readSalesButton.UseVisualStyleBackColor = true;
            this.readSalesButton.Click += new System.EventHandler(this.readSalesButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(592, 123);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(121, 36);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(592, 201);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 36);
            this.button4.TabIndex = 6;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search State";
            // 
            // stateComboBox
            // 
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AS",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FL",
            "GA",
            "GU",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "PR",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VI",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.stateComboBox.Location = new System.Drawing.Point(592, 59);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(121, 21);
            this.stateComboBox.TabIndex = 9;
            this.stateComboBox.SelectedIndexChanged += new System.EventHandler(this.stateComboBox_SelectedIndexChanged);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.CreateListing);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog1";
            this.printPreviewDialog.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.taxRateLabel);
            this.groupBox1.Location = new System.Drawing.Point(52, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tax Rate for State: ";
            // 
            // taxRateLabel
            // 
            this.taxRateLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.taxRateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taxRateLabel.Location = new System.Drawing.Point(144, 28);
            this.taxRateLabel.Name = "taxRateLabel";
            this.taxRateLabel.Size = new System.Drawing.Size(106, 19);
            this.taxRateLabel.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.readSalesButton);
            this.Controls.Add(this.readTaxButton);
            this.Controls.Add(this.listSales);
            this.Controls.Add(this.listTaxRate);
            this.Name = "Form1";
            this.Text = "Sales Nexus Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listTaxRate;
        private System.Windows.Forms.ListBox listSales;
        private System.Windows.Forms.Button readTaxButton;
        private System.Windows.Forms.Button readSalesButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label taxRateLabel;
    }
}


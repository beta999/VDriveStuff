namespace MIBExplorer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.OpenDir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DDSFiles = new System.Windows.Forms.ListView();
            this.MIBFiles = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DumpButton = new System.Windows.Forms.Button();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EncCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WidthCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeightCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 625);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.OpenDir);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Location = new System.Drawing.Point(12, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(435, 43);
            this.panel4.TabIndex = 3;
            // 
            // OpenDir
            // 
            this.OpenDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDir.Location = new System.Drawing.Point(357, 14);
            this.OpenDir.Name = "OpenDir";
            this.OpenDir.Size = new System.Drawing.Size(75, 23);
            this.OpenDir.TabIndex = 1;
            this.OpenDir.Text = "Directory";
            this.OpenDir.UseVisualStyleBackColor = true;
            this.OpenDir.Click += new System.EventHandler(this.OpenDir_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(348, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.DDSFiles);
            this.panel3.Controls.Add(this.MIBFiles);
            this.panel3.Location = new System.Drawing.Point(3, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 534);
            this.panel3.TabIndex = 1;
            // 
            // DDSFiles
            // 
            this.DDSFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DDSFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.EncCol,
            this.WidthCol,
            this.HeightCol});
            this.DDSFiles.Location = new System.Drawing.Point(228, 3);
            this.DDSFiles.Name = "DDSFiles";
            this.DDSFiles.Size = new System.Drawing.Size(216, 510);
            this.DDSFiles.TabIndex = 1;
            this.DDSFiles.UseCompatibleStateImageBehavior = false;
            this.DDSFiles.View = System.Windows.Forms.View.Details;
            // 
            // MIBFiles
            // 
            this.MIBFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MIBFiles.FormattingEnabled = true;
            this.MIBFiles.Location = new System.Drawing.Point(2, 2);
            this.MIBFiles.Name = "MIBFiles";
            this.MIBFiles.Size = new System.Drawing.Size(220, 511);
            this.MIBFiles.TabIndex = 0;
            this.MIBFiles.SelectedIndexChanged += new System.EventHandler(this.MIBFiles_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UpdateButton);
            this.panel2.Controls.Add(this.DumpButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 586);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 39);
            this.panel2.TabIndex = 2;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateButton.Location = new System.Drawing.Point(231, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(90, 25);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update MIB";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DumpButton
            // 
            this.DumpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DumpButton.Location = new System.Drawing.Point(135, 2);
            this.DumpButton.Name = "DumpButton";
            this.DumpButton.Size = new System.Drawing.Size(90, 25);
            this.DumpButton.TabIndex = 1;
            this.DumpButton.Text = "Dump DDS";
            this.DumpButton.UseVisualStyleBackColor = true;
            this.DumpButton.Click += new System.EventHandler(this.DumpButton_Click);
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            // 
            // EncCol
            // 
            this.EncCol.Text = "Encoding";
            // 
            // WidthCol
            // 
            this.WidthCol.Text = "Width";
            // 
            // HeightCol
            // 
            this.HeightCol.Text = "Height";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 625);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox MIBFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DumpButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OpenDir;
        private System.Windows.Forms.ListView DDSFiles;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader EncCol;
        private System.Windows.Forms.ColumnHeader WidthCol;
        private System.Windows.Forms.ColumnHeader HeightCol;
    }
}


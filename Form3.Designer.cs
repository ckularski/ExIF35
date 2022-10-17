namespace ExIF35
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.skipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkCopyright = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.chkWriteContact = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFileSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfromdir = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkKeepExpNum = new System.Windows.Forms.CheckBox();
            this.chkDetDes = new System.Windows.Forms.CheckBox();
            this.chkRnEn = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkPhotogDesc = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag files (in order) into the box to map them.";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 123);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(756, 184);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Exposure";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File name";
            this.columnHeader2.Width = 574;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skipToolStripMenuItem,
            this.setFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            // 
            // skipToolStripMenuItem
            // 
            this.skipToolStripMenuItem.Name = "skipToolStripMenuItem";
            this.skipToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.skipToolStripMenuItem.Text = "Skip";
            this.skipToolStripMenuItem.Click += new System.EventHandler(this.skipToolStripMenuItem_Click);
            // 
            // setFileToolStripMenuItem
            // 
            this.setFileToolStripMenuItem.Name = "setFileToolStripMenuItem";
            this.setFileToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.setFileToolStripMenuItem.Text = "Set File";
            this.setFileToolStripMenuItem.Click += new System.EventHandler(this.setFileToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Write to Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(414, 12);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(182, 17);
            this.chkPrint.TabIndex = 4;
            this.chkPrint.Text = "Write film info in \"User Comment\"";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // chkCopyright
            // 
            this.chkCopyright.AutoSize = true;
            this.chkCopyright.Location = new System.Drawing.Point(414, 33);
            this.chkCopyright.Name = "chkCopyright";
            this.chkCopyright.Size = new System.Drawing.Size(149, 17);
            this.chkCopyright.TabIndex = 5;
            this.chkCopyright.Text = "Write Copyright Statement";
            this.chkCopyright.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(106, 34);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(254, 20);
            this.txtDirectory.TabIndex = 9;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(366, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 21);
            this.button3.TabIndex = 10;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Output Prefix: ";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(106, 59);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(134, 20);
            this.txtPrefix.TabIndex = 12;
            this.txtPrefix.Text = "ASC_";
            // 
            // chkWriteContact
            // 
            this.chkWriteContact.AutoSize = true;
            this.chkWriteContact.Location = new System.Drawing.Point(414, 55);
            this.chkWriteContact.Name = "chkWriteContact";
            this.chkWriteContact.Size = new System.Drawing.Size(154, 17);
            this.chkWriteContact.TabIndex = 13;
            this.chkWriteContact.Text = "Include contact information";
            this.chkWriteContact.UseVisualStyleBackColor = true;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(414, 74);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(114, 17);
            this.chkOverwrite.TabIndex = 14;
            this.chkOverwrite.Text = "Overwrite Originals";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            this.chkOverwrite.CheckedChanged += new System.EventHandler(this.chkOverwrite_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "File Source:";
            // 
            // cboFileSource
            // 
            this.cboFileSource.FormattingEnabled = true;
            this.cboFileSource.Items.AddRange(new object[] {
            "Unknown",
            "Scanned Film",
            "Scanned Print",
            "Digital Photograph"});
            this.cboFileSource.Location = new System.Drawing.Point(106, 84);
            this.cboFileSource.Name = "cboFileSource";
            this.cboFileSource.Size = new System.Drawing.Size(134, 21);
            this.cboFileSource.TabIndex = 16;
            this.cboFileSource.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Get Images From:";
            // 
            // txtfromdir
            // 
            this.txtfromdir.Location = new System.Drawing.Point(109, 9);
            this.txtfromdir.Name = "txtfromdir";
            this.txtfromdir.ReadOnly = true;
            this.txtfromdir.Size = new System.Drawing.Size(251, 20);
            this.txtfromdir.TabIndex = 18;
            this.txtfromdir.Visible = false;
            this.txtfromdir.Click += new System.EventHandler(this.txtfromdir_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(109, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Select Directory";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.HelpRequest += new System.EventHandler(this.folderBrowserDialog2_HelpRequest);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "or drop files below";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(572, 313);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JPEG Images|*.jpg|JPEG Images|*.jpeg|All Files|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(414, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Allow Hide";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkKeepExpNum
            // 
            this.chkKeepExpNum.AutoSize = true;
            this.chkKeepExpNum.Location = new System.Drawing.Point(625, 55);
            this.chkKeepExpNum.Name = "chkKeepExpNum";
            this.chkKeepExpNum.Size = new System.Drawing.Size(145, 17);
            this.chkKeepExpNum.TabIndex = 23;
            this.chkKeepExpNum.Text = "Exposure Number In Title";
            this.chkKeepExpNum.UseVisualStyleBackColor = true;
            this.chkKeepExpNum.CheckedChanged += new System.EventHandler(this.chkKeepExpNum_CheckedChanged);
            // 
            // chkDetDes
            // 
            this.chkDetDes.AutoSize = true;
            this.chkDetDes.Checked = true;
            this.chkDetDes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetDes.Location = new System.Drawing.Point(625, 9);
            this.chkDetDes.Name = "chkDetDes";
            this.chkDetDes.Size = new System.Drawing.Size(148, 17);
            this.chkDetDes.TabIndex = 24;
            this.chkDetDes.Text = "Add Details to Description";
            this.chkDetDes.UseVisualStyleBackColor = true;
            // 
            // chkRnEn
            // 
            this.chkRnEn.AutoSize = true;
            this.chkRnEn.Checked = true;
            this.chkRnEn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRnEn.Location = new System.Drawing.Point(270, 64);
            this.chkRnEn.Name = "chkRnEn";
            this.chkRnEn.Size = new System.Drawing.Size(78, 17);
            this.chkRnEn.TabIndex = 25;
            this.chkRnEn.Text = "R#_E#.jpg";
            this.chkRnEn.UseVisualStyleBackColor = true;
            this.chkRnEn.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "or";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // chkPhotogDesc
            // 
            this.chkPhotogDesc.AutoSize = true;
            this.chkPhotogDesc.Checked = true;
            this.chkPhotogDesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhotogDesc.Location = new System.Drawing.Point(625, 32);
            this.chkPhotogDesc.Name = "chkPhotogDesc";
            this.chkPhotogDesc.Size = new System.Drawing.Size(127, 17);
            this.chkPhotogDesc.TabIndex = 27;
            this.chkPhotogDesc.Text = "Photog in Description";
            this.chkPhotogDesc.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 342);
            this.Controls.Add(this.chkPhotogDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkRnEn);
            this.Controls.Add(this.chkDetDes);
            this.Controls.Add(this.chkKeepExpNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtfromdir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboFileSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.chkWriteContact);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkCopyright);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 402);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map ExIf to Image Files";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkCopyright;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.CheckBox chkWriteContact;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFileSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfromdir;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem skipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkKeepExpNum;
        private System.Windows.Forms.CheckBox chkDetDes;
        private System.Windows.Forms.CheckBox chkRnEn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPhotogDesc;
    }
}
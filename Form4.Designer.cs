namespace ExIF35
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClock = new System.Windows.Forms.Button();
            this.btnCounter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTags = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfromdir = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.skipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClock);
            this.splitContainer1.Panel1.Controls.Add(this.btnCounter);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.btnTags);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtfromdir);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(1085, 471);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClock
            // 
            this.btnClock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClock.Image = global::ExIF35.Properties.Resources._1347827387_Clockwise_arrow;
            this.btnClock.Location = new System.Drawing.Point(335, 418);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(77, 41);
            this.btnClock.TabIndex = 2;
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // btnCounter
            // 
            this.btnCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounter.Image = global::ExIF35.Properties.Resources._1347827283_Counterclockwise_arrow;
            this.btnCounter.Location = new System.Drawing.Point(12, 418);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(77, 41);
            this.btnCounter.TabIndex = 1;
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnTags
            // 
            this.btnTags.Location = new System.Drawing.Point(518, 440);
            this.btnTags.Name = "btnTags";
            this.btnTags.Size = new System.Drawing.Size(65, 22);
            this.btnTags.TabIndex = 23;
            this.btnTags.Text = "Tags";
            this.btnTags.UseVisualStyleBackColor = true;
            this.btnTags.Click += new System.EventHandler(this.btnTags_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(508, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Select Directory";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "or drop files below";
            // 
            // txtfromdir
            // 
            this.txtfromdir.Location = new System.Drawing.Point(126, 9);
            this.txtfromdir.Name = "txtfromdir";
            this.txtfromdir.ReadOnly = true;
            this.txtfromdir.Size = new System.Drawing.Size(251, 20);
            this.txtfromdir.TabIndex = 20;
            this.txtfromdir.Visible = false;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(33, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(550, 400);
            this.listView1.TabIndex = 2;
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
            this.columnHeader2.Width = 342;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rotation";
            this.columnHeader3.Width = 53;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skipToolStripMenuItem,
            this.setFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Get Images From:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JPEG Images|*.jpg|JPEG Images|*.jpeg|All Files|*.*";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 471);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Mate & Rotate Files";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClock;
        private System.Windows.Forms.Button btnCounter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtfromdir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem skipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnTags;
    }
}
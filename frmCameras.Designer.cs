namespace ExIF35
{
    partial class frmCameras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCameras));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCameras = new System.Windows.Forms.DataGridView();
            this.cameraName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cameraMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cameraModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cameraSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameras)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 38);
            this.panel1.TabIndex = 0;
            // 
            // dgvCameras
            // 
            this.dgvCameras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCameras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCameras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cameraName,
            this.cameraMake,
            this.cameraModel,
            this.cameraSerial});
            this.dgvCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCameras.Location = new System.Drawing.Point(0, 0);
            this.dgvCameras.Name = "dgvCameras";
            this.dgvCameras.Size = new System.Drawing.Size(481, 204);
            this.dgvCameras.TabIndex = 1;
            // 
            // cameraName
            // 
            this.cameraName.HeaderText = "Name";
            this.cameraName.Name = "cameraName";
            // 
            // cameraMake
            // 
            this.cameraMake.HeaderText = "Make";
            this.cameraMake.Name = "cameraMake";
            // 
            // cameraModel
            // 
            this.cameraModel.HeaderText = "Model";
            this.cameraModel.Name = "cameraModel";
            // 
            // cameraSerial
            // 
            this.cameraSerial.HeaderText = "Serial";
            this.cameraSerial.Name = "cameraSerial";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(481, 242);
            this.Controls.Add(this.dgvCameras);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCameras";
            this.Text = "Manage Cameras";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCameras_FormClosing);
            this.Load += new System.EventHandler(this.frmCameras_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCameras;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraSerial;
        private System.Windows.Forms.Button btnSave;

    }
}
namespace ExIF35
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
            this.Exposure = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.aperture = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.focalLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.drpLens = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.drpProgram = new System.Windows.Forms.ComboBox();
            this.drpOrient = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.drpFlash = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.drpMeter = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.drpLight = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEV = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.drpScene = new System.Windows.Forms.ComboBox();
            this.txtPhotog = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboSR = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimeDigitized = new System.Windows.Forms.MaskedTextBox();
            this.dateTime = new System.Windows.Forms.MaskedTextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkVR = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.drpFocusMode = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.drpExposureMode = new System.Windows.Forms.ComboBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exposure
            // 
            this.Exposure.Location = new System.Drawing.Point(24, 55);
            this.Exposure.Name = "Exposure";
            this.Exposure.Size = new System.Drawing.Size(40, 20);
            this.Exposure.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DateTime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "DateTime Digitized";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Aperture";
            // 
            // aperture
            // 
            this.aperture.AutoCompleteCustomSource.AddRange(new string[] {
            "1.2",
            "1.4",
            "1.8",
            "2",
            "2.2",
            "2.4",
            "2.8",
            "3",
            "3.2",
            "3.3",
            "3.5",
            "3.8",
            "4",
            "4.2",
            "4.5",
            "4.8",
            "5",
            "5.6",
            "6.7",
            "8",
            "9.5",
            "11",
            "13",
            "16",
            "19",
            "22"});
            this.aperture.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.aperture.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.aperture.Location = new System.Drawing.Point(78, 55);
            this.aperture.Name = "aperture";
            this.aperture.Size = new System.Drawing.Size(62, 20);
            this.aperture.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Exposure Time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Title";
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(24, 156);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(388, 20);
            this.title.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Description";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 201);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 69);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // speed
            // 
            this.speed.AutoCompleteCustomSource.AddRange(new string[] {
            "30",
            "25",
            "20",
            "15",
            "10",
            "8",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "1/2",
            "1/4",
            "1/6",
            "1/8",
            "1/10",
            "1/15",
            "1/30",
            "1/60",
            "1/90",
            "1/125",
            "1/180",
            "1/200",
            "1/250",
            "1/300",
            "1/350",
            "1/500",
            "1/640",
            "1/800",
            "1/1000",
            "1/2000",
            "1/4000"});
            this.speed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.speed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.speed.Location = new System.Drawing.Point(147, 56);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(70, 20);
            this.speed.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Photographer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Focal Length";
            // 
            // focalLength
            // 
            this.focalLength.AutoCompleteCustomSource.AddRange(new string[] {
            "18",
            "24",
            "28",
            "35",
            "40",
            "50",
            "60",
            "70",
            "105",
            "135",
            "200",
            "250",
            "300"});
            this.focalLength.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.focalLength.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.focalLength.Location = new System.Drawing.Point(225, 55);
            this.focalLength.Name = "focalLength";
            this.focalLength.Size = new System.Drawing.Size(82, 20);
            this.focalLength.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Lens";
            // 
            // drpLens
            // 
            this.drpLens.FormattingEnabled = true;
            this.drpLens.Location = new System.Drawing.Point(9, 231);
            this.drpLens.Name = "drpLens";
            this.drpLens.Size = new System.Drawing.Size(259, 21);
            this.drpLens.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Exposure Program";
            // 
            // drpProgram
            // 
            this.drpProgram.FormattingEnabled = true;
            this.drpProgram.Items.AddRange(new object[] {
            "Not defined",
            "Manual (M)",
            "Normal Program (P)",
            "Aperture Priority (A)",
            "Shutter Priority (S)",
            "Creative (DOF)",
            "Action (Sports)",
            "Portrait",
            "Landscape (∞)"});
            this.drpProgram.Location = new System.Drawing.Point(6, 30);
            this.drpProgram.Name = "drpProgram";
            this.drpProgram.Size = new System.Drawing.Size(262, 21);
            this.drpProgram.TabIndex = 10;
            // 
            // drpOrient
            // 
            this.drpOrient.FormattingEnabled = true;
            this.drpOrient.Items.AddRange(new object[] {
            "0 (1)",
            "+90 (6)",
            "-90 (8)",
            "+180 (3)"});
            this.drpOrient.Location = new System.Drawing.Point(9, 193);
            this.drpOrient.Name = "drpOrient";
            this.drpOrient.Size = new System.Drawing.Size(115, 21);
            this.drpOrient.TabIndex = 15;
            this.drpOrient.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Orientation";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Flash";
            // 
            // drpFlash
            // 
            this.drpFlash.FormattingEnabled = true;
            this.drpFlash.Items.AddRange(new object[] {
            "Flash Did Not Fire",
            "Flash Fired"});
            this.drpFlash.Location = new System.Drawing.Point(147, 192);
            this.drpFlash.Name = "drpFlash";
            this.drpFlash.Size = new System.Drawing.Size(121, 21);
            this.drpFlash.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Metering Mode";
            // 
            // drpMeter
            // 
            this.drpMeter.FormattingEnabled = true;
            this.drpMeter.Items.AddRange(new object[] {
            "Unknown",
            "Average",
            "Center Weighted Average",
            "Spot",
            "Multi Spot",
            "Pattern",
            "Partial"});
            this.drpMeter.Location = new System.Drawing.Point(9, 114);
            this.drpMeter.Name = "drpMeter";
            this.drpMeter.Size = new System.Drawing.Size(262, 21);
            this.drpMeter.TabIndex = 13;
            this.drpMeter.SelectedIndexChanged += new System.EventHandler(this.drpMeter_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Light Source";
            // 
            // drpLight
            // 
            this.drpLight.FormattingEnabled = true;
            this.drpLight.Items.AddRange(new object[] {
            "Unknown",
            "Daylight",
            "Fluorescent",
            "Tungsten",
            "Flash",
            "Fine weather",
            "Cloudy weather",
            "Shade",
            "Daylight fluorescent (D 5700 – 7100K)",
            "Day white fluorescent (N 4600 – 5400K)",
            "Cool white fluorescent (W 3900 – 4500K)",
            "White fluorescent (WW 3200 – 3700K)",
            "Standard light A",
            "Standard light B",
            "Standard light C",
            "D55",
            "D65",
            "D75",
            "D50",
            "ISO studio tungsten",
            "Other"});
            this.drpLight.Location = new System.Drawing.Point(9, 153);
            this.drpLight.Name = "drpLight";
            this.drpLight.Size = new System.Drawing.Size(259, 21);
            this.drpLight.TabIndex = 14;
            this.drpLight.SelectedIndexChanged += new System.EventHandler(this.drpLight_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(668, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Enter values as precisely as possible, but use no units or other stray characters" +
    " (F/8 is entered as 8; 4 seconds is 4)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Exposure Bias (EV)";
            // 
            // txtEV
            // 
            this.txtEV.Location = new System.Drawing.Point(6, 72);
            this.txtEV.Name = "txtEV";
            this.txtEV.Size = new System.Drawing.Size(118, 20);
            this.txtEV.TabIndex = 11;
            this.txtEV.Text = "0.0";
            this.txtEV.TextChanged += new System.EventHandler(this.txtEV_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(144, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Scene Capture Type";
            // 
            // drpScene
            // 
            this.drpScene.FormattingEnabled = true;
            this.drpScene.Items.AddRange(new object[] {
            "Standard",
            "Landscape",
            "Portrait",
            "Night scene"});
            this.drpScene.Location = new System.Drawing.Point(147, 72);
            this.drpScene.Name = "drpScene";
            this.drpScene.Size = new System.Drawing.Size(121, 21);
            this.drpScene.TabIndex = 12;
            // 
            // txtPhotog
            // 
            this.txtPhotog.FormattingEnabled = true;
            this.txtPhotog.Location = new System.Drawing.Point(24, 299);
            this.txtPhotog.Name = "txtPhotog";
            this.txtPhotog.Size = new System.Drawing.Size(388, 21);
            this.txtPhotog.TabIndex = 9;
            this.txtPhotog.SelectedIndexChanged += new System.EventHandler(this.txtPhotog_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(314, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Subject Range";
            // 
            // cboSR
            // 
            this.cboSR.FormattingEnabled = true;
            this.cboSR.Items.AddRange(new object[] {
            "Unknown",
            "Macro",
            "Close",
            "Distant"});
            this.cboSR.Location = new System.Drawing.Point(317, 55);
            this.cboSR.Name = "cboSR";
            this.cboSR.Size = new System.Drawing.Size(95, 21);
            this.cboSR.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(622, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Tags";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimeDigitized
            // 
            this.dateTimeDigitized.Location = new System.Drawing.Point(225, 107);
            this.dateTimeDigitized.Mask = "0000:00:00 00:00:00";
            this.dateTimeDigitized.Name = "dateTimeDigitized";
            this.dateTimeDigitized.PromptChar = ' ';
            this.dateTimeDigitized.Size = new System.Drawing.Size(187, 20);
            this.dateTimeDigitized.TabIndex = 19;
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(24, 108);
            this.dateTime.Mask = "0000:00:00 00:00:00";
            this.dateTime.Name = "dateTime";
            this.dateTime.PromptChar = ' ';
            this.dateTime.Size = new System.Drawing.Size(193, 20);
            this.dateTime.TabIndex = 6;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTags.Location = new System.Drawing.Point(438, 330);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(104, 13);
            this.lblTags.TabIndex = 47;
            this.lblTags.Text = "Image has 0 tags";
            // 
            // txtFilter
            // 
            this.txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFilter.Location = new System.Drawing.Point(12, 273);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(256, 20);
            this.txtFilter.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 257);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "Filter/Aux Lens";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtAltitude);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtLongitude);
            this.panel1.Controls.Add(this.txtLatitude);
            this.panel1.Controls.Add(this.chkVR);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.drpFocusMode);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.drpExposureMode);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.drpLens);
            this.panel1.Controls.Add(this.drpProgram);
            this.panel1.Controls.Add(this.drpOrient);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.drpFlash);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.drpScene);
            this.panel1.Controls.Add(this.drpMeter);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtEV);
            this.panel1.Controls.Add(this.drpLight);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(418, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 295);
            this.panel1.TabIndex = 50;
            // 
            // chkVR
            // 
            this.chkVR.AutoSize = true;
            this.chkVR.Location = new System.Drawing.Point(224, 486);
            this.chkVR.Name = "chkVR";
            this.chkVR.Size = new System.Drawing.Size(41, 17);
            this.chkVR.TabIndex = 57;
            this.chkVR.Text = "VR";
            this.chkVR.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 391);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 56;
            this.label24.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(12, 407);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(253, 65);
            this.txtRemarks.TabIndex = 55;
            this.txtRemarks.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 347);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 54;
            this.label23.Text = "Focus Mode";
            // 
            // drpFocusMode
            // 
            this.drpFocusMode.FormattingEnabled = true;
            this.drpFocusMode.Items.AddRange(new object[] {
            "Unknown",
            "Single AF",
            "Continuous AF",
            "Auto AF",
            "Manual"});
            this.drpFocusMode.Location = new System.Drawing.Point(12, 363);
            this.drpFocusMode.Name = "drpFocusMode";
            this.drpFocusMode.Size = new System.Drawing.Size(253, 21);
            this.drpFocusMode.TabIndex = 53;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(118, 511);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(10, 13);
            this.label22.TabIndex = 52;
            this.label22.Text = ".";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 296);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 13);
            this.label21.TabIndex = 51;
            this.label21.Text = "Exposure/Release Mode";
            // 
            // drpExposureMode
            // 
            this.drpExposureMode.FormattingEnabled = true;
            this.drpExposureMode.Items.AddRange(new object[] {
            "Auto",
            "Manual",
            "Auto Bracket",
            "Continuous",
            "Self-timer",
            "IR Control",
            "Cable Release",
            "Unknown"});
            this.drpExposureMode.Location = new System.Drawing.Point(9, 315);
            this.drpExposureMode.Name = "drpExposureMode";
            this.drpExposureMode.Size = new System.Drawing.Size(259, 21);
            this.drpExposureMode.TabIndex = 50;
            this.drpExposureMode.Text = "Unknown";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(9, 527);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(259, 20);
            this.txtLatitude.TabIndex = 58;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(9, 566);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(259, 20);
            this.txtLongitude.TabIndex = 59;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 511);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 60;
            this.label25.Text = "Latitude";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 550);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 61;
            this.label26.Text = "Longitude";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 598);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 62;
            this.label27.Text = "Altitude";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(9, 615);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Size = new System.Drawing.Size(259, 20);
            this.txtAltitude.TabIndex = 63;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 354);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.dateTimeDigitized);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cboSR);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtPhotog);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.focalLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.aperture);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Exposure);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 393);
            this.MinimumSize = new System.Drawing.Size(727, 393);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Exposure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Exposure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox aperture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox focalLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox drpLens;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox drpProgram;
        private System.Windows.Forms.ComboBox drpOrient;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox drpFlash;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox drpMeter;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox drpLight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEV;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox drpScene;
        private System.Windows.Forms.ComboBox txtPhotog;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboSR;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox dateTimeDigitized;
        private System.Windows.Forms.MaskedTextBox dateTime;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox drpExposureMode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox drpFocusMode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RichTextBox txtRemarks;
        private System.Windows.Forms.CheckBox chkVR;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
    }
}


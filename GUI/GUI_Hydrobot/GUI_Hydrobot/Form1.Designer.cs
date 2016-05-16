namespace GUI_Hydrobot
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RemoveMarker_btn = new System.Windows.Forms.Button();
            this.CurrentMarker_Textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Port_Combobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenPort_btn = new System.Windows.Forms.Button();
            this.ClosePort_btn = new System.Windows.Forms.Button();
            this.Status_Label = new System.Windows.Forms.Label();
            this.General_Textbox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MotorA_Left_btn = new System.Windows.Forms.Button();
            this.MotorA_Right_btn = new System.Windows.Forms.Button();
            this.MotorA_groupBox = new System.Windows.Forms.GroupBox();
            this.MotorB_groupBox = new System.Windows.Forms.GroupBox();
            this.MotorB_Left_btn = new System.Windows.Forms.Button();
            this.MotorB_Right_btn = new System.Windows.Forms.Button();
            this.MotorA_Speed_TextBox = new System.Windows.Forms.TextBox();
            this.MotorB_Speed_TextBox = new System.Windows.Forms.TextBox();
            this.Stop_Motors_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.MotorA_groupBox.SuspendLayout();
            this.MotorB_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(712, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RemoveMarker_btn);
            this.tabPage2.Controls.Add(this.CurrentMarker_Textbox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.gmap);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(704, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RemoveMarker_btn
            // 
            this.RemoveMarker_btn.Location = new System.Drawing.Point(399, 350);
            this.RemoveMarker_btn.Name = "RemoveMarker_btn";
            this.RemoveMarker_btn.Size = new System.Drawing.Size(109, 23);
            this.RemoveMarker_btn.TabIndex = 3;
            this.RemoveMarker_btn.Text = "Remove Marker";
            this.RemoveMarker_btn.UseVisualStyleBackColor = true;
            this.RemoveMarker_btn.Click += new System.EventHandler(this.RemoveMarker_btn_Click);
            // 
            // CurrentMarker_Textbox
            // 
            this.CurrentMarker_Textbox.Location = new System.Drawing.Point(112, 352);
            this.CurrentMarker_Textbox.Name = "CurrentMarker_Textbox";
            this.CurrentMarker_Textbox.ReadOnly = true;
            this.CurrentMarker_Textbox.Size = new System.Drawing.Size(281, 20);
            this.CurrentMarker_Textbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Marker: ";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(23, 23);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 20;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(485, 325);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 5D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 416);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Graphs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Port_Combobox
            // 
            this.Port_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Port_Combobox.FormattingEnabled = true;
            this.Port_Combobox.Location = new System.Drawing.Point(16, 46);
            this.Port_Combobox.Name = "Port_Combobox";
            this.Port_Combobox.Size = new System.Drawing.Size(121, 21);
            this.Port_Combobox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Ports";
            // 
            // OpenPort_btn
            // 
            this.OpenPort_btn.Location = new System.Drawing.Point(153, 44);
            this.OpenPort_btn.Name = "OpenPort_btn";
            this.OpenPort_btn.Size = new System.Drawing.Size(75, 23);
            this.OpenPort_btn.TabIndex = 3;
            this.OpenPort_btn.Text = "Open Port";
            this.OpenPort_btn.UseVisualStyleBackColor = true;
            this.OpenPort_btn.Click += new System.EventHandler(this.OpenPort_btn_Click);
            // 
            // ClosePort_btn
            // 
            this.ClosePort_btn.Location = new System.Drawing.Point(234, 44);
            this.ClosePort_btn.Name = "ClosePort_btn";
            this.ClosePort_btn.Size = new System.Drawing.Size(75, 23);
            this.ClosePort_btn.TabIndex = 4;
            this.ClosePort_btn.Text = "Close Port";
            this.ClosePort_btn.UseVisualStyleBackColor = true;
            this.ClosePort_btn.Click += new System.EventHandler(this.ClosePort_btn_Click);
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(150, 27);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(65, 13);
            this.Status_Label.TabIndex = 5;
            this.Status_Label.Text = "Port Status: ";
            // 
            // General_Textbox
            // 
            this.General_Textbox.Location = new System.Drawing.Point(332, 12);
            this.General_Textbox.Multiline = true;
            this.General_Textbox.Name = "General_Textbox";
            this.General_Textbox.Size = new System.Drawing.Size(260, 82);
            this.General_Textbox.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Stop_Motors_btn);
            this.tabPage3.Controls.Add(this.MotorB_groupBox);
            this.tabPage3.Controls.Add(this.MotorA_groupBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(704, 416);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Motor Control";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MotorA_Left_btn
            // 
            this.MotorA_Left_btn.Location = new System.Drawing.Point(6, 19);
            this.MotorA_Left_btn.Name = "MotorA_Left_btn";
            this.MotorA_Left_btn.Size = new System.Drawing.Size(51, 50);
            this.MotorA_Left_btn.TabIndex = 0;
            this.MotorA_Left_btn.Text = "Left";
            this.MotorA_Left_btn.UseVisualStyleBackColor = true;
            this.MotorA_Left_btn.Click += new System.EventHandler(this.MotorA_Left_btn_Click);
            // 
            // MotorA_Right_btn
            // 
            this.MotorA_Right_btn.Location = new System.Drawing.Point(63, 19);
            this.MotorA_Right_btn.Name = "MotorA_Right_btn";
            this.MotorA_Right_btn.Size = new System.Drawing.Size(51, 50);
            this.MotorA_Right_btn.TabIndex = 1;
            this.MotorA_Right_btn.Text = "Right";
            this.MotorA_Right_btn.UseVisualStyleBackColor = true;
            this.MotorA_Right_btn.Click += new System.EventHandler(this.MotorA_Right_btn_Click);
            // 
            // MotorA_groupBox
            // 
            this.MotorA_groupBox.Controls.Add(this.label3);
            this.MotorA_groupBox.Controls.Add(this.MotorA_Speed_TextBox);
            this.MotorA_groupBox.Controls.Add(this.MotorA_Left_btn);
            this.MotorA_groupBox.Controls.Add(this.MotorA_Right_btn);
            this.MotorA_groupBox.Location = new System.Drawing.Point(21, 18);
            this.MotorA_groupBox.Name = "MotorA_groupBox";
            this.MotorA_groupBox.Size = new System.Drawing.Size(123, 101);
            this.MotorA_groupBox.TabIndex = 3;
            this.MotorA_groupBox.TabStop = false;
            this.MotorA_groupBox.Text = "Motor A";
            // 
            // MotorB_groupBox
            // 
            this.MotorB_groupBox.Controls.Add(this.label4);
            this.MotorB_groupBox.Controls.Add(this.MotorB_Speed_TextBox);
            this.MotorB_groupBox.Controls.Add(this.MotorB_Right_btn);
            this.MotorB_groupBox.Controls.Add(this.MotorB_Left_btn);
            this.MotorB_groupBox.Location = new System.Drawing.Point(150, 18);
            this.MotorB_groupBox.Name = "MotorB_groupBox";
            this.MotorB_groupBox.Size = new System.Drawing.Size(122, 101);
            this.MotorB_groupBox.TabIndex = 4;
            this.MotorB_groupBox.TabStop = false;
            this.MotorB_groupBox.Text = "Motor B";
            // 
            // MotorB_Left_btn
            // 
            this.MotorB_Left_btn.Location = new System.Drawing.Point(6, 19);
            this.MotorB_Left_btn.Name = "MotorB_Left_btn";
            this.MotorB_Left_btn.Size = new System.Drawing.Size(51, 50);
            this.MotorB_Left_btn.TabIndex = 2;
            this.MotorB_Left_btn.Text = "Left";
            this.MotorB_Left_btn.UseVisualStyleBackColor = true;
            // 
            // MotorB_Right_btn
            // 
            this.MotorB_Right_btn.Location = new System.Drawing.Point(63, 19);
            this.MotorB_Right_btn.Name = "MotorB_Right_btn";
            this.MotorB_Right_btn.Size = new System.Drawing.Size(51, 50);
            this.MotorB_Right_btn.TabIndex = 2;
            this.MotorB_Right_btn.Text = "Right";
            this.MotorB_Right_btn.UseVisualStyleBackColor = true;
            this.MotorB_Right_btn.Click += new System.EventHandler(this.MotorB_Right_btn_Click);
            // 
            // MotorA_Speed_TextBox
            // 
            this.MotorA_Speed_TextBox.Location = new System.Drawing.Point(43, 71);
            this.MotorA_Speed_TextBox.Name = "MotorA_Speed_TextBox";
            this.MotorA_Speed_TextBox.Size = new System.Drawing.Size(71, 20);
            this.MotorA_Speed_TextBox.TabIndex = 2;
            this.MotorA_Speed_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MotorB_Speed_TextBox
            // 
            this.MotorB_Speed_TextBox.Location = new System.Drawing.Point(43, 71);
            this.MotorB_Speed_TextBox.Name = "MotorB_Speed_TextBox";
            this.MotorB_Speed_TextBox.Size = new System.Drawing.Size(71, 20);
            this.MotorB_Speed_TextBox.TabIndex = 3;
            this.MotorB_Speed_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Stop_Motors_btn
            // 
            this.Stop_Motors_btn.Location = new System.Drawing.Point(51, 125);
            this.Stop_Motors_btn.Name = "Stop_Motors_btn";
            this.Stop_Motors_btn.Size = new System.Drawing.Size(48, 42);
            this.Stop_Motors_btn.TabIndex = 5;
            this.Stop_Motors_btn.Text = "Stop";
            this.Stop_Motors_btn.UseVisualStyleBackColor = true;
            this.Stop_Motors_btn.Click += new System.EventHandler(this.Stop_Motors_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Speed: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Speed: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 532);
            this.Controls.Add(this.General_Textbox);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.ClosePort_btn);
            this.Controls.Add(this.OpenPort_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port_Combobox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "USV Monitor and Control";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.MotorA_groupBox.ResumeLayout(false);
            this.MotorA_groupBox.PerformLayout();
            this.MotorB_groupBox.ResumeLayout(false);
            this.MotorB_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox Port_Combobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenPort_btn;
        private System.Windows.Forms.Button ClosePort_btn;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Button RemoveMarker_btn;
        private System.Windows.Forms.TextBox CurrentMarker_Textbox;
        private System.Windows.Forms.Label label2;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox General_Textbox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button MotorA_Right_btn;
        private System.Windows.Forms.Button MotorA_Left_btn;
        private System.Windows.Forms.GroupBox MotorA_groupBox;
        private System.Windows.Forms.GroupBox MotorB_groupBox;
        private System.Windows.Forms.Button MotorB_Right_btn;
        private System.Windows.Forms.Button MotorB_Left_btn;
        private System.Windows.Forms.TextBox MotorB_Speed_TextBox;
        private System.Windows.Forms.TextBox MotorA_Speed_TextBox;
        private System.Windows.Forms.Button Stop_Motors_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}


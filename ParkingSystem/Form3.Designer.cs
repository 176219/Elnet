namespace ParkingSystem
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSlot = new System.Windows.Forms.Button();
            this.btnParking = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exttimelbl = new System.Windows.Forms.Label();
            this.entrytimelbl = new System.Windows.Forms.Label();
            this.slotlbl = new System.Windows.Forms.Label();
            this.typelbl = new System.Windows.Forms.Label();
            this.platelbl = new System.Windows.Forms.Label();
            this.prklbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.prcsBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtbSearchPlate = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtbSearchVehicle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvVehicleLog = new System.Windows.Forms.DataGridView();
            this.btnNewEntry = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BackgroundImage = global::ParkingSystem.Properties.Resources._66;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnSlot);
            this.panel2.Controls.Add(this.btnParking);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 633);
            this.panel2.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogout.Location = new System.Drawing.Point(12, 468);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(222, 69);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "⏻ Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReport.Location = new System.Drawing.Point(3, 300);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(231, 45);
            this.btnReport.TabIndex = 19;
            this.btnReport.Text = "📄 Reports";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSlot
            // 
            this.btnSlot.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSlot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSlot.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSlot.Location = new System.Drawing.Point(3, 235);
            this.btnSlot.Name = "btnSlot";
            this.btnSlot.Size = new System.Drawing.Size(233, 45);
            this.btnSlot.TabIndex = 18;
            this.btnSlot.Text = "🎰 Slot";
            this.btnSlot.UseVisualStyleBackColor = false;
            this.btnSlot.Click += new System.EventHandler(this.btnSlot_Click);
            // 
            // btnParking
            // 
            this.btnParking.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnParking.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnParking.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnParking.Location = new System.Drawing.Point(3, 163);
            this.btnParking.Name = "btnParking";
            this.btnParking.Size = new System.Drawing.Size(231, 45);
            this.btnParking.TabIndex = 17;
            this.btnParking.Text = "🅿 Parking";
            this.btnParking.UseVisualStyleBackColor = false;
            this.btnParking.Click += new System.EventHandler(this.btnParking_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDashboard.Location = new System.Drawing.Point(3, 96);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(231, 45);
            this.btnDashboard.TabIndex = 16;
            this.btnDashboard.Text = "🏠︎ Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "ParkSmart";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(298, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 34);
            this.label9.TabIndex = 12;
            this.label9.Text = "Parking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(298, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Vehicle Status, Entry, And Exit";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BackgroundImage = global::ParkingSystem.Properties.Resources.Yumurta_yla_Tasarım_Dersleri;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.exttimelbl);
            this.panel3.Controls.Add(this.entrytimelbl);
            this.panel3.Controls.Add(this.slotlbl);
            this.panel3.Controls.Add(this.typelbl);
            this.panel3.Controls.Add(this.platelbl);
            this.panel3.Controls.Add(this.prklbl);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.prcsBtn);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtbSearchPlate);
            this.panel3.Location = new System.Drawing.Point(978, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 456);
            this.panel3.TabIndex = 15;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // exttimelbl
            // 
            this.exttimelbl.Location = new System.Drawing.Point(93, 307);
            this.exttimelbl.Name = "exttimelbl";
            this.exttimelbl.Size = new System.Drawing.Size(98, 18);
            this.exttimelbl.TabIndex = 37;
            this.exttimelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exttimelbl.Click += new System.EventHandler(this.exttimelbl_Click);
            // 
            // entrytimelbl
            // 
            this.entrytimelbl.Location = new System.Drawing.Point(93, 270);
            this.entrytimelbl.Name = "entrytimelbl";
            this.entrytimelbl.Size = new System.Drawing.Size(98, 18);
            this.entrytimelbl.TabIndex = 36;
            this.entrytimelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.entrytimelbl.Click += new System.EventHandler(this.entrytimelbl_Click);
            // 
            // slotlbl
            // 
            this.slotlbl.Location = new System.Drawing.Point(93, 234);
            this.slotlbl.Name = "slotlbl";
            this.slotlbl.Size = new System.Drawing.Size(98, 18);
            this.slotlbl.TabIndex = 35;
            this.slotlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.slotlbl.Click += new System.EventHandler(this.slotlbl_Click);
            // 
            // typelbl
            // 
            this.typelbl.Location = new System.Drawing.Point(93, 199);
            this.typelbl.Name = "typelbl";
            this.typelbl.Size = new System.Drawing.Size(98, 18);
            this.typelbl.TabIndex = 34;
            this.typelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.typelbl.Click += new System.EventHandler(this.typelbl_Click);
            // 
            // platelbl
            // 
            this.platelbl.Location = new System.Drawing.Point(93, 163);
            this.platelbl.Name = "platelbl";
            this.platelbl.Size = new System.Drawing.Size(98, 18);
            this.platelbl.TabIndex = 33;
            this.platelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platelbl.Click += new System.EventHandler(this.platelbl_Click);
            // 
            // prklbl
            // 
            this.prklbl.Location = new System.Drawing.Point(93, 128);
            this.prklbl.Name = "prklbl";
            this.prklbl.Size = new System.Drawing.Size(98, 18);
            this.prklbl.TabIndex = 32;
            this.prklbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.prklbl.Click += new System.EventHandler(this.prklbl_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(36, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 31;
            this.label7.Text = "Exit";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(36, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Entry";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(36, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "Slot";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(36, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(36, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Plate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(179, 236);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // prcsBtn
            // 
            this.prcsBtn.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.prcsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prcsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.prcsBtn.Location = new System.Drawing.Point(24, 385);
            this.prcsBtn.Name = "prcsBtn";
            this.prcsBtn.Size = new System.Drawing.Size(179, 30);
            this.prcsBtn.TabIndex = 23;
            this.prcsBtn.Text = "Process Exit";
            this.prcsBtn.UseVisualStyleBackColor = false;
            this.prcsBtn.Click += new System.EventHandler(this.prcsBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(24, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Search plate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Exit Processing";
            // 
            // txtbSearchPlate
            // 
            this.txtbSearchPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbSearchPlate.Location = new System.Drawing.Point(24, 63);
            this.txtbSearchPlate.Name = "txtbSearchPlate";
            this.txtbSearchPlate.Size = new System.Drawing.Size(179, 24);
            this.txtbSearchPlate.TabIndex = 24;
            this.txtbSearchPlate.TextChanged += new System.EventHandler(this.txtbSearchPlate_TextChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.BackgroundImage = global::ParkingSystem.Properties.Resources.Yumurta_yla_Tasarım_Dersleri;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.txtbSearchVehicle);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.dgvVehicleLog);
            this.panel5.Location = new System.Drawing.Point(272, 114);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(669, 456);
            this.panel5.TabIndex = 16;
            // 
            // txtbSearchVehicle
            // 
            this.txtbSearchVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbSearchVehicle.Location = new System.Drawing.Point(16, 36);
            this.txtbSearchVehicle.Name = "txtbSearchVehicle";
            this.txtbSearchVehicle.Size = new System.Drawing.Size(266, 24);
            this.txtbSearchVehicle.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(16, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 18);
            this.label12.TabIndex = 16;
            this.label12.Text = "Vehicle log";
            // 
            // dgvVehicleLog
            // 
            this.dgvVehicleLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleLog.Location = new System.Drawing.Point(11, 66);
            this.dgvVehicleLog.Name = "dgvVehicleLog";
            this.dgvVehicleLog.Size = new System.Drawing.Size(642, 376);
            this.dgvVehicleLog.TabIndex = 0;
            this.dgvVehicleLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleLog_CellContentClick);
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnNewEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewEntry.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEntry.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNewEntry.Location = new System.Drawing.Point(1079, 56);
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(102, 32);
            this.btnNewEntry.TabIndex = 24;
            this.btnNewEntry.Text = "➕ New Entry";
            this.btnNewEntry.UseVisualStyleBackColor = false;
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::ParkingSystem.Properties.Resources.Yumurta_yla_Tasarım_Dersleri;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1239, 633);
            this.Controls.Add(this.btnNewEntry);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Form";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button prcsBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtbSearchPlate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtbSearchVehicle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvVehicleLog;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSlot;
        private System.Windows.Forms.Button btnParking;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label exttimelbl;
        private System.Windows.Forms.Label entrytimelbl;
        private System.Windows.Forms.Label slotlbl;
        private System.Windows.Forms.Label typelbl;
        private System.Windows.Forms.Label platelbl;
        private System.Windows.Forms.Label prklbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNewEntry;
    }
}
namespace ParkingSystem
{
    partial class Receipt
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
            this.pbReceipt = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFromTime = new System.Windows.Forms.Label();
            this.lblToTime = new System.Windows.Forms.Label();
            this.lblPlateNumber = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbReceipt
            // 
            this.pbReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbReceipt.Location = new System.Drawing.Point(31, 18);
            this.pbReceipt.Name = "pbReceipt";
            this.pbReceipt.Size = new System.Drawing.Size(273, 449);
            this.pbReceipt.TabIndex = 1;
            this.pbReceipt.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ParkingSystem.Properties.Resources.Untitled_Project__1_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblFromTime);
            this.panel1.Controls.Add(this.lblToTime);
            this.panel1.Controls.Add(this.lblPlateNumber);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Location = new System.Drawing.Point(30, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 451);
            this.panel1.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(104, 140);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(77, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "12 / 24 / 2016";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblFromTime
            // 
            this.lblFromTime.AutoSize = true;
            this.lblFromTime.Location = new System.Drawing.Point(89, 178);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.Size = new System.Drawing.Size(47, 13);
            this.lblFromTime.TabIndex = 4;
            this.lblFromTime.Text = "7:40 AM";
            this.lblFromTime.Click += new System.EventHandler(this.lblFromTime_Click);
            // 
            // lblToTime
            // 
            this.lblToTime.AutoSize = true;
            this.lblToTime.Location = new System.Drawing.Point(166, 227);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.Size = new System.Drawing.Size(53, 13);
            this.lblToTime.TabIndex = 3;
            this.lblToTime.Text = "10:30 AM";
            this.lblToTime.Click += new System.EventHandler(this.lblToTime_Click);
            // 
            // lblPlateNumber
            // 
            this.lblPlateNumber.AutoSize = true;
            this.lblPlateNumber.Location = new System.Drawing.Point(104, 203);
            this.lblPlateNumber.Name = "lblPlateNumber";
            this.lblPlateNumber.Size = new System.Drawing.Size(67, 13);
            this.lblPlateNumber.TabIndex = 2;
            this.lblPlateNumber.Text = "ABC 123456";
            this.lblPlateNumber.Click += new System.EventHandler(this.lblPlateNumber_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(110, 278);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(71, 33);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "9.00";
            this.lblAmount.Click += new System.EventHandler(this.lblAmount_Click);
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 484);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbReceipt);
            this.Name = "Receipt";
            this.Text = "Receipt";
            ((System.ComponentModel.ISupportInitialize)(this.pbReceipt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbReceipt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFromTime;
        private System.Windows.Forms.Label lblToTime;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Label lblAmount;
    }
}
namespace ParkingSystem
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
            this.rmbrBox = new System.Windows.Forms.CheckBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtboxEmailAdd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rmbrBox
            // 
            this.rmbrBox.AutoSize = true;
            this.rmbrBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rmbrBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rmbrBox.Location = new System.Drawing.Point(476, 328);
            this.rmbrBox.Name = "rmbrBox";
            this.rmbrBox.Size = new System.Drawing.Size(29, 20);
            this.rmbrBox.TabIndex = 20;
            this.rmbrBox.Text = " ";
            this.rmbrBox.UseVisualStyleBackColor = false;
            this.rmbrBox.CheckedChanged += new System.EventHandler(this.rmbrBox_CheckedChanged);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(486, 372);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(266, 31);
            this.btnSignIn.TabIndex = 19;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.Location = new System.Drawing.Point(498, 293);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(266, 29);
            this.txtBoxPassword.TabIndex = 18;
            this.txtBoxPassword.TextChanged += new System.EventHandler(this.txtBoxPassword_TextChanged);
            // 
            // txtboxEmailAdd
            // 
            this.txtboxEmailAdd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtboxEmailAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxEmailAdd.Location = new System.Drawing.Point(498, 226);
            this.txtboxEmailAdd.Name = "txtboxEmailAdd";
            this.txtboxEmailAdd.Size = new System.Drawing.Size(266, 29);
            this.txtboxEmailAdd.TabIndex = 16;
            this.txtboxEmailAdd.TextChanged += new System.EventHandler(this.txtboxEmailAdd_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::ParkingSystem.Properties.Resources.Gemini_Generated_Image_pjoef4pjoef4pjoe;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 519);
            this.Controls.Add(this.rmbrBox);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtboxEmailAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox rmbrBox;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtboxEmailAdd;
    }
}


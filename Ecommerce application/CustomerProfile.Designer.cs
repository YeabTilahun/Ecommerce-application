
namespace Ecommerce_application
{
    partial class CustomerProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerProfile));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonChangePicture = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtCustEmail = new System.Windows.Forms.TextBox();
            this.txtCustUserName = new System.Windows.Forms.TextBox();
            this.txtCustLastName = new System.Windows.Forms.TextBox();
            this.txtCustFirstName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonChangePicture);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Controls.Add(this.pictureBoxProfile);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCustPhoneNumber);
            this.panel1.Controls.Add(this.txtCustEmail);
            this.panel1.Controls.Add(this.txtCustUserName);
            this.panel1.Controls.Add(this.txtCustLastName);
            this.panel1.Controls.Add(this.txtCustFirstName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 619);
            this.panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(359, 594);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(93, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_49;
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(714, 584);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonChangePicture
            // 
            this.buttonChangePicture.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_49;
            this.buttonChangePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChangePicture.FlatAppearance.BorderSize = 0;
            this.buttonChangePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePicture.ForeColor = System.Drawing.Color.White;
            this.buttonChangePicture.Location = new System.Drawing.Point(262, 181);
            this.buttonChangePicture.Name = "buttonChangePicture";
            this.buttonChangePicture.Size = new System.Drawing.Size(100, 23);
            this.buttonChangePicture.TabIndex = 3;
            this.buttonChangePicture.Text = "Change Picture";
            this.buttonChangePicture.UseVisualStyleBackColor = true;
            this.buttonChangePicture.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_49;
            this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(12, 584);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(233, 201);
            this.pictureBoxProfile.TabIndex = 2;
            this.pictureBoxProfile.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            // 
            // txtCustPhoneNumber
            // 
            this.txtCustPhoneNumber.Location = new System.Drawing.Point(414, 473);
            this.txtCustPhoneNumber.Name = "txtCustPhoneNumber";
            this.txtCustPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtCustPhoneNumber.TabIndex = 0;
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.Location = new System.Drawing.Point(414, 417);
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(100, 20);
            this.txtCustEmail.TabIndex = 0;
            // 
            // txtCustUserName
            // 
            this.txtCustUserName.Location = new System.Drawing.Point(414, 366);
            this.txtCustUserName.Name = "txtCustUserName";
            this.txtCustUserName.Size = new System.Drawing.Size(100, 20);
            this.txtCustUserName.TabIndex = 0;
            // 
            // txtCustLastName
            // 
            this.txtCustLastName.Location = new System.Drawing.Point(414, 312);
            this.txtCustLastName.Name = "txtCustLastName";
            this.txtCustLastName.Size = new System.Drawing.Size(100, 20);
            this.txtCustLastName.TabIndex = 0;
            // 
            // txtCustFirstName
            // 
            this.txtCustFirstName.Location = new System.Drawing.Point(414, 261);
            this.txtCustFirstName.Name = "txtCustFirstName";
            this.txtCustFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtCustFirstName.TabIndex = 0;
            // 
            // CustomerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 619);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerProfile";
            this.Text = "CustomerProfile";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonChangePicture;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        internal System.Windows.Forms.PictureBox pictureBoxProfile;
        internal System.Windows.Forms.TextBox txtCustPhoneNumber;
        internal System.Windows.Forms.TextBox txtCustEmail;
        internal System.Windows.Forms.TextBox txtCustUserName;
        internal System.Windows.Forms.TextBox txtCustLastName;
        internal System.Windows.Forms.TextBox txtCustFirstName;
    }
}
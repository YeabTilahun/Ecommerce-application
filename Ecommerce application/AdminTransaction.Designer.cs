
namespace Ecommerce_application
{
    partial class AdminTransaction
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
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnMerchants = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnAdmins = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.showPassBtn = new System.Windows.Forms.Button();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Location = new System.Drawing.Point(0, 51);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(160, 44);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnMerchants
            // 
            this.btnMerchants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(121)))), ((int)(((byte)(99)))));
            this.btnMerchants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMerchants.FlatAppearance.BorderSize = 0;
            this.btnMerchants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMerchants.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMerchants.Location = new System.Drawing.Point(0, 110);
            this.btnMerchants.Name = "btnMerchants";
            this.btnMerchants.Size = new System.Drawing.Size(160, 44);
            this.btnMerchants.TabIndex = 1;
            this.btnMerchants.Text = "Merchants";
            this.btnMerchants.UseVisualStyleBackColor = false;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(121)))), ((int)(((byte)(99)))));
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Location = new System.Drawing.Point(0, 170);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(160, 44);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.SystemColors.Control;
            this.btnTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Location = new System.Drawing.Point(0, 232);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(160, 44);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Location = new System.Drawing.Point(0, 513);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(160, 44);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register Admins";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnAdmins
            // 
            this.btnAdmins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmins.FlatAppearance.BorderSize = 0;
            this.btnAdmins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmins.Location = new System.Drawing.Point(0, 463);
            this.btnAdmins.Name = "btnAdmins";
            this.btnAdmins.Size = new System.Drawing.Size(160, 44);
            this.btnAdmins.TabIndex = 5;
            this.btnAdmins.Text = "Admins";
            this.btnAdmins.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(121)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.btnAdmins);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.btnTransactions);
            this.panel1.Controls.Add(this.btnCustomers);
            this.panel1.Controls.Add(this.btnMerchants);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Location = new System.Drawing.Point(-1, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 578);
            this.panel1.TabIndex = 31;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button4.BackgroundImage = global::Ecommerce_application.Properties.Resources.minimize;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.Location = new System.Drawing.Point(1046, -1);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 15;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // showPassBtn
            // 
            this.showPassBtn.BackColor = System.Drawing.Color.Brown;
            this.showPassBtn.BackgroundImage = global::Ecommerce_application.Properties.Resources.close_tab3;
            this.showPassBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.showPassBtn.FlatAppearance.BorderSize = 0;
            this.showPassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.showPassBtn.Location = new System.Drawing.Point(1075, 1);
            this.showPassBtn.Margin = new System.Windows.Forms.Padding(2);
            this.showPassBtn.Name = "showPassBtn";
            this.showPassBtn.Size = new System.Drawing.Size(25, 25);
            this.showPassBtn.TabIndex = 14;
            this.showPassBtn.UseVisualStyleBackColor = false;
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactions.Location = new System.Drawing.Point(540, 0);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(114, 22);
            this.lblTransactions.TabIndex = 16;
            this.lblTransactions.Text = "Transactions";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.lblTransactions);
            this.panel2.Controls.Add(this.showPassBtn);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1102, 24);
            this.panel2.TabIndex = 33;
            // 
            // AdminTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminTransaction";
            this.Text = "AdminTransaction";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnMerchants;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnAdmins;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button showPassBtn;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Panel panel2;
    }
}
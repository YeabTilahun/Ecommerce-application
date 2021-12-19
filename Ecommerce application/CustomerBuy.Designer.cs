
namespace Ecommerce_application
{
    partial class CustomerBuy
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
            this.panelCustomerBuy = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelCustomerBuy.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCustomerBuy
            // 
            this.panelCustomerBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCustomerBuy.BackColor = System.Drawing.Color.White;
            this.panelCustomerBuy.Controls.Add(this.button2);
            this.panelCustomerBuy.Controls.Add(this.button1);
            this.panelCustomerBuy.Location = new System.Drawing.Point(-1, 0);
            this.panelCustomerBuy.MinimumSize = new System.Drawing.Size(750, 500);
            this.panelCustomerBuy.Name = "panelCustomerBuy";
            this.panelCustomerBuy.Size = new System.Drawing.Size(812, 545);
            this.panelCustomerBuy.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Viner Hand ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Image = global::Ecommerce_application.Properties.Resources.icons8_hand_up_50;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(181, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 147);
            this.button1.TabIndex = 0;
            this.button1.Text = "To Buy A Single Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Viner Hand ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Image = global::Ecommerce_application.Properties.Resources.icons8_hand_up_50;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.Location = new System.Drawing.Point(475, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 147);
            this.button2.TabIndex = 0;
            this.button2.Text = "To Buy Multiple Items";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // CustomerBuy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(812, 545);
            this.Controls.Add(this.panelCustomerBuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerBuy";
            this.Text = " ";
            this.panelCustomerBuy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panelCustomerBuy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
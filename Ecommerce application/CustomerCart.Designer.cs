
namespace Ecommerce_application
{
    partial class CustomerCart
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
            this.panelCustomerCart = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCustomerCart
            // 
            this.panelCustomerCart.Location = new System.Drawing.Point(1, 3);
            this.panelCustomerCart.Name = "panelCustomerCart";
            this.panelCustomerCart.Size = new System.Drawing.Size(812, 545);
            this.panelCustomerCart.TabIndex = 0;
            // 
            // CustomerCart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(812, 545);
            this.Controls.Add(this.panelCustomerCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerCart";
            this.Text = "CustomerCart";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panelCustomerCart;
    }
}
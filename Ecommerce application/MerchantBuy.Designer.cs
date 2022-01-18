
namespace Ecommerce_application
{
    partial class MerchantBuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MerchantBuy));
            this.panelBuy = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // panelBuy
            // 
            this.panelBuy.AutoScroll = true;
            this.panelBuy.Location = new System.Drawing.Point(1, 1);
            this.panelBuy.Name = "panelBuy";
            this.panelBuy.Size = new System.Drawing.Size(933, 620);
            this.panelBuy.TabIndex = 0;
            this.panelBuy.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBuy_Paint_1);
            // 
            // MerchantBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 619);
            this.Controls.Add(this.panelBuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MerchantBuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ecommerce application";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel panelBuy;
    }
}
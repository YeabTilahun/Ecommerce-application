
namespace Ecommerce_application
{
    partial class Merchant
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.MinMer = new System.Windows.Forms.Button();
            this.CloseM = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.Controls.Add(this.MinMer);
            this.panel3.Controls.Add(this.CloseM);
            this.panel3.Location = new System.Drawing.Point(578, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 23);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(91)))));
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(50, 491);
            this.panel4.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "Sell";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "Buy";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 95);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 27);
            this.button5.TabIndex = 4;
            this.button5.Text = "Cart";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // MinMer
            // 
            this.MinMer.BackColor = System.Drawing.Color.Transparent;
            this.MinMer.BackgroundImage = global::Ecommerce_application.Properties.Resources.minimize;
            this.MinMer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinMer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinMer.ForeColor = System.Drawing.SystemColors.Control;
            this.MinMer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MinMer.Location = new System.Drawing.Point(8, -1);
            this.MinMer.Margin = new System.Windows.Forms.Padding(2);
            this.MinMer.Name = "MinMer";
            this.MinMer.Size = new System.Drawing.Size(25, 25);
            this.MinMer.TabIndex = 13;
            this.MinMer.UseVisualStyleBackColor = false;
            this.MinMer.Click += new System.EventHandler(this.MinMer_Click);
            // 
            // CloseM
            // 
            this.CloseM.BackColor = System.Drawing.Color.Transparent;
            this.CloseM.BackgroundImage = global::Ecommerce_application.Properties.Resources.close_tab3;
            this.CloseM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseM.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseM.Location = new System.Drawing.Point(46, 0);
            this.CloseM.Margin = new System.Windows.Forms.Padding(2);
            this.CloseM.Name = "CloseM";
            this.CloseM.Size = new System.Drawing.Size(25, 25);
            this.CloseM.TabIndex = 14;
            this.CloseM.UseVisualStyleBackColor = false;
            this.CloseM.Click += new System.EventHandler(this.CloseM_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(50, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 489);
            this.panel5.TabIndex = 2;
            // 
            // Merchant
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(651, 512);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Merchant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Merchant_Load);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button minMerchant;
        private System.Windows.Forms.Button closeMerchant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button CloseM;
        private System.Windows.Forms.Button MinMer;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel5;
    }
}
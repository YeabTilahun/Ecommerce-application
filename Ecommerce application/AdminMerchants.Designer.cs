
namespace Ecommerce_application
{
    partial class AdminMerchants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMerchants));
            this.pnlMerchant = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pnlValid = new System.Windows.Forms.Panel();
            this.pnlAll = new System.Windows.Forms.Panel();
            this.btnProgress = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvMerchants = new System.Windows.Forms.DataGridView();
            this.picBoxSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlMerchant.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMerchant
            // 
            this.pnlMerchant.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMerchant.Controls.Add(this.pnlProgress);
            this.pnlMerchant.Controls.Add(this.pnlValid);
            this.pnlMerchant.Controls.Add(this.pnlAll);
            this.pnlMerchant.Controls.Add(this.btnProgress);
            this.pnlMerchant.Controls.Add(this.btnAll);
            this.pnlMerchant.Controls.Add(this.btnValid);
            this.pnlMerchant.Controls.Add(this.panel1);
            this.pnlMerchant.Controls.Add(this.picBoxSearch);
            this.pnlMerchant.Controls.Add(this.txtSearch);
            this.pnlMerchant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMerchant.Location = new System.Drawing.Point(0, 0);
            this.pnlMerchant.Name = "pnlMerchant";
            this.pnlMerchant.Size = new System.Drawing.Size(940, 642);
            this.pnlMerchant.TabIndex = 18;
            this.pnlMerchant.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMerchant_Paint);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.pnlProgress.Location = new System.Drawing.Point(501, 72);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(84, 1);
            this.pnlProgress.TabIndex = 43;
            // 
            // pnlValid
            // 
            this.pnlValid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlValid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.pnlValid.Location = new System.Drawing.Point(344, 72);
            this.pnlValid.Name = "pnlValid";
            this.pnlValid.Size = new System.Drawing.Size(80, 1);
            this.pnlValid.TabIndex = 42;
            // 
            // pnlAll
            // 
            this.pnlAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            this.pnlAll.Location = new System.Drawing.Point(424, 72);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(77, 1);
            this.pnlAll.TabIndex = 42;
            // 
            // btnProgress
            // 
            this.btnProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProgress.FlatAppearance.BorderSize = 0;
            this.btnProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgress.Location = new System.Drawing.Point(501, 42);
            this.btnProgress.Name = "btnProgress";
            this.btnProgress.Size = new System.Drawing.Size(84, 32);
            this.btnProgress.TabIndex = 42;
            this.btnProgress.Text = "InProgress";
            this.btnProgress.UseVisualStyleBackColor = true;
            this.btnProgress.Click += new System.EventHandler(this.btnProgress_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(424, 42);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(84, 32);
            this.btnAll.TabIndex = 41;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnValid
            // 
            this.btnValid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnValid.FlatAppearance.BorderSize = 0;
            this.btnValid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValid.Location = new System.Drawing.Point(344, 42);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(84, 32);
            this.btnValid.TabIndex = 40;
            this.btnValid.Text = "Valid";
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 554);
            this.panel1.TabIndex = 39;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.dgvMerchants);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(916, 554);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgvMerchants
            // 
            this.dgvMerchants.AllowUserToAddRows = false;
            this.dgvMerchants.AllowUserToDeleteRows = false;
            this.dgvMerchants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMerchants.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvMerchants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMerchants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerchants.Location = new System.Drawing.Point(3, 3);
            this.dgvMerchants.Name = "dgvMerchants";
            this.dgvMerchants.ReadOnly = true;
            this.dgvMerchants.Size = new System.Drawing.Size(916, 0);
            this.dgvMerchants.TabIndex = 35;
            // 
            // picBoxSearch
            // 
            this.picBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxSearch.BackgroundImage")));
            this.picBoxSearch.Location = new System.Drawing.Point(910, 25);
            this.picBoxSearch.Name = "picBoxSearch";
            this.picBoxSearch.Size = new System.Drawing.Size(20, 20);
            this.picBoxSearch.TabIndex = 38;
            this.picBoxSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(724, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(177, 20);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.Tag = "";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // AdminMerchants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 642);
            this.Controls.Add(this.pnlMerchant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMerchants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMerchants";
            this.Load += new System.EventHandler(this.AdminMerchants_Load);
            this.pnlMerchant.ResumeLayout(false);
            this.pnlMerchant.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Panel pnlMerchant;
        public System.Windows.Forms.DataGridView dgvMerchants;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnValid;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Panel pnlAll;
        private System.Windows.Forms.Panel pnlValid;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
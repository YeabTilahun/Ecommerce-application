
namespace Ecommerce_application
{
    partial class AdminProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminProducts));
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.picBoxSearch = new System.Windows.Forms.PictureBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCatagories = new System.Windows.Forms.ComboBox();
            this.btnLatest = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProducts
            // 
            this.pnlProducts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlProducts.Controls.Add(this.panel1);
            this.pnlProducts.Controls.Add(this.btnAll);
            this.pnlProducts.Controls.Add(this.btnLatest);
            this.pnlProducts.Controls.Add(this.picBoxSearch);
            this.pnlProducts.Controls.Add(this.txtSearch);
            this.pnlProducts.Controls.Add(this.cmbCatagories);
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProducts.Location = new System.Drawing.Point(0, 0);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(937, 565);
            this.pnlProducts.TabIndex = 0;
            this.pnlProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProducts_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(915, 513);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // picBoxSearch
            // 
            this.picBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxSearch.BackgroundImage")));
            this.picBoxSearch.Location = new System.Drawing.Point(905, 13);
            this.picBoxSearch.Name = "picBoxSearch";
            this.picBoxSearch.Size = new System.Drawing.Size(20, 20);
            this.picBoxSearch.TabIndex = 36;
            this.picBoxSearch.TabStop = false;
            this.picBoxSearch.Click += new System.EventHandler(this.picBoxSearch_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProducts.Size = new System.Drawing.Size(913, 512);
            this.dgvProducts.TabIndex = 33;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // select
            // 
            this.select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.select.HeaderText = "";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select.Width = 30;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(722, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(177, 20);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // cmbCatagories
            // 
            this.cmbCatagories.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbCatagories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCatagories.ForeColor = System.Drawing.Color.Black;
            this.cmbCatagories.FormattingEnabled = true;
            this.cmbCatagories.Location = new System.Drawing.Point(12, 13);
            this.cmbCatagories.Name = "cmbCatagories";
            this.cmbCatagories.Size = new System.Drawing.Size(226, 21);
            this.cmbCatagories.TabIndex = 27;
            this.cmbCatagories.SelectedIndexChanged += new System.EventHandler(this.cmbCatagories_SelectedIndexChanged);
            // 
            // btnLatest
            // 
            this.btnLatest.FlatAppearance.BorderSize = 0;
            this.btnLatest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLatest.Location = new System.Drawing.Point(469, 6);
            this.btnLatest.Name = "btnLatest";
            this.btnLatest.Size = new System.Drawing.Size(84, 32);
            this.btnLatest.TabIndex = 38;
            this.btnLatest.Text = "Latest";
            this.btnLatest.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(388, 6);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(84, 32);
            this.btnAll.TabIndex = 39;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.dgvProducts);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 513);
            this.panel1.TabIndex = 40;
            // 
            // AdminProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(937, 565);
            this.Controls.Add(this.pnlProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.AdminProduct_Load);
            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Panel pnlProducts;
        public System.Windows.Forms.ComboBox cmbCatagories;
        public System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnLatest;
        private System.Windows.Forms.Panel panel1;
    }
}
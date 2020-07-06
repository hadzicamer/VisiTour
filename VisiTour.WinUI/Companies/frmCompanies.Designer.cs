namespace VisiTour.WinUI.Companies
{
    partial class frmCompanies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanies));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Headquarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnShowCompanies = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCompanies);
            this.groupBox1.Location = new System.Drawing.Point(0, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Companies";
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.AllowUserToAddRows = false;
            this.dgvCompanies.AllowUserToDeleteRows = false;
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyId,
            this.Name,
            this.Headquarter});
            this.dgvCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompanies.Location = new System.Drawing.Point(3, 18);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.ReadOnly = true;
            this.dgvCompanies.RowHeadersWidth = 51;
            this.dgvCompanies.RowTemplate.Height = 24;
            this.dgvCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanies.Size = new System.Drawing.Size(793, 266);
            this.dgvCompanies.TabIndex = 0;
            this.dgvCompanies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCompanies_MouseDoubleClick);
            // 
            // CompanyId
            // 
            this.CompanyId.DataPropertyName = "CompanyId";
            this.CompanyId.HeaderText = "CompanyId";
            this.CompanyId.MinimumWidth = 6;
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.ReadOnly = true;
            this.CompanyId.Visible = false;
            this.CompanyId.Width = 125;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 125;
            // 
            // Headquarter
            // 
            this.Headquarter.DataPropertyName = "Headquarter";
            this.Headquarter.HeaderText = "Headquarter";
            this.Headquarter.MinimumWidth = 6;
            this.Headquarter.Name = "Headquarter";
            this.Headquarter.ReadOnly = true;
            this.Headquarter.Width = 125;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(391, 22);
            this.txtName.TabIndex = 1;
            // 
            // btnShowCompanies
            // 
            this.btnShowCompanies.Location = new System.Drawing.Point(631, 59);
            this.btnShowCompanies.Name = "btnShowCompanies";
            this.btnShowCompanies.Size = new System.Drawing.Size(96, 27);
            this.btnShowCompanies.TabIndex = 2;
            this.btnShowCompanies.Text = "Show";
            this.btnShowCompanies.UseVisualStyleBackColor = true;
            this.btnShowCompanies.Click += new System.EventHandler(this.btnShowCompanies_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // frmCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowCompanies);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "frmCompanies";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnShowCompanies;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Headquarter;
        private System.Windows.Forms.Label label1;
    }
}
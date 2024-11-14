namespace SiparisYonetimSistemi
{
    partial class UserManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.overview_btn = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.user_m_btn = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.menu_m_btn = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.acc_btn = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.reports_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.sidebar.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1020, 533);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(891, 533);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 533);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FoodName,
            this.Description,
            this.Price,
            this.Ingredients,
            this.Date});
            this.dataGridView1.Location = new System.Drawing.Point(284, 106);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(859, 411);
            this.dataGridView1.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // FoodName
            // 
            this.FoodName.HeaderText = "Name";
            this.FoodName.MinimumWidth = 6;
            this.FoodName.Name = "FoodName";
            this.FoodName.Width = 125;
            // 
            // Description
            // 
            this.Description.HeaderText = "Email";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Password";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // Ingredients
            // 
            this.Ingredients.HeaderText = "Role";
            this.Ingredients.MinimumWidth = 6;
            this.Ingredients.Name = "Ingredients";
            this.Ingredients.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Last Login";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.Width = 125;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(933, 75);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 22);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "User Management";
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Controls.Add(this.panel10);
            this.sidebar.Controls.Add(this.panel11);
            this.sidebar.Controls.Add(this.panel12);
            this.sidebar.Controls.Add(this.panel13);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sidebar.MaximumSize = new System.Drawing.Size(248, 628);
            this.sidebar.MinimumSize = new System.Drawing.Size(40, 628);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(248, 628);
            this.sidebar.TabIndex = 17;
            // 
            // panel8
            // 
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(3, 2);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(245, 162);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.overview_btn);
            this.panel9.Location = new System.Drawing.Point(3, 168);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(245, 46);
            this.panel9.TabIndex = 0;
            // 
            // overview_btn
            // 
            this.overview_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.overview_btn.ForeColor = System.Drawing.Color.White;
            this.overview_btn.Location = new System.Drawing.Point(-3, -6);
            this.overview_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.overview_btn.Name = "overview_btn";
            this.overview_btn.Size = new System.Drawing.Size(255, 55);
            this.overview_btn.TabIndex = 4;
            this.overview_btn.Text = "          Overview";
            this.overview_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.overview_btn.UseVisualStyleBackColor = true;
            this.overview_btn.Click += new System.EventHandler(this.overview_btn_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.user_m_btn);
            this.panel10.Location = new System.Drawing.Point(3, 218);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(245, 46);
            this.panel10.TabIndex = 5;
            // 
            // user_m_btn
            // 
            this.user_m_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_m_btn.ForeColor = System.Drawing.Color.White;
            this.user_m_btn.Location = new System.Drawing.Point(-3, -6);
            this.user_m_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_m_btn.Name = "user_m_btn";
            this.user_m_btn.Size = new System.Drawing.Size(255, 55);
            this.user_m_btn.TabIndex = 4;
            this.user_m_btn.Text = "          User Management      ";
            this.user_m_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.user_m_btn.UseVisualStyleBackColor = true;
            this.user_m_btn.Click += new System.EventHandler(this.user_m_btn_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.menu_m_btn);
            this.panel11.Location = new System.Drawing.Point(3, 268);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(245, 46);
            this.panel11.TabIndex = 5;
            // 
            // menu_m_btn
            // 
            this.menu_m_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_m_btn.ForeColor = System.Drawing.Color.White;
            this.menu_m_btn.Location = new System.Drawing.Point(-3, -6);
            this.menu_m_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menu_m_btn.Name = "menu_m_btn";
            this.menu_m_btn.Size = new System.Drawing.Size(255, 55);
            this.menu_m_btn.TabIndex = 4;
            this.menu_m_btn.Text = "          Menu Management";
            this.menu_m_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_m_btn.UseVisualStyleBackColor = true;
            this.menu_m_btn.Click += new System.EventHandler(this.menu_m_btn_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.acc_btn);
            this.panel12.Location = new System.Drawing.Point(3, 318);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(245, 46);
            this.panel12.TabIndex = 5;
            // 
            // acc_btn
            // 
            this.acc_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acc_btn.ForeColor = System.Drawing.Color.White;
            this.acc_btn.Location = new System.Drawing.Point(-3, -6);
            this.acc_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.acc_btn.Name = "acc_btn";
            this.acc_btn.Size = new System.Drawing.Size(255, 55);
            this.acc_btn.TabIndex = 4;
            this.acc_btn.Text = "          Accountancy";
            this.acc_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.acc_btn.UseVisualStyleBackColor = true;
            this.acc_btn.Click += new System.EventHandler(this.acc_btn_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.reports_btn);
            this.panel13.Location = new System.Drawing.Point(3, 368);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(245, 46);
            this.panel13.TabIndex = 6;
            // 
            // reports_btn
            // 
            this.reports_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reports_btn.ForeColor = System.Drawing.Color.White;
            this.reports_btn.Location = new System.Drawing.Point(-3, -6);
            this.reports_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reports_btn.Name = "reports_btn";
            this.reports_btn.Size = new System.Drawing.Size(255, 55);
            this.reports_btn.TabIndex = 4;
            this.reports_btn.Text = "          Reports";
            this.reports_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reports_btn.UseVisualStyleBackColor = true;
            this.reports_btn.Click += new System.EventHandler(this.reports_btn_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserManagement";
            this.Text = "UserManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button overview_btn;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button user_m_btn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button menu_m_btn;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button acc_btn;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button reports_btn;
    }
}
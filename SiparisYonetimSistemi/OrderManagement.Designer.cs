namespace SiparisYonetimSistemi
{
    partial class OrderManagement
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
            this.sidebar1 = new SiparisYonetimSistemi.sidebar();
            this.dataGridView_OrderManagement = new System.Windows.Forms.DataGridView();
            this.orderManagementHeader = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebar1
            // 
            this.sidebar1.Location = new System.Drawing.Point(1, -1);
            this.sidebar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sidebar1.Name = "sidebar1";
            this.sidebar1.ParentFormRef = null;
            this.sidebar1.Size = new System.Drawing.Size(248, 628);
            this.sidebar1.TabIndex = 0;
            // 
            // dataGridView_OrderManagement
            // 
            this.dataGridView_OrderManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OrderManagement.Location = new System.Drawing.Point(285, 105);
            this.dataGridView_OrderManagement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_OrderManagement.Name = "dataGridView_OrderManagement";
            this.dataGridView_OrderManagement.RowHeadersWidth = 51;
            this.dataGridView_OrderManagement.Size = new System.Drawing.Size(1257, 431);
            this.dataGridView_OrderManagement.TabIndex = 1;
            // 
            // orderManagementHeader
            // 
            this.orderManagementHeader.AutoSize = true;
            this.orderManagementHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderManagementHeader.Location = new System.Drawing.Point(280, 63);
            this.orderManagementHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.orderManagementHeader.Name = "orderManagementHeader";
            this.orderManagementHeader.Size = new System.Drawing.Size(182, 25);
            this.orderManagementHeader.TabIndex = 2;
            this.orderManagementHeader.Text = "Order Management";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(1388, 543);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(155, 42);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh Table";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 628);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.orderManagementHeader);
            this.Controls.Add(this.dataGridView_OrderManagement);
            this.Controls.Add(this.sidebar1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OrderManagement";
            this.Text = "OrderManagement";
            this.Load += new System.EventHandler(this.OrderManagement_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sidebar sidebar1;
        private System.Windows.Forms.DataGridView dataGridView_OrderManagement;
        private System.Windows.Forms.Label orderManagementHeader;
        private System.Windows.Forms.Button refreshButton;
    }
}
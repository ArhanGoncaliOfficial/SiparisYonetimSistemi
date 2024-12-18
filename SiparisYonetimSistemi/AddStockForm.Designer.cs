namespace SiparisYonetimSistemi
{
    partial class AddStockForm
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
            this.Quantity = new System.Windows.Forms.Label();
            this.Material = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.MaterialComboBox = new System.Windows.Forms.ComboBox();
            this.SupplierComboBox = new System.Windows.Forms.ComboBox();
            this.TotalPriceLabel = new System.Windows.Forms.Label();
            this.AddStockButton = new System.Windows.Forms.Button();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(16, 98);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(46, 13);
            this.Quantity.TabIndex = 16;
            this.Quantity.Text = "Quantity";
            // 
            // Material
            // 
            this.Material.AutoSize = true;
            this.Material.Location = new System.Drawing.Point(16, 26);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(44, 13);
            this.Material.TabIndex = 14;
            this.Material.Text = "Material";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(16, 63);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(45, 13);
            this.Name.TabIndex = 15;
            this.Name.Text = "Supplier";
            // 
            // MaterialComboBox
            // 
            this.MaterialComboBox.FormattingEnabled = true;
            this.MaterialComboBox.Location = new System.Drawing.Point(105, 26);
            this.MaterialComboBox.Name = "MaterialComboBox";
            this.MaterialComboBox.Size = new System.Drawing.Size(144, 21);
            this.MaterialComboBox.TabIndex = 18;
            this.MaterialComboBox.SelectedIndexChanged += new System.EventHandler(this.MaterialComboBox_SelectedIndexChanged_1);
            // 
            // SupplierComboBox
            // 
            this.SupplierComboBox.FormattingEnabled = true;
            this.SupplierComboBox.Location = new System.Drawing.Point(105, 60);
            this.SupplierComboBox.Name = "SupplierComboBox";
            this.SupplierComboBox.Size = new System.Drawing.Size(144, 21);
            this.SupplierComboBox.TabIndex = 18;
            this.SupplierComboBox.SelectedIndexChanged += new System.EventHandler(this.SupplierComboBox_SelectedIndexChanged_1);
            // 
            // TotalPriceLabel
            // 
            this.TotalPriceLabel.AutoSize = true;
            this.TotalPriceLabel.Location = new System.Drawing.Point(16, 155);
            this.TotalPriceLabel.Name = "TotalPriceLabel";
            this.TotalPriceLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalPriceLabel.TabIndex = 20;
            this.TotalPriceLabel.Text = ".";
            // 
            // AddStockButton
            // 
            this.AddStockButton.Location = new System.Drawing.Point(94, 200);
            this.AddStockButton.Name = "AddStockButton";
            this.AddStockButton.Size = new System.Drawing.Size(75, 23);
            this.AddStockButton.TabIndex = 21;
            this.AddStockButton.Text = "Add";
            this.AddStockButton.UseVisualStyleBackColor = true;
            this.AddStockButton.Click += new System.EventHandler(this.AddStockButton_Click);
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(105, 96);
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(144, 20);
            this.QuantityNumericUpDown.TabIndex = 22;
            this.QuantityNumericUpDown.ValueChanged += new System.EventHandler(this.QuantityNumericUpDown_ValueChanged_1);
            // 
            // AddStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 249);
            this.Controls.Add(this.QuantityNumericUpDown);
            this.Controls.Add(this.AddStockButton);
            this.Controls.Add(this.TotalPriceLabel);
            this.Controls.Add(this.SupplierComboBox);
            this.Controls.Add(this.MaterialComboBox);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Material);
            this.Controls.Add(this.Name);
            this.Text = "AddStockForm";
            this.Text = "AddStockForm";
            this.Load += new System.EventHandler(this.AddStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label Material;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.ComboBox MaterialComboBox;
        private System.Windows.Forms.ComboBox SupplierComboBox;
        private System.Windows.Forms.Label TotalPriceLabel;
        private System.Windows.Forms.Button AddStockButton;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
    }
}
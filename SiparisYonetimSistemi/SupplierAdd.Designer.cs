namespace SiparisYonetimSistemi
{
    partial class SupplierAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaterialBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UniteComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UnitePriceBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SupplierEmailBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Name";
            // 
            // SupplierBox
            // 
            this.SupplierBox.Location = new System.Drawing.Point(103, 27);
            this.SupplierBox.Name = "SupplierBox";
            this.SupplierBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Name";
            // 
            // MaterialBox
            // 
            this.MaterialBox.Location = new System.Drawing.Point(103, 127);
            this.MaterialBox.Name = "MaterialBox";
            this.MaterialBox.Size = new System.Drawing.Size(144, 20);
            this.MaterialBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit";
            // 
            // UniteComboBox
            // 
            this.UniteComboBox.FormattingEnabled = true;
            this.UniteComboBox.Location = new System.Drawing.Point(103, 177);
            this.UniteComboBox.Name = "UniteComboBox";
            this.UniteComboBox.Size = new System.Drawing.Size(144, 21);
            this.UniteComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Unit Price";
            // 
            // UnitePriceBox
            // 
            this.UnitePriceBox.Location = new System.Drawing.Point(103, 227);
            this.UnitePriceBox.Name = "UnitePriceBox";
            this.UnitePriceBox.Size = new System.Drawing.Size(144, 20);
            this.UnitePriceBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(103, 286);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Supplier Email";
            // 
            // SupplierEmailBox
            // 
            this.SupplierEmailBox.Location = new System.Drawing.Point(103, 77);
            this.SupplierEmailBox.Name = "SupplierEmailBox";
            this.SupplierEmailBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierEmailBox.TabIndex = 8;
            // 
            // SupplierAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 321);
            this.Controls.Add(this.SupplierEmailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UniteComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnitePriceBox);
            this.Controls.Add(this.MaterialBox);
            this.Controls.Add(this.SupplierBox);
            this.Controls.Add(this.label1);
            this.Name = "SupplierAdd";
            this.Text = "t";
            this.Load += new System.EventHandler(this.SupplierAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SupplierBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MaterialBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UniteComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UnitePriceBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SupplierEmailBox;
    }
}
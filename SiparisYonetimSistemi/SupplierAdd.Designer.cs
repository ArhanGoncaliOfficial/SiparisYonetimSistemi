﻿namespace SiparisYonetimSistemi
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
            this.SupplierNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SupplierUniteBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SupplierPriceBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SupplierPhoneBox = new System.Windows.Forms.TextBox();
            this.MaterialComboBox = new System.Windows.Forms.ComboBox();
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
            // SupplierNameBox
            // 
            this.SupplierNameBox.Location = new System.Drawing.Point(103, 27);
            this.SupplierNameBox.Name = "SupplierNameBox";
            this.SupplierNameBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierNameBox.TabIndex = 1;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit";
            // 
            // SupplierUniteBox
            // 
            this.SupplierUniteBox.FormattingEnabled = true;
            this.SupplierUniteBox.Location = new System.Drawing.Point(103, 177);
            this.SupplierUniteBox.Name = "SupplierUniteBox";
            this.SupplierUniteBox.Size = new System.Drawing.Size(144, 21);
            this.SupplierUniteBox.TabIndex = 4;
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
            // SupplierPriceBox
            // 
            this.SupplierPriceBox.Location = new System.Drawing.Point(103, 227);
            this.SupplierPriceBox.Name = "SupplierPriceBox";
            this.SupplierPriceBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierPriceBox.TabIndex = 1;
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
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ContactPhone";
            // 
            // SupplierPhoneBox
            // 
            this.SupplierPhoneBox.Location = new System.Drawing.Point(103, 77);
            this.SupplierPhoneBox.Name = "SupplierPhoneBox";
            this.SupplierPhoneBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierPhoneBox.TabIndex = 8;
            // 
            // MaterialComboBox
            // 
            this.MaterialComboBox.FormattingEnabled = true;
            this.MaterialComboBox.Location = new System.Drawing.Point(103, 127);
            this.MaterialComboBox.Name = "MaterialComboBox";
            this.MaterialComboBox.Size = new System.Drawing.Size(144, 21);
            this.MaterialComboBox.TabIndex = 4;
            // 
            // SupplierAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 321);
            this.Controls.Add(this.SupplierPhoneBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaterialComboBox);
            this.Controls.Add(this.SupplierUniteBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SupplierPriceBox);
            this.Controls.Add(this.SupplierNameBox);
            this.Controls.Add(this.label1);
            this.Name = "SupplierAdd";
            this.Text = "t";
            this.Load += new System.EventHandler(this.SupplierAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SupplierNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SupplierUniteBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SupplierPriceBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SupplierPhoneBox;
        private System.Windows.Forms.ComboBox MaterialComboBox;
    }
}
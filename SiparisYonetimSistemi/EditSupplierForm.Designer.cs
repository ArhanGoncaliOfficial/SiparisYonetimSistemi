﻿namespace SiparisYonetimSistemi
{
    partial class EditSupplierForm
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
            this.SupplierPhoneBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditButon = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SupplierUniteBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SupplierPriceBox = new System.Windows.Forms.TextBox();
            this.SupplierNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaterialNameBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SupplierPhoneBox
            // 
            this.SupplierPhoneBox.Location = new System.Drawing.Point(110, 69);
            this.SupplierPhoneBox.Name = "SupplierPhoneBox";
            this.SupplierPhoneBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierPhoneBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "ContactPhone";
            // 
            // EditButon
            // 
            this.EditButon.Location = new System.Drawing.Point(110, 278);
            this.EditButon.Name = "EditButon";
            this.EditButon.Size = new System.Drawing.Size(75, 23);
            this.EditButon.TabIndex = 17;
            this.EditButon.Text = "Edit";
            this.EditButon.UseVisualStyleBackColor = true;
            this.EditButon.Click += new System.EventHandler(this.EditButon_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Unit Price";
            // 
            // SupplierUniteBox
            // 
            this.SupplierUniteBox.FormattingEnabled = true;
            this.SupplierUniteBox.Location = new System.Drawing.Point(110, 169);
            this.SupplierUniteBox.Name = "SupplierUniteBox";
            this.SupplierUniteBox.Size = new System.Drawing.Size(144, 21);
            this.SupplierUniteBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Material Name";
            // 
            // SupplierPriceBox
            // 
            this.SupplierPriceBox.Location = new System.Drawing.Point(110, 219);
            this.SupplierPriceBox.Name = "SupplierPriceBox";
            this.SupplierPriceBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierPriceBox.TabIndex = 10;
            // 
            // SupplierNameBox
            // 
            this.SupplierNameBox.Location = new System.Drawing.Point(110, 19);
            this.SupplierNameBox.Name = "SupplierNameBox";
            this.SupplierNameBox.Size = new System.Drawing.Size(144, 20);
            this.SupplierNameBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Supplier Name";
            // 
            // MaterialNameBox
            // 
            this.MaterialNameBox.FormattingEnabled = true;
            this.MaterialNameBox.Location = new System.Drawing.Point(110, 119);
            this.MaterialNameBox.Name = "MaterialNameBox";
            this.MaterialNameBox.Size = new System.Drawing.Size(144, 21);
            this.MaterialNameBox.TabIndex = 15;
            // 
            // EditSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 321);
            this.Controls.Add(this.SupplierPhoneBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EditButon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaterialNameBox);
            this.Controls.Add(this.SupplierUniteBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SupplierPriceBox);
            this.Controls.Add(this.SupplierNameBox);
            this.Controls.Add(this.label1);
            this.Name = "EditSupplierForm";
            this.Text = "EditSupplierForm";
            this.Load += new System.EventHandler(this.EditSupplierForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SupplierPhoneBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EditButon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SupplierUniteBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SupplierPriceBox;
        private System.Windows.Forms.TextBox SupplierNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MaterialNameBox;
    }
}
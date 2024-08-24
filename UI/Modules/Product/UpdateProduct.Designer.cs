namespace DevFluentDesign.UI.Modules.Product
{
    partial class UpdateProduct
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
            this.Save = new System.Windows.Forms.Button();
            this.Price = new System.Windows.Forms.TextBox();
            this.ProductName = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Navy;
            this.Save.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.White;
            this.Save.Location = new System.Drawing.Point(327, 335);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(158, 49);
            this.Save.TabIndex = 16;
            this.Save.Text = "Update";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(187, 191);
            this.Price.Name = "Price";
            this.Price.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Price.Size = new System.Drawing.Size(382, 27);
            this.Price.TabIndex = 14;
            // 
            // ProductName
            // 
            this.ProductName.Location = new System.Drawing.Point(187, 130);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(382, 27);
            this.ProductName.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(187, 244);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(382, 27);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.Text = "CategoryName";
            // 
            // UpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 515);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ProductName);
            this.Name = "UpdateProduct";
            this.Text = "UpdateProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.TextBox ProductName;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
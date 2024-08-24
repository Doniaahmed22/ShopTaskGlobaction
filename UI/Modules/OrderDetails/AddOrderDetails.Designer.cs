namespace DevFluentDesign.UI.Modules.OrderDetails
{
    partial class AddOrderDetails
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
            this.Add = new System.Windows.Forms.Button();
            this.Price = new System.Windows.Forms.TextBox();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Navy;
            this.Add.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(351, 313);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(195, 53);
            this.Add.TabIndex = 40;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(212, 230);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(604, 27);
            this.Price.TabIndex = 42;
            this.Price.Text = "Price";
            // 
            // Quantity
            // 
            this.Quantity.Location = new System.Drawing.Point(212, 170);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(604, 27);
            this.Quantity.TabIndex = 41;
            this.Quantity.Text = "Quantity";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(212, 118);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(604, 27);
            this.comboBox2.TabIndex = 44;
            this.comboBox2.Text = "Product";
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.Navy;
            this.Done.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.ForeColor = System.Drawing.Color.White;
            this.Done.Location = new System.Drawing.Point(594, 313);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(195, 53);
            this.Done.TabIndex = 45;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = false;
            this.Done.Click += new System.EventHandler(this.Done_Click_1);
            // 
            // AddOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 499);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Add);
            this.Name = "AddOrderDetails";
            this.Text = "AddOrderDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button Done;
    }
}
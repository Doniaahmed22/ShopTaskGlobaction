namespace DevFluentDesign.UI.Modules.Add
{
    partial class AddCustomer
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
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(55, 88);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(723, 27);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "FirstName";
            //this.FirstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(54, 152);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(724, 27);
            this.LastName.TabIndex = 1;
            this.LastName.Text = "LastName";
            //this.LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(54, 287);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(724, 27);
            this.Phone.TabIndex = 3;
            this.Phone.Text = "Phone";
            //this.Phone.TextChanged += new System.EventHandler(this.Phone_TextChanged);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(54, 219);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(724, 27);
            this.Email.TabIndex = 9;
            this.Email.Text = "Email";
            //this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Navy;
            this.Add.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(554, 345);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(174, 53);
            this.Add.TabIndex = 32;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 468);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Name = "AddCustomer";
            this.Text = "AddCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Button Add;
    }
}
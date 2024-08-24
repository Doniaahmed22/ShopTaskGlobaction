namespace DevFluentDesign.UI.Modules.Customer
{
    partial class updateCustomer
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
            this.Update = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.Navy;
            this.Update.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update.ForeColor = System.Drawing.Color.White;
            this.Update.Location = new System.Drawing.Point(564, 385);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(174, 53);
            this.Update.TabIndex = 30;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(132, 234);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(647, 27);
            this.Email.TabIndex = 25;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(132, 302);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(647, 27);
            this.Phone.TabIndex = 24;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(132, 167);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(647, 27);
            this.LastName.TabIndex = 23;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(133, 103);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(646, 27);
            this.FirstName.TabIndex = 22;
            // 
            // updateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 558);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Name = "updateCustomer";
            this.Text = "updateCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox FirstName;
    }
}
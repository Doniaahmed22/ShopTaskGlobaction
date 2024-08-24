using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevFluentDesign.UI.Modules.Customer
{
    public partial class updateCustomer : DevExpress.XtraEditors.XtraForm
    {
        public Customers Customer { get; private set; }

        public updateCustomer(Customers customer)
        {
            InitializeComponent();
            Customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            // تعبئة النموذج بالبيانات
            FirstName.Text = Customer.FirstName;
            LastName.Text = Customer.LastName;
            Email.Text = Customer.Email;
            Phone.Text = Customer.Phone;
        }


        private void Update_Click(object sender, EventArgs e)
        {
            // التحقق من صحة البيانات
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Phone.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // تعيين الخصائص
            Customer.FirstName = FirstName.Text;
            Customer.LastName = LastName.Text;
            Customer.Email = Email.Text;
            Customer.Phone = Phone.Text;

            // إغلاق النموذج مع إرجاع النتيجة OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

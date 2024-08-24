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
using System.Xml.Linq;

namespace DevFluentDesign.UI.Modules.Add
{
    public partial class AddCustomer : DevExpress.XtraEditors.XtraForm
    {
        public Customers Customer { get; private set; }

        public AddCustomer()
        {
            InitializeComponent();
            Customer = new Customers(); // تهيئة الكائن
        }



        private void Add_Click(object sender, EventArgs e)
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

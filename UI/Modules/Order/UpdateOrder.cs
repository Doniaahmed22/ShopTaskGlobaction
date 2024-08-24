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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DevFluentDesign.UI.Modules.Order
{
    public partial class UpdateOrder : DevExpress.XtraEditors.XtraForm
    {
        public Orders Order { get; private set; }
        private List<Customers> customers;
        public DatabaseManager dbManager { get; private set; }

        public UpdateOrder(Orders order)
        {
            InitializeComponent();
            Order = order;
            dbManager = new DatabaseManager();
            LoadCustomers();
            LoadOrderData();
        }

        private void LoadCustomers()
        {
            // افترض أن لديك طريقة لتحميل بيانات العملاء من قاعدة البيانات
            customers = dbManager.CustomersTable.AsEnumerable()
                .Select(row => new Customers
                {
                    Id = row.Field<int>("CustomerID"),
                    FirstName = row.Field<string>("FirstName"),
                })
                .ToList();

            // تعيين قائمة العملاء في ComboBox
            comboBox1.DataSource = customers;
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "Id";

            // تحديد العنصر بناءً على CustomerID
            if (Order != null)
            {
                comboBox1.SelectedValue = Order.CustomerID;
            }
        }

        private void LoadOrderData()
        {
            // تعبئة النموذج بالبيانات
            OrderDate.Text = Order.OrderDate.ToString("yyyy-MM-dd"); // ضبط تنسيق التاريخ حسب الحاجة
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // التحقق من صحة البيانات
            if (comboBox1.SelectedValue == null || string.IsNullOrEmpty(OrderDate.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // تعيين الخصائص
            Order.CustomerID = Convert.ToInt32(comboBox1.SelectedValue);
            Order.OrderDate = Convert.ToDateTime(OrderDate.Text);

            // إغلاق النموذج مع إرجاع النتيجة OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

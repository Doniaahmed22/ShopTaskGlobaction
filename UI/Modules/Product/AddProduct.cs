using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Customization;
using DevFluentDesign.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DevFluentDesign.UI.Modules.Product
{
    public partial class AddProduct : DevExpress.XtraEditors.XtraForm
    {
        public Products Product { get; private set; }
        private List<Categories> categories;
        public DatabaseManager dbManager { get; private set; }

        public AddProduct()
        {
            InitializeComponent();
            Product = new Products(); // تهيئة الكائن
            dbManager = new DatabaseManager();
            LoadCategories();
        }

        private void LoadCategories()
        {
            // افترض أن لديك طريقة لتحميل بيانات الفئات من قاعدة البيانات
            categories = dbManager.CategoriesTable.AsEnumerable()
                .Select(row => new Categories
                {
                    CategoryId = row.Field<int>("CategoryID"),
                    CategoryName = row.Field<string>("CategoryName"),
                })
                .ToList();

            // تعيين قائمة الفئات في ComboBox
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // التحقق من صحة البيانات
            if (string.IsNullOrEmpty(ProductName.Text) || string.IsNullOrEmpty(Price.Text) || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // تعيين الخصائص
            Product.ProductName = ProductName.Text;
            Product.Price = Price.Text;
            Product.CategoryID = Convert.ToInt32(comboBox1.SelectedValue);

            // إغلاق النموذج مع إرجاع النتيجة OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Customization;
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

namespace DevFluentDesign.UI.Modules.Category
{
    public partial class UpdateCategory : DevExpress.XtraEditors.XtraForm
    {
        public Categories Category { get; set; }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {

        }

        public UpdateCategory(Categories category)
        {
            InitializeComponent();
            Category = category;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            // تعبئة النموذج بالبيانات
            CategoryName.Text = Category.CategoryName;
            
        }




        private void Save_Click(object sender, EventArgs e)
        {
            // التحقق من صحة البيانات
            if (string.IsNullOrEmpty(CategoryName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // تعيين الخصائص
            Category.CategoryName = CategoryName.Text;

            // إغلاق النموذج مع إرجاع النتيجة OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
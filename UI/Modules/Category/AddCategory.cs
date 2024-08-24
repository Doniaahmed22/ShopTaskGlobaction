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

namespace DevFluentDesign.UI.Modules.Category
{
    public partial class AddCategory : DevExpress.XtraEditors.XtraForm
    {
        public Categories Category { get; private set; }

        public AddCategory()
        {
            InitializeComponent();
            Category = new Categories(); // تهيئة الكائن

        }

        private void Save_Click(object sender, EventArgs e)
        {
            // التحقق من صحة البيانات
            if (string.IsNullOrEmpty(CategoryName.Text) )
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

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
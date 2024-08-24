using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevFluentDesign.UI.Modules
{
    public partial class ucProductCategory : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucProductCategory() : this(null) // Constructor بدون معاملات
        {
            // يجب أن يبقى هذا constructor افتراضي ويُستخدم عندما لا يُمرر dbManager
        }

        public ucProductCategory(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucProductCategory_Load);
        }

        public void BindTreeList(DatabaseManager dbManager)
        {
            // مسح أي بيانات حالية في الـ TreeList
            treeList1.ClearNodes();

            // إضافة الأعمدة المطلوبة
            treeList1.Columns.Clear();
            treeList1.Columns.Add(new TreeListColumn { Caption = "Category Name", Visible = true });
            treeList1.Columns.Add(new TreeListColumn { Caption = "Product ID", Visible = true });
            treeList1.Columns.Add(new TreeListColumn { Caption = "Product Name", Visible = true });
            treeList1.Columns.Add(new TreeListColumn { Caption = "Price", Visible = true });
            treeList1.Columns.Add(new TreeListColumn { Caption = "Category", Visible = true });

            // إضافة الفئات كـ Nodes رئيسية
            foreach (DataRow categoryRow in dbManager.CategoriesTable.Rows)
            {
                string categoryName = categoryRow["CategoryName"].ToString();

                // إنشاء الـ Parent Node للفئة وإضافة اسم الفئة في العمود الأول
                TreeListNode categoryNode = treeList1.AppendNode(new object[] { categoryName, null, null, null, null }, null);

                // إضافة المنتجات تحت كل فئة كـ Child Nodes
                DataRow[] productRows = dbManager.ProductsTable.Select($"CategoryID = {categoryRow["CategoryID"]}");
                foreach (DataRow productRow in productRows)
                {
                    int productId = Convert.ToInt32(productRow["ProductID"]);
                    string productName = productRow["ProductName"].ToString();
                    decimal price = Convert.ToDecimal(productRow["Price"]);
                    string category = categoryRow["CategoryName"].ToString();

                    treeList1.AppendNode(new object[] { null, productId, productName, price, category }, categoryNode);
                }
            }

            // توسيع جميع الـ Nodes لعرضها بشكل افتراضي
            treeList1.ExpandAll();
        }

        private void ucProductCategory_Load(object sender, EventArgs e)
        {
            BindTreeList(dbManager);
        }


        private void treeList1_FocusedNodeChanged_1(object sender, FocusedNodeChangedEventArgs e)
        {

        }
    }
}

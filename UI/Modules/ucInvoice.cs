using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Category;
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

namespace DevFluentDesign.UI.Modules
{
    public partial class ucInvoice : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucInvoice() : this(null) // Constructor بدون معاملات
        {
            // يجب أن يبقى هذا constructor افتراضي ويُستخدم عندما لا يُمرر dbManager
        }

        public ucInvoice(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucInvoice_Load);

        }

        public void LoadData(DatabaseManager dbManager)
        {
            ((DataTable)gridControl1.DataSource).Clear();

            SqlDataAdapter InvoiceAdapter = new SqlDataAdapter("select * from Invoice", dbManager.connection);
            InvoiceAdapter.Fill(dbManager.InvoiceTable);
      
        }

        private void ucInvoice_Load(object sender, EventArgs e)
        {
            if (dbManager != null)
            {
                gridControl1.DataSource = dbManager.InvoiceTable;
                gridView1.PopulateColumns(); // هذا لضمان أن الأعمدة يتم إنشاؤها بشكل صحيح
            }
            else
            {
                MessageBox.Show("DatabaseManager is not initialized.");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                // الحصول على فهرس الصف المحدد
                int selectedRowIndex = gridView1.GetSelectedRows()[0];
                // الحصول على DataRow للصف المحدد
                DataRow selectedRow = gridView1.GetDataRow(selectedRowIndex);

                if (selectedRow != null)
                {
                    // الحصول على المعرف قبل حذف الصف
                    object InvoiceId = selectedRow["InvoiceId"]; // Assuming CustomerId is a column

                    // تأكيد الحذف
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Invoice?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // حذف الصف من DataTable
                            selectedRow.Delete();

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT * FROM Invoice", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(categoryAdapter);

                                // إعداد معلمة الحذف بناءً على العميل المحدد
                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@InvoiceId", InvoiceId); // استخدام المعرف المحفوظ
                                categoryAdapter.DeleteCommand = deleteCommand;

                                // تحديث قاعدة البيانات
                                categoryAdapter.Update(dbManager.CategoriesTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the Category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Category to delete.");
            }
        }
    }
}

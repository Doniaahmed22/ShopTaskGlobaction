using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Order;
using DevFluentDesign.UI.Modules.OrderDetails;
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
    public partial class ucOrderDetails : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucOrderDetails() : this(null) // Constructor بدون معاملات
        {
            // يجب أن يبقى هذا constructor افتراضي ويُستخدم عندما لا يُمرر dbManager
        }

        public ucOrderDetails(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucOrderDetails_Load);

        }

        public void LoadData(DatabaseManager dbManager)
        {
            ((DataTable)gridControl1.DataSource).Clear();

            SqlDataAdapter OrderDetailssAdapter = new SqlDataAdapter("select * from OrderDetail", dbManager.connection);
            OrderDetailssAdapter.Fill(dbManager.OrderDetailsTable);

        }
        private void ucOrderDetails_Load(object sender, EventArgs e)
        {
            if (dbManager != null)
            {
                gridControl1.DataSource = dbManager.OrderDetailsTable;
                gridView1.PopulateColumns(); // هذا لضمان أن الأعمدة يتم إنشاؤها بشكل صحيح
            }
            else
            {
                MessageBox.Show("DatabaseManager is not initialized.");
            }
        }

 
        

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    object orderDetailId = selectedRow["OrderDetailID"]; // تأكد من أن اسم العمود صحيح

                    // تأكيد الحذف
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this OrderDetail?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // حذف الصف من DataTable
                            selectedRow.Delete();

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter orderDetailAdapter = new SqlDataAdapter("SELECT * FROM OrderDetail", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(orderDetailAdapter);

                                // إعداد معلمة الحذف بناءً على الطلب المحدد
                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@OrderDetailsID", orderDetailId); // استخدام المعرف المحفوظ
                                orderDetailAdapter.DeleteCommand = deleteCommand;

                                // تحديث قاعدة البيانات
                                orderDetailAdapter.Update(dbManager.OrderDetailsTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the Order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an Order to delete.");
            }
        }


    }
}



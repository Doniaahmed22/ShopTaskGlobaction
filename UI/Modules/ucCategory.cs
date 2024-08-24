
using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Add;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DevFluentDesign.UI.Modules.Category;
using DevFluentDesign.UI.Modules.Customer;

namespace DevFluentDesign.UI.Modules
{
    public partial class ucCategory : DevExpress.DXperience.Demos.TutorialControlBase
    {

        private DatabaseManager dbManager;

        public ucCategory() : this(null) // Constructor بدون معاملات
        {
            // يجب أن يبقى هذا constructor افتراضي ويُستخدم عندما لا يُمرر dbManager
        }

        public ucCategory(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucCategory_Load);

        }

        public void LoadData(DatabaseManager dbManager)
        {
            ((DataTable)gridControl1.DataSource).Clear();
            SqlDataAdapter categoriesAdapter = new SqlDataAdapter("SELECT * FROM Category", dbManager.connection);
            categoriesAdapter.Fill(dbManager.CategoriesTable);         
        }

        private void ucCategory_Load(object sender, EventArgs e)
        {
            if (dbManager != null)
            {
                gridControl1.DataSource = dbManager.CategoriesTable;
                gridView1.PopulateColumns(); // هذا لضمان أن الأعمدة يتم إنشاؤها بشكل صحيح
            }
            else
            {
                MessageBox.Show("DatabaseManager is not initialized.");
            }
        }




        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddCategory form = new AddCategory())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // الحصول على الكائن من النموذج
                    Categories category = form.Category;

                    // إضافة الصف الجديد إلى DataTable
                    DataRow newRow = dbManager.CategoriesTable.NewRow();
                    newRow["CategoryName"] = category.CategoryName;

                    dbManager.CategoriesTable.Rows.Add(newRow);

                    // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                    SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT * FROM Category", dbManager.connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(categoryAdapter);

                    // إعداد معلمة الإدخال
                    categoryAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                    categoryAdapter.InsertCommand.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                    // تنفيذ عملية الإدخال
                    categoryAdapter.Update(dbManager.CategoriesTable);

                    // إعادة تحميل البيانات لتحديث العرض
                    ReloadCustomerData();
                }
            }
        }

        private void ReloadCustomerData()
        {
            dbManager.CategoriesTable.Clear(); // مسح البيانات القديمة
            SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT * FROM Category", dbManager.connection);
            categoryAdapter.Fill(dbManager.CategoriesTable);
            gridControl1.DataSource = dbManager.CategoriesTable;
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
                    object CategoryId = selectedRow["CategoryId"]; // Assuming CustomerId is a column

                    // تأكيد الحذف
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Category?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // حذف الصف من DataTable
                            selectedRow.Delete();

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT * FROM Category", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(categoryAdapter);

                                // إعداد معلمة الحذف بناءً على العميل المحدد
                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@CategoryId", CategoryId); // استخدام المعرف المحفوظ
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                // الحصول على فهرس الصف المحدد
                int selectedRowIndex = gridView1.GetSelectedRows()[0];
                // الحصول على DataRow للصف المحدد
                DataRow selectedRow = gridView1.GetDataRow(selectedRowIndex);

                if (selectedRow != null)
                {
                    // الحصول على البيانات من الصف المحدد
                    var category = new Categories
                    {
                        CategoryId = Convert.ToInt32(selectedRow["CategoryID"]), // Assuming CustomerId is a column
                        CategoryName = selectedRow["CategoryName"].ToString()
                    };

                    using (UpdateCategory form = new UpdateCategory(category))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            // الحصول على الكائن المحدث من النموذج
                            var updatedCustomer = form.Category;

                            // تحديث الصف في DataTable
                            selectedRow["CategoryName"] = updatedCustomer.CategoryName;

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter categoryAdapter = new SqlDataAdapter("SELECT * FROM Category", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(categoryAdapter);

                                // إعداد معلمة التحديث بناءً على العميل المحدد
                                SqlCommand updateCommand = commandBuilder.GetUpdateCommand();
                                categoryAdapter.UpdateCommand = updateCommand;

                                // إعداد المعلمات للتحديث
                                categoryAdapter.UpdateCommand.Parameters.AddWithValue("@CategoryName", updatedCustomer.CategoryName);
                                categoryAdapter.UpdateCommand.Parameters.AddWithValue("@CustomerId", updatedCustomer.CategoryId); // Assuming CustomerId is a column

                                // تحديث قاعدة البيانات
                                categoryAdapter.Update(dbManager.CategoriesTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to update.");
            }
        }
    }
    }


using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Add;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DevFluentDesign.UI.Modules.Customer;

namespace DevFluentDesign.UI.Modules
{
    public partial class ucCustomer : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucCustomer() : this(null) // Constructor بدون معاملات
        {
            // يجب أن يبقى هذا constructor افتراضي ويُستخدم عندما لا يُمرر dbManager
        }

        public ucCustomer(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucCustomer_Load);

        }

        public void LoadData(DatabaseManager dbManager)
        {
            ((DataTable)gridControl1.DataSource).Clear();
            SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", dbManager.connection);
            customersAdapter.Fill(dbManager.CustomersTable);



            
        }

        private void ucCustomer_Load(object sender, EventArgs e)
        {
            if (dbManager != null)
            {
                gridControl1.DataSource = dbManager.CustomersTable;
                gridView1.PopulateColumns(); // هذا لضمان أن الأعمدة يتم إنشاؤها بشكل صحيح
            }
            else
            {
                MessageBox.Show("DatabaseManager is not initialized.");
            }
        }




        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddCustomer form = new AddCustomer())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // الحصول على الكائن من النموذج
                    Customers customer = form.Customer;

                    // إضافة الصف الجديد إلى DataTable
                    DataRow newRow = dbManager.CustomersTable.NewRow();
                    newRow["FirstName"] = customer.FirstName;
                    newRow["LastName"] = customer.LastName;
                    newRow["Email"] = customer.Email;
                    newRow["Phone"] = customer.Phone;

                    dbManager.CustomersTable.Rows.Add(newRow);

                    // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                    SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", dbManager.connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customersAdapter);

                    // إعداد معلمة الإدخال
                    customersAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                    customersAdapter.InsertCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    customersAdapter.InsertCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                    customersAdapter.InsertCommand.Parameters.AddWithValue("@Email", customer.Email);
                    customersAdapter.InsertCommand.Parameters.AddWithValue("@Phone", customer.Phone);

                    // تنفيذ عملية الإدخال
                    customersAdapter.Update(dbManager.CustomersTable);

                    // إعادة تحميل البيانات لتحديث العرض
                    ReloadCustomerData();
                }
            }
        }

        private void ReloadCustomerData()
        {
            dbManager.CustomersTable.Clear(); // مسح البيانات القديمة
            SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", dbManager.connection);
            customersAdapter.Fill(dbManager.CustomersTable);
            gridControl1.DataSource = dbManager.CustomersTable;
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
                    object customerId = selectedRow["CustomerId"]; // Assuming CustomerId is a column

                    // تأكيد الحذف
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // حذف الصف من DataTable
                            selectedRow.Delete();

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customersAdapter);

                                // إعداد معلمة الحذف بناءً على العميل المحدد
                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@CustomerId", customerId); // استخدام المعرف المحفوظ
                                customersAdapter.DeleteCommand = deleteCommand;

                                // تحديث قاعدة البيانات
                                customersAdapter.Update(dbManager.CustomersTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
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
                    var customer = new Customers
                    {
                        Id = Convert.ToInt32(selectedRow["CustomerId"]), // Assuming CustomerId is a column
                        FirstName = selectedRow["FirstName"].ToString(),
                        LastName = selectedRow["LastName"].ToString(),
                        Email = selectedRow["Email"].ToString(),
                        Phone = selectedRow["Phone"].ToString()
                    };

                    using (updateCustomer form = new updateCustomer(customer))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            // الحصول على الكائن المحدث من النموذج
                            var updatedCustomer = form.Customer;

                            // تحديث الصف في DataTable
                            selectedRow["FirstName"] = updatedCustomer.FirstName;
                            selectedRow["LastName"] = updatedCustomer.LastName;
                            selectedRow["Email"] = updatedCustomer.Email;
                            selectedRow["Phone"] = updatedCustomer.Phone;

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customersAdapter);

                                // إعداد معلمة التحديث بناءً على العميل المحدد
                                SqlCommand updateCommand = commandBuilder.GetUpdateCommand();
                                customersAdapter.UpdateCommand = updateCommand;

                                // إعداد المعلمات للتحديث
                                customersAdapter.UpdateCommand.Parameters.AddWithValue("@FirstName", updatedCustomer.FirstName);
                                customersAdapter.UpdateCommand.Parameters.AddWithValue("@LastName", updatedCustomer.LastName);
                                customersAdapter.UpdateCommand.Parameters.AddWithValue("@Email", updatedCustomer.Email);
                                customersAdapter.UpdateCommand.Parameters.AddWithValue("@Phone", updatedCustomer.Phone);
                                customersAdapter.UpdateCommand.Parameters.AddWithValue("@CustomerId", updatedCustomer.Id); // Assuming CustomerId is a column

                                // تحديث قاعدة البيانات
                                customersAdapter.Update(dbManager.CustomersTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }
    }
}
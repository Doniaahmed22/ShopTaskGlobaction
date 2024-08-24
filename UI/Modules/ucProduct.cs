
using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DevFluentDesign.UI.Modules.Product;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Category;
using DevFluentDesign.UI.Modules.Customer;

namespace DevFluentDesign.UI.Modules
{
    public partial class ucProduct : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucProduct() : this(null) { }

        public ucProduct(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.Load += new EventHandler(ucProduct_Load);
        }


        public void LoadData(DatabaseManager dbManager)
        {
            ((DataTable)gridControl1.DataSource).Clear();

            SqlDataAdapter productsAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection);
            productsAdapter.Fill(dbManager.ProductsTable);    
        }
        private void ucProduct_Load(object sender, EventArgs e)
        {
            if (dbManager != null)
            {
                gridControl1.DataSource = dbManager.ProductsTable;
                gridView1.PopulateColumns(); // التأكد من أن الأعمدة تظهر بشكل صحيح
            }
            else
            {
                MessageBox.Show("DatabaseManager is not initialized.");
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddProduct form = new AddProduct())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // الحصول على الكائن من النموذج
                    Products product = form.Product;

                    // إضافة الصف الجديد إلى DataTable
                    DataRow newRow = dbManager.ProductsTable.NewRow();
                    newRow["ProductName"] = product.ProductName;
                    newRow["CategoryId"] = product.CategoryID; // تأكد من أن هذا العمود موجود في جدول المنتجات
                    newRow["Price"] = product.Price;

                    dbManager.ProductsTable.Rows.Add(newRow);

                    // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                    using (SqlDataAdapter productAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(productAdapter);

                        // إعداد معلمة الإدخال
                        productAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                        productAdapter.InsertCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
                        productAdapter.InsertCommand.Parameters.AddWithValue("@CategoryId", product.CategoryID);
                        productAdapter.InsertCommand.Parameters.AddWithValue("@Price", product.Price);
                        //productAdapter.InsertCommand.Parameters.AddWithValue("@Stock", product.Stock);

                        // تنفيذ عملية الإدخال
                        productAdapter.Update(dbManager.ProductsTable);
                    }

                    // إعادة تحميل البيانات لتحديث العرض
                    ReloadProductData();
                }
            }
        }

        private void ReloadProductData()
        {
            dbManager.ProductsTable.Clear(); // مسح البيانات القديمة
            SqlDataAdapter productAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection);
            productAdapter.Fill(dbManager.ProductsTable);
            gridControl1.DataSource = dbManager.ProductsTable;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int selectedRowIndex = gridView1.GetSelectedRows()[0];
                DataRow selectedRow = gridView1.GetDataRow(selectedRowIndex);

                if (selectedRow != null)
                {
                    object ProductId = selectedRow["ProductId"]; // افتراض أن ProductId هو عمود في الجدول

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Product?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            selectedRow.Delete();

                            using (SqlDataAdapter productAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(productAdapter);

                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@ProductId", ProductId);
                                productAdapter.DeleteCommand = deleteCommand;

                                productAdapter.Update(dbManager.ProductsTable);

                                gridView1.RefreshData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the Product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Product to delete.");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddProduct form = new AddProduct())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // الحصول على الكائن من النموذج
                    Products Product = form.Product;

                    // إضافة الصف الجديد إلى DataTable
                    DataRow newRow = dbManager.ProductsTable.NewRow();
                    newRow["ProductName"] = Product.ProductName;
                    newRow["Price"] = Product.Price;
                    newRow["CategoryId"] = Product.CategoryID;

                    dbManager.ProductsTable.Rows.Add(newRow);

                    // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                    SqlDataAdapter productAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(productAdapter);

                    // إعداد معلمة الإدخال
                    productAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                    productAdapter.InsertCommand.Parameters.AddWithValue("@ProductName", Product.ProductName);
                    productAdapter.InsertCommand.Parameters.AddWithValue("@Price", Product.Price);
                    productAdapter.InsertCommand.Parameters.AddWithValue("@CategoryId", Product.CategoryID);

                    // تنفيذ عملية الإدخال
                    productAdapter.Update(dbManager.ProductsTable);

                    // إعادة تحميل البيانات لتحديث العرض
                    ReloadCustomerData();
                }
            }
        }

        private void ReloadCustomerData()
        {
            dbManager.ProductsTable.Clear(); // مسح البيانات القديمة
            SqlDataAdapter productAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection);
            productAdapter.Fill(dbManager.ProductsTable);
            gridControl1.DataSource = dbManager.ProductsTable;
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
                    var product = new Products
                    {
                        ProductId = Convert.ToInt32(selectedRow["ProductId"]), // Assuming CustomerId is a column
                        ProductName = selectedRow["ProductName"].ToString(),
                        Price = selectedRow["Price"].ToString(),
                        CategoryID = Convert.ToInt32(selectedRow["CategoryId"].ToString())
                    };

                    using (UpdateProduct form = new UpdateProduct(product))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            // الحصول على الكائن المحدث من النموذج
                            var UpdateProduct = form.Product;

                            // تحديث الصف في DataTable
                            selectedRow["ProductName"] = UpdateProduct.ProductName;
                            selectedRow["Price"] = UpdateProduct.Price;
                            selectedRow["CategoryId"] = UpdateProduct.CategoryID;

                            // تحديث قاعدة البيانات باستخدام SqlDataAdapter
                            using (SqlDataAdapter productsAdapter = new SqlDataAdapter("SELECT * FROM Product", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(productsAdapter);

                                // إعداد معلمة التحديث بناءً على العميل المحدد
                                SqlCommand updateCommand = commandBuilder.GetUpdateCommand();
                                productsAdapter.UpdateCommand = updateCommand;

                                // إعداد المعلمات للتحديث
                                productsAdapter.UpdateCommand.Parameters.AddWithValue("@ProductName", UpdateProduct.ProductName);
                                productsAdapter.UpdateCommand.Parameters.AddWithValue("@Price", UpdateProduct.Price);
                                productsAdapter.UpdateCommand.Parameters.AddWithValue("@CategoryId", UpdateProduct.CategoryID);

                                // تحديث قاعدة البيانات
                                productsAdapter.Update(dbManager.ProductsTable);

                                // تحديث العرض
                                gridView1.RefreshData();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Product to update.");
            }



        }
    }
}




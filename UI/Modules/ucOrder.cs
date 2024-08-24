using DevExpress.XtraEditors;
using DevFluentDesign.Entity;
using DevFluentDesign.UI.Modules.Add;
using DevFluentDesign.UI.Modules.Customer;
using DevFluentDesign.UI.Modules.Order;
using DevFluentDesign.UI.Modules.OrderDetails;
using DevFluentDesign.UI.Modules.Product;
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
    public partial class ucOrder : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucOrder(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            LoadOrders();
        }

        public void LoadData(DatabaseManager dbManager)
        {
            SqlDataAdapter OrdersAdapter = new SqlDataAdapter("SELECT * FROM Orders", dbManager.connection);
            OrdersAdapter.Fill(dbManager.OrderTable);
        }

        private void LoadOrders()
        {
            string query = "SELECT * FROM Orders";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, dbManager.connection))
            {
                DataTable ordersTable = new DataTable();
                adapter.Fill(ordersTable);
                gridControl1.DataSource = ordersTable;
            }
        }

        private void barButtonItem1_ItemClick(object sender, EventArgs e)
        {
            using (AddOrder form = new AddOrder(dbManager))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int newOrderId = form.OrderId; // Retrieve the newly created Order ID
                    using (AddOrderDetails detailsForm = new AddOrderDetails(dbManager, newOrderId))
                    {
                        detailsForm.ShowDialog();
                    }
                    LoadOrders(); // Refresh the grid after adding a new order and its details
                }
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int selectedRowIndex = gridView1.GetSelectedRows()[0];
                DataRow selectedRow = gridView1.GetDataRow(selectedRowIndex);

                if (selectedRow != null)
                {
                    int orderId = Convert.ToInt32(selectedRow["OrderID"]);

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Order and its related details?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Delete related OrderDetails
                            string deleteOrderDetailsQuery = "DELETE FROM OrderDetail WHERE OrderID = @OrderID";
                            using (SqlCommand deleteOrderDetailsCommand = new SqlCommand(deleteOrderDetailsQuery, dbManager.connection))
                            {
                                deleteOrderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                                dbManager.connection.Open();
                                deleteOrderDetailsCommand.ExecuteNonQuery();
                                dbManager.connection.Close();
                            }

                            // Delete related Invoice
                            string deleteInvoiceQuery = "DELETE FROM Invoice WHERE OrderID = @OrderID";
                            using (SqlCommand deleteInvoiceCommand = new SqlCommand(deleteInvoiceQuery, dbManager.connection))
                            {
                                deleteInvoiceCommand.Parameters.AddWithValue("@OrderID", orderId);
                                dbManager.connection.Open();
                                deleteInvoiceCommand.ExecuteNonQuery();
                                dbManager.connection.Close();
                            }



                            // Delete related Invoice
                            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";
                            using (SqlCommand deleteOrderCommand = new SqlCommand(deleteOrderQuery, dbManager.connection))
                            {
                                deleteOrderCommand.Parameters.AddWithValue("@OrderID", orderId);
                                dbManager.connection.Open();
                                deleteOrderCommand.ExecuteNonQuery();
                                dbManager.connection.Close();
                            }

                            // Delete the Order
                            selectedRow.Delete();
                            using (SqlDataAdapter orderAdapter = new SqlDataAdapter("SELECT * FROM Orders", dbManager.connection))
                            {
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(orderAdapter);

                                SqlCommand deleteCommand = commandBuilder.GetDeleteCommand();
                                deleteCommand.Parameters.AddWithValue("@OrderID", orderId);
                                orderAdapter.DeleteCommand = deleteCommand;

                                orderAdapter.Update(dbManager.OrderTable);
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

        

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int selectedRowIndex = gridView1.GetSelectedRows()[0];
                DataRow selectedRow = gridView1.GetDataRow(selectedRowIndex);

                if (selectedRow != null)
                {
                    var order = new Orders
                    {
                        OrderId = Convert.ToInt32(selectedRow["OrderID"]),
                        CustomerID = Convert.ToInt32(selectedRow["CustomerID"]),
                        OrderDate = Convert.ToDateTime(selectedRow["OrderDate"])
                    };

                    using (UpdateOrder form = new UpdateOrder(order))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var updatedOrder = form.Order;

                            // تحديث الصف في DataTable
                            selectedRow["CustomerID"] = updatedOrder.CustomerID;
                            selectedRow["OrderDate"] = updatedOrder.OrderDate;

                            // تنفيذ استعلام UPDATE صريح
                            string updateQuery = @"
                        UPDATE Orders
                        SET CustomerID = @CustomerID, OrderDate = @OrderDate
                        WHERE OrderID = @OrderID";

                            try
                            {
                                using (SqlCommand updateCommand = new SqlCommand(updateQuery, dbManager.connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@OrderID", updatedOrder.OrderId);
                                    updateCommand.Parameters.AddWithValue("@CustomerID", updatedOrder.CustomerID);
                                    updateCommand.Parameters.AddWithValue("@OrderDate", updatedOrder.OrderDate);

                                    dbManager.connection.Open();
                                    int rowsAffected = updateCommand.ExecuteNonQuery();
                                    dbManager.connection.Close();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Order updated successfully.");
                                        // تحديث العرض
                                        LoadOrders();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No rows were updated. Please check the OrderID.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while updating the Order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an Order to update.");
            }
        }
    }
}

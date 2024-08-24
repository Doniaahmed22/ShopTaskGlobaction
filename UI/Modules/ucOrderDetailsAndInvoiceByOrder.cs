using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevFluentDesign.UI.Modules
{
    public partial class ucOrderDetailsAndInvoiceByOrder : DevExpress.DXperience.Demos.TutorialControlBase
    {
        private DatabaseManager dbManager;

        public ucOrderDetailsAndInvoiceByOrder() : this(null)
        {
            InitializeComponent();
            InitializeTreeList();
        }

        public ucOrderDetailsAndInvoiceByOrder(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
            InitializeComponent();
            InitializeTreeList();
        }

        public void InitializeTreeList()
        {

            // Clear the existing nodes
            treeList1.Nodes.Clear();

            // Add columns if not already added (you can add a check if needed)
            if (treeList1.Columns.Count == 0)
            {
                treeList1.Columns.Add(new TreeListColumn { Caption = "Order ID", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "OrderDetailsId", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Product Name", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Quantity", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Price", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Invoice ID", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Total Amount", Visible = true });
                treeList1.Columns.Add(new TreeListColumn { Caption = "Total Price", Visible = true });
            }

            // Set TreeList properties
            treeList1.OptionsView.ShowCheckBoxes = false;
            treeList1.OptionsBehavior.Editable = false;

            // Fetch data from DatabaseManager
            DataTable ordersTable = dbManager.OrderTable;
            DataTable orderDetailsTable = dbManager.OrderDetailsTable;
            DataTable productsTable = dbManager.ProductsTable;
            DataTable invoicesTable = dbManager.InvoiceTable;

            foreach (DataRow orderRow in ordersTable.Rows)
            {
                int orderId = Convert.ToInt32(orderRow["OrderId"]);

                // Add Order as a parent node
                TreeListNode parentNode = treeList1.AppendNode(new object[] { orderId }, null);

                // Fetch OrderDetails associated with this order
                DataRow[] orderDetailsRows = orderDetailsTable.Select($"OrderId = {orderId}");
                foreach (DataRow detailRow in orderDetailsRows)
                {
                    int orderDetailsId = Convert.ToInt32(detailRow["OrderDetailID"]);
                    int productId = Convert.ToInt32(detailRow["ProductID"]);
                    int quantity = Convert.ToInt32(detailRow["Quantity"]);
                    decimal price = Convert.ToDecimal(detailRow["Price"]);

                    // Fetch product name based on ProductID
                    string productName = productsTable.AsEnumerable()
                        .FirstOrDefault(p => p.Field<int>("ProductID") == productId)?["ProductName"].ToString();

                    // Add OrderDetails as child nodes
                    treeList1.AppendNode(new object[] { null, orderDetailsId, productName, quantity, price }, parentNode);
                }

                // Fetch Invoice associated with this order
                DataRow[] invoiceRows = invoicesTable.Select($"OrderId = {orderId}");
                foreach (DataRow invoiceRow in invoiceRows)
                {
                    int invoiceId = Convert.ToInt32(invoiceRow["InvoiceID"]);
                    decimal totalAmount = Convert.ToDecimal(invoiceRow["TotalAmount"]);
                    decimal totalPrice = Convert.ToDecimal(invoiceRow["TotalPrice"]);

                    // Add Invoice as a child node under the order node
                    treeList1.AppendNode(new object[] { null, null, null, null, null, invoiceId, totalAmount, totalPrice }, parentNode);
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //treeList1_FocusedNodeChanged_1();
        }
    }
}


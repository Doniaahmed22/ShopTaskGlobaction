using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevFluentDesign.Entity;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DevFluentDesign.UI.Modules.Order
{
    public partial class AddOrder : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseManager dbManager;

        public int OrderId { get; private set; } // Property to return the new Order ID

        public AddOrder(DatabaseManager dbManager)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            string query = "SELECT CustomerID, FirstName FROM Customer";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, dbManager.connection))
            {
                DataTable CustomerTable = new DataTable();
                adapter.Fill(CustomerTable);
                comboBox1.DataSource = CustomerTable;
                comboBox1.DisplayMember = "FirstName";
                comboBox1.ValueMember = "CustomerID";
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Add order and retrieve the order ID
                OrderId = AddOrderToDatabase();
                this.DialogResult = DialogResult.OK; // Indicate success
                this.Close();
                MessageBox.Show("Order added successfully! Now add order details.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private int AddOrderToDatabase()
        {
            string query = "INSERT INTO Orders (CustomerID, OrderDate ) OUTPUT INSERTED.OrderID VALUES (@CustomerID, @OrderDate)";
            using (SqlCommand command = new SqlCommand(query, dbManager.connection))
            {
                command.Parameters.AddWithValue("@CustomerID", comboBox1.SelectedValue);
                command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                dbManager.connection.Open();
                int orderId = (int)command.ExecuteScalar();
                dbManager.connection.Close();
                return orderId;
            }
        }


    }
}
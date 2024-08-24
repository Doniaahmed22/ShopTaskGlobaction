using DevExpress.Utils.About;
using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DevFluentDesign.UI.Modules.OrderDetails
{
    public partial class AddOrderDetails : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseManager dbManager;
        private int orderId;

        public AddOrderDetails(DatabaseManager dbManager, int orderId)
        {
            InitializeComponent();
            this.dbManager = dbManager;
            this.orderId = orderId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, dbManager.connection))
            {
                DataTable productsTable = new DataTable();
                adapter.Fill(productsTable);
                comboBox2.DataSource = productsTable;
                comboBox2.DisplayMember = "ProductName";
                comboBox2.ValueMember = "ProductID";
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderDetailsToDatabase();
                MessageBox.Show("Order detail added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        List<int> quantityOfProducts = new List<int>();
        List<double> PriceOfProducts = new List<double>();
        private void AddOrderDetailsToDatabase()
        {
            string query = "INSERT INTO OrderDetail (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)";
            using (SqlCommand command = new SqlCommand(query, dbManager.connection))
            {
                command.Parameters.AddWithValue("@OrderID", orderId);
                command.Parameters.AddWithValue("@ProductID", comboBox2.SelectedValue);
                command.Parameters.AddWithValue("@Quantity", int.Parse(Quantity.Text));
                command.Parameters.AddWithValue("@Price", decimal.Parse(Price.Text));
                quantityOfProducts.Add(int.Parse(Quantity.Text));
                PriceOfProducts.Add(double.Parse(Price.Text));
                dbManager.connection.Open();
                command.ExecuteNonQuery();
                dbManager.connection.Close();
            }
        }

        private void updateAmountOfProduct()
        {
            int AllQuantity = 0;

            // تأكد من تطابق اسم المتغير في الاستعلام مع المعامل الذي سيتم إضافته
            string query = "UPDATE Orders SET TotalAmount = @TotalAmount WHERE OrderID = @OrderID";

            for (int i = 0; i < quantityOfProducts.Count; i++)
            {
                AllQuantity += quantityOfProducts[i];
            }

            using (SqlCommand command = new SqlCommand(query, dbManager.connection))
            {
                // إضافة المعاملات الصحيحة
                command.Parameters.AddWithValue("@OrderID", orderId);
                command.Parameters.AddWithValue("@TotalAmount", AllQuantity);

                dbManager.connection.Open();
                command.ExecuteNonQuery();
                dbManager.connection.Close();
            }
        }

        private void AddInvoiceToDatabase()
        {
            string query = "INSERT INTO Invoice (OrderID, TotalPrice, TotalAmount) VALUES (@OrderID, @TotalPrice, @TotalAmount)";

            int AllQuantity = 0;
            double AllPrice = 0;

            for (int i = 0; i < quantityOfProducts.Count ; i++)
            {
                AllQuantity += quantityOfProducts[i];
            }

            for (int i = 0; i < PriceOfProducts.Count; i++)
            {
                AllPrice += PriceOfProducts[i] * quantityOfProducts[i];
            }

            using (SqlCommand command = new SqlCommand(query, dbManager.connection))
            {

                command.Parameters.AddWithValue("@OrderID", orderId);
                command.Parameters.AddWithValue("@TotalPrice", AllPrice);
                command.Parameters.AddWithValue("@TotalAmount", AllQuantity);
                dbManager.connection.Open();
                command.ExecuteNonQuery();
                dbManager.connection.Close();
            }
        }
        private void Done_Click_1(object sender, EventArgs e)
        {
            updateAmountOfProduct();
            AddInvoiceToDatabase();
            this.Close();
        }
    }
}
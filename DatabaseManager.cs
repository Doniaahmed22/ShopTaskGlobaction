using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFluentDesign
{

    public class DatabaseManager
    {
        private string connectionString = "Data Source=.;Initial Catalog=Shop;Integrated Security=True;";
    public SqlConnection connection;
    public DataTable CustomersTable { get; private set; }
    public DataTable CategoriesTable { get; private set; }
    public DataTable ProductsTable { get; private set; }
    public DataTable OrderTable { get; private set; }
    public DataTable InvoiceTable { get; private set; }
    public DataTable OrderDetailsTable { get; private set; }
    public DataTable ProductCategoryTable { get; private set; }

    public DatabaseManager()
    {
        connection = new SqlConnection(connectionString);
        CustomersTable = new DataTable();
        CategoriesTable = new DataTable();
        ProductsTable = new DataTable();
        OrderTable = new DataTable();
        InvoiceTable = new DataTable();
        OrderDetailsTable = new DataTable();
        ProductCategoryTable = new DataTable();
        LoadData();
    }

    private void LoadData()
    {
        RefreshData(); // قم بتحميل البيانات للمرة الأولى عند إنشاء الكائن
    }

    public void RefreshData()
    {
        // إعادة تحميل بيانات العملاء
        CustomersTable.Clear();
        SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customer", connection);
        customersAdapter.Fill(CustomersTable);

        // إعادة تحميل بيانات الفئات
        CategoriesTable.Clear();
        SqlDataAdapter categoriesAdapter = new SqlDataAdapter("SELECT * FROM Category", connection);
        categoriesAdapter.Fill(CategoriesTable);

        // إعادة تحميل بيانات المنتجات
        ProductsTable.Clear();
        SqlDataAdapter productsAdapter = new SqlDataAdapter("SELECT * FROM Product", connection);
        productsAdapter.Fill(ProductsTable);

        // إعادة تحميل بيانات الطلبات
        OrderTable.Clear();
        SqlDataAdapter OrdersAdapter = new SqlDataAdapter("SELECT * FROM Orders", connection);
        OrdersAdapter.Fill(OrderTable);

        // إعادة تحميل بيانات تفاصيل الطلبات
        OrderDetailsTable.Clear();
        SqlDataAdapter OrderDetailssAdapter = new SqlDataAdapter("select * from OrderDetail", connection);
        OrderDetailssAdapter.Fill(OrderDetailsTable);

        // إعادة تحميل بيانات الفواتير
        InvoiceTable.Clear();
        SqlDataAdapter InvoiceAdapter = new SqlDataAdapter("select * from Invoice", connection);
        InvoiceAdapter.Fill(InvoiceTable);
    }

    public DataTable ExecuteQuery(string query)
    {
        DataTable result = new DataTable();

        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(result);
        }
        catch (Exception ex)
        {
            // هنا ممكن تضيف معالجة للخطأ أو تسجيله
            Console.WriteLine("Error: " + ex.Message);
        }

        return result;
    }



    }
}

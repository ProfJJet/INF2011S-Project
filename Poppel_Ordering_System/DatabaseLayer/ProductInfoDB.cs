using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poppel_Ordering_System.DatabaseLayer;
using Poppel_Ordering_System.Entities;

namespace Poppel_Ordering_System.DatabaseLayer
{
    class ProductInfoDB:DB
    {
        #region Fields
        string table1 = "Product";
        private Collection<Product> products;
        private Collection<Product> expiredProducts;
        #endregion

        #region Property Methods
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        public Collection<Product> ExpiredProducts
        {
            get { return expiredProducts; }
        }
        #endregion

        #region Constructor
        public ProductInfoDB(): base()
        {
            products = new Collection<Product>();
            expiredProducts = new Collection<Product>();
            ReadDataFromTable("SELECT * FROM Product", products);
            ReadDataFromTable("SELECT * FROM Product WHERE Expiry < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", expiredProducts);
        }
        #endregion

        #region Data Reader
        public void FillProducts(SqlDataReader reader, Collection<Product> products)
        {
            Product product;
            while (reader.Read())
            {
                product = new Product();
                product.ProductNum = reader.GetInt32(0);
                product.Name = reader.GetString(1).Trim();
                product.Price = reader.GetDecimal(2);
                product.Stock = reader.GetInt32(3);
                product.Supplier = reader.GetString(4).Trim();
                product.Description = reader.GetString(5).Trim();
                product.Expiry = reader.GetDateTime(6);
                product.Shelf = reader.GetInt32(7);
                products.Add(product);
            }
        }

        private string ReadDataFromTable(string selectString, Collection<Product> output)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows) { FillProducts(reader, output); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }
        #endregion

        #region CRUD methods
        public  void Reserve(int productNum, int quantity)
        {
            string strSQL = "UPDATE Product SET Stock = Stock - " + quantity + " WHERE ProductNum = " + productNum;
            UpdateDataSource(new SqlCommand(strSQL, cnMain));

        }
        public Collection<Product> RefreshProducts()
        {
            products = new Collection<Product>();
            ReadDataFromTable("SELECT * FROM Product", products);
            return products;
        }
        public string GetValueString(Product tempProd)
        {

            string aStr;
            aStr = tempProd.ProductNum + ", ' " + tempProd.Name + " ' ," +
             " ' " + tempProd.Price + " ' ," +
             " ' " + tempProd.Stock + " ' , " +
             " ' " + tempProd.Supplier + " ' , " + tempProd.Description + " '";
            return aStr;
        }

        public void DatabaseAdd(Product tempProd)
        {

            string strSQL = "INSERT into Product(ProductNum, Name, Price, Stock, Supplier, Description)" +
                "VALUES(" + GetValueString(tempProd) + ")";

            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }

        public void DatabaseEdit(Product tempProd)
        {
            string sqlString = "";

            sqlString = "Update Product Set Name = '" + tempProd.Name.Trim() + "'," +
                              "Price = '" + tempProd.Price + "'," +
                              "Stock = '" + tempProd.Stock + "'," +
                              "Suplier = '" + tempProd.Supplier.Trim() + "'," +
                              "Description = '" + tempProd.Description.Trim() + "'," +
                               "WHERE (ProductNum = '" + tempProd.ProductNum + "')";

            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }
        #endregion
    }
}

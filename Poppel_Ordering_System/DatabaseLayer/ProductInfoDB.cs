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
        string sql_SELECT1 = "SELECT * FROM Product";
        private Collection<Product> products;
        #endregion

        #region Property Methods
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        #endregion

        #region Constructor
        public ProductInfoDB(): base()
        {
            products = new Collection<Product>();
            ReadDataFromTable(sql_SELECT1, table1);
        }
        #endregion

        #region Data Reader
        public void FillProducts(SqlDataReader reader, string dataTable, Collection<Product> products)
        {
            Product product;
            while (reader.Read())
            {
                product = new Product();
                product.ProductNum = reader.GetInt32(0);
                product.Name = reader.GetString(1).Trim();
                product.Price = reader.GetFloat(2);
                product.Stock = reader.GetInt32(3);
                product.Supplier = reader.GetString(4).Trim();
                product.Description = reader.GetString(5).Trim();
                products.Add(product);
            }
        }

        private string ReadDataFromTable(string selectString, string table)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows) { FillProducts(reader, table, products); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }

        #endregion

    }
}

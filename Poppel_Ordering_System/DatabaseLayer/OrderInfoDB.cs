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
    class OrderInfoDB:DB
    {
        #region Fields
        string table1 = "Order";
        string sql_SELECT1 = "SELECT * FROM Order";
        private Collection<Order> orders;
        #endregion

        #region Property Methods
        public Collection<Order> AllOrders
        {
            get { return orders; }
        }
        #endregion

        #region Constructor
        public OrderInfoDB(): base()
        {
            orders = new Collection<Order>();
            ReadDataFromTable(sql_SELECT1, table1);
        }
        #endregion

        #region Data Reader
        public void FillOrders(SqlDataReader reader, string dataTable, Collection<Order> orders)
        {
            Order order;
            while (reader.Read())
            {
                order = new Order();
                order.OrderNum = reader.GetInt32(0);
                int customerNum = reader.GetInt32(1);
//TODO: fix line below
                //order.Customer = FindCustomer(customerNum);
                order.DatePlaced = reader.GetDateTime(2);
                order.DateShipped = reader.GetDateTime(3);
                order.DeliveryAddress = reader.GetString(4).Trim();
                Enum.TryParse(reader.GetString(5).Trim(), out OrderStatus myStatus);
                order.Status = myStatus;
//TODO fix line below:
                //private Collection<OrderItem> items = reader.GetInt32(4);
                orders.Add(order);
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
                if (reader.HasRows) { FillOrders(reader, table, orders); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }

        #endregion

    }
}

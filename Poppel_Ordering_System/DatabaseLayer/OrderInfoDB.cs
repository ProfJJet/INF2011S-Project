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
        private Collection<Order> orders;
        private int custNum;
        #endregion

        #region Property Methods
        public Collection<Order> AllCustOrders
        {
            get 
            { 
                orders = new Collection<Order>();
                string sql_SELECT = "SELECT * FROM Orders WHERE CustomerNum="+custNum;
                ReadDataFromTable(sql_SELECT);
                return orders;
            }
        }
        public Collection<Order> AllOrders
        {
            get 
            { 
                orders = new Collection<Order>();
                string sql_SELECT = "SELECT * FROM Orders";
                ReadDataFromTable(sql_SELECT);
                return orders;
            }
        }
        public int NextInt
        {
            get 
            { 
                SqlCommand command = new SqlCommand("SELECT MAX(OrderNum) FROM Orders", cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int max = reader.GetInt32(0);
                reader.Close();
                cnMain.Close();
                return max + 1;
            }
        }
        #endregion

        #region Constructor
        public OrderInfoDB(int customerNum): base()
        {
            custNum = customerNum;
        }
        #endregion

        #region Data Reader
        public void FillOrders(SqlDataReader reader, Collection<Order> orders)
        {
            Order order;
            while (reader.Read())
            {
                order = new Order();
                order.OrderNum = reader.GetInt32(0);
                order.CustomerNum = reader.GetInt32(1); 
                order.DatePlaced = reader.GetDateTime(2);
                order.DateShipped = reader.GetDateTime(3);
                order.DeliveryAddress = reader.GetString(4).Trim();
                Enum.TryParse(reader.GetString(5).Trim(), out OrderStatus myStatus);
                order.Status = myStatus;
                orders.Add(order);
            }
        }

        private string ReadDataFromTable(string selectString)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows) { FillOrders(reader, orders); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }
        #endregion

        #region CRUD methods
        public void DatabaseAdd(Order tempOrder)
        {

            string values = tempOrder.OrderNum + ", '" + tempOrder.CustomerNum + "', " +
             " '" + tempOrder.DatePlaced.ToString("yyyyMMdd") + "', " + " '" + tempOrder.DateShipped.ToString("yyyyMMdd") + "', " +
             " '" + tempOrder.DeliveryAddress + "', " + " '" + tempOrder.Status +"'" ;
            string strSQL = "INSERT into Orders(OrderNum, CustomerNum, DatePlace, DateShipped, DeliveryAddress, Status)" + 
                "VALUES(" + values + ")";

            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }
        #endregion
    }
}

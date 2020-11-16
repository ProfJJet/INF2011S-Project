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
        string table1 = "Orders";
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
                ReadDataFromTable(sql_SELECT, table1);
                return orders;
            }
        }
        public Collection<Order> AllOrders
        {
            get 
            { 
                orders = new Collection<Order>();
                string sql_SELECT = "SELECT * FROM Orders";
                ReadDataFromTable(sql_SELECT, table1);
                return orders;
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
        public void FillOrders(SqlDataReader reader, string dataTable, Collection<Order> orders)
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

        #region CRUD methods
        public string GetValueString(Order tempOrder)
        {

            string aStr = tempOrder.OrderNum + ", '" + tempOrder.CustomerNum + "', " +
             " '" + tempOrder.DatePlaced.ToString("yyyyMMdd") + "', " + " '" + tempOrder.DateShipped.ToString("yyyyMMdd") + "', " +
             " '" + tempOrder.DeliveryAddress + "', " + " '" + tempOrder.Status +"'" ;
            return aStr;
        }

        public void DatabaseAdd(Order tempOrder)
        {

            string strSQL = "";
            strSQL = "INSERT into Orders(OrderNum, CustomerNum, DatePlace, DateShipped, DeliveryAddress, Status)" + 
                "VALUES(" + GetValueString(tempOrder) + ")";

            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }

        public void DatabaseUpdateStatus(Order tempOrder)
        {
            string sqlString = "";

            sqlString = "Update Order Set Status = '" + tempOrder.Status + "'," +
                                   "WHERE (OrderNum = '" + tempOrder.OrderNum + "')";
             
            UpdateDataSource(new SqlCommand(sqlString, cnMain));
        }

        public void DatabaseDelete(Order tempOrder)
        {
            string sqlStr = "DELETE FROM Order WHERE OrderNum = '" + tempOrder.OrderNum + "'"; //delete from table Order

            UpdateDataSource(new SqlCommand(sqlStr, cnMain));
        }
        #endregion

        #region Methods
        public Collection<Order> getCustomerOrders(Customer c)
        {
            String sql_GetCustOrders = "SELECT * FROM Order WHERE CustomerNum = " + c.CustomerNum + "";

            ReadDataFromTable(sql_GetCustOrders, table1);

            return orders;
        }
        #endregion
    }
}

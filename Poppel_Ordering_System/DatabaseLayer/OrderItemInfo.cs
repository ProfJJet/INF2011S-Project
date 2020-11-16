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
    class OrderItemInfoDB:DB
    {
        #region Fields
        private Collection<OrderItem> orderItems;
        private int orderNum;
        #endregion

        #region Property Methods
        public Collection<OrderItem> AllOrderItems
        {
            get 
            { 
                orderItems = new Collection<OrderItem>();

                string sql_SELECT = "SELECT * FROM OrderItem WHERE OrderNum="+orderNum;
                ReadDataFromTable(sql_SELECT);
                return orderItems; 
            }
        }
        public int NextInt
        {
            get 
            { 
                SqlCommand command = new SqlCommand("SELECT MAX(OrderItemNum) FROM OrderItem", cnMain);
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
        public OrderItemInfoDB(int orderNum): base()
        {
            this.orderNum = orderNum;
        }
        #endregion

        #region Data Reader
        public void FillOrderItems(SqlDataReader reader, Collection<OrderItem> orderItems)
        {
            OrderItem orderItem;
            while (reader.Read())
            {
                orderItem = new OrderItem();
                orderItem.OrderItemNum = reader.GetInt32(0);
                orderItem.OrderNum = reader.GetInt32(1);
                orderItem.ProductNum = reader.GetInt32(2);
                orderItem.Quantity = reader.GetInt32(3);
                orderItems.Add(orderItem);
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
                if (reader.HasRows) { FillOrderItems(reader, orderItems); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }

        #endregion

        #region CRUD methods
        public void DatabaseAdd(OrderItem tempItem)
        {

            string strSQL = "INSERT into OrderItem(OrderItemNum, OrderNum, ProductNum, Quantity)" +
                            "VALUES(" + tempItem.OrderItemNum + ", "+ tempItem.OrderNum + ", " +
                            tempItem.ProductNum + ", " + tempItem.Quantity + ")";

            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }
        public void DeleteOrder(int orderNum)
        {
            string strSQL = "DELETE FROM OrderItem WHERE OrderNum = " + orderNum;
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
            strSQL = "DELETE FROM Orders WHERE OrderNum = " + orderNum;
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }
        #endregion
    }
}

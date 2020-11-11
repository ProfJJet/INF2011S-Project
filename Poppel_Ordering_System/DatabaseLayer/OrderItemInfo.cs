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
        string table1 = "OrderItem";
        string sql_SELECT1 = "SELECT * FROM OrderItem";
        private Collection<OrderItem> orderItems;
        #endregion

        #region Property Methods
        public Collection<OrderItem> AllOrderItems
        {
            get { return orderItems; }
        }
        #endregion

        #region Constructor
        public OrderItemInfoDB(): base()
        {
            orderItems = new Collection<OrderItem>();
            ReadDataFromTable(sql_SELECT1, table1);
        }
        #endregion

        #region Data Reader
        public void FillOrderItems(SqlDataReader reader, string dataTable, Collection<OrderItem> orderItems)
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
                if (reader.HasRows) { FillOrderItems(reader, table, orderItems); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }

        #endregion

    }
}

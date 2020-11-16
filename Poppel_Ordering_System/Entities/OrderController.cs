using Poppel_Ordering_System.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    public class OrderController
    {
        #region Properties
        OrderInfoDB orderDB;
        private Collection<Order> custOrders;
        private Collection<Order> allOrders;
        int custNum;
        #endregion

        #region Property methods
        public Collection<Order> AllCustOrders
        {
            get { return custOrders; }
        }
        public int NextID
        {
            get { return orderDB.NextInt; }
        }
        #endregion

        #region Constructor
        public OrderController(int customerNum)
        {
            custNum = customerNum;
            orderDB = new OrderInfoDB(custNum);
            custOrders = orderDB.AllCustOrders;
            allOrders = orderDB.AllOrders;
        }
        #endregion

        #region CRUD methods
        public void AddOrder(Order order)
        {
            custOrders.Add(order);
            orderDB.DatabaseAdd(order);
        }
        #endregion

        #region search methods
        public int FindOrderIndex(Order order)
        {
            int index = 0;
            bool found = false;
            while (!found && index < custOrders.Count)
            {
                found = (custOrders[index].OrderNum == order.OrderNum);
                if (!found) { index++; }
            }
            if (found) { return index; }
            else { return -1; }
        }

        public Order FindOrderByID(string IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == custOrders[position].OrderNum.ToString());
            while (!found && position < custOrders.Count)
            {
                found = (IDvalue == custOrders[position].OrderNum.ToString());
                if (!found) { position += 1; }
            }
            if (found) { return custOrders[position]; }
            else { return null; }
        }

        #endregion
    }
}

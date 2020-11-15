using Poppel_Ordering_System.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    class OrderItemController
    {
        #region Properties
        OrderItemInfoDB itemDB;
        private Collection<OrderItem> orderItems;
        int orderNum;
        #endregion

        #region Property methods
        public Collection<OrderItem> AllOrderItems
        {
            get { return orderItems; }
        }
        #endregion

        #region Constructor
        public OrderItemController(int orderNum)
        {
            this.orderNum = orderNum;
            itemDB = new OrderItemInfoDB(orderNum);
            orderItems = itemDB.AllOrderItems;
        }
        #endregion

        #region search methods
        public int FindItemIndex(OrderItem item)
        {
            int index = 0;
            bool found = false;
            while (!found && index < orderItems.Count)
            {
                found = (orderItems[index].OrderItemNum == item.OrderItemNum);
                if (!found) { index++; }
            }

            if (found) { return index; }
            else { return -1; }
        }

        public OrderItem FinditemByID(string IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == orderItems[position].OrderItemNum.ToString());
            while (!found && position < orderItems.Count)
            {
                found = (IDvalue == orderItems[position].OrderItemNum.ToString());
                if (!found) { position += 1; }
            }

            if (found) { return orderItems[position]; }
            else { return null; }
        }
        #endregion
        #region CRUD Methods
        public void DeleteOrder() { itemDB.DeleteOrder(orderNum); }
        #endregion
    }
}

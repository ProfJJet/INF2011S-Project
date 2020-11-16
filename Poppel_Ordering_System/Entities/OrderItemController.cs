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
        public int NextID
        {
            get { return itemDB.NextInt; }
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

        #region CRUD methods
        public void AddItem(OrderItem order) { itemDB.DatabaseAdd(order); }
        public void DeleteOrder() { itemDB.DeleteOrder(orderNum); }
        #endregion
    }
}

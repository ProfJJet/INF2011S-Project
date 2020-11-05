using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    enum OrderStatus { New_Order, On_Hold, Shipped, Delivered, Closed }
    class Order
    {
        #region Order Fields
        private int orderNum;
        private DateTime datePlaced;
        private DateTime dateShipped;
        private OrderStatus status;
        private OrderItem[] items;
        #endregion


        #region Order Property Methods

        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }

        public DateTime DatePlaced
        {
            get { return datePlaced; }
            set { datePlaced = value; }
        }

        public DateTime DateShipped
        {
            get { return dateShipped; }
            set { dateShipped = value; }
        }

        public OrderStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public OrderItem[]  Items
        {
            get { return items ; }
            set { items  = value; }
        }
        #endregion
    }
}

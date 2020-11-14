using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    enum OrderStatus { New_Order, On_Hold, Invoiced, Shipped, Delivered, Closed }
    enum OrderChangeType { Status, Item}
    class Order
    {
        #region Order Fields
        private int orderNum;
        private int customerNum;
        private DateTime datePlaced;
        private DateTime dateShipped;
        private String deliveryAddress;
        private OrderStatus status;
        #endregion

        #region Order Property Methods

        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }
        public int CustomerNum
        {
            get { return customerNum; }
            set { customerNum = value; }
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

        public String DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        public OrderStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Constructors
        public Order(int orderNum, int customerNum, DateTime datePlaced, DateTime dateShipped, String deliveryAddress, OrderStatus status)
        {
            this.OrderNum = orderNum;
            this.CustomerNum = customerNum;
            this.DatePlaced = datePlaced;
            this.DateShipped = dateShipped;
            this.DeliveryAddress = deliveryAddress;
            this.Status = status;
        }
        public Order()
        {
            this.OrderNum = 0;
            this.CustomerNum = 0;
            this.DatePlaced = DateTime.MinValue;
            this.DateShipped = DateTime.MinValue;
            this.DeliveryAddress = "";
            this.Status = OrderStatus.New_Order;
        }
        #endregion

        #region Methods
            
        #endregion
    }
}
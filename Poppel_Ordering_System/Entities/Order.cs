using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Customer customer;
        private DateTime datePlaced;
        private DateTime dateShipped;
        private String deliveryAddress;
        private OrderStatus status;
        private Collection<OrderItem> items;
        #endregion


        #region Order Property Methods

        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
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

        public Collection<OrderItem> Items
        {
            get { return items; }
            set { items = value; }
        }
        #endregion

        #region Constructors
        public Order(int orderNum, Customer customer, DateTime datePlaced, DateTime dateShipped, String deliveryAddress, OrderStatus status, Collection<OrderItem> items)
        {
            this.OrderNum = orderNum;
            this.Customer = customer;
            this.DatePlaced = datePlaced;
            this.DateShipped = dateShipped;
            this.DeliveryAddress = deliveryAddress;
            this.Status = status;
            this.Items = items;
        }
        public Order()
        {
            this.OrderNum = 0;
            this.Customer = null;
            this.DatePlaced = DateTime.MinValue;
            this.DateShipped = DateTime.MinValue;
            this.DeliveryAddress = "";
            this.Status = OrderStatus.New_Order;
            this.Items = null;
        }
        #endregion
    }
}
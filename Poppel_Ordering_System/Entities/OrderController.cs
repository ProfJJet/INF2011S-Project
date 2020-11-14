using Poppel_Ordering_System.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    class OrderController
    {
        #region Properties
        OrderInfoDB orderDB;
        OrderItemInfoDB itemDB;
        private Collection<OrderItem> items;
        private Collection<Order> orders;
        #endregion

        #region Property methods
        public Collection<Order> AllOrders
        {
            get { return orders; }
        }
        #endregion

        #region Constructor
        public OrderController()
        {
            orderDB = new OrderInfoDB();
            orders = orderDB.AllOrders;
            items = itemDB.AllOrderItems;
        }
        #endregion

        #region CRUD methods
        public void AddOrder(Order o)
        {
            orders.Add(o);
            orderDB.DatabaseAdd(o);

            foreach (OrderItem item in o.Items)
            {
                itemDB.DatabaseAdd(o, item);
            }
        }

        public void EditOrder(Order o, OrderChangeType type)
        {
            int ordInd = FindOrderIndex(o); //index of order in Collection orders
            int itemInd = 0; //initiate item index in Collection items

            //If the type of the edit is an item edit
            if (type == OrderChangeType.Item)
            {
                if (orders[ordInd].Status < OrderStatus.Invoiced)
                {
                    foreach(OrderItem item in o.Items)
                    {
                        itemDB.DatabaseEdit(item);

                        itemInd = FindItemIndex(item);
                        items[itemInd].Quantity = item.Quantity;
                    }
                }
                else
                {
                    //TODO: Display "error can't change now"
                }
            }
            else
            {
                orderDB.DatabaseUpdateStatus(o);
                orders[ordInd].Status = o.Status;
            }
        }

        public void DeleteOrder(Order o)
        {
            itemDB.DatabaseDelete(o);
            orderDB.DatabaseDelete(o);
        }

        public void RemoveItem(Order o, OrderItem i)
        {
            itemDB.DatabaseRemoveItem(o, i);
        }
        #endregion

        #region search methods
        public int FindOrderIndex(Order order)
        {
            int index = 0;
            bool found = false;
            while (!found && index < orders.Count)
            {
                found = (orders[index].OrderNum == order.OrderNum);
                if (!found)
                {
                    index++;
                }
            }
            if (found)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public Order FindOrderByID(string IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == orders[position].OrderNum.ToString());
            while (!found && position < orders.Count)
            {
                found = (IDvalue == orders[position].OrderNum.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return orders[position];
            }
            else
            {
                return null;
            }
        }

        public int FindItemIndex(OrderItem item)
        {
            int index = 0;
            bool found = false;
            while (!found && index < items.Count)
            {
                found = (items[index].OrderItemNum == item.OrderItemNum);
                if (!found)
                {
                    index++;
                }
            }
            if (found)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public OrderItem FinditemByID(string IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == items[position].OrderItemNum.ToString());
            while (!found && position < items.Count)
            {
                found = (IDvalue == items[position].OrderItemNum.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return items[position];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

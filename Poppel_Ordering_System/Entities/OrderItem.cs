using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    class OrderItem
    {
        #region OrderItem Fields
        private int orderItemNum;
        private int orderNum;
        private int productNum;
        private int quantity;
        #endregion

        #region OrderItem Property Methods
        public int OrderItemNum
        {
            get { return orderItemNum; }
            set { orderItemNum = value; }
        }
        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }

        public int ProductNum
        {
            get { return productNum; }
            set { productNum = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        public OrderItem()
        {
            this.OrderItemNum = 0;
            this.OrderNum = 0;
            this.ProductNum = 0;
            this.Quantity = 0;
        }
        public OrderItem( int orderItemNum, int orderNum, int productNum, int quantity )
        {
            this.OrderItemNum = orderItemNum;
            this.OrderNum = orderNum;
            this.ProductNum = productNum;
            this.Quantity = quantity;
        }
        #endregion
    }
}

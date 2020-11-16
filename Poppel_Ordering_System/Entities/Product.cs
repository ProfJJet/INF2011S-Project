using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    class Product
    {
        #region Product Fields
        private int productNum;
        private string name;
        private decimal price;
        private int stock;
        private string supplier;
        private string description;
        private DateTime expiry;
        #endregion

        #region Product Property Methods

        public int ProductNum
        {
            get { return productNum; }
            set { productNum = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime Expiry
        {
            get { return expiry; }
            set { expiry = value; }
        }
        #endregion
        
        #region Constructors
        public Product( int productNum, string name, decimal price, int stock, string supplier, string address, string creditStatus, int creditLimit, string description, DateTime expiry)
        {
            this.ProductNum = productNum;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Supplier = supplier;
            this.Description = description;
            this.Expiry = expiry;
        }
        public Product()
        {
            this.ProductNum = 0;
            this.Name = "";
            this.Price = 0;
            this.Stock = 0;
            this.Supplier = "";
            this.Description = "";
            this.Expiry = DateTime.MinValue;
        }
        #endregion
    }
}

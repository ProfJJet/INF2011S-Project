using Poppel_Ordering_System.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    class ProductController
    {
        #region Properties
        ProductInfoDB productDB;
        private Collection<Product> products;
        private Collection<Product> expiredProducts;
        #endregion

        #region Property methods
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        public Collection<Product> ExpiredProducts
        {
            get { return expiredProducts; }
        }
        #endregion

        #region Constructor
        public ProductController()
        {
            productDB = new ProductInfoDB();
            products = productDB.AllProducts;
            expiredProducts = productDB.ExpiredProducts;
        }
        #endregion

        #region CRUD methods
        public void Reserve(int productNum, int quantity) { productDB.Reserve(productNum, quantity); }
        public void Unreserve(int productNum, int quantity) { productDB.Reserve(productNum, quantity*(-1)); }
        public void Refresh() { products = productDB.RefreshProducts(); }
        #endregion

        #region search methods
        public Product FindByID(int productNum)
        {
            int position = 0;
            bool found = (productNum == products[position].ProductNum);
            while (!found && position < products.Count)
            {
                found = (productNum == products[position].ProductNum);
                if (!found) { position += 1; }
            }
            if (found) { return products[position]; }
            else { return null; }
        }
        #endregion
    }
}

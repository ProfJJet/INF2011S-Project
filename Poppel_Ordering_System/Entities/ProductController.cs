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
        #endregion

        #region Property methods
        public Collection<Product> AllProducts
        {
            get { return products; }
        }
        #endregion

        #region Constructor
        public ProductController()
        {
            productDB = new ProductInfoDB();
            products = productDB.AllProducts;
        }
        #endregion

        #region CRUD methods
        public void Addproduct(Product p)
        {
            products.Add(p);
            productDB.DatabaseAdd(p);
        }

        public void EditProduct(Product p)
        {
            int ind = FindIndex(p);

            products[ind].Name = p.Name;
            products[ind].Price = p.Price;
            products[ind].Stock = p.Stock;
            products[ind].Supplier = p.Supplier;
            products[ind].Description = p.Description;

            productDB.DatabaseEdit(p);
        }
        #endregion

        #region search methods
        public int FindIndex(Product product)
        {
            int index = 0;
            bool found = false;
            while (!found && index < products.Count)
            {
                found = (products[index].ProductNum == product.ProductNum);
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

        public Product FindByID(int productNum)
        {
            int position = 0;
            Console.WriteLine(products.Count);
            Console.WriteLine(productNum);
            bool found = (productNum == products[position].ProductNum);
            while (!found && position < products.Count)
            {
                Console.WriteLine(products[position].ProductNum);
                found = (productNum == products[position].ProductNum);
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return products[position];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

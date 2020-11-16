using Poppel_Ordering_System.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    public class CustomerController
    {
        #region Properties
        CustomerInfoDB custDB;
        private Collection<Customer> customers;
        #endregion

        #region Property methods
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        public int NextID
        {
            get { return custDB.NextInt; }
        }
        #endregion

        #region Constructor
        public CustomerController()
        {
            custDB = new CustomerInfoDB();
            customers = custDB.AllCustomers;
        }
        #endregion

        #region CRUD methods
        public void AddCustomer(Customer c)
        {
            customers.Add(c);
            custDB.DatabaseAdd(c);
        }
        #endregion

        #region search methods
        public Customer FindByCustNum(string IDvalue)
        {
            int position = 0;
            bool found = (IDvalue == customers[position].CustomerNum.ToString());
            while (!found && position < customers.Count)
            {
                found = (IDvalue == customers[position].CustomerNum.ToString());
                if (!found)
                {
                    position += 1;
                }
            }
            if (found)
            {
                return customers[position];
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

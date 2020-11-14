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
            get { return customers.Last().CustomerNum + 1; }
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

        public void EditCustomer(Customer c)
        {
            int ind = FindIndex(c);

            customers[ind].Name = c.Name;
            customers[ind].Email = c.Email;
            customers[ind].PhoneNum = c.PhoneNum;
            customers[ind].Address = c.Address;
            customers[ind].CreditStatus = c.CreditStatus;
            customers[ind].CreditLimit = c.CreditLimit;
            customers[ind].Blacklisted = c.Blacklisted;

            custDB.DatabaseEdit(c);
        }
        #endregion

        #region search methods
        public int FindIndex(Customer customer)
        {
            int index = 0;
            bool found = false;
            while (!found && index < customers.Count)
            {
                found = (customers[index].CustomerNum == customer.CustomerNum);
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

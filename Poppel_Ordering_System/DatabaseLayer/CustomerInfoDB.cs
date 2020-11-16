using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poppel_Ordering_System.DatabaseLayer;
using Poppel_Ordering_System.Entities;

namespace Poppel_Ordering_System.DatabaseLayer
{
    class CustomerInfoDB:DB
    {
        #region Fields
        string sql_SELECT1 = "SELECT * FROM Customer";
        private Collection<Customer> customers;
        #endregion

        #region Property Methods
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        public int NextInt
        {
            get 
            { 
                SqlCommand command = new SqlCommand("SELECT MAX(CustomerNum) FROM Customer", cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int max = reader.GetInt32(0);
                reader.Close();
                cnMain.Close();
                return max + 1;
            }
        }
        #endregion

        #region Constructor
        public CustomerInfoDB(): base()
        {
            customers = new Collection<Customer>();
            ReadDataFromTable(sql_SELECT1);
        }
        #endregion

        #region Data Reader
        public void FillCustomers(SqlDataReader reader, Collection<Customer> customers)
        {
            Customer customer;
            while (reader.Read())
            {
                customer = new Customer();
                customer.CustomerNum = reader.GetInt32(0);
                customer.Name = reader.GetString(1).Trim();
                customer.Email = reader.GetString(2).Trim();
                customer.PhoneNum = reader.GetString(3).Trim();
                customer.Address = reader.GetString(4).Trim();
                customer.CreditStatus = reader.GetString(5).Trim();
                customer.CreditLimit = reader.GetInt32(6);
                customer.Blacklisted = reader.GetBoolean(7);
                customers.Add(customer);
            }
        }

        private string ReadDataFromTable(string selectString)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(selectString, cnMain);
                cnMain.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows) { FillCustomers(reader, customers); }
                reader.Close();
                cnMain.Close();
                return "success";
            }
            catch (Exception ex) { return (ex.ToString()); }
        }

        #endregion

        #region CRUD methods
        public void DatabaseAdd(Customer tempCust)
        {
            string values = tempCust.CustomerNum + ", '" + tempCust.Name + "', " + " '" + tempCust.Email + "', " +
                            " '" + tempCust.PhoneNum + "', " + " '" + tempCust.Address + " ', " + " '" + tempCust.CreditStatus + "', " +
                            tempCust.CreditLimit + ", " + Convert.ToString(tempCust.Blacklisted ? 1 : 0);

            string strSQL = "INSERT INTO Customer (CustomerNum, Name, Email, PhoneNum, Address, CreditStatus, CreditLimit, BlackListed)" +
                "VALUES ( " + values + ")";
            UpdateDataSource(new SqlCommand(strSQL, cnMain));
        }
        #endregion
    }
}

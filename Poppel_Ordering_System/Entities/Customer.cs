using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poppel_Ordering_System.Entities
{
    public class Customer
    {
        #region Customer Fields
        private int customerNum;
        private string name;
        private string email;
        private string phoneNum;
        private string address;
        private string creditStatus;
        private int creditLimit;
        private bool blacklisted;
        #endregion

        #region Customer Property Methods
        public int CustomerNum
        {
            get { return customerNum; }
            set { customerNum = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string CreditStatus
        {
            get { return creditStatus; }
            set { creditStatus = value; }
        }

        public int CreditLimit
        {
            get { return creditLimit; }
            set { creditLimit = value; }
        }

        public bool Blacklisted
        {
            get { return blacklisted; }
            set { blacklisted = value; }
        }
        #endregion

        #region Constructors
        public Customer( int customerNum, string name, string email, string phoneNum, string address, string creditStatus, int creditLimit, bool blacklisted )
        {
            this.CustomerNum = customerNum;
            this.Name = name;
            this.Email = email;
            this.PhoneNum = phoneNum;
            this.Address = address;
            this.CreditStatus = creditStatus;
            this.CreditLimit = creditLimit;
            this.Blacklisted = blacklisted;
        }
        public Customer()
        {
            this.CustomerNum = 0;
            this.Name = "";
            this.Email = "";
            this.PhoneNum = "";
            this.Address = "";
            this.CreditStatus = "";
            this.CreditLimit = 0;
            this.Blacklisted = false;
        }
        #endregion
    }
}

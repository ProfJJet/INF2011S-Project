using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poppel_Ordering_System.Entities;

namespace Poppel_Ordering_System.PresentationLayer
{
    public partial class AddCustomerForm : Form
    {
        #region Fields
        public bool addCustFormClosed = false;
        public CustomerController custController;
        MainForm mainForm;
        private int custNum;
        #endregion
        public AddCustomerForm(int custNum)
        {
            InitializeComponent();
            custController = new CustomerController();
            PopulateForm(custNum);
        }

        #region Methods
        private Customer CreateCust()
        {
            if (CustNameTB.Text == "") { MessageBox.Show("Customer Name is empty", "Empty Field"); return null; }
            if (CustEmailTB.Text == "") { MessageBox.Show("Customer Email is empty", "Empty Field"); return null; }
            if (CustPhoneTB.Text == "") { MessageBox.Show("Default Address is empty", "Empty Field"); return null; }
            if (CustAddressTB.Text == "") { MessageBox.Show("Phone Number is empty", "Empty Field"); return null; }
            if (CustCredLimTB.Text == "") { MessageBox.Show("Credit Limit is empty", "Empty Field"); return null; }
            
            int credLim = -1;
            try { credLim = Convert.ToInt32(CustCredLimTB.Text); }
            catch (Exception) { }
            if (credLim < 0) { MessageBox.Show("Credit Limit must be a postive integer", "Invalid Credit Limit"); return null; }
            return new Customer(
                custNum,
                CustNameTB.Text,
                CustEmailTB.Text,
                CustPhoneTB.Text,
                CustAddressTB.Text,
                "paid", credLim,
                false);
        }
        public void PopulateForm(int customerNum)
        {
            CustNumLabel.Text = Convert.ToString(customerNum);
            this.custNum = customerNum;
        }

        #endregion

        #region Form Methods
        private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addCustFormClosed = true;
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
        }

        private void AddCustomerForm_Activated(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
        }
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            Customer cust = CreateCust();
            if (cust == null) { return; }
            mainForm.custControl.AddCustomer(cust);
            custNum++;
            this.Close();
            mainForm.CreateProfileForm(cust);
        }
        #endregion

    }
}

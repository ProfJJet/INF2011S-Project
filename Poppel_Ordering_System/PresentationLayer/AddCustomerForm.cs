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
            return new Customer(
                custNum,
                CustNameTB.Text,
                CustEmailTB.Text,
                CustPhoneTB.Text,
                CustAddressTB.Text,
                "paid",
                Convert.ToInt32(CustCredLimTB.Text),
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
            mainForm.custControl.AddCustomer(cust);
            custNum++;
            this.Close();
            mainForm.CreateProfileForm(cust);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ProfileForm : Form
    {
        #region Fields
        public bool profileFormClosed = false;
        MainForm mainForm;
        private Customer cust;
        #endregion

        #region Constructor
        public ProfileForm(Customer cust)
        {
            InitializeComponent();
            PopulateForm(cust);
        }
        #endregion

        #region Methods
        public void PopulateForm(Customer customer)
        {
            cust = customer;
            CustNumLabel.Text = Convert.ToString(cust.CustomerNum);
            CustNameLabel.Text = cust.Name;
            CustEmailLabel.Text = cust.Email;
            CustAddressLabel.Text = cust.Address;
            CustPhoneLabel.Text = cust.PhoneNum;
            CustStatusLabel.Text = cust.CreditStatus;
            CustCredLimLabel.Text = "R" + Convert.ToString(cust.CreditLimit);
            CustBlackLabel.Text = cust.Blacklisted ? "true" : "false";
        }
        #endregion

        #region Form Methods
        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            profileFormClosed = true;
        }
        private void ProfileForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
        }
        private void ProfileForm_Activated(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
        }
        #endregion
        //	32	Wimpy	root@wimpy.co.za	084 621 5082	1739 Albert St, Katlehong, Gauteng	overdue	93000	True
    }
}

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
        #region Properties
        public Customer customer;
        public Collection<Customer> customers;
        //public CustomerController custContr;
        #endregion

        #region Constructor
        public ProfileForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public void Display()
        {

        }
        #endregion

        #region Events
        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

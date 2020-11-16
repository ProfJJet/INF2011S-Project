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
    public partial class MainForm : Form
    {
        #region Fields
        public ProfileForm profileForm;
        public AddCustomerForm addCustForm;
        public CustomerController custControl;
        #endregion
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            custControl = new CustomerController();
        }
        #endregion

        #region Methods
        private void CreateNewAddCustForm()
        {
            int custNum = custControl.NextID;
            addCustForm = new AddCustomerForm(custNum);
            addCustForm.MdiParent = this;
            addCustForm.StartPosition = FormStartPosition.CenterScreen;
        }
        public void CreateProfileForm(Customer cust)
        {
            if (profileForm == null || profileForm.profileFormClosed)
            {
                profileForm = new ProfileForm(cust);
                profileForm.MdiParent = this;
                profileForm.StartPosition = FormStartPosition.CenterScreen;
                profileForm.Show();
            }
            else { profileForm.PopulateForm(cust); }
        }
        #endregion

        #region Form Methods
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            if (addCustForm == null || addCustForm.addCustFormClosed) { CreateNewAddCustForm(); }
            else { addCustForm.PopulateForm(custControl.NextID); }
            addCustForm.Show();
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Customer cust = custControl.FindByCustNum(SearchTB.Text);
            if (cust is null) 
            { 
                MessageBox.Show("A customer with customer number '" + SearchTB.Text + "' could not be found",
                    "Customer Not Found");
                return;
            }
            else { CreateProfileForm(cust); }

        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            ProductController prodCont = new ProductController();
            Collection<Product> products = prodCont.ExpiredProducts;
            string message;
            if (products.Count == 0) { message = "No Expired Products"; }
            else
            {
                message = "No. \tExpiry Date\n";
                foreach (Product product in products)
                {
                    message += product.ProductNum + " \t" +
                        product.Expiry.ToString("yyyy/MM/dd") + " \n";
                }
            }
            MessageBox.Show(message, "Expired Products");

        }
        #endregion
    }
}

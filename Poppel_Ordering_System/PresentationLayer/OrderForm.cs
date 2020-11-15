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
    public partial class OrderForm : Form
    {
        #region Fields
        public bool orderFormClosed = false;
        public bool newOrder;
        private Customer cust;
        private Order order;
        MainForm mainForm;
        #endregion
        #region Constructor
        public OrderForm(Customer customer, Order order, bool newOrder)
        {
            InitializeComponent();
            PopulateForm(customer, order, newOrder);
        }
        #endregion
        #region Methods
        public void PopulateForm(Customer cust, Order order, bool newOrder)
        {
            this.cust = cust;
            this.order = order;
            this.newOrder = newOrder;
            displayNewButtons(newOrder);
            OrderNumLabel.Text = Convert.ToString(order.OrderNum);
            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd");
            CustNumLabel.Text = Convert.ToString(cust.CustomerNum);
            CustNameLabel.Text = cust.Name;
            CustAddressLabel.Text = cust.Address;
            CustPhoneLabel.Text = cust.PhoneNum;
            setupListView();

        }
        public void displayNewButtons(bool value)
        {
            btnBack.Visible = !value;
            btnCancel.Visible = value;
            btnPlaceOrder.Visible = value;
            btnAddItem.Visible = value;

            switch (order.Status)
            {
                case OrderStatus.New_Order:
                case OrderStatus.On_Hold:
                case OrderStatus.Invoiced:
                    btnCancelOrder.Visible = !value;
                    break;
                default:
                    btnCancelOrder.Visible = false;
                    break;
            }
        }
        public void setupListView()
        {
            ListViewItem itemListItem;
            OrderItemController itemCont = new OrderItemController(order.OrderNum);
            ProductController prodCont = new ProductController();
            Collection<OrderItem> items = itemCont.AllOrderItems;
            itemListView.Clear();
            itemListView.Columns.Insert(0, "Product No.", 150, HorizontalAlignment.Left);
            itemListView.Columns.Insert(1, "Product Name", 350, HorizontalAlignment.Left);
            itemListView.Columns.Insert(2, "Product Price", 100, HorizontalAlignment.Left);
            itemListView.Columns.Insert(3, "Quantity", 100, HorizontalAlignment.Left);
            itemListView.Columns.Insert(4, "Product Total", 100, HorizontalAlignment.Left);
            decimal totalPrice = 0;

            foreach (OrderItem item in items)
            {
                itemListItem = new ListViewItem();
                Product product = prodCont.FindByID(item.ProductNum);
                if (product != null)
                {
                    decimal productTotal = item.Quantity * product.Price;
                    totalPrice += productTotal;
                    itemListItem.Text = product.ProductNum.ToString();
                    itemListItem.SubItems.Add(product.Name);
                    itemListItem.SubItems.Add(product.Price.ToString());
                    itemListItem.SubItems.Add(item.Quantity.ToString());
                    itemListItem.SubItems.Add(productTotal.ToString());
                    itemListView.Items.Add(itemListItem);
                }
            }
            TotalLabel.Text = totalPrice.ToString();
            itemListView.Refresh();
            itemListView.GridLines = true;
        }
        #endregion
        #region Form Methods
        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderFormClosed = true;
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            itemListView.View = View.Details;
            setupListView();
        }
        private void OrderForm_Activated(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            itemListView.View = View.Details;
            setupListView();
        }
        private void btnBack_Click(object sender, EventArgs e) { Close(); }
        #endregion

    }
}

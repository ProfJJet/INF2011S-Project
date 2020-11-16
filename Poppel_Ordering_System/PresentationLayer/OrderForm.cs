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
        public bool submitted = false;
        private ProfileForm profileForm;
        private AddItemForm itemForm;
        private Customer cust;
        private Order order;
        MainForm mainForm;
        #endregion
        #region Constructor
        public OrderForm(Customer customer, Order order, bool newOrder, ProfileForm profileForm)
        {
            InitializeComponent();
            PopulateForm(customer, order, newOrder, profileForm);
        }
        #endregion
        #region Methods
        public void PopulateForm(Customer cust, Order order, bool newOrder, ProfileForm profileForm)
        {
            this.cust = cust;
            this.order = order;
            this.newOrder = newOrder;
            this.profileForm = profileForm;
            displayNewButtons(newOrder);
            OrderNumLabel.Text = Convert.ToString(order.OrderNum);
            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd");
            CustNumLabel.Text = Convert.ToString(cust.CustomerNum);
            CustNameLabel.Text = cust.Name;
            CustAddressLabel.Text = cust.Address;
            CustPhoneLabel.Text = cust.PhoneNum;
            if (newOrder) { AddOrderToDB(); }
        }
        public void AddOrderToDB()
        {
            Order temp = new Order();
            temp.OrderNum = order.OrderNum;
            temp.CustomerNum = cust.CustomerNum;
            temp.DatePlaced = DateTime.Now;
            temp.DeliveryAddress = cust.Address;
            temp.Status = OrderStatus.New_Order;
            profileForm.orderCont.AddOrder(temp);
        }
        public void displayNewButtons(bool value)
        {
            btnBack.Visible = !value;
            btnPicking.Visible = !value;
            btnCancel.Visible = value;
            btnPlaceOrder.Visible = value;
            btnAddItem.Visible = value;

            try
            {
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
            catch (Exception) { btnCancelOrder.Visible = false; }
        }
        public void setupListView()
        {
            submitted = false;
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
        public void DisplayPickingList()
        {
            OrderItemController itemCont = new OrderItemController(order.OrderNum);
            ProductController prodCont = new ProductController();
            Collection<OrderItem> items = itemCont.AllOrderItems;

            string message = "Product No. \t Qty \t Shelf";
            foreach (OrderItem item in items)
            {
                Product product = prodCont.FindByID(item.ProductNum);
                if (product != null)
                {
                    message += "\n" + product.ProductNum.ToString() +
                              " \t\t " + item.Quantity.ToString() +
                              " \t " + product.Shelf.ToString();
                }
            }
            MessageBox.Show(message, "Picking List"); 
        } 
        #endregion
        #region Form Methods
        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderFormClosed = true;
            profileForm.Activate(); 
            if (newOrder && submitted) 
            {
                DisplayPickingList();
                profileForm.setupListView();
            }
            
            if (newOrder && !submitted)
            {
                OrderItemController itemCont = new OrderItemController(order.OrderNum);
                ProductController prodCont = new ProductController();
                Collection<OrderItem> items = itemCont.AllOrderItems;

                foreach (OrderItem item in items) { prodCont.Unreserve(item.ProductNum, item.Quantity); }
                prodCont.Refresh();
                itemCont.DeleteOrder();
                profileForm.setupListView();
            }
            submitted = false;
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

        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
        private void btnCancelOrder_Click(object sender, EventArgs e) { Close(); ; }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            OrderItemController itemCont = new OrderItemController(order.OrderNum);
            OrderItem item = new OrderItem();
            item.OrderItemNum = itemCont.NextID;
            if (itemForm == null || itemForm.itemFormClosed)
            {
                itemForm = new AddItemForm(order, item, this);
                itemForm.MdiParent = this.mainForm;
                itemForm.StartPosition = FormStartPosition.CenterScreen;
                itemForm.Show();
            }
            else { itemForm.PopulateForm(order, item, this); }
            itemListView.Refresh();
        }


        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (TotalLabel.Text == "0") { MessageBox.Show("Cannot place empty order", "Order Empty"); }
            else
            {
                submitted = true;
                Close();
            }
        }
        private void btnPicking_Click(object sender, EventArgs e) { DisplayPickingList(); }
        #endregion

    }
}

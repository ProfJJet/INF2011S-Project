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
    public partial class AddItemForm : Form
    {
        #region Fields
        public bool itemFormClosed = false;
        private OrderForm orderForm;
        private Order order;
        private OrderItem item;
        ProductController prodCont;
        OrderItemController itemCont; 
        MainForm mainForm;
        #endregion
        #region Constructor
        public AddItemForm(Order order, OrderItem orderItem,  OrderForm orderForm)
        {
            InitializeComponent();
            PopulateForm(order, orderItem, orderForm);
            prodCont = new ProductController();
            itemCont = new OrderItemController(order.OrderNum);
        }
        #endregion
        #region Methods
        public void PopulateForm(Order order, OrderItem orderItem,  OrderForm orderForm)
        {
            this.order = order;
            this.item = orderItem;
            this.orderForm = orderForm;
            OrderNumLabel.Text = Convert.ToString(order.OrderNum);
            DateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd");
            priceLabel.Text = "-";
        }
        public void setupListView()
        {
            Collection<Product> products = prodCont.AllProducts;
            ListViewItem productListItem;
            productListView.Clear();
            productListView.Columns.Insert(0, "No.", 40, HorizontalAlignment.Left);
            productListView.Columns.Insert(1, "Price", 60, HorizontalAlignment.Left);
            productListView.Columns.Insert(2, "Stock", 60, HorizontalAlignment.Left);
            productListView.Columns.Insert(3, "Product Name", 300, HorizontalAlignment.Left);
            productListView.Columns.Insert(4, "Supplier", 100, HorizontalAlignment.Left);
            productListView.Columns.Insert(5, "Expiry Date", 150, HorizontalAlignment.Left);
            productListView.Columns.Insert(6, "Description", 350, HorizontalAlignment.Left);

            foreach (Product product in products)
            {
                productListItem = new ListViewItem();
                productListItem.Text = product.ProductNum.ToString();
                productListItem.SubItems.Add(product.Price.ToString());
                productListItem.SubItems.Add(product.Stock.ToString());
                productListItem.SubItems.Add(product.Name);
                productListItem.SubItems.Add(product.Supplier);
                productListItem.SubItems.Add(product.Expiry.ToString("yyyy/MM/dd"));
                productListItem.SubItems.Add(product.Description);
                productListView.Items.Add(productListItem);
            }
            productListView.Refresh();
            productListView.GridLines = true;
        }
        #endregion
        #region Form Methods
        private void AddItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            itemFormClosed = true;
            orderForm.Activate();
        }
        private void AddItemForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            productListView.View = View.Details;
            setupListView();
        }
        private void AddItemForm_Activated(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            productListView.View = View.Details;
            setupListView();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e) { Close(); }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            Product product = null;
            try
            {
                int productNum = Convert.ToInt32(productNumTB.Text);
                product = prodCont.FindByID(productNum);
            }
            catch (Exception) { }
            
            if (product == null) { MessageBox.Show("Invalid Product Number", "Invalid Product Number"); return; }
            int quantity = -1;
            try { quantity = Convert.ToInt32(quantityTB.Text); }
            catch (Exception) { }
            if (quantity <= 0) { MessageBox.Show("Quantity must be a positive integer.", "Invalid Quantity"); return; }
            else if (quantity > product.Stock)
            {
                MessageBox.Show("This product has a current stock level of "+product.Stock, "Not Enough Stock");
                return; 
            }
            OrderItem item = new OrderItem(itemCont.NextID, order.OrderNum, product.ProductNum, quantity);
            itemCont.AddItem(item);
            prodCont.Reserve(product.ProductNum, quantity);
            Close();
        }
        private void productListView_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string prodNum = productListView.FocusedItem.Text;
            productNumTB.Text = prodNum;
            productListView.Refresh();
        }
        private void valueChanged(object sender, EventArgs e)
        {
            try
            {
                Product product = prodCont.FindByID(Convert.ToInt32(productNumTB.Text));
                priceLabel.Text = Convert.ToString(product.Price * Convert.ToInt32(quantityTB.Text));
            }
            catch (Exception) { priceLabel.Text = "-"; }
        }
        #endregion

    }
}

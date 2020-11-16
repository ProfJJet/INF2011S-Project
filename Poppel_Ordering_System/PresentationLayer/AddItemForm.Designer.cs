namespace Poppel_Ordering_System.PresentationLayer
{
    partial class AddItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.priceLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DateLabel = new System.Windows.Forms.Label();
            this.OrderNumLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quantityTB = new System.Windows.Forms.TextBox();
            this.productNumTB = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.productListView = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(723, 539);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(113, 23);
            this.btnPlaceOrder.TabIndex = 44;
            this.btnPlaceOrder.Text = "Add to Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(572, 539);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(118, 23);
            this.btnCancelOrder.TabIndex = 45;
            this.btnCancelOrder.Text = "Cancel";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.priceLabel.Location = new System.Drawing.Point(739, 495);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(64, 20);
            this.priceLabel.TabIndex = 33;
            this.priceLabel.Text = "-----------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(591, 495);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Total Price:        R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Select a Product:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DateLabel);
            this.panel1.Controls.Add(this.OrderNumLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 64);
            this.panel1.TabIndex = 31;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.DateLabel.Location = new System.Drawing.Point(705, 17);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(80, 25);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "--/--/----";
            // 
            // OrderNumLabel
            // 
            this.OrderNumLabel.AutoSize = true;
            this.OrderNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderNumLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.OrderNumLabel.Location = new System.Drawing.Point(120, 17);
            this.OrderNumLabel.Name = "OrderNumLabel";
            this.OrderNumLabel.Size = new System.Drawing.Size(159, 25);
            this.OrderNumLabel.TabIndex = 4;
            this.OrderNumLabel.Text = "---------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(636, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order no:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(609, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Quantity:";
            // 
            // quantityTB
            // 
            this.quantityTB.Location = new System.Drawing.Point(723, 459);
            this.quantityTB.Name = "quantityTB";
            this.quantityTB.Size = new System.Drawing.Size(113, 20);
            this.quantityTB.TabIndex = 43;
            this.quantityTB.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // productNumTB
            // 
            this.productNumTB.Location = new System.Drawing.Point(723, 423);
            this.productNumTB.Name = "productNumTB";
            this.productNumTB.Size = new System.Drawing.Size(113, 20);
            this.productNumTB.TabIndex = 41;
            this.productNumTB.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label.Location = new System.Drawing.Point(587, 421);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(103, 20);
            this.label.TabIndex = 42;
            this.label.Text = "Product No:";
            // 
            // productListView
            // 
            this.productListView.HideSelection = false;
            this.productListView.Location = new System.Drawing.Point(12, 102);
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(554, 460);
            this.productListView.TabIndex = 46;
            this.productListView.UseCompatibleStateImageBehavior = false;
            this.productListView.SelectedIndexChanged += new System.EventHandler(this.productListView_SelectedIndexChanged);
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 574);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.productNumTB);
            this.Controls.Add(this.label);
            this.Controls.Add(this.quantityTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "AddItemForm";
            this.Text = "AddItemForm";
            this.Activated += new System.EventHandler(this.AddItemForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddItemForm_FormClosed);
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label OrderNumLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox quantityTB;
        private System.Windows.Forms.TextBox productNumTB;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListView productListView;
    }
}
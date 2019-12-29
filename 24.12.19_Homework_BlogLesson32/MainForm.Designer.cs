namespace _24._12._19_Homework_BlogLesson32
{
    partial class MainForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.btnGetAllCustomers = new System.Windows.Forms.Button();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.btnMakeOrder = new System.Windows.Forms.Button();
            this.btnMaxOrdersCustomer = new System.Windows.Forms.Button();
            this.btnCustomerPaidMaximum = new System.Windows.Forms.Button();
            this.btnCustomersWithoutOrders = new System.Windows.Forms.Button();
            this.btnOrdersWithoutCustomers = new System.Windows.Forms.Button();
            this.btnPurchasesSumOFEveryCustomer = new System.Windows.Forms.Button();
            this.btnPurchasesAverageOFEveryCustomer = new System.Windows.Forms.Button();
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage = new System.Windows.Forms.Button();
            this.btnTotalPurchasesSumOfAllTheCustomers = new System.Windows.Forms.Button();
            this.btnMostFrequentProduct = new System.Windows.Forms.Button();
            this.btnProductsNotBoughtAtAll = new System.Windows.Forms.Button();
            this.btnCustomersWithoutOrdersByJoin = new System.Windows.Forms.Button();
            this.btnProductsNotBoughtAtAllByJoin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(138, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 84);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(138, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(99, 110);
            this.numAge.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(51, 20);
            this.numAge.TabIndex = 2;
            this.numAge.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 69);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(12, 112);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 13);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age:";
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Location = new System.Drawing.Point(12, 147);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(100, 23);
            this.btnCreateCustomer.TabIndex = 6;
            this.btnCreateCustomer.Text = "Create Customer";
            this.btnCreateCustomer.UseVisualStyleBackColor = true;
            // 
            // btnGetAllCustomers
            // 
            this.btnGetAllCustomers.Location = new System.Drawing.Point(12, 188);
            this.btnGetAllCustomers.Name = "btnGetAllCustomers";
            this.btnGetAllCustomers.Size = new System.Drawing.Size(100, 23);
            this.btnGetAllCustomers.TabIndex = 7;
            this.btnGetAllCustomers.Text = "get all customers";
            this.btnGetAllCustomers.UseVisualStyleBackColor = true;
            this.btnGetAllCustomers.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(522, 12);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(266, 21);
            this.cmbCustomers.TabIndex = 8;
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(522, 44);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(176, 21);
            this.cmbProducts.TabIndex = 9;
            // 
            // btnMakeOrder
            // 
            this.btnMakeOrder.Location = new System.Drawing.Point(713, 42);
            this.btnMakeOrder.Name = "btnMakeOrder";
            this.btnMakeOrder.Size = new System.Drawing.Size(75, 23);
            this.btnMakeOrder.TabIndex = 10;
            this.btnMakeOrder.Text = "Make Order";
            this.btnMakeOrder.UseVisualStyleBackColor = true;
            this.btnMakeOrder.Click += new System.EventHandler(this.btnMakeOrder_Click);
            // 
            // btnMaxOrdersCustomer
            // 
            this.btnMaxOrdersCustomer.Location = new System.Drawing.Point(211, 39);
            this.btnMaxOrdersCustomer.Name = "btnMaxOrdersCustomer";
            this.btnMaxOrdersCustomer.Size = new System.Drawing.Size(289, 23);
            this.btnMaxOrdersCustomer.TabIndex = 11;
            this.btnMaxOrdersCustomer.Text = "לקוח עם הכי הרבה רכישות";
            this.btnMaxOrdersCustomer.UseVisualStyleBackColor = true;
            this.btnMaxOrdersCustomer.Click += new System.EventHandler(this.btnMaxOrdersCustomer_Click);
            // 
            // btnCustomerPaidMaximum
            // 
            this.btnCustomerPaidMaximum.Location = new System.Drawing.Point(211, 10);
            this.btnCustomerPaidMaximum.Name = "btnCustomerPaidMaximum";
            this.btnCustomerPaidMaximum.Size = new System.Drawing.Size(289, 23);
            this.btnCustomerPaidMaximum.TabIndex = 12;
            this.btnCustomerPaidMaximum.Text = "לקוח ששילם הכי הרבה";
            this.btnCustomerPaidMaximum.UseVisualStyleBackColor = true;
            this.btnCustomerPaidMaximum.Click += new System.EventHandler(this.btnCustomerPaidMaximum_Click);
            // 
            // btnCustomersWithoutOrders
            // 
            this.btnCustomersWithoutOrders.Location = new System.Drawing.Point(211, 70);
            this.btnCustomersWithoutOrders.Name = "btnCustomersWithoutOrders";
            this.btnCustomersWithoutOrders.Size = new System.Drawing.Size(289, 23);
            this.btnCustomersWithoutOrders.TabIndex = 13;
            this.btnCustomersWithoutOrders.Text = "לקוחות ללא הזמנות";
            this.btnCustomersWithoutOrders.UseVisualStyleBackColor = true;
            this.btnCustomersWithoutOrders.Click += new System.EventHandler(this.btnCustomersWithoutOrders_Click);
            // 
            // btnOrdersWithoutCustomers
            // 
            this.btnOrdersWithoutCustomers.Location = new System.Drawing.Point(211, 129);
            this.btnOrdersWithoutCustomers.Name = "btnOrdersWithoutCustomers";
            this.btnOrdersWithoutCustomers.Size = new System.Drawing.Size(289, 23);
            this.btnOrdersWithoutCustomers.TabIndex = 14;
            this.btnOrdersWithoutCustomers.Text = "הזמנות ללא לקוחות";
            this.btnOrdersWithoutCustomers.UseVisualStyleBackColor = true;
            this.btnOrdersWithoutCustomers.Click += new System.EventHandler(this.btnOrdersWithoutCustomers_Click);
            // 
            // btnPurchasesSumOFEveryCustomer
            // 
            this.btnPurchasesSumOFEveryCustomer.Location = new System.Drawing.Point(211, 159);
            this.btnPurchasesSumOFEveryCustomer.Name = "btnPurchasesSumOFEveryCustomer";
            this.btnPurchasesSumOFEveryCustomer.Size = new System.Drawing.Size(289, 23);
            this.btnPurchasesSumOFEveryCustomer.TabIndex = 15;
            this.btnPurchasesSumOFEveryCustomer.Text = "כמה כל לקוח שילם";
            this.btnPurchasesSumOFEveryCustomer.UseVisualStyleBackColor = true;
            this.btnPurchasesSumOFEveryCustomer.Click += new System.EventHandler(this.btnPurchasesSumOFEveryCustomer_Click);
            // 
            // btnPurchasesAverageOFEveryCustomer
            // 
            this.btnPurchasesAverageOFEveryCustomer.Location = new System.Drawing.Point(211, 189);
            this.btnPurchasesAverageOFEveryCustomer.Name = "btnPurchasesAverageOFEveryCustomer";
            this.btnPurchasesAverageOFEveryCustomer.Size = new System.Drawing.Size(289, 23);
            this.btnPurchasesAverageOFEveryCustomer.TabIndex = 16;
            this.btnPurchasesAverageOFEveryCustomer.Text = "ממוצע של כמה כל לקוח שילם";
            this.btnPurchasesAverageOFEveryCustomer.UseVisualStyleBackColor = true;
            this.btnPurchasesAverageOFEveryCustomer.Click += new System.EventHandler(this.btnPurchasesAverageOFEveryCustomer_Click);
            // 
            // btnPurchasesAverageOFEveryCustomerOverTheTotalAverage
            // 
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.Location = new System.Drawing.Point(211, 219);
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.Name = "btnPurchasesAverageOFEveryCustomerOverTheTotalAverage";
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.Size = new System.Drawing.Size(289, 23);
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.TabIndex = 17;
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.Text = "כמה כל לקוח שילם (מעל הממוצע הכללי)";
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.UseVisualStyleBackColor = true;
            this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage.Click += new System.EventHandler(this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage_Click);
            // 
            // btnTotalPurchasesSumOfAllTheCustomers
            // 
            this.btnTotalPurchasesSumOfAllTheCustomers.Location = new System.Drawing.Point(211, 249);
            this.btnTotalPurchasesSumOfAllTheCustomers.Name = "btnTotalPurchasesSumOfAllTheCustomers";
            this.btnTotalPurchasesSumOfAllTheCustomers.Size = new System.Drawing.Size(289, 23);
            this.btnTotalPurchasesSumOfAllTheCustomers.TabIndex = 18;
            this.btnTotalPurchasesSumOfAllTheCustomers.Text = "כמה שילמו כל הלקוחות ביחד";
            this.btnTotalPurchasesSumOfAllTheCustomers.UseVisualStyleBackColor = true;
            this.btnTotalPurchasesSumOfAllTheCustomers.Click += new System.EventHandler(this.btnTotalPurchasesSumOfAllTheCustomers_Click);
            // 
            // btnMostFrequentProduct
            // 
            this.btnMostFrequentProduct.Location = new System.Drawing.Point(211, 279);
            this.btnMostFrequentProduct.Name = "btnMostFrequentProduct";
            this.btnMostFrequentProduct.Size = new System.Drawing.Size(289, 23);
            this.btnMostFrequentProduct.TabIndex = 19;
            this.btnMostFrequentProduct.Text = "פריט שהוזמן הכי הרבה פעמים";
            this.btnMostFrequentProduct.UseVisualStyleBackColor = true;
            this.btnMostFrequentProduct.Click += new System.EventHandler(this.btnMostFrequentProduct_Click);
            // 
            // btnProductsNotBoughtAtAll
            // 
            this.btnProductsNotBoughtAtAll.Location = new System.Drawing.Point(211, 309);
            this.btnProductsNotBoughtAtAll.Name = "btnProductsNotBoughtAtAll";
            this.btnProductsNotBoughtAtAll.Size = new System.Drawing.Size(289, 23);
            this.btnProductsNotBoughtAtAll.TabIndex = 20;
            this.btnProductsNotBoughtAtAll.Text = "מוצרים שלא נקנו כלל";
            this.btnProductsNotBoughtAtAll.UseVisualStyleBackColor = true;
            this.btnProductsNotBoughtAtAll.Click += new System.EventHandler(this.btnProductsNotBoughtAtAll_Click);
            // 
            // btnCustomersWithoutOrdersByJoin
            // 
            this.btnCustomersWithoutOrdersByJoin.Location = new System.Drawing.Point(211, 100);
            this.btnCustomersWithoutOrdersByJoin.Name = "btnCustomersWithoutOrdersByJoin";
            this.btnCustomersWithoutOrdersByJoin.Size = new System.Drawing.Size(289, 23);
            this.btnCustomersWithoutOrdersByJoin.TabIndex = 21;
            this.btnCustomersWithoutOrdersByJoin.Text = "לקוחות ללא הזמנות by Join query";
            this.btnCustomersWithoutOrdersByJoin.UseVisualStyleBackColor = true;
            this.btnCustomersWithoutOrdersByJoin.Click += new System.EventHandler(this.btnCustomersWithoutOrdersByJoin_Click);
            // 
            // btnProductsNotBoughtAtAllByJoin
            // 
            this.btnProductsNotBoughtAtAllByJoin.Location = new System.Drawing.Point(211, 339);
            this.btnProductsNotBoughtAtAllByJoin.Name = "btnProductsNotBoughtAtAllByJoin";
            this.btnProductsNotBoughtAtAllByJoin.Size = new System.Drawing.Size(289, 23);
            this.btnProductsNotBoughtAtAllByJoin.TabIndex = 22;
            this.btnProductsNotBoughtAtAllByJoin.Text = "מוצרים שלא נקנו כלל by Join query";
            this.btnProductsNotBoughtAtAllByJoin.UseVisualStyleBackColor = true;
            this.btnProductsNotBoughtAtAllByJoin.Click += new System.EventHandler(this.btnProductsNotBoughtAtAllByJoin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProductsNotBoughtAtAllByJoin);
            this.Controls.Add(this.btnCustomersWithoutOrdersByJoin);
            this.Controls.Add(this.btnProductsNotBoughtAtAll);
            this.Controls.Add(this.btnMostFrequentProduct);
            this.Controls.Add(this.btnTotalPurchasesSumOfAllTheCustomers);
            this.Controls.Add(this.btnPurchasesAverageOFEveryCustomerOverTheTotalAverage);
            this.Controls.Add(this.btnPurchasesAverageOFEveryCustomer);
            this.Controls.Add(this.btnPurchasesSumOFEveryCustomer);
            this.Controls.Add(this.btnOrdersWithoutCustomers);
            this.Controls.Add(this.btnCustomersWithoutOrders);
            this.Controls.Add(this.btnCustomerPaidMaximum);
            this.Controls.Add(this.btnMaxOrdersCustomer);
            this.Controls.Add(this.btnMakeOrder);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.btnGetAllCustomers);
            this.Controls.Add(this.btnCreateCustomer);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Name = "MainForm";
            this.Text = "מערכת מסדי נתונים";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Button btnCreateCustomer;
        private System.Windows.Forms.Button btnGetAllCustomers;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Button btnMakeOrder;
        private System.Windows.Forms.Button btnMaxOrdersCustomer;
        private System.Windows.Forms.Button btnCustomerPaidMaximum;
        private System.Windows.Forms.Button btnCustomersWithoutOrders;
        private System.Windows.Forms.Button btnOrdersWithoutCustomers;
        private System.Windows.Forms.Button btnPurchasesSumOFEveryCustomer;
        private System.Windows.Forms.Button btnPurchasesAverageOFEveryCustomer;
        private System.Windows.Forms.Button btnPurchasesAverageOFEveryCustomerOverTheTotalAverage;
        private System.Windows.Forms.Button btnTotalPurchasesSumOfAllTheCustomers;
        private System.Windows.Forms.Button btnMostFrequentProduct;
        private System.Windows.Forms.Button btnProductsNotBoughtAtAll;
        private System.Windows.Forms.Button btnCustomersWithoutOrdersByJoin;
        private System.Windows.Forms.Button btnProductsNotBoughtAtAllByJoin;
    }
}


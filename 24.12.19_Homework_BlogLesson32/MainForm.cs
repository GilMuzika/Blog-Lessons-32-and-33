using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._12._19_Homework_BlogLesson32
{
    public partial class MainForm : Form
    {
        private DAO currentDAO = new DAO();

        private string[] namesToUsing;
        private Random _rnd = new Random();

        private string customersTableName;
        private string productsTableName;
        public MainForm()
        {
            InitializeComponent();
            ReadFromFile();
            Initialise();
            InitializeCombos();
        }
        private void Initialise()
        {
            customersTableName = currentDAO.GetTablesNamesAndCapacity()[0][1];
            productsTableName = currentDAO.GetTablesNamesAndCapacity()[0][0];            

            FlexibleMessageBox.MAX_WIDTH_FACTOR = Screen.PrimaryScreen.Bounds.Width;
            FlexibleMessageBox.MAX_HEIGHT_FACTOR = Screen.PrimaryScreen.WorkingArea.Height / 3;

            this.Load += new EventHandler(thisOnLoad);

            btnCreateCustomer.Click += (object sender, EventArgs e) => 
                {                    
                    currentDAO.InsertValueToTable(new { NAME = txtName.Text, ADDRESS = txtAddress.Text, AGE = numAge.Value }, customersTableName);

                    thisOnLoad(this, new EventArgs());                    
                    
                };
        }

        private void InitializeCombos()
        {         
            foreach (var s in currentDAO.RetriveAllFromTable(customersTableName))
            {
                cmbCustomers.Items.Add(new ComboItem<Dictionary<string, Object>>(s));
            }
            foreach (var s in currentDAO.RetriveAllFromTable(productsTableName))
            {
                cmbProducts.Items.Add(new ComboItem<Dictionary<string, Object>>(s));
            }
            refreshCombosIndices();
            
        }

        private void refreshCombosIndices()
        {
            cmbCustomers.SelectedIndex = _rnd.Next(0, cmbCustomers.Items.Count - 1);
            cmbProducts.SelectedIndex = _rnd.Next(0, cmbProducts.Items.Count - 1);
        }
        private void thisOnLoad(object sender, EventArgs e)
        {
            currentDAO.CreateTableIfDontExists();

            string custName = namesToUsing[_rnd.Next(0, namesToUsing.Length - 1)];            
            string custAddress = $"{Statics.GetUniqueKeyOriginal_BIASED(_rnd.Next(5, 15)).FirstLetterToUpper()}";
            int custAge = _rnd.Next((int)numAge.Minimum, (int)numAge.Maximum);

            txtName.Text = custName;
            txtAddress.Text = custAddress;
            numAge.Value = custAge;
        }

        private void ReadFromFile()
        {
            string names = string.Empty;
            string cities = string.Empty;
            try
            {
                names = File.ReadAllText("_names.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n\nSo the program will use the defult names");
                names = " Alfred Benny Connnor Daniel Eran ";
            }
            namesToUsing = names.Split(new char[] { ' ', '\t', '\n' }).Where(x => !String.IsNullOrEmpty(x)).ToArray();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var customers = currentDAO.RetriveAllFromTable(customersTableName);

            string str = string.Empty;
            foreach(var s in customers)
            {
                foreach(var ss in s)
                {
                    str += $"{ss.Key}: {ss.Value}\n";
                }
                str += "\n-----------------------\n";
            }

            FlexibleMessageBox.Show(str);
        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            try
            {
                refreshCombosIndices();
                currentDAO.MakeOrder((cmbCustomers.SelectedItem as ComboItem<Dictionary<string, Object>>).Value, (cmbProducts.SelectedItem as ComboItem<Dictionary<string, Object>>).Value);                
            }
            catch(Exception ex)
            {
                string nullReferenceExceptionMessage = string.Empty;
                if(ex is NullReferenceException) nullReferenceExceptionMessage += "Please select from two ComboBoxes both";

                FlexibleMessageBox.Show($"{ex.GetType().Name}\n{nullReferenceExceptionMessage}\n\n{ex.Message}\n\n{ex.StackTrace}");
            }

        }

        private void btnMaxOrdersCustomer_Click(object sender, EventArgs e)
        {
            DAO.ShowContentOfADictionary(currentDAO.RetriveSpecialData(SQLCommands.FindTheCustomerWithMaxNumberOfOrders).First());
        }

        private void btnCustomerPaidMaximum_Click(object sender, EventArgs e)
        {
            DAO.ShowContentOfADictionary(currentDAO.RetriveSpecialData(SQLCommands.FindTheCustomerThatPaidMaximum).First());
        }

        private void btnCustomersWithoutOrders_Click(object sender, EventArgs e)
        {
            var customersWithoutOrders = currentDAO.RetriveSpecialData(SQLCommands.CustomersWithoutOrders);
            customersWithoutOrders.Reverse();

             DAO.DisplayListOfDictionaries(customersWithoutOrders, "Customers without orders:\n");
        }

        private void btnOrdersWithoutCustomers_Click(object sender, EventArgs e)
        {
            var ordersWithoutCustomers = currentDAO.RetriveSpecialData(SQLCommands.OrdersWithoutCustomer);
            DAO.DisplayListOfDictionaries(ordersWithoutCustomers, "orders without customer:");
            
        }

        private void btnPurchasesSumOFEveryCustomer_Click(object sender, EventArgs e)
        {
            var allTheCustomersWithPurchasesSum = currentDAO.RetriveSpecialData(SQLCommands.AllTheCustomersWithPurchasesSum, AdditionalDataFlags.totalPurchasesSumForEveryClient);
            DAO.DisplayListOfDictionaries(allTheCustomersWithPurchasesSum, "All the customers that have orders with their \nrespective sums of all the purchases (per customer):", "Her/his Purchasing Sum");
        }

        private void btnPurchasesAverageOFEveryCustomer_Click(object sender, EventArgs e)
        {
            var allTheCustomersWithPurchasesSum = currentDAO.RetriveSpecialData(SQLCommands.AllTheCustomersWithTheAverageOfTheirPurchases, AdditionalDataFlags.totalPurchasesSumForEveryClient);
            DAO.DisplayListOfDictionaries(allTheCustomersWithPurchasesSum, "All the customers that have orders with their \nrespective averages of all the purchases (per customer):", "Her/his Average Purchasing Sum");
        }

        private void btnPurchasesAverageOFEveryCustomerOverTheTotalAverage_Click(object sender, EventArgs e)
        {
            var allTheCustomersWithPurchasesSum = currentDAO.RetriveSpecialData(SQLCommands.PurchasesAverageOFEveryCustomerOverTheTotalAverage, AdditionalDataFlags.totalPurchasesSumForEveryClient);
            DAO.DisplayListOfDictionaries(allTheCustomersWithPurchasesSum, "All the customers that have orders with their \nrespective averages of all the purchases \n(per customer, only the customers that purchased over the total average):", "Her/his Purchasing Sum \n(over the total average)");
        }

        private void btnTotalPurchasesSumOfAllTheCustomers_Click(object sender, EventArgs e)
        {
            var allTheCustomersTotalPurchaseSum = currentDAO.RetriveSpecialData(SQLCommands.TotalPurchasesSumOfAllTheCustomers, AdditionalDataFlags.totalPurchasesSumForEveryClient);

            string allTheCustomersTotalPurchaseSumAsString = string.Empty;
            foreach(var s in allTheCustomersTotalPurchaseSum.First())
            {
                if (s.Key.Equals("AdditionalDataKey")) allTheCustomersTotalPurchaseSumAsString = s.Value.ToString();
            }

            FlexibleMessageBox.Show($":כמה שילמו כל הלקוחות ביחד\n{allTheCustomersTotalPurchaseSumAsString}");
        }

        private void btnMostFrequentProduct_Click(object sender, EventArgs e)
        {
            var mostFrequentProduct = currentDAO.RetriveSpecialData(SQLCommands.mostFrequentProduct, AdditionalDataFlags.findProductPlainly);
            DAO.DisplayListOfDictionaries(mostFrequentProduct, "מוצר הנקנה הכי הרבה");
        }

        private void btnProductsNotBoughtAtAll_Click(object sender, EventArgs e)
        {
            var mostFrequentProduct = currentDAO.RetriveSpecialData(SQLCommands.ProductsNotBoughtAtAll, AdditionalDataFlags.findProductPlainly);
            DAO.DisplayListOfDictionaries(mostFrequentProduct, "מוצרים שלא נקנו כלל");
        }

        private void btnCustomersWithoutOrdersByJoin_Click(object sender, EventArgs e)
        {
            var customersWithoutOrdersByJoin = currentDAO.RetriveSpecialData(SQLCommands.CustomersWithoutOrdersByJoin);
            customersWithoutOrdersByJoin.Reverse();

            DAO.DisplayListOfDictionaries(customersWithoutOrdersByJoin, "Customers without orders (by Join query):\n");
        }

        private void btnProductsNotBoughtAtAllByJoin_Click(object sender, EventArgs e)
        {
            var productsNotBoughtAtAllByJoin = currentDAO.RetriveSpecialData(SQLCommands.ProductsNotBoughtAtAllByJoin, AdditionalDataFlags.findProductPlainly);
            productsNotBoughtAtAllByJoin.Reverse();

            DAO.DisplayListOfDictionaries(productsNotBoughtAtAllByJoin, "מוצרים שלא נקנו כלל (by Join query):\n");
        }
    }
}

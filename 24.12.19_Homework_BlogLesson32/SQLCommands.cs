using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._12._19_Homework_BlogLesson32
{
    static class SQLCommands
    {
        public static string FindTheCustomerWithMaxNumberOfOrders { get; }
        public static string FindTheCustomerThatPaidMaximum { get; }
        public static string CustomersWithoutOrders { get; }
        public static string OrdersWithoutCustomer { get; }
        public static string AllTheCustomersWithPurchasesSum { get; }
        public static string AllTheCustomersWithTheAverageOfTheirPurchases { get; }
        public static string PurchasesAverageOFEveryCustomerOverTheTotalAverage { get; }
        public static string TotalPurchasesSumOfAllTheCustomers { get; }
        public static string mostFrequentProduct { get; }
        public static string ProductsNotBoughtAtAll { get; }
        public static string CustomersWithoutOrdersByJoin { get; }
        public static string ProductsNotBoughtAtAllByJoin { get;}

        static SQLCommands()
        {
            FindTheCustomerWithMaxNumberOfOrders = "SELECT CUSTOMER_ID, PRODUCT_ID, COUNT(PRODUCT_ID) as countProductID FROM Orders group BY CUSTOMER_ID ORDER BY countProductID";
            FindTheCustomerThatPaidMaximum = "SELECT CUSTOMER_ID, PRODUCT_ID, SUM (Products.PRICE) AS SuMPricePerCustomer FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID GROUP BY Orders.CUSTOMER_ID ORDER BY SuMPricePerCustomer";
            CustomersWithoutOrders = "SELECT ID as CUSTOMER_ID, NAME, ADDRESS, AGE FROM Customer WHERE NOT EXISTS (SELECT CUSTOMER_ID FROM Orders WHERE Customer.ID = Orders.CUSTOMER_ID)";
            OrdersWithoutCustomer = "SELECT * FROM Orders WHERE NOT EXISTS (SELECT ID FROM Customer WHERE Orders.CUSTOMER_ID = Customer.ID)";
            AllTheCustomersWithPurchasesSum = "SELECT CUSTOMER_ID, PRODUCT_ID, SUM (Products.PRICE) AS AdditionalData FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID GROUP BY Orders.CUSTOMER_ID ORDER BY AdditionalData";
            AllTheCustomersWithTheAverageOfTheirPurchases = "SELECT CUSTOMER_ID, PRODUCT_ID, AVG (Products.PRICE) AS AdditionalData FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID GROUP BY Orders.CUSTOMER_ID ORDER BY AdditionalData";
            PurchasesAverageOFEveryCustomerOverTheTotalAverage = "SELECT CUSTOMER_ID, PRODUCT_ID, SUM (Products.PRICE) AS AdditionalData FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID  GROUP BY Orders.CUSTOMER_ID HAVING AdditionalData>(SELECT  AVG(Products.PRICE) FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID) ORDER BY AdditionalData";
            TotalPurchasesSumOfAllTheCustomers = "SELECT CUSTOMER_ID, SUM (Products.PRICE) AS AdditionalData FROM Orders JOIN Products ON Products.ID = Orders.PRODUCT_ID";
            mostFrequentProduct = "SELECT MAX (y.CountProductID)  , CUSTOMER_ID, PRODUCT_ID  FROM (	SELECT Count(PRODUCT_ID) as CountProductID, CUSTOMER_ID, PRODUCT_ID FROM Orders GROUP BY CUSTOMER_ID ORDER BY CountProductID	) y  ";
            ProductsNotBoughtAtAll = "SELECT ID as CUSTOMER_ID, ID as PRODUCT_ID, * FROM Products WHERE NOT EXISTS (SELECT PRODUCT_ID FROM Orders WHERE Products.ID = Orders.PRODUCT_ID)";
            CustomersWithoutOrdersByJoin = "SELECT ID as CUSTOMER_ID, AGE as PRODUCT_ID FROM Customer LEFT OUTER JOIN Orders ON Customer.ID = Orders.CUSTOMER_ID WHERE Orders.CUSTOMER_ID is NULl";
            ProductsNotBoughtAtAllByJoin = "SELECT ID as PRODUCT_ID, VENDOR as CUSTOMER_ID FROM Products LEFT OUTER JOIN Orders ON Products.ID = Orders.PRODUCT_ID WHERE Orders.CUSTOMER_ID is NULL";



        }
            




    }
}

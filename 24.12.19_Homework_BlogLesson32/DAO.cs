using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace _24._12._19_Homework_BlogLesson32
{
    enum AdditionalDataFlags
    {       
        totalPurchasesSumForEveryClient = 0, //finding customers
        findProductPlainly = 1, //finding product
        findProductWithAdditionalData = 2, //finding products
        noFlagTerminator = 1000 //also finding customers
    }


    class DAO
    {
        private SQLiteConnection _connection = new SQLiteConnection();
        private SQLiteCommand _command = new SQLiteCommand();        

        public DAO()
        {
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["companyDb_local"].ConnectionString.Replace(@"=\", $"={Directory.GetCurrentDirectory()}\\");
           
            _command.CommandType = System.Data.CommandType.Text;
            _command.Connection = _connection;
            
            FlexibleMessageBox.MAX_WIDTH_FACTOR = Screen.PrimaryScreen.WorkingArea.Width;
            FlexibleMessageBox.MAX_HEIGHT_FACTOR = Screen.PrimaryScreen.WorkingArea.Height;
        }

        public void InsertValueToTable(object insertValueHoldingObject, string tableName)
        {
            _connection.Open();         
            try
            {
                _command.CommandText = $"INSERT INTO {tableName} ({insertValueHoldingObject.GetType().GetProperties()[0].Name}) VALUES ('{insertValueHoldingObject.GetType().GetProperties()[0].GetValue(insertValueHoldingObject)}')";
                _command.ExecuteNonQuery();

                for (int i = 1; i < insertValueHoldingObject.GetType().GetProperties().Length; i++)
                {
                    var val = insertValueHoldingObject.GetType().GetProperties()[i].GetValue(insertValueHoldingObject);
                    if (!Int32.TryParse(val.ToString(), out int numVal)) val = $"'{val}'";
                    _command.CommandText = $"UPDATE Customer SET {insertValueHoldingObject.GetType().GetProperties()[i].Name} = {val} WHERE {insertValueHoldingObject.GetType().GetProperties()[0].Name} = '{insertValueHoldingObject.GetType().GetProperties()[0].GetValue(insertValueHoldingObject)}'";
                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {                
                FlexibleMessageBox.Show($"{ex.GetType().Name}\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
            _connection.Close();
        }
        public List<Dictionary<string, Object>> RetriveAllFromTable(string tableName)
        {
            return RetriveFromTableInternal(tableName, -2, AdditionalDataFlags.noFlagTerminator);
        }
        public List<Dictionary<string, Object>> RetriveOneFromTable(string tableName, int ID)
        {
            return RetriveFromTableInternal(tableName, ID, AdditionalDataFlags.noFlagTerminator);
        }
        public List<Dictionary<string, Object>> RetriveAllFromTableWithAdditionalData(string tableName, int ID, AdditionalDataFlags additionalDataFlag)
        {
            return RetriveFromTableInternal(tableName, ID, additionalDataFlag);
        }

        private List<Dictionary<string, Object>> RetriveFromTableInternal(string tableName, int id, AdditionalDataFlags additionalDataFlag)
        {          
            List<Dictionary<string, Object>> ret = new List<Dictionary<string, Object>>();
            try
            {

                _connection.Open();
                if (id > -1) _command.CommandText = $"SELECT * FROM {tableName} WHERE ID = {id}";
                else _command.CommandText = $"SELECT * FROM {tableName}";
                using (SQLiteDataReader reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dict = BuildDictionary(reader);

                        ret.Add(dict);

                        if (id > -1) break;
                    }
                }
                _connection.Close();
            }
            catch (Exception ex)
            {
                FlexibleMessageBox.Show($"{ex.GetType().Name}\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
            return ret;
        }

        public List<Dictionary<string, Object>> RetriveSpecialData(string sqlText)
        {
            return RetriveSpecialDataInternal(sqlText, AdditionalDataFlags.noFlagTerminator);
        }
        public List<Dictionary<string, Object>> RetriveSpecialData(string sqlText, AdditionalDataFlags additionalDataFlag)
        {
            return RetriveSpecialDataInternal(sqlText, additionalDataFlag);
        }
        //this function retrives customer ID according to the SQL command and returns a customer with this ID
        public List<Dictionary<string, Object>> RetriveSpecialDataInternal(string sqlText, AdditionalDataFlags additionalDataFlag)
        {
            List<Dictionary<string, Object>> listOfDictionaries = new List<Dictionary<string, object>>();
            Dictionary<string, Object> dictionaryWithCustomerID;
            _connection.Open();
            _command.CommandText = sqlText;
            try
            {
                int count = 0;
                using (SQLiteDataReader reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dictionaryWithCustomerID = BuildDictionary(reader);                        
                        listOfDictionaries.Add(dictionaryWithCustomerID);

                        count++;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                FlexibleMessageBox.Show($"{ex.GetType().Name}\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
            _connection.Close();
            List<Dictionary<string, Object>> endListToReturn = new List<Dictionary<string, object>>();
            int emptyRecordsCount = 1;
            for (int i = listOfDictionaries.Count - 1; i >= 0; i--)
            {                
                try
                {
                    if (!(listOfDictionaries[i]["CUSTOMER_ID"] is DBNull) || !(listOfDictionaries[i]["PRODUCT_ID"] is DBNull))
                    //if (!(listOfDictionaries[i]["CUSTOMER_ID"] is DBNull))
                        {
                        if(additionalDataFlag == AdditionalDataFlags.noFlagTerminator)
                            endListToReturn.Add(RetriveOneFromTable(GetTablesNamesAndCapacity()[0][1], Convert.ToInt32(listOfDictionaries[i]["CUSTOMER_ID"])).First());

                        if(additionalDataFlag == AdditionalDataFlags.findProductPlainly)
                            endListToReturn.Add(RetriveOneFromTable(GetTablesNamesAndCapacity()[0][0], Convert.ToInt32(listOfDictionaries[i]["PRODUCT_ID"])).First());

                        if (additionalDataFlag == AdditionalDataFlags.totalPurchasesSumForEveryClient)
                        {                            
                            var dict = RetriveAllFromTableWithAdditionalData(GetTablesNamesAndCapacity()[0][1], Convert.ToInt32(listOfDictionaries[i]["CUSTOMER_ID"]), additionalDataFlag).First();
                            dict.Add("AdditionalDataKey", listOfDictionaries[i]["AdditionalData"]);
                            endListToReturn.Add(dict);                         
                        }
                    }
                    else
                    {
                        Dictionary<string, Object> newDict = new Dictionary<string, object>();
                        newDict.Add("RecordName", "This is empty record in the DB");
                        newDict.Add("Number of empty record", emptyRecordsCount);
                        endListToReturn.Add(newDict);
                        emptyRecordsCount++;
                    }

                }
                catch (Exception ex)
                {
                    FlexibleMessageBox.Show($"{ex.GetType().Name}\n\n{ex.Message}\n\n{ex.StackTrace}\n\n----------------------------------------\n\nThe actual type of the record in question: {listOfDictionaries[i]["CUSTOMER_ID"].GetType().Name}");
                }

            }            

            return endListToReturn;
        }
        //End: this function retrives customer ID according to the SQL command and returns a customer with this ID
        private Dictionary<string, Object> BuildDictionary(SQLiteDataReader reader)
        {          
            Dictionary<string, object> dict = new Dictionary<string, object>();
            int count = 0;
            while (count < reader.FieldCount)
            {            
                dict.Add(reader.GetName(count), reader.GetValue(count));
                count++;
            }
            return dict;
        }


        public string[][] GetTablesNamesAndCapacity()
        {
            List<string> tableNames = new List<string>();
            List<string> tableCapacities = new List<string>();

            _connection.Open();
            _command.CommandText = "SELECT * FROM sqlite_sequence";
            using (SQLiteDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tableNames.Add((string)reader["name"]);
                    tableCapacities.Add(reader["seq"].ToString());
                }
            }
            _connection.Close();

            string[][] output = new string[2][];
            output[0] = tableNames.ToArray();
            output[1] = tableCapacities.ToArray();

            return output;
        }

        public void MakeOrder(Dictionary<string, Object> customer, Dictionary<string, Object> product)
        {
            int customerID = Convert.ToInt32(customer["ID"]);
            int productID = Convert.ToInt32(product["ID"]);
            _connection.Open();
            _command.CommandText = $"INSERT INTO Orders (PRODUCT_ID, CUSTOMER_ID) VALUES ({productID}, {customerID})";
            _command.ExecuteNonQuery();

            _connection.Close();


        }

        public static void ShowContentOfADictionary(Dictionary<string, object> dict)
        {
            string str = string.Empty;
            str += "customer:\n";
            foreach (var s in dict) str += $"{s.Key}: {s.Value}\n";
            str += "-------------\n";
            FlexibleMessageBox.Show(str);
        }
        public static void DisplayListOfDictionaries(List<Dictionary<string, object>> listOfDictionaries, string textMessage, string AdditionalDataKeyReplacement)
        {
            DisplayListOfDictionariesInternal(listOfDictionaries, textMessage, AdditionalDataKeyReplacement);
        }
        public static void DisplayListOfDictionaries(List<Dictionary<string, object>> listOfDictionaries, string textMessage)
        {
            DisplayListOfDictionariesInternal(listOfDictionaries, textMessage, "");
        }
        private static void DisplayListOfDictionariesInternal(List<Dictionary<string, object>> listOfDictionaries, string textMessage, string AdditionalDataKeyReplacement)
        {
            string str = string.Empty;
            str += textMessage + "\n\n";
            foreach (var s in listOfDictionaries)
            {
                string ssKey = string.Empty;
                foreach (var ss in s)
                {
                    ssKey = ss.Key;
                    if (!String.IsNullOrEmpty(AdditionalDataKeyReplacement) && ss.Key.Equals("AdditionalDataKey")) ssKey = AdditionalDataKeyReplacement;
                    str += $"{ssKey}: {ss.Value}\n";
                }
                str += "---------------\n";
            }
            FlexibleMessageBox.Show(str);
        }

        public void CreateTableIfDontExists()
        {
            try
            {
                _connection.Open();
                _command.CommandText = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\_database\\24.12.19_Dtabase_homework_SQL_commands.txt");
                _command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                FlexibleMessageBox.MAX_WIDTH_FACTOR = Screen.PrimaryScreen.WorkingArea.Width;
                FlexibleMessageBox.Show($"{ex.GetType().Name}\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}

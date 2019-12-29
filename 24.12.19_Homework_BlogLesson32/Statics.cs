using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._12._19_Homework_BlogLesson32
{
    static class Statics
    {
        public static string UniqeRandomString(int smallest, int biggest)
        {
            smallest--;
            List<int> possibilities = new List<int>();
            for (int i = smallest; i <= biggest; i++) possibilities.Add(i);

            string output = string.Empty;

            Random rnd = new Random();

            int rangeCount = biggest - smallest;

            for (int i = 0; i < rangeCount; i++)
            {
                int randomIndex = rnd.Next(0, possibilities.Count() - 1) + 1;
                output += possibilities[randomIndex];
                possibilities.Remove(possibilities[randomIndex]);
            }
            return output;
        }



        public static void drawBorder<T>(this T drawableObject, int borderWidth, Color bordercolor) where T : class
        {
            int width = 0; int height = 0;
            if (drawableObject is Image) { width = (drawableObject as Image).Width; height = (drawableObject as Image).Height; }
            if (drawableObject is Control) { width = (drawableObject as Control).Width; height = (drawableObject as Control).Height; }

            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphicsObj = Graphics.FromImage(bitmap);

            Pen myPen = new Pen(bordercolor, borderWidth);
            graphicsObj.DrawRectangle(myPen, 0, 0, width - 1, height - 1);

            if (drawableObject is Image) drawableObject = bitmap as T;
            else
            {
                drawableObject.GetType().GetProperty("BackgroundImage")?.SetValue(drawableObject, bitmap);
                drawableObject.GetType().GetProperty("Image")?.SetValue(drawableObject, bitmap);
            }
            graphicsObj.Dispose();
        }



        static public string GetUniqueKeyOriginal_BIASED(int size)
        {
            char[] chars =
                //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        static public string FirstLetterToUpper(this string str)
        {
            string str2 = string.Empty;
            for(int i = 0; i < str.Length; i++)
            {
                if (i == 0) { str2 += str[i].ToString().ToUpper(); }
                else str2 += str[i];
            }
            return str2;
           
        }

        public static ExpandoObject DictionaryToObject(this IDictionary<String, Object> dictionary)
        {
            var expandoObj = new ExpandoObject();
            var expandoObjCollection = (ICollection<KeyValuePair<String, Object>>)expandoObj;

            foreach (var keyValuePair in dictionary)
            {
                expandoObjCollection.Add(keyValuePair);
            }
            //dynamic eoDynamic = expandoObj;

            //return eoDynamic;
            return expandoObj;
        }

        static public List<T> ReverseCollectionOrder<T>(this List<T> collection)  
        {
            List<T> coll = new List<T>();
            for(int i = coll.Count - 1; i >= 0; i--)
            {
                coll.Add(collection[i]);
            }
            return coll;
        }



    }





}

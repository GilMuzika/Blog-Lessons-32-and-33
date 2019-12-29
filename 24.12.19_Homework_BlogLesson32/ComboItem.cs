using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._12._19_Homework_BlogLesson32
{
    class ComboItem<T>
    {
        public T Value { get; set; } = default(T);

        public ComboItem(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            string str = string.Empty;

            int count = 0;
            foreach(var s in Value as IDictionary<string, object>)
            {
                if(count > 0 && count < 3)
                {
                    str += $"{s.Value} ";
                }
                count++;
            }

            /*
            for(int i = 1; i < (Value as IDictionary<string, object>).Count; i++)
            {
                str += $"{}\n";
            }

            return $"{(Value as IDictionary<string, object>)["NAME"]}, {(Value as Dictionary<string, object>)["ADDRESS"]}";
            */
            return str;
        }
    }
}

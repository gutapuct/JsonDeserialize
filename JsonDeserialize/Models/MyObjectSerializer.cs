using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserialize
{
    class MyObjectSerializer : IMyObjectSerializer
    {
        public StringBuilder result = new StringBuilder("[\r\n");
        public string Serialize(IMyObject myObject)
        {
            foreach (var property in myObject.GetProperties())
            {
                var arrayObject = property.Value as IEnumerable;
                if (arrayObject != null)
                {
                    result.AppendFormat("{0} :\r\n[\r\n", property.Name);
                    foreach (var obj in arrayObject)
                    {
                        ParseAndSaveValueObject(obj);
                    }
                    result.Remove(result.Length - 3, 3).Append("\r\n],\r\n");
                }
                else
                {
                    result.AppendFormat("{0} : {1},\r\n", property.Name, property.Value ?? "null");
                }
            }

            return result.Remove(result.Length - 3, 3).Append("\r\n]").ToString();
        }

        private void ParseAndSaveValueObject(object value)
        {
            if (value is IMyObject)
            {
                var myObject = (IMyObject)value;
                foreach (var p in myObject.GetProperties())
                {
                    if (p  is IMyObject)
                    {
                        ParseAndSaveValueObject(p);
                    }
                    else
                    {
                        result.AppendFormat("\t{0} : {1},\r\n", p.Name, p.Value ?? "null");
                    }
                }
            }
            else
            {
                result.AppendFormat("\t{0},\r\n", value.ToString());
            }
        }
    }
}

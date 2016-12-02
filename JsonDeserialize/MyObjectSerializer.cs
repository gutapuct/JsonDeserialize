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
        public string Serialize(IMyObject myObject)
        {
            var res = new StringBuilder("");
            foreach (var p in myObject.GetProperties())
            {
                var arrayObject = p.Value as IEnumerable;
                if (arrayObject != null)
                {
                    res.AppendFormat("{0} :\r\n[\r\n", p.Name);
                    foreach (var obj in arrayObject)
                    {
                        res.AppendFormat("\t{0},\r\n", obj);
                    }
                    res.Remove(res.Length - 3, 3).Append("\r\n]\r\n");
                }
                else
                {
                    res.AppendFormat("{0} : {1}\r\n", p.Name, p.Value ?? "null");
                }
            }
            return res.ToString();
        }
    }
}

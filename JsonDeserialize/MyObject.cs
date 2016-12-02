using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonDeserialize
{
    public class MyObject : IMyObject, IMyObjectSerialize
    {
        private List<Property> _properties = new List<Property>();

        public void AddProperty(string name, object value = null)
        {
            if (_properties.Where(i => i.Name == name).Any())
            {
                _properties.Where(i => i.Name == name).FirstOrDefault().Value = value; 
            }
            else
            {
                _properties.Add(new Property { Name = name, Value = value });
            }
        }

        public Property GetPropertyByName(string name)
        {
            return _properties.Where(i => i.Name == name).FirstOrDefault();
        }
        
        public List<Property> GetProperties()
        {
            return _properties;
        }

        public override string ToString()
        {
            var res = new StringBuilder("");
            foreach (var p in _properties)
            {
                if (p.Value is object[])
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

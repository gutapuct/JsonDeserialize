using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonDeserialize
{
    public class MyObject : IMyObject
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
    }   
}

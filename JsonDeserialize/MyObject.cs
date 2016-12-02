using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonDeserialize
{
    public class MyObject : IProperty
    {
        private List<Property> _properties = new List<Property>();

        public void SetProperty(string name, object value)
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
        public void SetPropertyName(string name)
        {
            if (!_properties.Where(i => i.Name == name).Any())
            {
                _properties.Add(new Property { Name = name, Value = null });
            }
        }
        public void SetPropertyValueByName(string name, object value)
        {
            if (_properties.Where(i => i.Name == name).FirstOrDefault() != null)
            {
                _properties.Where(i => i.Name == name).FirstOrDefault().Value = value;
            }
        }
        public Property GetPropertyByName(string name)
        {
            return _properties.Where(i => i.Name == name).FirstOrDefault();
        }
        public List<Property> GetPropertiesByValue(object value)
        {
            return _properties.Where(i => i.Value == value).ToList();
        }
        public List<Property> GetProperties()
        {
            return _properties;
        }
    }   
}

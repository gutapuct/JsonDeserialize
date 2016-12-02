using System.Collections.Generic;

namespace JsonDeserialize
{
    public interface IProperty
    {
        void SetProperty(string name, object value);
        void SetPropertyName(string name);
        void SetPropertyValueByName(string name, object value);
        Property GetPropertyByName(string name);
        List<Property> GetPropertiesByValue(object value);
        List<Property> GetProperties();
        //test
    }
}
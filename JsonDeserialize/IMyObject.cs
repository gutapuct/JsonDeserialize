using System.Collections.Generic;

namespace JsonDeserialize
{
    public interface IMyObject
    {
        void AddProperty(string name, object value = null);
        Property GetPropertyByName(string name);
        List<Property> GetProperties();
    }
}
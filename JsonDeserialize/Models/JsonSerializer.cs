using JsonDeserialize.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDeserialize
{
    public class JsonSerializer : IJsonSerializer
    {
        private List<IMyObject> _myObjects = new List<IMyObject>();

        public List<IMyObject> ParseJsonToMyObject(string json)
        {
            json = json.Replace("\r", "").Replace("\n", "").Replace("\"", "").Replace(" ", "");
            json = json.Replace("{", "{\r\n").Replace("}", "\r\n}").Replace(",", ",\r\n");

            var lines = json.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            MyObject myObject = new MyObject();

            foreach (var line in lines)
            {
                var pair = line.Split(':');
                if (pair.Length == 2)
                {
                    var value = pair[1].Trim();
                    if (value.EndsWith(",")) value = value.Trim().Remove(value.Length - 1, 1);
                    myObject.AddProperty(pair[0].Trim(), value);
                }
                else if(pair[0].Trim().Contains("{"))
                {
                    myObject = new MyObject();
                }
                else if (pair[0].Trim().Contains("}"))
                {
                    _myObjects.Add(myObject);
                }
            }

            return _myObjects;
        }
    }
}

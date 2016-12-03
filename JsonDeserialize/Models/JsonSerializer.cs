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
        private Dictionary<char, char> Dictionary = new Dictionary<char, char>()
        {
             {'{', '}'},
             {'[', ']'},
             {'(', ')'},
        };
        private static Stack<char> Stack = new Stack<char>();

        public List<IMyObject> ParseJsonToMyObject(string json)
        {
            json = json.Replace("\r", "").Replace("\n", "");
            json = json.Substring(1, json.Length - 2);

            StringBuilder name = new StringBuilder();
            StringBuilder value = new StringBuilder();
            var isName = false;
            var isValue = false;
            var isObject = false;
            MyObject myObjet = new MyObject();

            for (var i = 0; i < json.Length; i++)
            {
                if (json[i] == '{')
                {
                    myObjet = new MyObject();
                    continue;
                }
                if (json[i] == '"' && !isName && !isValue)
                {
                    isName = true;
                    continue;
                }
                if (json[i] == '"' && isName && json[i + 1] == ':' && name.Length > 0)
                {
                    i++;
                    isName = false;
                    isValue = true;
                    continue;
                }
                if (isName)
                {
                    name.Append(json[i]);
                    continue;
                }
                if (json[i] == ',' && name.Length > 0 && !isObject)
                {
                    myObjet.AddProperty(name.ToString(), (object)value);
                    isName = false;
                    isValue = false;
                    name = new StringBuilder();
                    value = new StringBuilder();
                    continue;
                }
                if (json[i] == '}' && name.Length > 0)
                {
                    myObjet.AddProperty(name.ToString(), (object)value);
                    _myObjects.Add(myObjet);
                    isName = false;
                    isValue = false;
                    name = new StringBuilder();
                    value = new StringBuilder();
                }
                if (isValue)
                {
                    if (json[i] == '[') isObject = true;
                    value.Append(json[i]);
                    if (json[i] == ']') isObject = false;
                    continue;
                }
            }

            return _myObjects;
        }

        public bool IsJsonValid(string json)
        {
            foreach (var symbol in json)
            {
                if (Dictionary.ContainsKey(symbol))
                {
                    Stack.Push(symbol);
                }
                else if (Dictionary.ContainsValue(symbol))
                {
                    if (Stack.Count == 0) return false;
                    if (symbol == Dictionary.Where(i => i.Key == Stack.Peek()).Select(i => i.Value).First())
                    {
                        Stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

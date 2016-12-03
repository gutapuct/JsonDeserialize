using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using JsonDeserialize;

namespace json
{
    class Program
    {
        private static void Main(string[] args)
        {
            var jsonObject = new MyObject();

            jsonObject.AddProperty("align", new object[]
            {
                false,
                "parameters",
                "arguments",
                "statements"
            });
            jsonObject.AddProperty("ban", 10);
            jsonObject.AddProperty("class-name", true);
            jsonObject.AddProperty("indent", new object[]
            {
                true,
                "spaces"
            });
            jsonObject.AddProperty("member-access", 55.1);

            var innerObject = new MyObject();
            innerObject.AddProperty("multiline", "never");
            innerObject.AddProperty("singleline", "never2");

            jsonObject.AddProperty("trailing-comma", new object[] { true, innerObject });
            jsonObject.AddProperty("no-trailing-whitespace");

            var serializer = new MyObjectSerializer();
            //Console.WriteLine(serializer.Serialize(jsonObject));
            var jsonString = @"[{
                            ""Author"":""Заявка"",
                            ""Date"":""Date(1451596124240)"",
                            ""Text"":""Проверена автоматически""
                            },
                            {
                            ""Author"":""Козина Екатерина"",
                            ""Date"":""Date(1450436456660)"",
                            ""Text"":""данный пункт ...""
                            }
                            ]";

            var jsonString2 = @"[{""name1"":10,""name2"":true,""name3"":null,""name4"":""value_string"",""name5"":[false, ""value_string2"", 13, ""value_string3""]}]";
            var jsonString3 = @"[{""name1"":10,""name5"":[""value_string2"", 13]},{""name2"":11,""name6"":[""value_string3"", 14]}]";

            var jsonSerializer = new JsonDeserialize.JsonSerializer();
            var myObjects = jsonSerializer.ParseJsonToMyObject(jsonString3);
            Console.ReadKey();
        }
    }
}
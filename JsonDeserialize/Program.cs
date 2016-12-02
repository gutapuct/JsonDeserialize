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
            innerObject.AddProperty("singleline", "never");

            jsonObject.AddProperty("trailing-comma", new object[] { true, innerObject });
            jsonObject.AddProperty("no-trailing-whitespace");

            Console.WriteLine(jsonObject.ToString());

            Console.ReadKey();
        }
    }
}
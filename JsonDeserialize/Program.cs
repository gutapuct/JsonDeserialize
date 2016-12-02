using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonDeserialize;

namespace json
{
    class Program
    {
        private static void Main(string[] args)
        {
            var jsonObject = new MyObject();

            Console.ReadKey();
        }
    }
}
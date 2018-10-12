using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DIClass
{
    public class MyDependency : IMyDependency
    {
        private string _myStringValue;
        public MyDependency(IConfiguration config)
        {
            _myStringValue = config["URLS"];
        }

        public Task WriteMessage(string message)
        {
            var myStringValue = _myStringValue;

            Console.WriteLine(
                $"{myStringValue}MyDependency.WriteMessage called. Message: {message}");

            return Task.FromResult(0);
        }
    }
}

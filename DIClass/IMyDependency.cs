using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIClass
{
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}

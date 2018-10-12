using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricalCarWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public string Index()
        {
            return "this is just a test";
        }


        public string Welcome()
        {
            return "a welcome message";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElecCarApiApp.Controllers
{
 
    public class ManufacturersController : ODataController
    {
        [Authorize]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok("test");
        }

    }
}
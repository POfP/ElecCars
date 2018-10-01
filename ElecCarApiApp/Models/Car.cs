using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElecCarApiApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
    
    }
}

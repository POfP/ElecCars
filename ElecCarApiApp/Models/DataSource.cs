using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElecCarApiApp.Models
{
    public static class DataSource
    {
        private static IList<Car> _cars { get; set; }

        public static IList<Car> GetCars()
        {
            if (_cars != null)
            {
                return _cars;
            }

            _cars = new List<Car>();

            // car #1
            Car car = new Car
            {
                //Id = 1,
                Name = "PriusV",
                Price = 59,
                Manufacturer = new Manufacturer { Name = "Toyota"/*, Id =2*/ },
               
            };
            _cars.Add(car);

            // car #2
            car = new Car
            {
              //  Id = 2,
                 Name= "Leaf",
                Price = 49,
                Manufacturer = new Manufacturer {  Name = "Nissan"/*,  Id=1*/ },
                
            };
            _cars.Add(car);

            return _cars;
        }
    }
}

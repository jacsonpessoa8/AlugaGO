using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlugaGo.Models;

namespace AlugaGo.ViewModels
{
    public class CarViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public List<Car> listCar;
    }
}
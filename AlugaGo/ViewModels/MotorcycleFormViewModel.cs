using AlugaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaGo.ViewModels
{
    public class MotorcycleFormViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public Motorcycle Motorcycle { get; set; }

        public string Title
        {
            get
            {
                if (Motorcycle != null && Motorcycle.Id != 0)
                    return "Editar Moto";

                return "Nova Moto";
            }
        }
    }
}
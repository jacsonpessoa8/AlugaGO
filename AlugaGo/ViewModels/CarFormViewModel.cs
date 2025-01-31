﻿using AlugaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaGo.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<Category> Category { get; set;}
        public Car Car { get; set; }

        public string Title
        {
            get
            {
                if (Car != null && Car.Id != 0)
                    return "Editar Carro";

                return "Novo Carro";
            }
        }
    }
}
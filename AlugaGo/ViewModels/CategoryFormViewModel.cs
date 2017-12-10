using AlugaGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlugaGo.ViewModels
{
    public class CategoryFormViewModel
    {
        public Category Category { get; set; }

        public string Title
        {
            get
            {
                if (Category != null && Category.Id != 0)
                    return "Editar Categoria";

                return "Novo Categoria";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlugaGo.Models
{

    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor entre o nome do cliente.")]
        [StringLength (255)]
        [Display(Name= "Nome")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Por favor entre o CPF do cliente.")]
        [StringLength(50)]
        [Display(Name = "CPF")]
        public String Cpf { get; set; }

        [Required(ErrorMessage = "Por favor entre o data de nascimento do cliente.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime Birthdate { get; set; }


    }

}
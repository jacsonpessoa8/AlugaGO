using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlugaGo.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        [Required]
        [StringLength(100)]
        public String Fabricante { get; set; }
        public Category Category { get; set; }
        public int CylinderCapacity { get; set; }
    }
}
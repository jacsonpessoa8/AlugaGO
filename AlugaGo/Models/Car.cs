using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlugaGo.Models
{

    public class Car
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        [StringLength(100)]
        public String Fabricante { get; set; }

        public CarCategory Category { get; set; }

        public int Door { get; set; }

        public String Image { get; set; }

        public Boolean Direction { get; set; }
        public Boolean Air { get; set; }
        public Boolean EletricWindows { get; set; }
        public Boolean SoundSystem { get; set; }
        public Boolean Lock { get; set; }
        public Boolean Alarm { get; set; }
        public Boolean Airbag { get; set; }
        public Boolean ABS { get; set; }

    }
}
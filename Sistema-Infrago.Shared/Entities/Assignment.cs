using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public Project? Project { get; set; }

        public Material? Material { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Cantidad de material")]
        public int Quantity { get; set; }


    }
}

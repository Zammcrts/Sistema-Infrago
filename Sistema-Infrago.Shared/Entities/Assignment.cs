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

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Proyecto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Project Project { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Material")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Material Material { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Cantidad de material")]
        public int Quantity { get; set; }


    }
}

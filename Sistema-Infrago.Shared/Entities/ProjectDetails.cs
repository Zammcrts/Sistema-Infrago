using Sistema_Infrago.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class ProjectDetails
    {
        public int DetailD { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción de los Detalles")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string DetailDescription { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo de Servicio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string ServiceType { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Costo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public float Cost { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Proyecto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Service? Service { get; set; }
        public Project? Project { get; set; }
    }
}

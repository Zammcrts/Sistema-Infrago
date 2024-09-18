using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Nombre del proyecto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string ProjectName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Cliente")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Client { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Fecha de inicio del proyecto")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string StartDate { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Fecha de termino del proyecto")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string EndDate { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Fecha de asignación del proyecto")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string AssignationDate { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Presupuesto")]
        public float Budget { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [Display(Name = "Estado del proyecto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Status { get; set; } = null!;
    }
}

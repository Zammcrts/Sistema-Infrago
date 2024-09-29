using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class Maintenance
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID de Mantenimiento ")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public int MaintenanceID { get; set; } 
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID del Equipo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public int EquipmentID { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de mantenimiento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public int MaintenanceDate { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Tipo de mantenimiento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string MaintenanceType { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Costo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public float Cost { get; set; }
        public ICollection<MaintenanceDetails>? Details { get; set; } // relacion con los detalles

    }
}

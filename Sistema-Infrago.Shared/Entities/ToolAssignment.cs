using Sistema_Infrago.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class ToolAssignment
    {
        public int ToolAssignmentID { get; set; }
        
        public Tool? Tool { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de Asignación de la Herramienta")]
        public int AssignmentDate { get; set; }
        public Project? Project { get; set; }
    }
}

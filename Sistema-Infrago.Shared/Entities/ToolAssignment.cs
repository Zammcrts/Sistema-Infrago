using System.ComponentModel.DataAnnotations;

namespace Sistema_Infrago.Shared.Entities
{
    public class ToolAssignment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID de la herramienta ")]
        public int ToolAssignmentID { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de Asignación de la Herramienta")]
        public int AssignmentDate { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Herramienta ")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Tool? Tool { get; set; }
        public Project? Project { get; set; }
    }
}

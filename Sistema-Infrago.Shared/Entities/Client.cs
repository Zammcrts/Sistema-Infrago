using System.ComponentModel.DataAnnotations;

namespace Sistema_Infrago.Shared.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre del cliente")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Teléfono")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Calle")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Número exterior")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string ExteriorNumber { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Municipio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Township { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Código Postal")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string ZipCode { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")] //obligatorio pertenece al public string Name
        [Display(Name = "Proyecto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Project { get; set; } = null!;
        public ICollection<Project>? Projects { get; set; }
    }
}

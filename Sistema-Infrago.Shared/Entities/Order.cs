using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Proveedor")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Stockist Stockist { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de la orden")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string OrderDate { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de entrega de la orden")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string DeliveyDate { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Costo total")]
        public float TotalCost { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Departamento solicitante")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public Department Department { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre del departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public List<OrderDetail> OrderDetails { get; set; } = null!;

    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_Infrago.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }

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
        [Display(Name = "Detalles de la orden")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Details { get; set; } = null!;

        public Stockist? Stockists { get; set; }
        public Department? Department { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}

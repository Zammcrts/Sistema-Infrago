using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Infrago.Shared.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public Order? Order { get; set; }

        public Material? Material { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Precio")]
        public float PricePerUnit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [Column(TypeName = "varchar(24)")]
        public OrderStatus Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.ViewModels
{
    public class OrdersListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

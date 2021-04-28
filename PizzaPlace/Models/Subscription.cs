using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DateSubscribed { get; set; }
    }
}

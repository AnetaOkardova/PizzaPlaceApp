using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.ViewModels
{
    public class MenuItemView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
    }
}

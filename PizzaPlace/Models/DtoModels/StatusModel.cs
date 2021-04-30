using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Models.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            IsSuccessfull = true;
        }
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }
    }
}

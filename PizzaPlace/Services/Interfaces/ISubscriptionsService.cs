using PizzaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services.Interfaces
{
    public interface ISubscriptionsService
    {
        bool Create(Subscription subscription);
    }
}

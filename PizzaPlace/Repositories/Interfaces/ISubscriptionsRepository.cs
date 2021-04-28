using PizzaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface ISubscriptionsRepository
    {
        void Add(Subscription  subscription);
        bool CheckIfExists(string email);
    }
}

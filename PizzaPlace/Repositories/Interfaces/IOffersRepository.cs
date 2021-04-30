using PizzaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface IOffersRepository
    {
        List<Offer> GetAllValid();
        List<Offer> GetAll();
        Offer GetById(int id);
        void Delete(Offer offer);
        bool CheckIfExists(Offer offer, string title);
        void Create(Offer offer);
        void Update(Offer offer);
    }
}

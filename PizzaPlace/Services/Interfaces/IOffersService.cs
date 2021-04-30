using PizzaPlace.Models;
using PizzaPlace.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services.Interfaces
{
    public interface IOffersService
    {
        List<Offer> GetAllValid();
        List<Offer> GetAll();
        Offer GetById(int id);
        void Delete(Offer offer);
        StatusModel Create(Offer offer);
        StatusModel Update(Offer offer);
    }
}

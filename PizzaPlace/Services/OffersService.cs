using PizzaPlace.Models;
using PizzaPlace.Models.DtoModels;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services
{
    public class OffersService : IOffersService
    {
        private readonly IOffersRepository _offersRepository;

        public OffersService(IOffersRepository offersRepository)
        {
            _offersRepository = offersRepository;
        }

        public StatusModel Create(Offer offer)
        {
            var response = new StatusModel();
            bool ifExists = _offersRepository.CheckIfExists(null, offer.Title);
            if (ifExists)
            {
                response.IsSuccessfull = false;
                response.Message = $"There already is an offer with title {offer.Title}";
            }
            else
            {
                offer.DateCreated = DateTime.Now;
                //offer.Slug = offer.Title.GenerateSlug();
                _offersRepository.Create(offer);
            }
            return response;
        }

        public void Delete(Offer offer)
        {
            _offersRepository.Delete(offer);
        }

        public List<Offer> GetAll()
        {
            return _offersRepository.GetAll();
        }

        public List<Offer> GetAllValid()
        {
            return _offersRepository.GetAllValid();
        }

        public Offer GetById(int id)
        {
            return _offersRepository.GetById(id);
        }

        public StatusModel Update(Offer offer)
        {
            var response = new StatusModel();
            var offerToModify = _offersRepository.GetById(offer.Id);
            if (offerToModify != null)
            {
                var checkIfExists = _offersRepository.CheckIfExists(null, offer.Title);

                if (checkIfExists)
                {
                    response.IsSuccessfull = false;
                    response.Message = $"There is already an offer with title {offer.Title}";
                }
                else
                {
                    offerToModify.Title = offer.Title;
                    offerToModify.ValidUntil = offer.ValidUntil;
                    offerToModify.Description = offer.Description;
                    //offerToModify.DateModified = DateTime.Now;
                    //offerToModify.Slug = menuItem.Title.GenerateSlug();
                    _offersRepository.Update(offerToModify);
                    response.Message = $"The offer with ID {offerToModify.Id} has been successfully updated.";
                }
            }
            else
            {
                response.IsSuccessfull = false;
                response.Message = $"There is no offer with ID {offer.Id}";
            }
            return response;
        }
    }
}

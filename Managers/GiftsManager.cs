using FinalProject.Entities;
using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public class GiftsManager : IGiftsManager
    {
        private readonly IGiftsRepository giftsRepository;
        public GiftsManager(IGiftsRepository giftsRepository)
        {
            this.giftsRepository = giftsRepository;
        }
        public List<GiftModel> GetGifts()
        {
            var gifts = giftsRepository.GetGiftsIQueryable()
                .Select(x => new GiftModel
                {
                    Id = x.Id,
                })
                .ToList();
            return gifts;
        }
        public List<int> GetGiftIdsList()
        {
            var gifts = giftsRepository.GetGiftsIQueryable();
            var idList = gifts.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Gift GetGiftById(int id)
        {
            var gift = giftsRepository.GetGiftsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return gift;
        }

        public void CreateGift(GiftModel giftModel)
        {
            var newGift = new Gift
            {
                Id = giftModel.Id
            };

            giftsRepository.CreateGift(newGift);
        }

        public void DeleteGift(int Id)
        {
            var gift = GetGiftById(Id);
            giftsRepository.DeleteGift(gift);
        }

    }
}

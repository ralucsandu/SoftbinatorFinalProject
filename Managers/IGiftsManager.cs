using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface IGiftsManager
    {
        List<GiftModel> GetGifts();
        List<int> GetGiftIdsList();
        Gift GetGiftById(int id);
        void CreateGift(GiftModel concertModel);
        void DeleteGift(int GiftId);

    }
}

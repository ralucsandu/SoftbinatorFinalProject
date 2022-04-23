using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IGiftsRepository
    {
        IQueryable<Gift> GetGiftsIQueryable();
        void CreateGift(Gift gift);
        void DeleteGift(Gift gift);
    }
}

using btre.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace btre.Models
{
    public interface IListingRepository
    {
        public Task<IEnumerable<Listing>> GetListings();
        public Task<Listing> GetListing(int id);
        public Task<string> CreateListing(CreateListingViewModel model);
        Task<IEnumerable<Listing>> GetTop3Listing();
    }
}

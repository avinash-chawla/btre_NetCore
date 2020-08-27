using btre.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace btre.Models
{
    public interface IRealtorRepository
    {
        Task<Realtor> GetRealtor(int id);
        IEnumerable<Realtor> GetRealtors();
        Task<string> CreateRealtor(CreateRealtorViewModel model);
    }
}

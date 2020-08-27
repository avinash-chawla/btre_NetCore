using btre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using btre.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace btre.Models
{
    public class ListingRepository : IListingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ListingRepository(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Listing> GetListing(int id)
        {
            var listing = await _context.Listings.SingleOrDefaultAsync(x => x.Id == id);
            return listing;
        }

        public async Task<IEnumerable<Listing>> GetListings()
        {
            var listings = await _context.Listings.Include(x => x.Realtor).ToListAsync();
            return listings;
        }

        public async Task<string> CreateListing(CreateListingViewModel model)
        {
            var uniqueFileName = UploadedFile(model.PhotoMain);
            var uniqueFileName1 = UploadedFile(model.Photo1);
            var uniqueFileName2 = UploadedFile(model.Photo2);
            var uniqueFileName3 = UploadedFile(model.Photo3);
            var uniqueFileName4 = UploadedFile(model.Photo4);
            var uniqueFileName5 = UploadedFile(model.Photo5);
            var uniqueFileName6 = UploadedFile(model.Photo6);

            Listing listing = new Listing
            {
                Title = model.Title,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Description = model.Description,
                Price = model.Price,
                Bedrooms = model.Bedrooms,
                Bathrooms = model.Bathrooms,
                Garage = model.Garage,
                Sqft = model.Sqft,
                LotSize = model.LotSize,
                PhotoMain = uniqueFileName,
                Photo1 = uniqueFileName1,
                Photo2 = uniqueFileName2,
                Photo3 = uniqueFileName3,
                Photo4 = uniqueFileName4,
                Photo5 = uniqueFileName5,
                Photo6 = uniqueFileName6,
                IsPublished = model.IsPublished,
                RealtorId = model.RealtorId
            };

            await _context.Listings.AddAsync(listing);
            await _context.SaveChangesAsync();
            return "Successfully Created";
        }

        private String UploadedFile(IFormFile photo)
        {
            string uniqueFileName = null;
            if(photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = DateTime.Now.ToString("yyyyMMdd") + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

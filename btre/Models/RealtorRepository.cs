using btre.Data;
using btre.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace btre.Models
{
    public class RealtorRepository : IRealtorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RealtorRepository(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> CreateRealtor(CreateRealtorViewModel model)
        {
            string uniqueFileName = UploadedFile(model.Image);
            Realtor realtor = new Realtor
            {
                Name = model.Name,
                Description = model.Description,
                Phone = model.Phone,
                Email = model.Email,
                Image = uniqueFileName
            };
            await _context.Realtors.AddAsync(realtor);
            await _context.SaveChangesAsync();
            return "Successfully Created";
        }

        private String UploadedFile(IFormFile photo)
        {
            string uniqueFileName = null;
            if(photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "realtors");
                uniqueFileName = DateTime.Now.ToString("yyyyMMdd") + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public Task<Realtor> GetRealtor(int id)
        {
            var realtor = _context.Realtors.FirstOrDefaultAsync(x => x.Id == id);
            return realtor;
        }

        public IEnumerable<Realtor> GetRealtors()
        {
            var realtors = _context.Realtors.ToList();
            return realtors;
        }
    }
}

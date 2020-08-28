using System;
using System.IO;
using System.Threading.Tasks;
using btre.Models;
using btre.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace btre.Controllers
{
    public class AdminController : Controller
    {
        private readonly IListingRepository _listingRepo;
        private readonly IRealtorRepository _realtorRepo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(IListingRepository listingRepo, IRealtorRepository realtorRepo, IWebHostEnvironment hostEnvironment)
        {
            _listingRepo = listingRepo;
            _realtorRepo = realtorRepo;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listings()
        {
            var listings = await _listingRepo.GetListings();
            return View(listings);
        }

        public IActionResult CreateListing()
        {
            CreateListingViewModel model = new CreateListingViewModel
            {
                Realtors = _realtorRepo.GetRealtors()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateListing(CreateListingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = await _listingRepo.CreateListing(model);
                return RedirectToAction(nameof(Listings));
            }
            return View();
        }

        public IActionResult CreateRealtor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRealtor(CreateRealtorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = await _realtorRepo.CreateRealtor(model);
                return RedirectToAction(nameof(Realtors));
            }
            return View();
        }

        public IActionResult Realtors()
        {
            var realtors = _realtorRepo.GetRealtors();
            return View(realtors);
        }

        public async Task<IActionResult> EditListing(int id)
        {
            var listing = await _listingRepo.GetListing(id);
            EditListingViewModel model = new EditListingViewModel()
            {
                Id = listing.Id,
                Title = listing.Title,
                Address = listing.Address,
                City = listing.City,
                State = listing.State,
                ZipCode = listing.ZipCode,
                Description = listing.Description,
                Price = listing.Price,
                Bedrooms = listing.Bedrooms,
                Bathrooms = listing.Bathrooms,
                Garage = listing.Garage,
                Sqft = listing.Sqft,
                LotSize = listing.LotSize,
                IsPublished = listing.IsPublished,
                RealtorId = listing.RealtorId,
                Realtors = _realtorRepo.GetRealtors(),
                ExistingPhotoMain = listing.PhotoMain,
                ExistingPhoto1 = listing.Photo1,
                ExistingPhoto2 = listing.Photo2,
                ExistingPhoto3 = listing.Photo3,
                ExistingPhoto4 = listing.Photo4,
                ExistingPhoto5 = listing.Photo5,
                ExistingPhoto6 = listing.Photo6,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditListing(EditListingViewModel model)
        {
            if(ModelState.IsValid)
            {
                var listing = await _listingRepo.GetListing(model.Id);
                listing.Title = model.Title;
                listing.Title = model.Title;
                listing.Address = model.Address;
                listing.City = model.City;
                listing.State = model.State;
                listing.ZipCode = model.ZipCode;
                listing.Description = model.Description;
                listing.Price = model.Price;
                listing.Bedrooms = model.Bedrooms;
                listing.Bathrooms = model.Bathrooms;
                listing.Garage = model.Garage;
                listing.Sqft = model.Sqft;
                listing.LotSize = model.LotSize;
                listing.IsPublished = model.IsPublished;
                listing.RealtorId = model.RealtorId;

                if(model.PhotoMain != null)
                {
                    if(model.ExistingPhotoMain != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhotoMain);
                        System.IO.File.Delete(filePath);
                    }
                    listing.PhotoMain = UploadedFile(model.PhotoMain);
                };
                if (model.Photo1 != null)
                {
                    if (model.ExistingPhoto1 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto1);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo1 = UploadedFile(model.Photo1);
                };
                if (model.Photo2 != null)
                {
                    if (model.ExistingPhoto2 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto2);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo2 = UploadedFile(model.Photo2);
                };
                if (model.Photo3 != null)
                {
                    if (model.ExistingPhoto3 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto3);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo3 = UploadedFile(model.Photo3);
                };
                if (model.Photo4 != null)
                {
                    if (model.ExistingPhoto4 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto4);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo4 = UploadedFile(model.Photo4);
                };
                if (model.Photo5 != null)
                {
                    if (model.ExistingPhoto5 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto5);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo5 = UploadedFile(model.Photo5);
                };
                if (model.Photo6 != null)
                {
                    if (model.ExistingPhoto6 != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhoto6);
                        System.IO.File.Delete(filePath);
                    }
                    listing.Photo6 = UploadedFile(model.Photo6);
                };

                Listing updatedListing = _listingRepo.Update(listing);
                return RedirectToAction("Index");
            }
            return View();
        }

        private String UploadedFile(IFormFile photo)
        {
            string uniqueFileName = null;
            if (photo != null)
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


        public async Task<IActionResult> EditRealtor(int id)
        {
            var realtor = await _realtorRepo.GetRealtor(id);
            EditRealtorViewModel model = new EditRealtorViewModel
            {
                Name = realtor.Name,
                Description = realtor.Description,
                Email = realtor.Email,
                Phone = realtor.Phone,
                IsMvp = realtor.IsMvp,
                ExistingImage = realtor.Image
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRealtor(EditRealtorViewModel model)
        { 
            if(ModelState.IsValid)
            {
                var realtor = await _realtorRepo.GetRealtor(model.Id);
                realtor.Name = model.Name;
                realtor.Description = model.Description;
                realtor.Email = model.Email;
                realtor.Phone = model.Phone;
                realtor.IsMvp = model.IsMvp;
                if(model.Image != null)
                {
                    if(model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "realtors", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    };
                    realtor.Image = UploadedFile(model.Image);
                };
                Realtor updatedRealtor = _realtorRepo.Update(realtor);
                return RedirectToAction("Index");
            };
            return View();
        }

        [HttpPost]
        public IActionResult DeleteListing(int id)
        {
            var result = _listingRepo.Delete(id);
            return RedirectToAction(nameof(Listings)); ;
        }

        [HttpPost]
        public IActionResult DeleteRealtor(int id)
        {
            var result = _realtorRepo.Delete(id);
            if (result == null)
            {
                throw new NotImplementedException();
            };
            return RedirectToAction(nameof(Realtors));
        }
    }
}
//private object UploadedFile2(CreateListingViewModel model)
//{
//    PropertyInfo[] properties = model.GetType().GetProperties();
//    foreach(PropertyInfo property in properties)
//    {
//        if(property.GetType().IsInterface)
//        {
//            string uniqueFileName = null;

//            if (property.Name != null)
//            {
//                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", model.Id.ToString());
//                uniqueFileName = DateTime.Now.ToString("yyyyMMdd") + "_" + model.property.FileName;
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    model.property.CopyTo(fileStream);
//                }
//            }
//        }
//    }
//}

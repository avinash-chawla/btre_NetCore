using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(IListingRepository listingRepo, IWebHostEnvironment hostEnvironment)
        {
            _listingRepo = listingRepo;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();

        }

        public async Task<IActionResult>Listings()
        {
            var listings = await _listingRepo.GetListings();
            return View(listings);
        }

        public IActionResult CreateListing()
        {
            return View();
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
        public IActionResult CreateRealtor(CreateRealtorViewModel model)
        {
            return View();
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

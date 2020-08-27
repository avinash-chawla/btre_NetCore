using System.Threading.Tasks;
using btre.Models;
using btre.ViewModels;
using Microsoft.AspNetCore.Hosting;
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

        public async Task<IActionResult>Listings()
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
            CreateListingViewModel model = new CreateListingViewModel()
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
                Realtors = _realtorRepo.GetRealtors()
            };

            return View("CreateListing",model);
        }

        public async Task<IActionResult> EditRealtor(int id)
        {
            var realtor = await _realtorRepo.GetRealtor(id);
            CreateRealtorViewModel model = new CreateRealtorViewModel
            {
                Name = realtor.Name,
                Description = realtor.Description,
                Email = realtor.Email,
                Phone = realtor.Phone,
                IsMvp = realtor.IsMvp,
            };
            return View("CreateRealtor", model);
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

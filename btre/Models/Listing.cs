using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace btre.Models
{
    public class Listing
    {
        public Listing()
        {
            this.Garage = 0;
            this.IsPublished = true;
            this.ListDate = DateTime.Now;
        }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Garage { get; set; }
        public int Sqft { get; set; }
        public decimal LotSize { get; set; }
        public IFormFile PhotoMain { get; set; }
        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }
        public IFormFile Photo4 { get; set; }
        public IFormFile Photo5 { get; set; }
        public IFormFile Photo6 { get; set; }
        public Boolean IsPublished { get; set; }
        public DateTime? ListDate { get; set; }
        public int RealtorId { get; set; }

        [ForeignKey("RealtorId")]
        public Realtor Realtor { get; set; }
    }
}

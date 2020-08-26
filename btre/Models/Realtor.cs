using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace btre.Models
{
    public class Realtor
    {
        public Realtor()
        {
            this.HireDate = DateTime.Now;
        }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        public Boolean? IsMvp { get; set; }
        public DateTime? HireDate { get; set; }
        public IFormFile Image { get; set; }
    }
}

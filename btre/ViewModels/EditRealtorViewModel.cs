using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace btre.ViewModels
{
    public class EditRealtorViewModel : CreateRealtorViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}

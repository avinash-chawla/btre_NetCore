using System;

namespace btre.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public void GetName()
        {
            new DateTime();
        }
    }
    
        
}

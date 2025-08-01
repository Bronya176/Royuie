using Microsoft.AspNetCore.Mvc;

namespace royuie.Models
{
    public class ManageAccountViewModel
    {
        public string Email { get; set; }  // read-only in form

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostCode { get; set; }

        public string State { get; set; }
    }
}

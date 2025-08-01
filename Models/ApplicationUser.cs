using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    public override string UserName { get; set; } // Ensure this is overridden to control the behaviour

    [Required]
    public string Name { get; set; }

    [Required]
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "PostCode must be 4 digits")]
    public string PostCode { get; set; }

    [Required]
    public string State { get; set; }

    // Email and Phone Number are inherited from the default properties of IdentityUser as it is part of ASP.NET identity //
}

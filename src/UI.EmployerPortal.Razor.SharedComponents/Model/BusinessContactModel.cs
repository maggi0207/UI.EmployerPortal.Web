using System.ComponentModel.DataAnnotations;

namespace UI.EmployerPortal.Razor.SharedComponents.Model;

/// <summary>
/// Model for the Business Contact step of the employer registration wizard.
/// </summary>
public class BusinessContactModel
{
    [Required(ErrorMessage = "First Name is required.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    public string? LastName { get; set; }

    public string? Title { get; set; }

    public bool? IsDifferentAddress { get; set; }

    public AddressModel ContactAddress { get; set; } = new();
}

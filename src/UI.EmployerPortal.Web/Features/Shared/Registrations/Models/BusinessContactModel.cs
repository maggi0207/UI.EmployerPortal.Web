using System.ComponentModel.DataAnnotations;
using UI.EmployerPortal.Razor.SharedComponents.Model;

namespace UI.EmployerPortal.Web.Features.Shared.Registrations.Models;

/// <summary>
/// Model for the Business Contact step of the employer registration wizard.
/// </summary>
public class BusinessContactModel
{
    /// <summary>
    /// Contact's first name.
    /// </summary>
    [Required(ErrorMessage = "First Name is required.")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Contact's last name.
    /// </summary>
    [Required(ErrorMessage = "Last Name is required.")]
    public string? LastName { get; set; }

    /// <summary>
    /// Contact's job title (optional).
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Indicates whether the business contact address differs from the mailing address.
    /// Null means the user has not yet made a selection.
    /// </summary>
    public bool? IsDifferentAddress { get; set; }

    /// <summary>
    /// Business contact address, collected only when <see cref="IsDifferentAddress"/> is true.
    /// </summary>
    public AddressModel ContactAddress { get; set; } = new();
}

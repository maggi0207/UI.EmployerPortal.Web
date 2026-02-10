using System.ComponentModel.DataAnnotations;

namespace UI.EmployerPortal.Web.Features.EmployerRegistration.Models;

public class BusinessInformationModel
{
    [Required]
    public string FEIN { get; set; } = string.Empty;

    [Required]
    public string LegalName { get; set; } = string.Empty;

    public string TradeName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    // Mailing Address
    [Required]
    public string MailingCountry { get; set; } = "United States";

    [Required]
    public string MailingAddressLine1 { get; set; } = string.Empty;

    public string MailingAddressLine2 { get; set; } = string.Empty;

    [Required]
    public string MailingCity { get; set; } = string.Empty;

    [Required]
    public string MailingState { get; set; } = string.Empty;

    [Required]
    public string MailingZip { get; set; } = string.Empty;

    public string MailingExtension { get; set; } = string.Empty;

    // Physical Location 1
    [Required]
    public string PhysicalCountry { get; set; } = "United States";

    [Required]
    public string PhysicalAddressLine1 { get; set; } = string.Empty;

    public string PhysicalAddressLine2 { get; set; } = string.Empty;

    [Required]
    public string PhysicalCity { get; set; } = string.Empty;

    [Required]
    public string PhysicalState { get; set; } = string.Empty;

    [Required]
    public string PhysicalZip { get; set; } = string.Empty;

    public string PhysicalExtension { get; set; } = string.Empty;
}

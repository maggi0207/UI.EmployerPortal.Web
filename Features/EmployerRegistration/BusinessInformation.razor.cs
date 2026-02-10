using Microsoft.AspNetCore.Components;
using UI.EmployerPortal.Web.Components.Shared;
using UI.EmployerPortal.Web.Features.EmployerRegistration.Models;

namespace UI.EmployerPortal.Web.Features.EmployerRegistration;

public partial class BusinessInformation
{
    [Inject] private NavigationManager Nav { get; set; } = default!;

    protected BusinessInformationModel Model { get; set; } = new();
    protected HashSet<string> ErrorFields { get; set; } = new();

    protected List<SelectOption> Countries { get; set; } = new()
    {
        new SelectOption { Value = "United States", Text = "United States" },
        new SelectOption { Value = "Canada", Text = "Canada" },
        new SelectOption { Value = "Mexico", Text = "Mexico" }
    };

    protected List<SelectOption> States { get; set; } = new()
    {
        new SelectOption { Value = "AL", Text = "Alabama" },
        new SelectOption { Value = "AK", Text = "Alaska" },
        new SelectOption { Value = "AZ", Text = "Arizona" },
        new SelectOption { Value = "AR", Text = "Arkansas" },
        new SelectOption { Value = "CA", Text = "California" },
        new SelectOption { Value = "CO", Text = "Colorado" },
        new SelectOption { Value = "CT", Text = "Connecticut" },
        new SelectOption { Value = "DE", Text = "Delaware" },
        new SelectOption { Value = "FL", Text = "Florida" },
        new SelectOption { Value = "GA", Text = "Georgia" },
        new SelectOption { Value = "HI", Text = "Hawaii" },
        new SelectOption { Value = "ID", Text = "Idaho" },
        new SelectOption { Value = "IL", Text = "Illinois" },
        new SelectOption { Value = "IN", Text = "Indiana" },
        new SelectOption { Value = "IA", Text = "Iowa" },
        new SelectOption { Value = "KS", Text = "Kansas" },
        new SelectOption { Value = "KY", Text = "Kentucky" },
        new SelectOption { Value = "LA", Text = "Louisiana" },
        new SelectOption { Value = "ME", Text = "Maine" },
        new SelectOption { Value = "MD", Text = "Maryland" },
        new SelectOption { Value = "MA", Text = "Massachusetts" },
        new SelectOption { Value = "MI", Text = "Michigan" },
        new SelectOption { Value = "MN", Text = "Minnesota" },
        new SelectOption { Value = "MS", Text = "Mississippi" },
        new SelectOption { Value = "MO", Text = "Missouri" },
        new SelectOption { Value = "MT", Text = "Montana" },
        new SelectOption { Value = "NE", Text = "Nebraska" },
        new SelectOption { Value = "NV", Text = "Nevada" },
        new SelectOption { Value = "NH", Text = "New Hampshire" },
        new SelectOption { Value = "NJ", Text = "New Jersey" },
        new SelectOption { Value = "NM", Text = "New Mexico" },
        new SelectOption { Value = "NY", Text = "New York" },
        new SelectOption { Value = "NC", Text = "North Carolina" },
        new SelectOption { Value = "ND", Text = "North Dakota" },
        new SelectOption { Value = "OH", Text = "Ohio" },
        new SelectOption { Value = "OK", Text = "Oklahoma" },
        new SelectOption { Value = "OR", Text = "Oregon" },
        new SelectOption { Value = "PA", Text = "Pennsylvania" },
        new SelectOption { Value = "RI", Text = "Rhode Island" },
        new SelectOption { Value = "SC", Text = "South Carolina" },
        new SelectOption { Value = "SD", Text = "South Dakota" },
        new SelectOption { Value = "TN", Text = "Tennessee" },
        new SelectOption { Value = "TX", Text = "Texas" },
        new SelectOption { Value = "UT", Text = "Utah" },
        new SelectOption { Value = "VT", Text = "Vermont" },
        new SelectOption { Value = "VA", Text = "Virginia" },
        new SelectOption { Value = "WA", Text = "Washington" },
        new SelectOption { Value = "WV", Text = "West Virginia" },
        new SelectOption { Value = "WI", Text = "Wisconsin" },
        new SelectOption { Value = "WY", Text = "Wyoming" }
    };

    protected bool HasFieldError(string fieldName) => ErrorFields.Contains(fieldName);

    protected void HandleBack()
    {
        Nav.NavigateTo("/ownership");
    }

    protected void HandleSaveQuit()
    {
        Nav.NavigateTo("/dashboard");
    }

    protected void HandleContinue()
    {
        Validate();

        if (!ErrorFields.Any())
        {
            Nav.NavigateTo("/address-correction");
        }
    }

    protected void AddPhysicalLocation()
    {
        // TODO: Add additional physical location support
    }

    private void Validate()
    {
        ErrorFields.Clear();

        if (string.IsNullOrWhiteSpace(Model.FEIN))
            ErrorFields.Add(nameof(Model.FEIN));

        if (string.IsNullOrWhiteSpace(Model.LegalName))
            ErrorFields.Add(nameof(Model.LegalName));

        if (string.IsNullOrWhiteSpace(Model.PhoneNumber))
            ErrorFields.Add(nameof(Model.PhoneNumber));

        if (string.IsNullOrWhiteSpace(Model.Email))
            ErrorFields.Add(nameof(Model.Email));

        if (string.IsNullOrWhiteSpace(Model.MailingAddressLine1))
            ErrorFields.Add(nameof(Model.MailingAddressLine1));

        if (string.IsNullOrWhiteSpace(Model.MailingCity))
            ErrorFields.Add(nameof(Model.MailingCity));

        if (string.IsNullOrWhiteSpace(Model.MailingState))
            ErrorFields.Add(nameof(Model.MailingState));

        if (string.IsNullOrWhiteSpace(Model.MailingZip))
            ErrorFields.Add(nameof(Model.MailingZip));

        if (string.IsNullOrWhiteSpace(Model.PhysicalAddressLine1))
            ErrorFields.Add(nameof(Model.PhysicalAddressLine1));

        if (string.IsNullOrWhiteSpace(Model.PhysicalCity))
            ErrorFields.Add(nameof(Model.PhysicalCity));

        if (string.IsNullOrWhiteSpace(Model.PhysicalState))
            ErrorFields.Add(nameof(Model.PhysicalState));

        if (string.IsNullOrWhiteSpace(Model.PhysicalZip))
            ErrorFields.Add(nameof(Model.PhysicalZip));
    }
}

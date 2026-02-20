# Shared Components — Simple Usage Guide

---

## Namespaces & Setup

**Required @using statements in your .razor file or _Imports.razor:**

```razor
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Components.Forms
@using UI.EmployerPortal.Web.Features.Shared.Registrations.Models
@using UI.EmployerPortal.Razor.SharedComponents.Model
@using UI.EmployerPortal.Razor.SharedComponents.Address
@using UI.EmployerPortal.Razor.SharedComponents.Validation
@using UI.EmployerPortal.Razor.SharedComponents.Inputs
```

**What each namespace provides:**
| Namespace | Purpose |
|-----------|---------|
| `System.ComponentModel.DataAnnotations` | Provides `[Required]`, `[RegularExpression]`, `[EmailAddress]` attributes |
| `Microsoft.AspNetCore.Components.Forms` | Provides `<EditForm>`, validation context |
| `UI.EmployerPortal.Web.Features.Shared.Registrations.Models` | **BusinessInformationModel**, **BusinessContactModel** |
| `UI.EmployerPortal.Razor.SharedComponents.Model` | **AddressModel** |
| `UI.EmployerPortal.Razor.SharedComponents.Address` | **AddressField** component |
| `UI.EmployerPortal.Razor.SharedComponents.Validation` | **FieldError** component |
| `UI.EmployerPortal.Razor.SharedComponents.Inputs` | **OutlinedTextField**, **OutlinedSelectField** components |

These are already imported in:
- `Features/_Imports.razor` (for all pages under Features)
- `Components/_Imports.razor` (for all components)

So you only need to add them if you're creating a page/component outside these locations.

---

## Available Components Reference

Here are all the input and validation components available in SharedComponents:

| Component | Location | Purpose |
|-----------|----------|---------|
| **FEINField** | `Inputs/FEINField.razor` | FEIN input with auto-formatting (XX-XXXXXXX) |
| **PhoneNumberField** | `Inputs/PhoneNumberField.razor` | Phone input with auto-formatting (XXX-XXX-XXXX) |
| **OutlinedTextField** | `Inputs/OutlinedTextField.razor` | Generic text input (text, email, number, tel, etc.) |
| **OutlinedSelectField** | `Inputs/OutlinedSelectField.razor` | Dropdown/select field |
| **FieldError** | `Validation/FieldError.razor` | Error message display (pairs with input fields) |
| **AddressField** | `Address/AddressField.razor` | Full address form (bundles all 7 address fields) |

**Quick picking guide:**
- Need FEIN input? → Use `FEINField`
- Need phone input? → Use `PhoneNumberField`
- Need generic text? → Use `OutlinedTextField`
- Need dropdown? → Use `OutlinedSelectField`
- Need a full address? → Use `AddressField` (which contains an `AddressModel`)
- Need error message? → Pair any input with `FieldError`

---

## What are these components?

These are reusable input fields used across the Employer Registration form.
Instead of building a new input every time, you drop in one of these components.

---

## 1. FEIN Number Field

**What it does**
A specialized text field for Federal Employer Identification Number.
Automatically formats input as `XX-XXXXXXX` (2 digits, hyphen, 7 digits).
Turns red if left empty on submit.

**File**
`Razor.SharedComponents/Inputs/FEINField.razor`

**How to use it**
```razor
<FEINField @bind-Value="Model.FEIN"
           For="() => Model.FEIN"
           Visible="formSubmitted" />
<FieldError For="@(() => Model.FEIN)" Visible="formSubmitted" />
```

**Parameters**
| Parameter | Type | Default | Purpose |
|-----------|------|---------|---------|
| `Value` | string? | | The FEIN value (2-digit-7-digit format) |
| `ValueChanged` | EventCallback | | Fires when value changes |
| `Label` | string | "FEIN" | Field label text |
| `For` | Expression | | Validation expression |
| `Visible` | bool | | Show/hide field |
| `Disabled` | bool | false | Disable input |

**Where the value is saved**
`Features/Shared/Registrations/Models/BusinessInformationModel.cs`
```csharp
[Required(ErrorMessage = "FEIN is required.")]
[RegularExpression(@"^\d{2}-\d{7}$", ErrorMessage = "FEIN must be in format 99-9999999.")]
public string? FEIN { get; set; }
```

---

## 2. Phone Number Field

**What it does**
A specialized text field for phone numbers.
Automatically formats input as `XXX-XXX-XXXX` as the user types.
Opens numeric keyboard on mobile. Turns red if left empty on submit.

**File**
`Razor.SharedComponents/Inputs/PhoneNumberField.razor`

**How to use it**
```razor
<PhoneNumberField @bind-Value="Model.PhoneNumber"
                  For="() => Model.PhoneNumber"
                  Visible="formSubmitted" />
<FieldError For="@(() => Model.PhoneNumber)" Visible="formSubmitted" />
```

**Parameters**
| Parameter | Type | Default | Purpose |
|-----------|------|---------|---------|
| `Value` | string? | | The phone number (XXX-XXX-XXXX format) |
| `ValueChanged` | EventCallback | | Fires when value changes |
| `Label` | string | "Phone Number" | Field label text |
| `For` | Expression | | Validation expression |
| `Visible` | bool | | Show/hide field |
| `Disabled` | bool | false | Disable input |

**Where the value is saved**
`Features/Shared/Registrations/Models/BusinessInformationModel.cs`
```csharp
[Required(ErrorMessage = "Phone Number is required.")]
[RegularExpression(@"^\d{3}-\d{3}-\d{4}$",
    ErrorMessage = "Phone Number must be in format 999-999-9999.")]
public string? PhoneNumber { get; set; }
```

---

## 3. Select / Dropdown Field

**What it does**
A dropdown/select field where the user picks one option from a list (e.g. State, Country).
Shows a custom arrow icon. Turns red if nothing is selected on submit.

**File**
`Razor.SharedComponents/Inputs/OutlinedSelectField.razor`

**How to use it**
```razor
<OutlinedSelectField Label="State"
                     @bind-Value="Model.State"
                     Options="States"
                     Placeholder="Select a state"
                     For="() => Model.State"
                     Visible="formSubmitted" />
<FieldError For="@(() => Model.State)" Visible="formSubmitted" />
```

**Parameters**
| Parameter | Type | Default | Purpose |
|-----------|------|---------|---------|
| `Value` | string? | | Selected option value |
| `ValueChanged` | EventCallback | | Fires when selection changes |
| `Label` | string? | | Field label text |
| `Options` | List<SelectOption> | | List of available options |
| `Placeholder` | string? | | Placeholder text shown in dropdown |
| `For` | Expression | | Validation expression |
| `Visible` | bool | | Show/hide field |
| `Disabled` | bool | false | Disable dropdown |

**Defining options in code-behind:**
`Features/EmployerRegistration/BusinessInformation.razor.cs`
```csharp
protected List<SelectOption> States { get; set; } = new()
{
    new SelectOption { Value = "AL", Text = "Alabama" },
    new SelectOption { Value = "AK", Text = "Alaska" },
    // add more as needed
};
```

**Where the value is saved**
`Features/Shared/Registrations/Models/BusinessInformationModel.cs`
```csharp
[Required(ErrorMessage = "State is required.")]
public string? State { get; set; }
```

---

## 4. Address Fields (Using AddressModel)

**What it does**
A reusable address form component that collects Country, Address Line 1/2, City, State, and Zip.
Instead of binding individual properties, use the `AddressField` component with `AddressModel`.
Required fields show errors if left empty; optional fields (Address Line 2, Extension) do not.

**Files**
- Component: `Razor.SharedComponents/Address/AddressField.razor`
- Model: `Razor.SharedComponents/Model/AddressModel.cs`

**How to use it**
```razor
<AddressField @bind-Value="Model.MailingAddress"
             Visible="formSubmitted" />
```

The form automatically handles all 7 address fields (Country, Address Line 1/2, City, State, Zip, Extension).

**Where the value is saved**
`Features/Shared/Registrations/Models/BusinessInformationModel.cs`
```csharp
public AddressModel MailingAddress { get; set; } = new();
public List<AddressModel> PhysicalLocations { get; set; } = new()
{
    new AddressModel()
};
```

For Business Contact:
`Features/Shared/Registrations/Models/BusinessContactModel.cs`
```csharp
public AddressModel ContactAddress { get; set; } = new();
```

**AddressModel properties**
```csharp
public string? Country { get; set; } = "United States";  // required
public string? AddressLine1 { get; set; }                // required
public string? AddressLine2 { get; set; }                // optional
public string? City { get; set; }                        // required
public string? State { get; set; }                       // required
public string? Zip { get; set; }                         // required
public string? Extension { get; set; }                   // optional (ZIP+4)
```

---

## 5. Validation (Error Messages)

**What it does**
Error messages stay hidden when the page first loads.
They only appear after the user clicks Submit and leaves a required field empty.
Once the user starts typing in that field, the error clears automatically.

**File**
`Features/EmployerRegistration/Components/FieldError.razor`

**The rule — always pair every required field with FieldError**

```
OutlinedTextField  ← the input box
FieldError         ← the red error message below it
```

Both must point to the same model property using `For`:

```razor
<OutlinedTextField Label="Zip Code"
                   @bind-Value="Model.MailingZip"
                   For="() => Model.MailingZip"
                   Visible="formSubmitted" />

<FieldError For="@(() => Model.MailingZip)" Visible="formSubmitted" />
```

**Where errors are defined**
`Features/Shared/Registrations/Models/BusinessInformationModel.cs`

Add `[Required]` above a property to make it mandatory:
```csharp
[Required(ErrorMessage = "Zip Code is required.")]
public string? Zip { get; set; }
```

Change the text inside `ErrorMessage = "..."` to control what the user sees.

---

## Quick Checklist — Adding a New Field

- [ ] Add the property to `BusinessInformationModel.cs` or `BusinessContactModel.cs`
- [ ] Add `[Required]` if the field is mandatory
- [ ] Drop in `OutlinedTextField` or `OutlinedSelectField` in the `.razor` page
- [ ] Add `<FieldError>` directly below it (required fields only)
- [ ] Make sure `For=` on both lines points to the same property
- [ ] Make sure `Visible="formSubmitted"` is on both lines

---

## Address Model Structure

For address data (mailing, physical locations, contact), use the reusable `AddressModel` in `Razor.SharedComponents/Model/AddressModel.cs`:

**In BusinessInformationModel:**
```csharp
public AddressModel MailingAddress { get; set; } = new();
public List<AddressModel> PhysicalLocations { get; set; } = new();
```

**In BusinessContactModel:**
```csharp
public AddressModel ContactAddress { get; set; } = new();
```

**In your .razor page, bind the entire address at once:**
```razor
<AddressField @bind-Value="Model.MailingAddress" />
```

using Microsoft.AspNetCore.Components;

namespace UI.EmployerPortal.Web.Components.Shared;

public partial class SelectField
{
    [Parameter] public string Label { get; set; } = string.Empty;
    [Parameter] public string Value { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public List<SelectOption> Options { get; set; } = new();
    [Parameter] public string Placeholder { get; set; } = string.Empty;
    [Parameter] public bool HasError { get; set; }
    [Parameter] public string ErrorMessage { get; set; } = string.Empty;

    private async Task OnChange(ChangeEventArgs e)
    {
        await ValueChanged.InvokeAsync(e.Value?.ToString() ?? string.Empty);
    }
}

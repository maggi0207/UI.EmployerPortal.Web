using Microsoft.AspNetCore.Components;

namespace UI.EmployerPortal.Web.Components.Shared;

public partial class TextField
{
    [Parameter] public string Label { get; set; } = string.Empty;
    [Parameter] public string Value { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public string Type { get; set; } = "text";
    [Parameter] public bool HasError { get; set; }
    [Parameter] public string ErrorMessage { get; set; } = string.Empty;

    private async Task OnInput(ChangeEventArgs e)
    {
        await ValueChanged.InvokeAsync(e.Value?.ToString() ?? string.Empty);
    }
}

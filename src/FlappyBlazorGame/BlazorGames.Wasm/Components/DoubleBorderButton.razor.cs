using Microsoft.AspNetCore.Components;

namespace BlazorGames.Wasm.Components;
public partial class DoubleBorderButton
{
    [Parameter] public string Caption { get; set; } = string.Empty;
    [Parameter] public string Href { get; set; } = "#";
}

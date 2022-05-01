using Microsoft.AspNetCore.Components;

namespace BananaBattles.Shared;
public partial class TopMenu
{
    [Parameter]
    public uint Bananas { get; set; } = 100;
}

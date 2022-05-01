using Microsoft.AspNetCore.Components;

namespace BananaBattles.Shared;

public partial class AddBanana
{
    [Parameter]
    public EventCallback<int> BananasAdded { get; set; }

    public async Task IncreaseBananaCount()
    {
        await BananasAdded.InvokeAsync(10);
    }
}

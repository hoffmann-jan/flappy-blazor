using Microsoft.AspNetCore.Components;

namespace BananaBattles.Shared;
public partial class TopMenu
{
    [Parameter]
    public int Bananas { get; set; } = 100;

    public void AddBananas(int value)
    {
        Bananas += value;
    }
}

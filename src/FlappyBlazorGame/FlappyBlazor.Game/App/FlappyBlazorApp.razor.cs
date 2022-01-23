using Microsoft.AspNetCore.Components.Web;

namespace FlappyBlazor.Game.App;
public partial class FlappyBlazorApp : IAsyncDisposable
{
    GameManager? _gameManager;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _gameManager = new GameManager();
        _gameManager.MainLoopCycleCompleted += OnPropertyChanged;
    }

    private void OnPropertyChanged(object? sender, EventArgs e)
    {
        StateHasChanged();
    }


    public async ValueTask DisposeAsync()
    {
        if (_gameManager != null)
        {
            _gameManager.MainLoopCycleCompleted -= OnPropertyChanged;
            _gameManager = null;
        }


        await ValueTask.CompletedTask;
    }

}

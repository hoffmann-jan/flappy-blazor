using FlappyBlazor.Game.Models;

using Microsoft.AspNetCore.Components.Web;

namespace FlappyBlazor.Game;
internal class GameManager
{
    public event EventHandler? MainLoopCycleCompleted;

    public BirdModel Bird { get; private set; }
    public List<PipeModel> Pipes { get; private set; }
    public bool IsRunning { get; private set; } = false;

    public GameManager()
    {
        Bird = new ();
        Pipes = new ();
    }

    public void HandleKeyUp(KeyboardEventArgs keyboardEventArgs)
    {
        if (keyboardEventArgs.Key == Configuration.Bird_JumpKeyString)
        {
            Jump();
        }
    }

    public async void HandleTouched(TouchEventArgs touchEventArgs)
    {
        if (IsRunning)
        {
            Jump();
        }
        else
        {
            await StartGame();
        }
    }

    public async Task StartGame()
    {
        if (IsRunning)
            return;

        Bird = new();
        Pipes = new();
        await GameLoop();
    }

    private void CheckForCollisions()
    {
        if (Bird.IsOnGround())
        {
            GameOver();
        }

        var centeredPipe = Pipes.FirstOrDefault(p => p.IsCentered(Configuration.Bird_Width, Configuration.Game_Width));

        if (centeredPipe != null)
        {
            var hasCollidedWithBottom = Bird.DistanceFromGround < centeredPipe.GapBottom - Configuration.Game_GroundHeight;
            var hasCollidedWithTop = Bird.DistanceFromGround + Configuration.Bird_Height > centeredPipe.GapTop - Configuration.Game_GroundHeight;

            if (hasCollidedWithBottom || hasCollidedWithTop)
            {
                GameOver();
            }
        }
    }

    private async Task GameLoop()
    {
        IsRunning = true;
        while(IsRunning)
        {
            MoveObjects();
            CheckForCollisions();
            ManagePipes();

            MainLoopCycleCompleted?.Invoke(this, EventArgs.Empty);
            await Task.Delay(Configuration.Game_MainLoopDelay);
        }
    }

    private void ManagePipes()
    {
        if (!Pipes.Any()
            || Pipes.Last().DistanceFromLeft <= Configuration.Game_DistanceFromLeftToNextPipe)
        {
            Pipes.Add(new PipeModel(Configuration.Pipe_Gap, Configuration.Pipe_Height, Configuration.Pipe_Width));
        }

        if (Pipes.First().IsOffScreen(Configuration.Pipe_Width))
        {
            Pipes.Remove(Pipes.First());
        }

    }

    private void MoveObjects()
    {
        Bird.Fall(Configuration.Gravity);
        Pipes.ForEach(p => p.Move());
    }

    private void Jump()
    {
        if (IsRunning)
        {
            Bird.Jump();
        }
    }

    private void GameOver()
    {
        IsRunning = false;
    }
}

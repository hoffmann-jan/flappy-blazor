using FlappyBlazor.Game.Models;

using Microsoft.AspNetCore.Components.Web;

namespace FlappyBlazor.Game;
internal class GameManager
{
    private readonly int _birdHeight = 45;
    private readonly int _birdWidth = 60;
    private readonly int _gameWidth = 500;
    private readonly int _groundHeight = 150;
    private readonly int _pipeGap = 150;
    private readonly int _pipeHeight = 300;
    private readonly int _pipeWidth = 60;
    private readonly int _gravity = 2;

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
        if (keyboardEventArgs.Key == " ")
        {
            Jump();
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

        var centeredPipe = Pipes.FirstOrDefault(p => p.IsCentered(_birdWidth, _gameWidth));

        if (centeredPipe != null)
        {
            var hasCollidedWithBottom = Bird.DistanceFromGround < centeredPipe.GapBottom - _groundHeight;
            var hasCollidedWithTop = Bird.DistanceFromGround + _birdHeight > centeredPipe.GapTop - _groundHeight;

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
            await Task.Delay(20);
        }
    }

    private void ManagePipes()
    {
        if (!Pipes.Any()
            || Pipes.Last().DistanceFromLeft <= 250)
        {
            Pipes.Add(new PipeModel(_pipeGap, _pipeHeight, _pipeWidth));
        }

        if (Pipes.First().IsOffScreen(_pipeWidth))
        {
            Pipes.Remove(Pipes.First());
        }

    }

    private void MoveObjects()
    {
        Bird.Fall(_gravity);
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

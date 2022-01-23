namespace FlappyBlazor.Game.Models;
public class PipeModel
{
    public int DistanceFromBottom { get; private set; } = new Random()
        .Next(Configuration.Pipe_DistanceFromBottomMin, Configuration.Pipe_DistanceFromBottomMax);
    public int DistanceFromLeft { get; private set; } = Configuration.Pipe_DistanceFromLeft;
    public int Gap { get; private set; }
    public int Heigth { get; private set; }
    public int Speed { get; private set; }
    public int Width { get; private set; }

    public int GapBottom => DistanceFromBottom + Heigth;
    public int GapTop => GapBottom + Gap;


    public PipeModel(int gap, int heigth, int width, int speed = Configuration.Pipe_Speed)
    {
        Gap = gap;
        Heigth = heigth;
        Width = width;
        Speed = speed;
    }

    public bool IsCentered(int birdWidth, int gameWidth)
    {
        var hasEnteredCenter = DistanceFromLeft < (gameWidth / 2) + (birdWidth / 2);
        var hasExitedCenter = DistanceFromLeft > (gameWidth / 2) + (birdWidth / 2) - Width;

        return hasEnteredCenter && !hasExitedCenter;

    }

    public bool IsOffScreen(int pipeWidth)
    {
        return DistanceFromLeft <= -pipeWidth;
    }

    public void Move()
    {
        DistanceFromLeft -= Speed;
    }
}

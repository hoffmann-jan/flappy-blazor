namespace FlappyBlazor.Game.Models;
public class PipeModel
{
    public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
    public int DistanceFromLeft { get; private set; } = 500;
    public int Gap { get; private set; }
    public int Heigth { get; private set; }
    public int Speed { get; private set; }
    public int Width { get; private set; }

    public int GapBottom => DistanceFromBottom + Heigth;
    public int GapTop => GapBottom + Gap;


    public PipeModel(int gap, int heigth, int width, int speed = 2)
    {
        Gap = gap;
        Heigth = heigth;
        Speed = speed;
    }

    public bool IsCentered(int birdWidth, int gameWidth)
    {
        var hasEnteredCenter = DistanceFromLeft <= (gameWidth / 2) + (birdWidth / 2);
        var hasExitedCenter = DistanceFromLeft <= (gameWidth / 2) + (birdWidth / 2) - Width;

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

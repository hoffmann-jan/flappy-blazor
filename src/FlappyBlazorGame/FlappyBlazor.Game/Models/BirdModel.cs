namespace FlappyBlazor.Game.Models;
public class BirdModel
{
    public int DistanceFromGround { get; private set; } = 100;
    public int JumpStremgth { get; private set; } = 50;

    public void Fall(int gravity)
    {
        DistanceFromGround -= gravity;
    }

    public bool IsOnGround()
    {
        return DistanceFromGround <= 0;
    }

    public void Jump()
    {
        if (DistanceFromGround < 530)
        {
            DistanceFromGround += JumpStremgth;
        }
    }
}

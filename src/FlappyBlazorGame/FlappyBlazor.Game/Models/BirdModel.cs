namespace FlappyBlazor.Game.Models;
public class BirdModel
{
    public int DistanceFromGround { get; private set; } = Configuration.Bird_StartDistanceFromGround;
    public int JumpStrength { get; private set; } = Configuration.Bird_JumpStrength;

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
        if (DistanceFromGround < Configuration.Bird_MaximalHightForJump)
        {
            DistanceFromGround += JumpStrength;
        }
    }
}

namespace FlappyBlazor.Game;
internal class Configuration
{
    public const int Gravity = 2;

    public const int Game_MainLoopDelay = 20;
    public const int Game_Width = 500;
    public const int Game_GroundHeight = 150;
    public const int Game_DistanceFromLeftToNextPipe = 250;

    public const int Bird_Height = 45;
    public const int Bird_Width = 60;
    public const int Bird_JumpStrength = 50;
    public const int Bird_StartDistanceFromGround = 100;
    public const int Bird_MaximalHightForJump = 530;
    public const string Bird_JumpKeyString = " ";

    public const int Pipe_Gap = 150;
    public const int Pipe_Height = 300;
    public const int Pipe_Width = 60;
    public const int Pipe_Speed = 2;
    public const int Pipe_DistanceFromBottomMin = 1;
    public const int Pipe_DistanceFromBottomMax = 60;
    public const int Pipe_DistanceFromLeft = Game_Width;
}

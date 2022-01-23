using FlappyBlazor.Game.Models;

using Microsoft.AspNetCore.Components;

namespace FlappyBlazor.Game.Components;
public partial class Pipe
{
    [Parameter] public PipeModel? Model { get; set; }
    [Parameter] public int PipeHeigth { get; set; } = 300;


    string _bottomPipeCss =>
        $"left: {Model?.DistanceFromLeft}px; bottom: {Model?.DistanceFromBottom}px;";
    string _topPipeCss =>
        $"left: {Model?.DistanceFromLeft}px; bottom: {Model?.DistanceFromBottom + PipeHeigth + Model?.Gap}px;";
}

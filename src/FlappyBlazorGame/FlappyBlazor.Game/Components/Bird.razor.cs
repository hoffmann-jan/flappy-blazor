using FlappyBlazor.Game.Models;

using Microsoft.AspNetCore.Components;

namespace FlappyBlazor.Game.Components;
public partial class Bird
{
    [Parameter] public BirdModel? Model { get; set; }

    string _birdCss => $"bottom: {Model?.DistanceFromGround}px";
}


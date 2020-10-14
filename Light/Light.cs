using Godot;
using System;

public class Light : Node2D
{
    public override void _Process(float delta)
    {
        var inputPin = GetNode<InputPin>("InputPin");
        GetNode<ColorRect>("ColorRect").Color = inputPin.Value ? Color.ColorN("yellow") : Color.ColorN("gray");
    }
}

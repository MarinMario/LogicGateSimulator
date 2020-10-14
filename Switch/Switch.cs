using Godot;
using System;

public class Switch : Node2D
{
    public void OnPressed()
    {
        var outputPin = GetNode<OutputPin>("OutputPin");
        outputPin.Value = !outputPin.Value;
        GetNode<Button>("Button").Text = outputPin.Value ? "ON" : "OFF";
    }
}
    
using Godot;
using System;

public class Light : Draggable
{
    public bool Value = false;
    protected override void Process(float delta)
    {
        Value = GetNode<InputPin>("InputPin").Value;
        GetNode<ColorRect>("ColorRect").Color = Value ? Color.ColorN("white") : Color.ColorN("black");
    }
}

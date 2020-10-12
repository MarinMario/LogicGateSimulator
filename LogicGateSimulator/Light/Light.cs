using Godot;
using System;

public class Light : Draggable
{
    public bool value = false;
    protected override void Process(float delta)
    {
        value = GetNode<InputPin>("InputPin").value;
        GetNode<ColorRect>("ColorRect").Color = value ? Color.ColorN("white") : Color.ColorN("black");
    }
}

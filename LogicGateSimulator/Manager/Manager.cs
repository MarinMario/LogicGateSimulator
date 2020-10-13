using Godot;
using System;

public class Manager : Node2D
{
    public InputPin lastInputPin;
    public OutputPin lastOutputPin;
    public Node2D world;

    public override void _Process(float delta)
    {
        if (lastInputPin != null && lastOutputPin != null)
        {
            lastInputPin.ConnectedPin = lastOutputPin;
            lastOutputPin.ConnectedPin = lastInputPin;
            lastInputPin = null;
            lastOutputPin = null;
        }
    }

    public void AddWire(IPin pin)
    {
        var wire = (Wire)ResourceLoader.Load<PackedScene>("res://Wire/Wire.tscn").Instance();
        wire.Init(pin);
        GetNode<Manager>("/root/Manager").world.AddChild(wire);
    }
}

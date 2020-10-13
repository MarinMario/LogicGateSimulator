using Godot;
using System;

public class InputPin : Node2D, IPin
{
    public bool Value { get; set; }
    public IPin ConnectedPin { get; set; }
    Manager manager;

    public override void _Ready()
    {
        manager = GetNode<Manager>("/root/Manager");
    }

    public override void _Process(float delta)
    {
        Value = ConnectedPin != null ? ConnectedPin.Value : false;
    }

    public void OnPressed()
    {
        if (ConnectedPin == null && manager.lastInputPin == null)
        {
            manager.lastInputPin = this;
            if (manager.lastOutputPin == null)
                manager.AddWire(this);
        }
    }
}

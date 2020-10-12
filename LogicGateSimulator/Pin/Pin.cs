using Godot;
using System;

public class Pin : Area2D
{
    protected bool mouseOver = false;
    public bool value = false;
    public override void _Ready()
    {
        Connect("mouse_entered", this, nameof(MouseEntered));
        Connect("mouse_exited", this, nameof(MouseExited));

        Ready();
    }

    public override void _Process(float delta)
    {
        //if (Input.IsActionJustPressed("click") && mouseOver)
        //{
        //    var wire = (Wire)ResourceLoader.Load<PackedScene>("res://Wire/Wire.tscn").Instance();
        //    wire.GlobalPosition = GlobalPosition;
        //    GetParent().GetParent().AddChild(wire);
        //}

        Process(delta);
    }

    protected virtual void Ready() { }
    protected virtual void Process(float delta) { }

    void MouseEntered()
    {
        mouseOver = true;
    }

    void MouseExited()
    {
        mouseOver = false;
    }
}

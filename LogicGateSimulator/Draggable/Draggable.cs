using Godot;
using System;

public class Draggable : Area2D
{
    protected bool mouseOver = false;
    protected bool followMouse = false;

    /// <summary>
    /// Don't override this unless you want to break the functionality of Draggable (base class).
    /// Instead, override Ready
    /// </summary>
    public override void _Ready()
    {
        Connect("mouse_entered", this, nameof(MouseEntered));
        Connect("mouse_exited", this, nameof(MouseExited));

        Ready();
    }

    /// <summary>
    /// Don't override this unless you want to break the functionality of Draggable (base class).
    /// Instead, override Process
    /// </summary>
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("click") && mouseOver)
            followMouse = true;
        if (Input.IsActionJustReleased("click"))
            followMouse = false;

        if (followMouse)
            GlobalPosition = GetGlobalMousePosition();

        Process(delta);
    }

    virtual protected void Ready() { }
    virtual protected void Process(float delta) { }

    void MouseEntered()
    {
        mouseOver = true;
    }

    void MouseExited()
    {
        mouseOver = false;
    }
}

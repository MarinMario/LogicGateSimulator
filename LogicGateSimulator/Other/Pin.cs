
public interface IPin
{
    IPin ConnectedPin { get; set; }
    bool Value { get; set; }
    void OnPressed();
    void Despawn();
}
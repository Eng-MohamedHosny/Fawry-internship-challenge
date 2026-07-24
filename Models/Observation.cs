namespace QuantumRadarSystem.Models;

public class Observation
{
    public string PlateNumber { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public CarType Type { get; set; }
    public int Speed { get; set; }
    public bool SeatbeltFastened { get; set; }
}

namespace QuantumRadarSystem.Models;

public class Violation
{
    public string Description { get; set; } = string.Empty;
    public int Fee { get; set; }
    public string RuleName { get; set; } = string.Empty;
}

namespace CarStore.Core.DomainObjects;

public class LogError   
{
    public Guid Id { get; set; }
    public string? Method { get; set; }
    public string? Path { get; set; }
    public string? Error { get; set; }
    public string? ErrorFull { get; set; }
    public string? Query { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
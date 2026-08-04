namespace MinimalAPISample.Models;

/// <summary>
/// Represents a task for a task list.
/// </summary>
public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}

namespace BlazorTreeView.Models;

/// <summary>
/// Represents a node in a tree structure.
/// </summary>
public class TreeNodeData<T>
{
    /// <summary>
    /// Unique identifier for the node.
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Display text for the node.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Child nodes of this node.
    /// </summary>
    public List<TreeNodeData<T>> Children { get; set; } = new();

    /// <summary>
    /// Optional custom data associated with the node.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Whether the node is expanded (showing children).
    /// </summary>
    public bool IsExpanded { get; set; } = false;

    /// <summary>
    /// Whether the node is selectable.
    /// </summary>
    public bool IsSelectable { get; set; } = true;
}

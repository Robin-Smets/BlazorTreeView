# BlazorTreeView Component Library

A basic, extensible Blazor component library for representing hierarchical tree structures with expand/collapse functionality and node selection.

## Features

- ✅ **Hierarchical Tree Rendering** - Display nested tree structures with unlimited depth
- ✅ **Expand/Collapse** - Toggle node visibility with visual indicators (▼/▶)
- ✅ **Node Selection** - Click nodes to select them and get callbacks
- ✅ **Flexible Data Model** - Generic `TreeNodeData` supports custom data attachment
- ✅ **Event Callbacks** - `OnNodeToggled` and `OnNodeSelected` events
- ✅ **Selectable Toggle** - Per-node control over selectability
- ✅ **Responsive Styling** - Clean, accessible tree visualization with CSS

## Quick Start

### Installation

Add the BlazorTreeView library to your Blazor application.

### Basic Usage

```razor
@using BlazorTreeView.Models
@using BlazorTreeView.Components

<TreeView 
    Nodes="@treeNodes" 
    OnNodeToggled="@HandleToggled"
    OnNodeSelected="@HandleSelected" />

@code {
    private List<TreeNodeData> treeNodes = new();

    protected override void OnInitialized()
    {
        treeNodes = new List<TreeNodeData>
        {
            new TreeNodeData 
            { 
                Label = "Parent Node",
                Children = new List<TreeNodeData>
                {
                    new TreeNodeData { Label = "Child 1" },
                    new TreeNodeData { Label = "Child 2" }
                }
            }
        };
    }

    private Task HandleToggled(TreeNodeData node)
    {
        // Handle node expansion/collapse
        return Task.CompletedTask;
    }

    private Task HandleSelected(TreeNodeData node)
    {
        // Handle node selection
        return Task.CompletedTask;
    }
}
```

## API Reference

### TreeNodeData

The model class for tree node data.

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Id` | string | Guid | Unique identifier for the node |
| `Label` | string | "" | Display text for the node |
| `Children` | List<TreeNodeData> | [] | Child nodes |
| `Data` | object? | null | Optional custom data |
| `IsExpanded` | bool | false | Whether node children are visible |
| `IsSelectable` | bool | true | Whether node can be selected |

### TreeView Component

Main component for rendering tree structures.

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `Nodes` | List<TreeNodeData>? | No | Root nodes to display |
| `OnNodeToggled` | EventCallback<TreeNodeData> | No | Fired when node is expanded/collapsed |
| `OnNodeSelected` | EventCallback<TreeNodeData> | No | Fired when node is selected |

### TreeNode Component

Internal component for rendering individual nodes (used by TreeView).

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `Node` | TreeNodeData | Yes | Node to render |
| `OnNodeToggled` | EventCallback<TreeNodeData> | Yes | Toggle callback |
| `OnNodeSelected` | EventCallback<TreeNodeData> | Yes | Selection callback |
| `Level` | int | No | Indentation level (0 = root) |

## Advanced Usage

### Custom Data Storage

```razor
@code {
    var node = new TreeNodeData 
    { 
        Label = "File.txt",
        Data = new { FileSize = "1.2MB", Type = "Document" }
    };
}
```

### Non-Selectable Nodes

```razor
@code {
    var node = new TreeNodeData 
    { 
        Label = "Read-only",
        IsSelectable = false
    };
}
```

### Default Expanded State

```razor
@code {
    var node = new TreeNodeData 
    { 
        Label = "Expanded Parent",
        IsExpanded = true,
        Children = new List<TreeNodeData> { /* ... */ }
    };
}
```

## Project Structure

- **Models/** - `TreeNodeData` class for tree node representation
- **Components/** - `TreeView.razor`, `TreeNode.razor`, and `TreeViewDemo.razor`
- **Components/TreeView.razor.css** - Component styling

## Extensibility

The component is designed to be extensible:

- Inherit from `TreeNodeData` to add custom properties
- Use the `Data` property to attach arbitrary objects
- Override styling via CSS custom properties
- Fork the component code to customize rendering

## Styling

Tree nodes are rendered with semantic CSS classes:

- `.tree-view` - Main container
- `.tree-node` - Individual node wrapper
- `.tree-node-content` - Node label and toggle
- `.tree-node-toggle` - Expand/collapse button
- `.tree-node-label` - Selectable node label
- `.tree-node-children` - Container for child nodes

Custom styles can be applied through component CSS or external stylesheets.

## Browser Support

- Chrome/Edge 90+
- Firefox 88+
- Safari 14+

## License

BSD 2-Clause (see LICENSE file)

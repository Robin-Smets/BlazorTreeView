using Bunit;
using BlazorTreeView.Components;
using BlazorTreeView.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorTreeView.Tests;

[TestClass]
public class TreeViewTests : Bunit.TestContext
{
    [TestMethod]
    public void TreeView_RenderWithNoData_ShowsEmptyMessage()
    {
        // Arrange
        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, new List<TreeNodeData>()));

        // Act
        var emptyMessage = component.Find(".tree-view-empty");

        // Assert
        Assert.IsNotNull(emptyMessage);
        Assert.AreEqual("No data", emptyMessage.TextContent);
    }

    [TestMethod]
    public void TreeView_RenderWithNullData_ShowsEmptyMessage()
    {
        // Arrange
        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, (List<TreeNodeData>?)null));

        // Act
        var emptyMessage = component.Find(".tree-view-empty");

        // Assert
        Assert.IsNotNull(emptyMessage);
    }

    [TestMethod]
    public void TreeView_RenderWithNodes_RendersTreeNodes()
    {
        // Arrange
        var nodes = new List<TreeNodeData>
        {
            new() { Id = "1", Label = "Node 1", IsSelectable = true },
            new() { Id = "2", Label = "Node 2", IsSelectable = true }
        };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes));

        // Act
        var treeNodes = component.FindAll(".tree-node");

        // Assert
        Assert.IsTrue(treeNodes.Count >= 2, "Expected at least 2 tree nodes to be rendered");
    }

    [TestMethod]
    public void TreeView_ClickNodeLabel_InvokesOnNodeSelectedCallback()
    {
        // Arrange
        var selectedNodes = new List<TreeNodeData>();
        var node = new TreeNodeData { Id = "1", Label = "Test Node", IsSelectable = true };
        var nodes = new List<TreeNodeData> { node };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes)
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(
                this, (selectedNode) => selectedNodes.Add(selectedNode))));

        // Act
        var nodeLabel = component.Find(".tree-node-label");
        nodeLabel.Click();

        // Assert
        Assert.AreEqual(1, selectedNodes.Count);
        Assert.AreEqual(node.Id, selectedNodes[0].Id);
        Assert.AreEqual(node.Label, selectedNodes[0].Label);
    }

    [TestMethod]
    public void TreeView_ClickNodeToggle_InvokesOnNodeToggledCallback()
    {
        // Arrange
        var toggledNodes = new List<TreeNodeData>();
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child Node", IsSelectable = true };
        var parentNode = new TreeNodeData
        {
            Id = "1",
            Label = "Parent Node",
            IsSelectable = true,
            IsExpanded = false,
            Children = new List<TreeNodeData> { childNode }
        };
        var nodes = new List<TreeNodeData> { parentNode };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(
                this, (toggledNode) => toggledNodes.Add(toggledNode))));

        // Act
        var toggleButton = component.Find(".tree-node-toggle");
        toggleButton.Click();

        // Assert
        Assert.AreEqual(1, toggledNodes.Count);
        Assert.AreEqual(parentNode.Id, toggledNodes[0].Id);
    }

    [TestMethod]
    public void TreeView_ParentWithChildren_ToggleExpands()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child Node", IsSelectable = true };
        var parentNode = new TreeNodeData
        {
            Id = "1",
            Label = "Parent Node",
            IsSelectable = true,
            IsExpanded = false,
            Children = new List<TreeNodeData> { childNode }
        };
        var nodes = new List<TreeNodeData> { parentNode };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes));

        // Act
        var toggleButton = component.Find(".tree-node-toggle");
        toggleButton.Click();

        // Assert
        Assert.IsTrue(parentNode.IsExpanded, "Node should be expanded after toggle");
    }

    [TestMethod]
    public void TreeView_MultipleNodes_RenderCorrectly()
    {
        // Arrange
        var nodes = new List<TreeNodeData>
        {
            new() 
            { 
                Id = "1", 
                Label = "Node 1", 
                IsSelectable = true,
                IsExpanded = true,
                Children = new List<TreeNodeData>
                {
                    new() { Id = "1-1", Label = "Node 1-1", IsSelectable = true },
                    new() { Id = "1-2", Label = "Node 1-2", IsSelectable = false }
                }
            },
            new() { Id = "2", Label = "Node 2", IsSelectable = true }
        };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes));

        // Act
        var allLabels = component.FindAll(".tree-node-label, .tree-node-label-static");

        // Assert
        Assert.IsTrue(allLabels.Count >= 3, "Expected at least 3 labels to be rendered");
    }

    [TestMethod]
    public void TreeView_NonSelectableNode_RenderAsStaticLabel()
    {
        // Arrange
        var node = new TreeNodeData { Id = "1", Label = "Non-Selectable Node", IsSelectable = false };
        var nodes = new List<TreeNodeData> { node };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes));

        // Act
        var staticLabel = component.Find(".tree-node-label-static");

        // Assert
        Assert.IsNotNull(staticLabel);
        Assert.AreEqual("Non-Selectable Node", staticLabel.TextContent);
    }

    [TestMethod]
    public void TreeView_NodesWithoutChildren_NoToggleButton()
    {
        // Arrange
        var node = new TreeNodeData { Id = "1", Label = "Leaf Node", IsSelectable = true, Children = new() };
        var nodes = new List<TreeNodeData> { node };

        var component = Render<TreeView>(parameters => parameters
            .Add(p => p.Nodes, nodes));

        // Act
        var spacer = component.Find(".tree-node-spacer");

        // Assert
        Assert.IsNotNull(spacer, "Should render spacer instead of toggle button for leaf nodes");
    }
}

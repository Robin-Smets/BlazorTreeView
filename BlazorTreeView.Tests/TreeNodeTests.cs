using Bunit;
using BlazorTreeView.Components;
using BlazorTreeView.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorTreeView.Tests;

[TestClass]
public class TreeNodeTests : Bunit.TestContext
{
    [TestMethod]
    public void TreeNode_RenderLeafNode_DisplaysLabel()
    {
        // Arrange
        var node = new TreeNodeData { Id = "1", Label = "Leaf Node", IsSelectable = true };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, node)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var label = component.Find(".tree-node-label");

        // Assert
        Assert.IsNotNull(label);
        Assert.AreEqual("Leaf Node", label.TextContent);
    }

    [TestMethod]
    public void TreeNode_RenderNonSelectableNode_DisplaysStaticLabel()
    {
        // Arrange
        var node = new TreeNodeData { Id = "1", Label = "Static Node", IsSelectable = false };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, node)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var staticLabel = component.Find(".tree-node-label-static");

        // Assert
        Assert.IsNotNull(staticLabel);
        Assert.AreEqual("Static Node", staticLabel.TextContent);
    }

    [TestMethod]
    public void TreeNode_RenderNodeWithChildren_DisplaysToggleButton()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var toggleButton = component.Find(".tree-node-toggle");

        // Assert
        Assert.IsNotNull(toggleButton);
    }

    [TestMethod]
    public void TreeNode_ClickLabel_InvokesOnNodeSelected()
    {
        // Arrange
        var selectedNode = (TreeNodeData?)null;
        var node = new TreeNodeData { Id = "1", Label = "Test Node", IsSelectable = true };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, node)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, (n) => selectedNode = n))
            .Add(p => p.Level, 0));

        // Act
        var label = component.Find(".tree-node-label");
        label.Click();

        // Assert
        Assert.IsNotNull(selectedNode);
        Assert.AreEqual(node.Id, selectedNode!.Id);
    }

    [TestMethod]
    public void TreeNode_ClickToggle_InvokesOnNodeToggled()
    {
        // Arrange
        var toggledNode = (TreeNodeData?)null;
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, (n) => toggledNode = n))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var toggleButton = component.Find(".tree-node-toggle");
        toggleButton.Click();

        // Assert
        Assert.IsNotNull(toggledNode);
        Assert.AreEqual(parentNode.Id, toggledNode!.Id);
    }

    [TestMethod]
    public void TreeNode_ExpandedParent_RendersChildren()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            IsExpanded = true,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var childrenDiv = component.Find(".tree-node-children");

        // Assert
        Assert.IsNotNull(childrenDiv);
    }

    [TestMethod]
    public void TreeNode_CollapsedParent_ChildrenNotVisible()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            IsExpanded = false,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var childrenDivs = component.FindAll(".tree-node-children");

        // Assert
        Assert.AreEqual(0, childrenDivs.Count, "Children should not be rendered when collapsed");
    }

    [TestMethod]
    public void TreeNode_IndentationLevel_AppliesCorrectMargin()
    {
        // Arrange
        var node = new TreeNodeData { Id = "1", Label = "Indented Node", IsSelectable = true };
        var level = 3;
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, node)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, level));

        // Act
        var nodeContent = component.Find(".tree-node-content");
        var style = nodeContent.GetAttribute("style");

        // Assert
        Assert.IsNotNull(style);
        Assert.IsTrue(style.Contains("margin-left"), "Style should contain margin-left");
        Assert.IsTrue(style.Contains("60"), "Expected margin-left to be 60px (3 * 20)");
    }

    [TestMethod]
    public void TreeNode_ExpandedNodeToggleIcon_ShowsDownArrow()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            IsExpanded = true,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var toggleSpan = component.Find(".tree-node-toggle span");

        // Assert
        Assert.AreEqual("▼", toggleSpan.TextContent);
    }

    [TestMethod]
    public void TreeNode_CollapsedNodeToggleIcon_ShowsRightArrow()
    {
        // Arrange
        var childNode = new TreeNodeData { Id = "1-1", Label = "Child", IsSelectable = true };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            IsExpanded = false,
            Children = new List<TreeNodeData> { childNode }
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var toggleSpan = component.Find(".tree-node-toggle span");

        // Assert
        Assert.AreEqual("▶", toggleSpan.TextContent);
    }

    [TestMethod]
    public void TreeNode_MultipleChildren_RenderAllChildren()
    {
        // Arrange
        var children = new List<TreeNodeData>
        {
            new() { Id = "1-1", Label = "Child 1", IsSelectable = true },
            new() { Id = "1-2", Label = "Child 2", IsSelectable = true },
            new() { Id = "1-3", Label = "Child 3", IsSelectable = true }
        };
        var parentNode = new TreeNodeData 
        { 
            Id = "1", 
            Label = "Parent", 
            IsSelectable = true,
            IsExpanded = true,
            Children = children
        };
        var component = Render<TreeNode>(parameters => parameters
            .Add(p => p.Node, parentNode)
            .Add(p => p.OnNodeToggled, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.OnNodeSelected, EventCallback.Factory.Create<TreeNodeData>(this, _ => { }))
            .Add(p => p.Level, 0));

        // Act
        var childNodes = component.FindAll(".tree-node");

        // Assert
        Assert.IsTrue(childNodes.Count >= 4, "Should render parent and all 3 children");
    }
}

# BlazorTreeView - Quick Start Guide

## 🚀 Schnelleinstieg in 3 Minuten

### 1. Showcase-App starten
```bash
cd BlazorTreeView.Showcase
dotnet watch run
```
Öffne dann: `https://localhost:7001`

### 2. Tests ausführen
```bash
cd BlazorTreeView/BlazorTreeView
dotnet test
```
Erwartet: ✅ 20/20 Tests bestanden

### 3. In deinem Projekt verwenden

**Schritt 1**: Referenz hinzufügen
```bash
dotnet add reference ../BlazorTreeView/BlazorTreeView.csproj
```

**Schritt 2**: Imports in `_Imports.razor`
```razor
@using BlazorTreeView.Components
@using BlazorTreeView.Models
```

**Schritt 3**: Komponente verwenden
```razor
<TreeView 
    Nodes="MyNodes" 
    OnNodeToggled="HandleToggled"
    OnNodeSelected="HandleSelected" />
```

**Schritt 4**: Daten in `@code`
```csharp
List<TreeNodeData> MyNodes = new()
{
    new TreeNodeData
    {
        Id = "1",
        Label = "Parent",
        Children = new()
        {
            new TreeNodeData { Id = "1.1", Label = "Child" }
        }
    }
};

private Task HandleToggled(TreeNodeData node)
{
    node.IsExpanded = !node.IsExpanded;
    return Task.CompletedTask;
}

private Task HandleSelected(TreeNodeData node)
{
    Console.WriteLine($"Selected: {node.Label}");
    return Task.CompletedTask;
}
```

## 📚 Dokumentation

- **[PROJECT_OVERVIEW.md](./PROJECT_OVERVIEW.md)** - Komplette Projektübersicht
- **[BlazorTreeView/README.md](./BlazorTreeView/README.md)** - Komponenten-Dokumentation
- **[BlazorTreeView.Tests/README.md](./BlazorTreeView.Tests/README.md)** - Test-Dokumentation
- **[BlazorTreeView.Showcase/README.md](./BlazorTreeView.Showcase/README.md)** - Showcase-Dokumentation

## 🎨 Styling-Beispiel

```css
/* Customize tree view appearance */
.tree-view {
    font-family: 'Segoe UI', sans-serif;
    padding: 1rem;
}

.tree-node-label {
    cursor: pointer;
    color: #667eea;
    padding: 0.25rem 0.5rem;
    border-radius: 4px;
}

.tree-node-label:hover {
    background-color: #f0f0f0;
}

.tree-node-toggle {
    background: none;
    border: none;
    cursor: pointer;
    padding: 0;
    margin-right: 0.5rem;
}
```

## 🔧 Features

✅ Hierarchische Baumstrukturen  
✅ Expand/Collapse mit visuellen Icons  
✅ Selektierbare und nicht-selektierbare Knoten  
✅ Event-Callbacks (OnNodeToggled, OnNodeSelected)  
✅ Rekursives Rendering  
✅ Fully tested (20 bunit Tests)  
✅ Production-ready  

## 📁 Projektstruktur

```
BlazorTreeView/              # Komponenten
BlazorTreeView.Tests/        # 20 Unit-Tests
BlazorTreeView.Showcase/     # Demo-App
BlazorTreeView.sln           # Solution
```

## ✅ Checkliste

- [ ] Showcase-App läuft unter https://localhost:7001
- [ ] `dotnet test` zeigt: 20/20 Tests ✅
- [ ] Komponente in deinem Projekt hinzugefügt
- [ ] TreeViewDemo mit Daten funktioniert
- [ ] Callbacks arbeiten (OnNodeToggled, OnNodeSelected)

---

**Ready to go!** 🌳 Viel Spaß mit BlazorTreeView!

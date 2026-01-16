# BlazorTreeView - Komplette Lösung

Ein vollständiges Blazor-Komponentenprojekt mit Unit-Tests und Showcase-Anwendung.

## 📦 Projektstruktur

```
BlazorTreeView/
├── BlazorTreeView/                    # Komponenten-Bibliothek
│   ├── Components/
│   │   ├── TreeView.razor            # TreeView-Komponente
│   │   ├── TreeNode.razor            # TreeNode-Komponente (rekursiv)
│   │   ├── TreeViewDemo.razor        # Demo-Komponente
│   │   └── TreeView.razor.css        # Styling
│   ├── Models/
│   │   └── TreeNodeData.cs           # Datenmodell
│   ├── _Imports.razor
│   └── BlazorTreeView.csproj
│
├── BlazorTreeView.Tests/              # Unit-Test-Projekt (bunit)
│   ├── TreeViewTests.cs              # TreeView-Tests (10 Tests)
│   ├── TreeNodeTests.cs              # TreeNode-Tests (11 Tests)
│   ├── README.md                     # Test-Dokumentation
│   └── BlazorTreeView.Tests.csproj
│
├── BlazorTreeView.Showcase/           # Showcase-Web-App
│   ├── Components/
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor
│   │   │   └── NavMenu.razor
│   │   ├── Pages/
│   │   │   ├── Home.razor            # Interaktive Demo
│   │   │   └── ...
│   │   ├── App.razor
│   │   └── _Imports.razor
│   ├── Properties/
│   ├── wwwroot/
│   ├── Program.cs
│   ├── README.md
│   └── BlazorTreeView.Showcase.csproj
│
├── BlazorTreeView.sln                # Solution
└── README.md                         # Diese Datei
```

## 🎯 Hauptkomponenten

### BlazorTreeView (Komponenten-Bibliothek)

Die Kernkomponentenbibliothek mit:

- **TreeView.razor**: Container-Komponente für Baumstruktur
  - Parameter: `Nodes`, `OnNodeToggled`, `OnNodeSelected`
  - Zeigt Knotenlisten mit TreeNode-Komponenten

- **TreeNode.razor**: Rekursive Komponente für einzelne Knoten
  - Parameter: `Node`, `OnNodeToggled`, `OnNodeSelected`, `Level`
  - Rendert Toggle-Button, Label und Kinder

- **TreeNodeData.cs**: Datenmodell
  - Eigenschaften: `Id`, `Label`, `Children`, `IsExpanded`, `IsSelectable`, `Data`

### BlazorTreeView.Tests (Unit-Tests)

Umfassende Test-Suite mit **20 Tests** für beide Komponenten:

**TreeViewTests (10 Tests)**:
- Rendering ohne Daten
- Rendering mit Knoten
- Event-Callbacks
- Expand/Collapse-Logik
- Nicht-selektierbare Knoten

**TreeNodeTests (11 Tests)**:
- Basis-Rendering
- Kinder-Rendering
- Toggle-Icons
- Indentation
- Event-Handling

**Status**: ✅ Alle 20 Tests bestanden

### BlazorTreeView.Showcase (Web-App)

Interaktive Demonstration mit:

- Moderne, responsive UI
- Hierarchische Demo-Daten
- Live-Interaktion mit TreeView
- Feature-Übersicht
- Professionelles Design mit Gradienten

## 🚀 Schnellstart

### 1. Komponenten-Bibliothek verwenden

Referenz hinzufügen:
```bash
dotnet add reference ../BlazorTreeView/BlazorTreeView.csproj
```

Imports hinzufügen:
```razor
@using BlazorTreeView.Components
@using BlazorTreeView.Models
```

Komponente verwenden:
```razor
<TreeView 
    Nodes="MyNodes" 
    OnNodeToggled="HandleToggled"
    OnNodeSelected="HandleSelected" />
```

### 2. Tests ausführen

Alle Tests:
```bash
dotnet test BlazorTreeView.Tests
```

Spezifische Tests:
```bash
dotnet test --filter "TreeViewTests"
```

### 3. Showcase starten

```bash
cd BlazorTreeView.Showcase
dotnet watch run
```

Öffne: `https://localhost:7001`

## 📋 Features

✅ **TreeView-Komponente**
- Hierarchische Baumstruktur-Visualisierung
- Expand/Collapse-Funktionalität mit visuellen Indikatoren
- Selektierbare und nicht-selektierbare Knoten
- Event-Callbacks für Benutzerinteraktionen
- Rekursive Kind-Rendering
- Anpassbares Styling mit CSS

✅ **Umfassende Tests**
- 20 Unit-Tests mit bunit
- 100% Test-Bestand
- Testabdeckung für alle Komponenten-Funktionen
- MSTest Framework

✅ **Showcase-Anwendung**
- Interaktive Demo mit echten Beispieldaten
- Responsive Design für alle Geräte
- Modern UI mit Gradienten
- Feature-Übersicht
- Professionelle Dokumentation

## 🔧 Technologie-Stack

- **Blazor**: Web-Framework mit C#
- **.NET 8.0**: Laufzeit
- **bunit**: Komponenten-Test-Framework
- **MSTest**: Unit-Test-Framework
- **Bootstrap**: CSS-Framework (in Showcase)

## 📝 API-Referenz

### TreeViewData (Datenmodell)

```csharp
public class TreeNodeData
{
    public string Id { get; set; }                    // Eindeutige ID
    public string Label { get; set; }                 // Anzeigetext
    public List<TreeNodeData> Children { get; set; } // Kinder-Knoten
    public object? Data { get; set; }                 // Benutzerdaten
    public bool IsExpanded { get; set; }              // Auf-/Zustand
    public bool IsSelectable { get; set; }            // Selektierbarkeit
}
```

### TreeView-Parameter

```razor
<TreeView 
    Nodes="List<TreeNodeData>"                           
    OnNodeToggled="EventCallback<TreeNodeData>"         
    OnNodeSelected="EventCallback<TreeNodeData>" />
```

### TreeNode-Parameter (intern)

```csharp
[Parameter] public required TreeNodeData Node { get; set; }
[Parameter] public required EventCallback<TreeNodeData> OnNodeToggled { get; set; }
[Parameter] public required EventCallback<TreeNodeData> OnNodeSelected { get; set; }
[Parameter] public int Level { get; set; } = 0;
```

## 🧪 Test-Übersicht

- **TreeView_RenderWithNoData_ShowsEmptyMessage**
- **TreeView_RenderWithNullData_ShowsEmptyMessage**
- **TreeView_RenderWithNodes_RendersTreeNodes**
- **TreeView_ClickNodeLabel_InvokesOnNodeSelectedCallback**
- **TreeView_ClickNodeToggle_InvokesOnNodeToggledCallback**
- **TreeView_ParentWithChildren_ToggleExpands**
- **TreeView_MultipleNodes_RenderCorrectly**
- **TreeView_NonSelectableNode_RenderAsStaticLabel**
- **TreeView_NodesWithoutChildren_NoToggleButton**
- **TreeNode_RenderLeafNode_DisplaysLabel**
- **TreeNode_RenderNonSelectableNode_DisplaysStaticLabel**
- **TreeNode_RenderNodeWithChildren_DisplaysToggleButton**
- **TreeNode_ClickLabel_InvokesOnNodeSelected**
- **TreeNode_ClickToggle_InvokesOnNodeToggled**
- **TreeNode_ExpandedParent_RendersChildren**
- **TreeNode_CollapsedParent_ChildrenNotVisible**
- **TreeNode_IndentationLevel_AppliesCorrectMargin**
- **TreeNode_ExpandedNodeToggleIcon_ShowsDownArrow**
- **TreeNode_CollapsedNodeToggleIcon_ShowsRightArrow**
- **TreeNode_MultipleChildren_RenderAllChildren**

## 📚 Dokumentation

- [BlazorTreeView Component README](./BlazorTreeView/README.md)
- [Test Documentation](./BlazorTreeView.Tests/README.md)
- [Showcase App README](./BlazorTreeView.Showcase/README.md)

## 🛠️ Entwicklung

### Build
```bash
dotnet build
```

### Tests ausführen
```bash
dotnet test
```

### Showcase starten
```bash
cd BlazorTreeView.Showcase
dotnet run
```

## 📦 NuGet Packages

- **BlazorTreeView**: Component library (lokal)
- **BlazorTreeView.Tests**: Test suite (lokal)
- **Microsoft.AspNetCore.Components.Web**: 8.0.19
- **bunit**: 2.5.3
- **MSTest**: 3.1.1

## 🤝 Zusammenarbeit

Alle Projekte sind in einer einzigen Solution organisiert für einfache Verwaltung.

```bash
dotnet sln list
```

Zeigt:
- BlazorTreeView (Component Library)
- BlazorTreeView.Tests (Test Project)
- BlazorTreeView.Showcase (Web App)

## 📄 Lizenz

Dieses Projekt dient zu Demonstrationszwecken.

---

**Erstellt mit ❤️ für Blazor-Entwickler** 🌳

# BlazorTreeView Showcase

Eine moderne und interaktive Showcase-Anwendung für die **BlazorTreeView**-Komponente.

## 🌳 Über dieses Projekt

Diese Blazor Web App demonstriert die Funktionalität und Verwendung der BlazorTreeView-Komponente mit:

- **Hierarchische Datenvisualisierung**: Baumstruktur mit mehreren Ebenen
- **Interaktive Navigation**: Expand/Collapse-Funktionalität
- **Knotenauswahl**: Klickbare selektierbare und nicht-selektierbare Knoten
- **Event-Callbacks**: Reagiert auf Benutzerinteraktionen
- **Modern UI**: Responsive Design mit Gradient-Styling

## 🚀 Features

✅ **TreeView-Komponente**
- Hierarchische Datendarstellung
- Expand/Collapse mit visuellen Indikatoren (▼/▶)
- Selektierbar/Nicht-selektierbar-Knoten
- Event-Callbacks für Benutzerinteraktionen

✅ **Demo-Daten**
- Realistische Beispieldaten (Ordner, Dateien, Medien)
- Mehrschichtige Baumstruktur
- Emoji-Icons für bessere Visualisierung

✅ **Responsive Design**
- Mobile-freundliches Layout
- Sidebar-Navigation
- Moderne Farbpalette mit Gradienten

## 📋 Voraussetzungen

- .NET 8.0 oder höher
- Visual Studio 2022, VS Code mit C#-Erweiterung oder CLI-Tools

## 🏃 Ausführung

### Mit Visual Studio
1. Öffne die Lösung `BlazorTreeView.sln`
2. Setze `BlazorTreeView.Showcase` als Startprojekt
3. Drücke `F5` oder klicke auf "Start"

### Mit .NET CLI
```bash
cd BlazorTreeView.Showcase
dotnet watch run
```

Die Anwendung wird unter `https://localhost:7001` verfügbar sein.

### Mit Docker (optional)
```bash
dotnet publish -c Release -o ./bin/Release/publish
# Dockerfile-Erstellung und Image-Build
```

## 🎯 Verwendung

### TreeView-Komponente laden
```razor
<TreeView 
    Nodes="SampleNodes" 
    OnNodeToggled="HandleNodeToggled"
    OnNodeSelected="HandleNodeSelected" />
```

### Beispiel-Daten erstellen
```csharp
var nodes = new List<TreeNodeData>
{
    new TreeNodeData
    {
        Id = "1",
        Label = "Parent Node",
        IsSelectable = true,
        Children = new List<TreeNodeData>
        {
            new TreeNodeData { Id = "1.1", Label = "Child Node", IsSelectable = true }
        }
    }
};
```

### Event-Handler implementieren
```csharp
private Task HandleNodeSelected(TreeNodeData node)
{
    Console.WriteLine($"Selected: {node.Label}");
    return Task.CompletedTask;
}

private Task HandleNodeToggled(TreeNodeData node)
{
    Console.WriteLine($"Toggled: {node.Label}, Expanded: {node.IsExpanded}");
    return Task.CompletedTask;
}
```

## 📁 Projektstruktur

```
BlazorTreeView.Showcase/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor      # Hauptlayout
│   │   ├── NavMenu.razor         # Navigation
│   │   └── NavMenu.razor.css     # Navigation-Styling
│   ├── Pages/
│   │   ├── Home.razor            # Showcase-Homepage
│   │   ├── Error.razor           # Fehlerseite
│   │   └── ... (weitere Seiten)
│   ├── App.razor                 # Root-Komponente
│   ├── _Imports.razor            # Global Usings
│   └── Routes.razor              # Routing
├── Properties/
│   └── launchSettings.json       # Start-Konfiguration
├── wwwroot/                      # Statische Assets
├── Program.cs                    # App-Konfiguration
├── appsettings.json              # Konfiguration
└── BlazorTreeView.Showcase.csproj # Projektdatei
```

## 🔧 Konfiguration

### App-Einstellungen
Bearbeite `appsettings.json` für Logging und andere Konfigurationen.

### Custom-Styling
Modifiziere CSS in `Components/Pages/Home.razor` für dein Branding.

## 📚 Ressourcen

- [BlazorTreeView GitHub](https://github.com)
- [Blazor Dokumentation](https://blazor.net)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)

## 🤝 Beitragen

Feedback und Verbesserungsvorschläge sind willkommen!

## 📄 Lizenz

Dieses Projekt ist Teil des BlazorTreeView-Komponenten-Bibliotheks-Projekts.

---

**Viel Spaß mit BlazorTreeView!** 🌳

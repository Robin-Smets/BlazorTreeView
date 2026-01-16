# BlazorTreeView Tests

Dieses Verzeichnis enthält umfassende Unit-Tests für die BlazorTreeView-Komponenten.

## Übersicht

Das Test-Projekt wurde mit bunit (2.5.3) erstellt, einem Testing-Framework speziell für Blazor-Komponenten.

### Testabdeckung

#### TreeViewTests (10 Tests)
- **TreeView_RenderWithNoData_ShowsEmptyMessage**: Überprüft, dass eine Leer-Nachricht angezeigt wird, wenn keine Daten vorhanden sind
- **TreeView_RenderWithNullData_ShowsEmptyMessage**: Überprüft die Anzeige bei null-Daten
- **TreeView_RenderWithNodes_RendersTreeNodes**: Validiert das Rendern mehrerer Baum-Knoten
- **TreeView_ClickNodeLabel_InvokesOnNodeSelectedCallback**: Testet den Callback bei Knotenselektion
- **TreeView_ClickNodeToggle_InvokesOnNodeToggledCallback**: Testet den Callback bei Knotenschalter-Klick
- **TreeView_ParentWithChildren_ToggleExpands**: Überprüft das Auf-/Zuklappen von übergeordneten Knoten
- **TreeView_MultipleNodes_RenderCorrectly**: Validiert das Rendern komplexer Baumstrukturen
- **TreeView_NonSelectableNode_RenderAsStaticLabel**: Testet nicht-selektierbare Knoten
- **TreeView_NodesWithoutChildren_NoToggleButton**: Überprüft, dass Blattknoten keinen Toggle-Button haben

#### TreeNodeTests (11 Tests)
- **TreeNode_RenderLeafNode_DisplaysLabel**: Überprüft die Anzeige von Blattknoten
- **TreeNode_RenderNonSelectableNode_DisplaysStaticLabel**: Testet statische Beschriftungen
- **TreeNode_RenderNodeWithChildren_DisplaysToggleButton**: Validiert das Toggle-Button-Rendern
- **TreeNode_ClickLabel_InvokesOnNodeSelected**: Testet den Auswahlcallback
- **TreeNode_ClickToggle_InvokesOnNodeToggled**: Testet den Toggle-Callback
- **TreeNode_ExpandedParent_RendersChildren**: Überprüft das Rendern von untergeordneten Knoten
- **TreeNode_CollapsedParent_ChildrenNotVisible**: Validiert das Ausblenden von Kindern
- **TreeNode_IndentationLevel_AppliesCorrectMargin**: Testet die korrekte Einrückung
- **TreeNode_ExpandedNodeToggleIcon_ShowsDownArrow**: Überprüft die Pfeiconsn beim Auf-/Zuklappen
- **TreeNode_CollapsedNodeToggleIcon_ShowsRightArrow**: Validiert die Richtung des Pfeils
- **TreeNode_MultipleChildren_RenderAllChildren**: Testet das Rendern mehrerer untergeordneter Knoten

## Tests ausführen

Alle Tests ausführen:
```bash
dotnet test
```

Spezifische Test-Klasse ausführen:
```bash
dotnet test --filter "TreeViewTests"
dotnet test --filter "TreeNodeTests"
```

Spezifischen Test ausführen:
```bash
dotnet test --filter "TreeView_RenderWithNoData_ShowsEmptyMessage"
```

Mit ausführlichem Output:
```bash
dotnet test --verbosity detailed
```

## Test-Coverage

Die Tests decken folgende Funktionalitäten ab:

- ✅ Rendering von Baumstrukturen
- ✅ Event-Callbacks (OnNodeSelected, OnNodeToggled)
- ✅ Expand/Collapse-Logik
- ✅ Selektierbar/Nicht-selektierbar-Knoten
- ✅ Indentation und Styling
- ✅ UI-Element-Anzeige (Toggle-Buttons, Labels)
- ✅ Datenstruktur-Verarbeitung (leere Listen, null-Werte)

## Dependencies

- **bunit**: 2.5.3 - Testing Framework für Blazor
- **MSTest**: TestAdapter und TestFramework
- **BlazorTreeView**: Referenz zum zu testenden Projekt

## Weitere Ressourcen

- [bunit Dokumentation](https://bunit.dev/)
- [MSTest Dokumentation](https://github.com/microsoft/testfx)

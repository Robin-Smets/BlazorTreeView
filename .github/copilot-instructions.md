# BlazorTreeView AI Coding Guidelines

## Project Overview
BlazorTreeView is a Blazor component library for representing hierarchical tree structures. This is an early-stage project using C# and Razor components (.NET/Blazor stack).

**License:** BSD 2-Clause (see LICENSE file)

## Architecture Guidance
- **Technology Stack:** .NET/Blazor (C# + Razor components)
- **Component Model:** Reusable Razor components for tree visualization
- **Design Principle:** Basic, extensible - avoid over-engineering; prioritize flexibility for different tree data structures

## Key Development Patterns
- **Razor Components:** Store in `/Components` or root (TBD based on project structure)
- **C# Logic:** Keep component logic separated; use partial classes or code-behind patterns when complexity warrants
- **Parameters:** Blazor components use `[Parameter]` attributes for parent-child communication
- **Events:** Implement `EventCallback<T>` for child-to-parent communication

## Build & Test Workflow
```bash
# Typical .NET/Blazor commands (exact structure TBD)
dotnet build
dotnet test
dotnet publish
```

## Git Workflow
- **Main branches:** `main` (stable) and `develop` (integration)
- Create feature branches from `develop`: `feature/description`
- Commit messages: Be specific about changes
- Merge to `main` only from stabilized releases

## Project-Specific Conventions
- **Component naming:** Use PascalCase (e.g., `TreeView.razor`, `TreeNode.razor`)
- **Parameter naming:** Descriptive names indicating purpose and accepted types
- **Extensibility first:** Design with inheritance/composition in mind for custom tree renderers

## Files to Understand First
- [README.md](../../README.md) - Project purpose (minimal currently)
- [LICENSE](../../LICENSE) - BSD 2-Clause terms
- `.gitignore` - Excludes Visual Studio build artifacts

## Next Steps for Development
- Define core component structure (TreeView container, TreeNode items)
- Establish parameter patterns for tree data binding
- Create example usage documentation
- Add unit tests for component behavior

# BlazorTreeView

A Blazor component library for representing hierarchical tree structures. 

See [BlazorTreeView Library README](BlazorTreeView/README.md) for full documentation.

## Cloning the Repository

This repository uses Git submodules for external dependencies. When cloning, make sure to use the `--recurse-submodules` flag:

```bash
git clone --recurse-submodules https://github.com/robins/BlazorTreeView.git
```

If you've already cloned without submodules, initialize them with:

```bash
git submodule update --init --recursive
```

## Quick Start

```bash
cd BlazorTreeView
dotnet build
```

## Project Structure

- **BlazorTreeView/** - Main component library (Razor class library)
  - `Components/` - TreeView and TreeNode Razor components
  - `Models/` - TreeNodeData class
  - `README.md` - Full API documentation

## License

BSD 2-Clause (see LICENSE file)

# Copilot Instructions for InventarioISP20

## Build, test, and lint commands

This repository is a .NET 8 Windows Forms solution (`InventarioISP20.sln`) with one app project in `Desktop\Desktop.csproj`.

- Restore: `dotnet restore .\InventarioISP20.sln`
- Build (Debug): `dotnet build .\InventarioISP20.sln -c Debug`
- Build (Release): `dotnet build .\InventarioISP20.sln -c Release`
- Run app: `dotnet run --project .\Desktop\Desktop.csproj`

Testing and linting status in current repo state:

- There is no test project in the solution yet (`dotnet test` has nothing meaningful to run).
- There is no dedicated lint command/config (no `.editorconfig` ruleset, no analyzers configuration, no external linter setup).

## High-level architecture

- **App type:** single-process WinForms desktop app (`net8.0-windows`, `UseWindowsForms=true`).
- **Entry point:** `Desktop\Program.cs` initializes WinForms config and starts `MenuPrincipalView`.
- **UI structure:** forms are under `Desktop\Views\` and use WinForms partial-class split:
  - `*View.cs` for behavior/event handlers.
  - `*View.Designer.cs` for generated UI layout and control wiring.
- **Current navigation flow:** `MenuPrincipalView` is the shell/menu form; it opens other forms (currently `ArticulosView`) from menu event handlers.
- **Dependency worth noting:** main form uses `FontAwesome.Sharp` controls/icons (`IconButton`, `IconMenuItem`).

## Key conventions in this codebase

- Keep manual code in `*View.cs`; do not hand-edit `*View.Designer.cs` unless absolutely necessary for designer sync issues.
- Follow existing event handler naming (`<ControlName>_<Event>`) and wire handlers from designer-generated code.
- Preserve Spanish domain/UI naming (`Articulos`, `Categorias`, `Prestamos`, `Ubicaciones`, `MenuPrincipal`) when adding forms, controls, and handlers.
- Keep namespace consistency between each form file and its designer partial class. Forms in `Desktop\Views\` use `namespace Desktop.Views`.

## Mandatory instructions for Copilot
- Hablar en espa�ol.

# Project: Steel Towers
A Hero Tower defense game.

## Development Process
`main`: Stable, but still in development. Requires a PR to merge to from feature branches.
`feature/*`:  Where features are developed. Doesn't require PRs to it. Unstable changes can exist here.
`release/[semver]`: Where releases go. Merged to *only* from `main` and only done when significant feature milestones are hit.

## Standards
- [Semantic Versioning](semver.org)


### Godot Addons

- [Plenticons](https://github.com/foxssake/plenticons)


### C# Dependencies

- Validation:
  - FluentValidation: https://docs.fluentvalidation.net/en/latest/
- Jetbrains Annotations:
  - https://www.nuget.org/packages/JetBrains.Annotations
- Testing
  - GDUnit4: https://www.nuget.org/packages/gdUnit4.api/5.1.0-rc3
  - GDUnit4 Static Type Analysis: https://www.nuget.org/packages/gdUnit4.analyzers

#### Maybe? Dependencies
- Application lifecycle (startup, configuration, shutdown):
  - Docs: https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder
  - Dep: https://www.nuget.org/packages/Microsoft.Extensions.Hosting
- Dependency injection:
  - https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection
- Caching:
  - https://www.nuget.org/packages/System.Runtime.Caching
- JSON
  - Option A: https://www.nuget.org/packages/Newtonsoft.Json
  - Option B: https://www.nuget.org/packages/System.Text.Json
- Binary data types: https://www.nuget.org/packages/System.Memory.Data
- Asynchronous interfaces: https://www.nuget.org/packages/Microsoft.Bcl.AsyncInterfaces
- Mediator/broker pattern: https://www.nuget.org/packages/MediatR/14.0.0-beta-1
# Agent Instructions

## Project
- This is a .NET 10 C# receipt calculator. Production code is in `Kvittoraknaren/`; tests are in `Kvittoraknaren.Tests/`.
- Preserve the existing Swedish domain names and public API unless a task explicitly requires changing them.

## Code and Tests
- Keep nullable reference types and implicit usings enabled, matching the project files.
- Use `decimal` for prices, tax rates, and monetary calculations; use decimal literals such as `100m`.
- Add or update xUnit tests for behavior changes, following the existing test style.
- Commit every changes, but do not push.

## Validation
- Run `dotnet test Kvittoraknaren.Tests/Kvittoraknaren.Tests.csproj` after code changes.

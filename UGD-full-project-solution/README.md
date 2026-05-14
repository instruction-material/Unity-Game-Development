# UGD-full-project-solution

This is the solution full-project Unity baseline for Unity Game Development.

## Unity Version

- Unity 6.3 LTS / 6000.3.15f1

## Package Baseline

- `com.unity.inputsystem` 1.14.0
- `com.unity.test-framework` 1.5.2
- `com.unity.ugui` 2.0.0

The solution pins the Input System package. The current `PlayerController`
still uses a simple horizontal axis polling path so students can compare the
completed game-state logic without also debugging editor-created action maps.

## Build Profile

Use the profile contract in `BuildProfiles/README.md`. The expected local build
profile is `DesktopDevelopment`, outputting to `Builds/DesktopDevelopment`.

## Verification

1. Open this folder in Unity Hub with the pinned editor version.
2. Run Edit Mode tests from `Assets/Tests/EditMode`.
3. Run the Play Mode smoke test from `Assets/Tests/PlayMode`.
4. Create or open the `RelicRunner` scene following `Assets/Scenes/README.md`.
5. Build a desktop profile after the scene is playable.

## Asset Attribution

Use self-created assets or permissively licensed assets only. Record every
external asset in `THIRD_PARTY_ASSETS.md` before committing.

## Scope

The starter intentionally keeps scene wiring lightweight so students build the project in Unity. The solution includes the completed session rules and a broader test set, but still expects students to inspect scene wiring and asset attribution.

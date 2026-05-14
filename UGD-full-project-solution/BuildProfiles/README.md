# Build Profile Contract

Create the Unity Build Profile in the editor rather than by hand-editing
serialized assets. This folder documents the expected profile so the solution
package can be checked in without generated cache files.

## Required Profile

- Name: `DesktopDevelopment`
- Platform: desktop standalone for the tutor/student machine
- Scene: `RelicRunner`, created from `Assets/Scenes/README.md`
- Output folder: `Builds/DesktopDevelopment`
- Development build: enabled during review so console and debugging output stay visible
- Compression/build optimization: default editor settings are acceptable for this course

## Verification

1. Open this project with the editor version in `ProjectSettings/ProjectVersion.txt`.
2. Confirm the completed `RelicRunner` scene wiring.
3. Create or confirm the `DesktopDevelopment` Build Profile.
4. Run Edit Mode tests and Play Mode smoke tests.
5. Build once locally and confirm the win/fail/restart flow still works.
6. Do not commit `Library/`, `Temp/`, `Logs/`, or `Builds/`.

# Unity-Game-Development Structure

This repository backs `Unity Game Development`. Folder names use the normalized
`UGD-*` course prefix so the live course links, manifest, and filesystem follow
one naming family.

Most top-level folders are script snapshots rather than full Unity project
roots. Starter and solution roles may be encoded in folder names for those
snapshots.

The `UGD-full-project-starter` and `UGD-full-project-solution` folders are full
Unity project roots. Their parent folder names were normalized only after
checking that `Packages/`, `ProjectSettings/`, and visible text references did
not depend on the old names.

Do not rename full Unity project roots in the future unless the Unity metadata is
checked in the same pass.

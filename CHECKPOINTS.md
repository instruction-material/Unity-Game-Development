# Unity Game Development Checkpoints

This repository is snapshot-based rather than a single Unity project that grew
one commit at a time. The checkpoint contract below makes that structure
inspectable without rewriting history or flattening the teaching folders.

Use the folders in the table as the source of truth for each stage. After a
validated commit, run `scripts/create-checkpoint-tags.sh` to add annotated tags
that point to the current source pack and describe which folders represent each
checkpoint.

## Checkpoint Tags

| Tag | Stage | Source folders | Verification expectation |
| --- | --- | --- | --- |
| `ugd/checkpoint-01-source-baseline` | Course source baseline | `COURSE_SOURCE_MANIFEST.md`, `STRUCTURE.md`, `SOURCE_BACKLOG.md`, `UGD-full-project-starter`, `UGD-full-project-solution` | Manifest, naming structure, Unity editor version, package locks, asset ledger, and verification script are present. |
| `ugd/checkpoint-02-input-and-movement` | Input and movement | `UGD-04-project-1`, `UGD-04-project-2`, `UGD-05-project-1`, `UGD-05-project-2`, `UGD-full-project-starter/Assets/Scripts/PlayerController.cs` | Movement code is readable, input assumptions are documented, and the full-project starter has an input package baseline. |
| `ugd/checkpoint-03-collisions-and-collectibles` | Collisions and collectibles | `UGD-06-01-collision-commotion`, `UGD-06-02-collecting-coins`, `UGD-06-03-collecting-colliding-chaos`, `UGD-full-project-starter/Assets/Scripts/Collectible.cs`, `UGD-full-project-starter/Assets/Scripts/Hazard.cs` | Collision tags, collectible behavior, and hazard behavior are represented in script snapshots and the full-project starter. |
| `ugd/checkpoint-04-ui-state` | UI state and start flow | `UGD-07-01-displaying-text`, `UGD-07-02-changing-text`, `UGD-07-03-start-button`, `UGD-07-04-user-friendly-platformer` | UI text, score/state changes, and start-button flow are present as progressive snapshots. |
| `ugd/checkpoint-05-game-endings` | Bounds, win, restart, and hazards | `UGD-08-01-out-of-bounds`, `UGD-08-02-winning-and-restarting`, `UGD-08-03-killer-objects` | End conditions and restart/failure flow are available as late-course snapshots. |
| `ugd/checkpoint-06-build-profile` | Build profile contract | `UGD-full-project-starter/BuildProfiles`, `UGD-full-project-solution/BuildProfiles` | Desktop build profile expectations, output path, scene expectation, and manual Unity verification are documented. |
| `ugd/checkpoint-07-test-pass` | Edit Mode and Play Mode verification | `UGD-full-project-starter/Assets/Tests`, `UGD-full-project-solution/Assets/Tests`, `.github/workflows/verify-unity-source.yml` | Static CI is available, and manual Unity test jobs can run when Unity credentials are configured. |
| `ugd/checkpoint-08-final-polish` | Final project polish and attribution | `UGD-full-project-solution`, `THIRD_PARTY_ASSETS.md` files | Completed solution baseline, attribution requirements, and scene/prefab notes are present. |

## Instructor Use

When a lesson asks students to inspect how the game grows, point them to this
file first. Then have them compare the listed source folders instead of jumping
through unrelated Unity editor cache files.

The tags are stable references for GitHub links and release notes. The folders
are the practical source history that students should read.

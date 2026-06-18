# Course Source Manifest

Canonical source repository: `Unity-Game-Development`

## Mapped Catalog Courses

- `unity-game-development`: Unity Game Development

## Verification Gate

- Run `./verify-course-source.sh` from this repository root before treating the source pack as ready.
- The verification gate checks for this manifest, the source backlog ledger, the checkpoint manifest, source-like files, removed Replit metadata, Git LFS setup, CI workflow files, and Unity full-project readiness files.
- Project-specific unit tests or build commands should still be run inside individual project folders when a project includes its own test harness.

## Checkpoint and CI Contract

- `CHECKPOINTS.md` maps the snapshot folders into a stable course checkpoint sequence.
- `scripts/create-checkpoint-tags.sh` creates annotated `ugd/checkpoint-*` tags after a validated commit.
- `.github/workflows/verify-unity-source.yml` runs static source verification in CI and exposes manual Unity test jobs for repos with Unity credentials configured.
- Full Unity project roots must document editor version, package baseline, Input System setup, Build Profile expectations, test coverage, and asset attribution.

## Active Catalog Targets

| Folder |
| --- |
| `UGD-06-01-collision-commotion` |
| `UGD-06-02-collecting-coins` |
| `UGD-06-03-collecting-colliding-chaos` |
| `UGD-07-01-displaying-text` |
| `UGD-07-02-changing-text` |
| `UGD-07-03-start-button` |
| `UGD-07-04-user-friendly-platformer` |
| `UGD-08-01-out-of-bounds` |
| `UGD-08-02-winning-and-restarting` |
| `UGD-08-03-killer-objects` |
| `UGD-03-supplemental-1-starter` |
| `UGD-03-supplemental-1-solution` |
| `UGD-03-supplemental-2-starter` |
| `UGD-03-supplemental-2-alternate-starter` |
| `UGD-03-supplemental-2-solution` |
| `UGD-03-supplemental-2-alternate-solution` |
| `UGD-04-project-1` |
| `UGD-04-project-2` |
| `UGD-05-project-1` |
| `UGD-05-project-2` |
| `UGD-full-project-solution` |
| `UGD-full-project-starter` |

## Source Inventory

- Top-level folders: 23
- Active linked folders: 22
- Ledgered inactive/support folders: 1
- Source-like files: 56

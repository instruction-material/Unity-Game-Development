# Unity Game Development

This repo contains the local C# / Unity-style game development course material
that previously lived in `~/Documents/Work/Juni/C#`.

The project set is organized as a progression of small game and UI mechanics
labs, including:

- collision and movement exercises
- collectibles and platforming
- on-screen text and start-button flows
- hazard, win, and restart states
- supplemental and module capstone projects

Most folders are lightweight script-first project snapshots rather than full
Unity editor projects. The goal is to preserve the teaching code and project
structure without checking in generated cache or build artifacts.

## Source Package Contract

Run `./verify-course-source.sh` before using or publishing this source pack.
That gate checks the course manifest, checkpoint manifest, Unity editor version
files, package manifests/locks, build-profile documentation, Edit Mode and Play
Mode test source files, asset attribution ledgers, and Git LFS tracking for
binary assets.

The full Unity project roots are:

- `UGD-full-project-starter`
- `UGD-full-project-solution`

Each full project documents:

- pinned Unity editor version
- Input System, Unity UI, and Test Framework package baseline
- expected desktop Build Profile
- Edit Mode and Play Mode verification
- third-party asset attribution requirements

## Checkpoint History

The original material is organized as source snapshots. `CHECKPOINTS.md` maps
those snapshots to a stable checkpoint sequence so students can inspect how the
game grows without reading generated Unity cache files.

After committing a validated source pack, run:

```bash
scripts/create-checkpoint-tags.sh
git push origin --tags
```

The script creates annotated `ugd/checkpoint-*` tags that point at the current
validated source pack and describe which folders represent each checkpoint.

## CI

`.github/workflows/verify-unity-source.yml` runs the static verification gate on
push and pull request. It also provides a manual Unity test job for repositories
with GameCI Unity credentials configured.

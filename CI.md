# Unity Source CI

This repo has two levels of verification.

## Static Verification

`./verify-course-source.sh` is the required gate for every commit. It checks:

- course manifest, structure notes, backlog ledger, and checkpoint manifest
- normalized source folders and full-project roots
- Unity editor version files
- package manifests and package locks for Input System, Test Framework, and UI
- build-profile documentation for starter and solution packages
- asset attribution ledgers
- Edit Mode and Play Mode test source files
- removed Replit/export metadata
- Git LFS tracking for binary Unity assets

GitHub Actions runs this static verification on push and pull request.

## Unity Editor Verification

The workflow also includes manual `workflow_dispatch` Unity test jobs. These
jobs are intentionally manual because Unity runners require configured Unity
credentials and can be slow or unavailable on forks.

To run them in GitHub Actions:

1. Configure the repository secrets required by GameCI:
   `UNITY_LICENSE`, `UNITY_EMAIL`, and `UNITY_PASSWORD`.
2. Open the `Verify Unity Course Source` workflow.
3. Use `Run workflow`.
4. Choose `UGD-full-project-starter` or `UGD-full-project-solution`.
5. Choose `EditMode` or `PlayMode`.

Local Unity verification should still be done from Unity Hub with the pinned
editor version in each project root's `ProjectSettings/ProjectVersion.txt`.

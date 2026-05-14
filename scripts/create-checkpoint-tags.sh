#!/usr/bin/env bash
set -euo pipefail

root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"

fail() {
  printf 'checkpoint tag creation failed: %s\n' "$1" >&2
  exit 1
}

require_clean_tree() {
  git diff --quiet || fail "commit or stash working-tree changes first"
  git diff --cached --quiet || fail "commit or unstage index changes first"
}

create_tag() {
  local tag="$1"
  local title="$2"
  local folders="$3"
  local head

  head="$(git rev-parse HEAD)"

  if git rev-parse -q --verify "refs/tags/$tag" >/dev/null; then
    local existing
    existing="$(git rev-list -n 1 "$tag")"
    if [ "$existing" = "$head" ]; then
      printf 'checkpoint tag already current: %s\n' "$tag"
      return
    fi
    fail "tag $tag already exists at $existing; move it intentionally if needed"
  fi

  git tag -a "$tag" "$head" -m "$title

Source folders:
$folders

This repository is snapshot-based. The tag marks the validated source pack, and CHECKPOINTS.md maps this stage to the folders students should inspect."
  printf 'created checkpoint tag: %s\n' "$tag"
}

require_clean_tree

create_tag \
  "ugd/checkpoint-01-source-baseline" \
  "UGD checkpoint 01: source baseline" \
  "COURSE_SOURCE_MANIFEST.md, STRUCTURE.md, SOURCE_BACKLOG.md, UGD-full-project-starter, UGD-full-project-solution"

create_tag \
  "ugd/checkpoint-02-input-and-movement" \
  "UGD checkpoint 02: input and movement" \
  "UGD-04-project-1, UGD-04-project-2, UGD-05-project-1, UGD-05-project-2, UGD-full-project-starter/Assets/Scripts/PlayerController.cs"

create_tag \
  "ugd/checkpoint-03-collisions-and-collectibles" \
  "UGD checkpoint 03: collisions and collectibles" \
  "UGD-06-01-collision-commotion, UGD-06-02-collecting-coins, UGD-06-03-collecting-colliding-chaos, Collectible.cs, Hazard.cs"

create_tag \
  "ugd/checkpoint-04-ui-state" \
  "UGD checkpoint 04: UI state and start flow" \
  "UGD-07-01-displaying-text, UGD-07-02-changing-text, UGD-07-03-start-button, UGD-07-04-user-friendly-platformer"

create_tag \
  "ugd/checkpoint-05-game-endings" \
  "UGD checkpoint 05: game endings" \
  "UGD-08-01-out-of-bounds, UGD-08-02-winning-and-restarting, UGD-08-03-killer-objects"

create_tag \
  "ugd/checkpoint-06-build-profile" \
  "UGD checkpoint 06: build profile contract" \
  "UGD-full-project-starter/BuildProfiles, UGD-full-project-solution/BuildProfiles"

create_tag \
  "ugd/checkpoint-07-test-pass" \
  "UGD checkpoint 07: test pass" \
  "UGD-full-project-starter/Assets/Tests, UGD-full-project-solution/Assets/Tests, .github/workflows/verify-unity-source.yml"

create_tag \
  "ugd/checkpoint-08-final-polish" \
  "UGD checkpoint 08: final polish" \
  "UGD-full-project-solution, THIRD_PARTY_ASSETS.md"

printf 'checkpoint tags ready. Push with: git push origin --tags\n'

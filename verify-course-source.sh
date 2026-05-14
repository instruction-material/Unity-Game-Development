#!/usr/bin/env bash
set -euo pipefail

root="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$root"

fail() {
  printf 'course source verification failed: %s\n' "$1" >&2
  exit 1
}

require_file() {
  [ -f "$1" ] || fail "missing $1"
}

require_executable() {
  [ -x "$1" ] || fail "$1 must be executable"
}

require_text() {
  local file="$1"
  local text="$2"
  grep -Fq "$text" "$file" || fail "$file must mention $text"
}

require_file "COURSE_SOURCE_MANIFEST.md"
require_file "SOURCE_BACKLOG.md"
require_file "STRUCTURE.md"
require_file "CHECKPOINTS.md"
require_file "CI.md"
require_file ".github/workflows/verify-unity-source.yml"
require_file "scripts/create-checkpoint-tags.sh"
require_executable "verify-course-source.sh"
require_executable "scripts/create-checkpoint-tags.sh"

for project in UGD-full-project-starter UGD-full-project-solution; do
  require_file "$project/ProjectSettings/ProjectVersion.txt"
  require_file "$project/Packages/manifest.json"
  require_file "$project/Packages/packages-lock.json"
  require_file "$project/BuildProfiles/README.md"
  require_file "$project/Assets/Scripts/GameSession.cs"
  require_file "$project/Assets/Tests/EditMode/GameSessionTests.cs"
  require_file "$project/Assets/Tests/PlayMode/PlayModeSmokeTests.cs"
  require_file "$project/THIRD_PARTY_ASSETS.md"
  require_text "$project/ProjectSettings/ProjectVersion.txt" "6000.3.15f1"
  require_text "$project/Packages/manifest.json" "com.unity.inputsystem"
  require_text "$project/Packages/manifest.json" "com.unity.test-framework"
  require_text "$project/Packages/manifest.json" "com.unity.ugui"
  require_text "$project/Packages/packages-lock.json" "1.14.0"
  require_text "$project/Packages/packages-lock.json" "1.5.2"
  require_text "$project/README.md" "Package Baseline"
  require_text "$project/README.md" "Build Profile"
  require_text "$project/README.md" "Asset Attribution"
  require_text "$project/BuildProfiles/README.md" "DesktopDevelopment"
done
require_file ".gitattributes"
require_text ".gitattributes" "*.png filter=lfs"
require_text ".gitattributes" "*.unity text eol=lf"
require_text "CHECKPOINTS.md" "ugd/checkpoint-01-source-baseline"
require_text "CHECKPOINTS.md" "ugd/checkpoint-08-final-polish"
require_text ".github/workflows/verify-unity-source.yml" "game-ci/unity-test-runner"

if find . \
  \( -path './.git' -o -path './node_modules' -o -path './Library' -o -path './Temp' -o -path './Logs' \) -prune -o \
  \( -name '.replit' -o -name 'replit.nix' -o -name 'replit.nix.backup' -o -name 'replit_zip_error_log.txt' \) -print | grep -q .; then
  fail "replit metadata should not be committed"
fi

source_count="$(find . \
  \( -path './.git' -o -path './node_modules' -o -path './Library' -o -path './Temp' -o -path './Logs' \) -prune -o \
  -type f \( -name '*.py' -o -name '*.java' -o -name '*.cpp' -o -name '*.c' -o -name '*.h' -o -name '*.hpp' -o -name '*.js' -o -name '*.ts' -o -name '*.swift' -o -name '*.cs' -o -name '*.md' \) -print | wc -l | tr -d ' ')"

[ "$source_count" -gt 0 ] || fail "no source-like files found"

printf 'course source verification passed: %s source-like files\n' "$source_count"

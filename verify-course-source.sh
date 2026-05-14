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

require_file "COURSE_SOURCE_MANIFEST.md"
require_file "SOURCE_BACKLOG.md"

for project in UGD-FullProject-Starter UGD-FullProject-Solution; do
  require_file "$project/ProjectSettings/ProjectVersion.txt"
  require_file "$project/Packages/manifest.json"
  require_file "$project/Packages/packages-lock.json"
  require_file "$project/Assets/Scripts/GameSession.cs"
  require_file "$project/Assets/Tests/EditMode/GameSessionTests.cs"
  require_file "$project/THIRD_PARTY_ASSETS.md"
done
require_file ".gitattributes"

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

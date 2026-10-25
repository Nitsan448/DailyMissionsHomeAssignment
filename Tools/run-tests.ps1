<#
.SYNOPSIS
    Runs the project's tests headlessly, the same way CI does.
.DESCRIPTION
    Unity must not have this project open — the Editor holds an exclusive lock on it.
    Exit codes come from Unity: 0 = all passed, 2 = tests failed, 3 = the run itself failed.
#>
param(
    [ValidateSet("EditMode", "PlayMode")]
    [string]$TestPlatform = "EditMode"
)

$ErrorActionPreference = "Stop"
$projectPath = Split-Path -Parent $PSScriptRoot

$editorVersion = (Select-String -Path "$projectPath\ProjectSettings\ProjectVersion.txt" -Pattern '^m_EditorVersion: (.+)$').Matches[0].Groups[1].Value
$unityExe = "C:\Program Files\Unity\Hub\Editor\$editorVersion\Editor\Unity.exe"

if (-not (Test-Path $unityExe)) {
    throw "Unity $editorVersion not found at $unityExe. Install it via Unity Hub."
}

$resultsPath = "$projectPath\TestResults\$TestPlatform.xml"
New-Item -ItemType Directory -Force -Path (Split-Path -Parent $resultsPath) | Out-Null

& $unityExe `
    -batchmode `
    -nographics `
    -runTests `
    -projectPath $projectPath `
    -testPlatform $TestPlatform `
    -testResults $resultsPath `
    -logFile -

$unityExitCode = $LASTEXITCODE
Write-Host "Unity exited with code $unityExitCode. Results: $resultsPath"
exit $unityExitCode

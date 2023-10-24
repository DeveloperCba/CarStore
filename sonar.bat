@echo off

set NAME_PROJECT="CarStore"
set HOST=http://localhost:8000
SET TOKEN=sqp_9af1f48464f400107e2710e23f8b1df9b71d9cc2

dotnet sonarscanner begin /k:"%NAME_PROJECT%" /d:sonar.host.url="%HOST%" /d:sonar.token="%TOKEN%"

dotnet build

dotnet sonarscanner end /d:sonar.token="%TOKEN%"

pause
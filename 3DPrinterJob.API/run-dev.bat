@echo off
echo Starting Docker Compose Dev Setup...

REM Check if Docker is running
docker info >nul 2>&1
IF ERRORLEVEL 1 (
    echo Docker is not running. Please start Docker Desktop.
    pause
    exit /b
)

REM Run your dev compose file
docker compose -f docker-compose.dev.yml up -d

echo Dev environment is up!
pause

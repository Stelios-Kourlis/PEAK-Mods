@echo off

cd MoveableUI
dotnet build -c Release || exit /b

cd ../RunTracker
dotnet build -c Release || exit /b

cd ../RopeTracker
dotnet build -c Release -t:PackTS -v d || exit /b

cd ../IsTheScoutmasterClose
dotnet build -c Release -t:PackTS -v d || exit /b

cd ..
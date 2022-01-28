@REM %1 he target project
@echo off
echo -----------------------------------------
echo *** Clean Project ***
echo -----------------------------------------
dotnet clean

echo -----------------------------------------
echo *** Build Project ***
echo -----------------------------------------
dotnet build

echo -----------------------------------------
echo *** Run Project %1 ***
echo -----------------------------------------
dotnet run --project %1
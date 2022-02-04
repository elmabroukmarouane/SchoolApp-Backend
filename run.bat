@REM %1 the target project
@echo off
echo -----------------------------------------
echo *** Clean Project ***
echo -----------------------------------------
dotnet clean

echo -----------------------------------------
echo *** Build Project ***
echo -----------------------------------------
dotnet build -nowarn:CS8604,CS8602,CS8603,CS8618,CS8625,CS8767,CS8613

echo -----------------------------------------
echo *** Run Project %1 ***
echo -----------------------------------------
dotnet run -nowarn:CS8604,CS8602,CS8603,CS8618,CS8625,CS8767,CS8613 --project %1
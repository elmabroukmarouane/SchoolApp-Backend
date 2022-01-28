@REM %1 is the name of the migration, %2 is the project startup which has the db credentials and information
@REM Don't forget to install globally the entityframework tool package in the root project (where the .sln file exists) before executing this batch file by the following command : dotnet tool install --global dotnet-ef
@echo off
echo -----------------------------------------
echo *** Add Migrations ***
echo -----------------------------------------
dotnet-ef migrations add %1 -s %2

echo -----------------------------------------
echo *** Update Database ***
echo -----------------------------------------
dotnet ef database update -s %2
@REM %1 is the name of the migration (or just 0 to delete all migrations), %2 is the project startup which has the db credentials and information
@echo off
echo -----------------------------------------
echo *** Update Database ***
echo -----------------------------------------
dotnet ef database update %1 -s %2

echo -----------------------------------------
echo *** Remove Migrations ***
echo -----------------------------------------
dotnet ef migrations remove -s %2
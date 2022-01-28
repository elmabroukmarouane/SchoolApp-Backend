@REM %1 is the name of the migration, %2 target project 
@echo off
echo -----------------------------------------
echo *** Add Migrations to Project : %2 ***
echo -----------------------------------------
echo dotnet ef --startup-project %2 migrations add %1
dotnet ef --startup-project %2 migrations add %1

echo -----------------------------------------
echo *** Update Database to Project : %2 ***
echo -----------------------------------------
echo dotnet ef database update --startup-project %2
dotnet ef database update --startup-project %2
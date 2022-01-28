@REM %1 he target project and %2 is the source project te be referenced
@echo off
echo -----------------------------------------
echo *** Remove Reference from Project : %1 ***
echo -----------------------------------------
dotnet remove %1 reference %2
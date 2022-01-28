@REM %1 he target project and %2 is the source project te be referenced
@echo off
echo -----------------------------------------
echo *** Add Reference to Project : %1 ***
echo -----------------------------------------
dotnet add %1 reference %2
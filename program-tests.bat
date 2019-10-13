@echo off

dotnet build -c Release

echo -- Ejecucion caso mutante --
dotnet MutantDetector.Program/bin/Release/netcoreapp2.2/MutantDetector.Program.dll ATGCGA CAGTGC TTATGT AGAAGG CCCCTA TCACTG

echo -- Ejecucion caso no mutante --
dotnet MutantDetector.Program/bin/Release/netcoreapp2.2/MutantDetector.Program.dll ATGCGA CCGTGC TTATGT AGAAGG TACGTA TCACTG
dotnet publish -c Release

copy app.yaml .\MutantDetector.Api\bin\Release\netcoreapp2.2\publish\app.yaml

gcloud app deploy .\MutantDetector.Api\bin\Release\netcoreapp2.2\publish\app.yaml

gcloud app browse



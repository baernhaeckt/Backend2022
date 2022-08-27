Push-Location $PSScriptRoot
try {
    dotnet restore ..\MixMeal.sln
    dotnet build ..\MixMeal.sln --no-restore --configuration release
    dotnet test ..\MixMeal.sln --no-build --no-restore --configuration release --logger:trx -v minimal /p:CollectCoverage=true '/p:ExcludeByAttribute=\"GeneratedCodeAttribute\"' /p:Exclude=[*]*.Migrations.* /p:CoverletOutputFormat=opencover
    dotnet tool update -g dotnet-reportgenerator-globaltool
    reportgenerator "-reports:..\**\*.opencover.xml" "-targetdir:coveragereport" -reporttypes:HTMLInline

    . .\coveragereport\index.htm
}
finally {
    Pop-Location
}
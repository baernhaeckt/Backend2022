# Backend2022

.NET Repository for the winner team of Baernhaeckt2022

## PostgreSQL DB Migrations

Open the NuGet Manager Console in Visual Studio.

```Add-Migration -Name Setup -Project MixMeal.Persistence.PostgreSQL -StartupProject MixMeal.Web```

## Data Seeding

To create the initial data a seeding application has been created:

Connection detail of the targeted web application can be configured via the "appsettings.json".

The console app is using cocona for help when using in the console.

Example call:
```./MixMeal.Seeder.exe seed --seed Ingredient```
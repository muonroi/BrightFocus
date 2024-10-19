# BrightFocus

dotnet ef migrations add "InitDb" -p .\BrightFocus.Data --startup-project .\BrightFocus -o Persistence/Migrations
dotnet ef database update --project .\BrightFocus

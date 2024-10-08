# BrightFocus

dotnet ef migrations add "InitDb" -p .\BrightFocus.Data --startup-project .\BrightFocus -o Persistance/Migrations
dotnet ef database update --project .\BrightFocus

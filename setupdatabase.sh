dotnet restore
dotnet build
cd SieuThiMini-backend.Dal
dotnet ef database drop
dotnet ef database update

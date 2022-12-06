# agit-polman-dotnet-crud
from agit with love

penjelasan sintaks

winget install Microsoft.DotNet.SDK.7
=install dotnet sdk via winget

dotnet new webapi
=membuat proyek webapi

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
=add lib ef sqllite ke proyek

dotnet tool install --global dotnet-ef
=add cmd ef

dotnet add package Microsoft.EntityFrameworkCore.Design
=add lib ef design

dotnet ef migrations add InitialCreate
=add migration

dotnet ef database update
=eksekusi migration (code first, dari code ke database)

dotnet run
=run aplikasi

dotnet watch
=run dengan hot reload
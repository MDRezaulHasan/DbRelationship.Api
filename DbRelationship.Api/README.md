## DbRelationship.Api
#### Added Nuget packages
1. `dotnet add DbRelationship.Api package Microsoft.EntityFrameworkCore.Sqlite`
2. `dotnet add DbRelationship.Api package Microsoft.EntityFrameworkCore.Design`
#### DB Migrration
`dotnet ef migrations add "initial-migration" --project DbRelationship.Api`
`dotnet ef database update --project DbRelationship.Api`

This application is an establishment of relation between entities. 
One to one
One to Many
Many to Many

This application is for study purpose.
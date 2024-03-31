docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=ACapdevila1$" -p 1433:1433 --name "sqlserver-rabbitbanking" -d mcr.microsoft.com/mssql/server

To login to the docker container using MSQLS Management Studio use : 127.0.0.1\{container_name},1433


EF cmds
Add-Migration "Initial Migration" -Context BankingDbContext => creates migration


Update-Database -Context {Entity}DbContext = > runs migration

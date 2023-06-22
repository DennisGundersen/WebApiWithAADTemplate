# Calling WebApi Secured With AAD from various Clients (Template)
## Under development

### Goals:
1. Simple example (tutorial) with steps for registering web api and clients in Azure AAD (see appsettings.json for MVC and Api)
2. Showing code for logging in user in web clients (see MVC client)
3. Showing code for calling downstream web api from web clients on behalf of user (see MVC client)
4. Showing code for calling downstream web api from console app as a daemon/application using client secret
5. Sample should use IDownstreamApi (not IDownstreamWebApi, which is used in all of Microsofts examples, but which is also deprecated)
6. Sample code should be as standardized as possible for flexibility/reuseability (feel free to ignore any eccentricities in my code, I'm not a programmer) 

### Information:
1. The MVC app has most of the code already setup, but as I updated from the deprecated IDownstreamWebApi to IDownstreamApi, it no longer maintains the tokens correctly (must log out and re-login on restart of app)
2. Also some error crept in about JSON token, so the sample no longer runs
3. Database can be auto created from the SSDT project (set to local MS SQL instance installed with Visual Studio), just publish it
4. DAL uses Dapper and calls stored procedures included in the SSDT project 
5. Database uses added schema "dbo.pragmatic" for flexibility/reuseability

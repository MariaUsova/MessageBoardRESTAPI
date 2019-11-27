# Message board RESTful API

RESTful API to serve as the backend for a public message board. It supports the following features:
  - A client can create a message in the service (POST /message {"message": "any message"})
  - A client can modify their own messages (PUT /message/{id:guid} {"message": "updated message"})
  - A client can delete their own messages (DELETE /message/{id:guid})
  - A client can view all messages in the service (GET /message)

In-memory solution used for storing any data for this service. 

Supports Basic Auth mechanism. List of available users: 
```
new User { Id = 1, Username = "test", Password = "test" },
new User { Id = 2, Username = "user", Password = "password" },
new User { Id = 2, Username = "admin", Password = "admin" }
```            

## Used technologies

- ASP.NET Core 3.0
- Visual Studio 2019
- Docker

## Build and run solution on local machine

- Open project in Visual Studio 2019
- Select, build and run `Storytel` profile
- New browser window with address https://localhost:5001/message will be opened, if not - open this url in any browser
- Now you can test API (e.g. using Postman)  
For testing you need to provide Basic Auth header (e.g. `Authorization Basic dGVzdDp0ZXN0`)

## Build and run solution using Docker

Based on:  
https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-3.0
https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/aspnetcore-docker-arm64.md </br>

In repository root folder:

- If you or Windows:   
`$ docker build . -f Dockerfile-t storytel:latest-windows --no-cache`   
`$ docker run -it --rm -p 5000:80 storytel:latest-windows`

- On MacOS or Linux:  
`$ docker build . -f Dockerfile-linux -t storytel:latest-linux --no-cache`    
`$ docker run -it --rm -p 5000:80 storytel:latest-linux`

Application will be available at http://localhost:5000. For example, open http://localhost:5000/messages

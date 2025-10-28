# TaskTrackerAPI
A simple **ASP.NET Core Web API** project that demonstrates clean architecture and basic CRUD operations for managing tasks.  
Built as a sample project to showcase backend development skills in C# and .NET.

---

## Live Demo
You can explore and test the API using Swagger UI here:  
[https://tasktrackerapi.azurewebsites.net/](https://tasktrackerapi.azurewebsites.net/)

---

## Features
- ASP.NET Core 8 Web API  
- RESTful endpoints for managing tasks  
- Separation of DTOs and entities  
- In-memory data store (for simplicity)  
- Fully documented with Swagger UI  

---

## Endpoints Overview

| Method | Endpoint | Description |
|--------|-----------|-------------|
| `GET` | `/api/tasks` | Get all tasks |
| `GET` | `/api/tasks/{id}` | Get a specific task by ID |
| `POST` | `/api/tasks` | Create a new task |
| `PUT` | `/api/tasks/{id}` | Update an existing task |
| `DELETE` | `/api/tasks/{id}` | Delete a task |

---

## Run Locally

1. Clone this repository:
   git clone https://github.com/<your-username>/TaskTrackerAPI.git
Open the solution in Visual Studio 2022 or VS Code.

Run the project:
  dotnet run
Visit Swagger UI locally at:
https://localhost:5001/swagger


**Technologies Used**
C# / .NET 8
ASP.NET Core Web API
Swagger (Swashbuckle)
Azure App Service (for hosting)


**Notes**
This is a lightweight demo API intended for learning and portfolio purposes.
Feel free to fork, extend, or use it as a base for your own backend experiments.

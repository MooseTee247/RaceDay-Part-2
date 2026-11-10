# RaceDay Platform - Part 2 Update (POE Part 3)

## Project Overview
RaceDay is a comprehensive ASP.NET Core solution built with .NET 9.0, Entity Framework Core 9.0, and SQL Server LocalDB. It provides a robust RESTful Web API backend alongside an interactive ASP.NET Core MVC frontend for managing race events, participant registrations, categories, results, and cloud media uploads.

---

## Technical Stack
- **Framework & Language**: .NET 9.0 / C#
- **Architecture**: MVC & RESTful Web API
- **ORM**: Entity Framework Core 9.0
- **Database**: SQL Server LocalDB / InMemory (for Unit Testing)
- **Containerization**: Docker
- **API Documentation**: Swashbuckle / Swagger UI
- **Testing Framework**: xUnit with Automated CI/CD
- **CI/CD Pipeline**: GitHub Actions

---

## Entity Models & Roles
1. **User**: Represents participants and organisers. Includes security roles: `Organiser` and `Participant`.
2. **Event**: Stores details regarding race events (names, dates, locations, banner images).
3. **Category**: Defines age/distance categories linked to specific events.
4. **Enrolment**: Connects a User to an Event and Category.
5. **Result**: Stores finish times and rankings for enrolled participants.

---

## How to Run the Application Locally

### Prerequisites
* [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
* SQL Server LocalDB
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) (optional, for containerized execution)

### 1. Running via .NET CLI
Clone the repository and run the projects from your terminal:

```bash
git clone [https://github.com/MooseTee247/RaceDay-Part-2.git](https://github.com/MooseTee247/RaceDay-Part-2.git)
cd RaceDay
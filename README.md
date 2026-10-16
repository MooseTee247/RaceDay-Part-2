# RaceDay API - Part 2 Backend Implementation

## Project Overview
RaceDay is an ASP.NET Core Web API built with Entity Framework Core 9.0 and SQL Server LocalDB. It provides RESTful endpoints for managing race events, participant registrations, categories, and results.



## Technical Stack
* **Framework**: .NET 9.0 / C#
* **ORM**: Entity Framework Core 9.0
* **Database**: SQL Server LocalDB / InMemory (for Unit Testing)
* **API Documentation**: Swashbuckle / Swagger UI
* **Testing Framework**: xUnit
* **CI/CD**: GitHub Actions



## Entity Models & Roles
1. **User**: Represents participants and organisers. Includes roles: `Organiser` and `Participant`.
2. **Event**: Stores details regarding race events (names, dates, locations).
3. **Category**: Defines age/distance categories linked to specific events.
4. **Enrolment**: Connects a User to an Event and Category.
5. **Result**: Stores finish times and rankings for enrolled participants.



## How to Run the API Locally

### Prerequisites
* .NET 9.0 SDK
* SQL Server LocalDB

### Steps
1. Clone the repository:
   ```bash
   git clone <YOUR_GITHUB_REPO_URL>
   cd RaceDay
# Eventify-Master

Eventify-Master is a comprehensive Event Management System built on the principles of Clean Architecture using .NET Core. This system enables users to efficiently create, manage, and register for events, incorporating features such as venue management, sponsorships, speaker engagements, and attendee feedback.

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## Features

- Create, manage, and register for events.
- Venue management for event locations.
- Sponsorship management for event sponsors.
- Speaker engagements and profiles.
- Session management within events.
- Attendee feedback for sessions.
- Clean Architecture design principles.
- CQRS implementation for improved scalability.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [NPGSL Postgres](https://www.npgsql.org/)
- [Automapper](https://automapper.org/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/ihajoosten/Eventify.git
   ```
   ```bash
   cd Eventify
   ```
   ```bash
   dotnet run
   ```

2. Add Migrations Entity Framework:
      
   ```bash
   dotnet ef add migrations <Name> -c EventifyDbContext --project Eventify.Infrastructure --startup-project Eventify.Api
   ```

2. Update Database Entity Framework:
   ```bash
   dotnet ef database update -c EventifyDbContext --project Eventify.Infrastructure --startup-project Eventify.Api
   ```

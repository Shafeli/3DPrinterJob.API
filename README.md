# 3DPrinterJob.API

## Project Description
This repository contains the backend API for a family 3D printer task system. The API, built with **ASP.NET Core** and **Entity Framework Core**, handles the creation, tracking, and management of 3D printing jobs. It allows users to log and view tasks with details such as a download link for the model, notes, status, and the family member who requested it. The application is containerized for easy deployment on a home lab server like unRAID.

## Features
-   **RESTful API:** Provides endpoints for full CRUD (Create, Read, Update, Delete) functionality for 3D print tasks.
-   **Job Tracking:** Each job can be assigned a status (e.g., "Not Started," "In Progress," "Ended").
-   **User Tracking:** Logs which family member requested a print job.
-   **Model Links:** Stores a URL for easy access to the model's download link.
-   **Containerized:** Built with Docker support for straightforward deployment.

## Technology Stack
-   **ASP.NET Core Web API:** The core framework for the API.
-   **Entity Framework Core:** Used for database access and management.
-   **SQL Server:** The database engine used for data persistence.
-   **Docker:** Used for containerization and deployment.

## Getting Started
To run this project locally, you will need the following installed:
-   [.NET SDK](https://dotnet.microsoft.com/download)
-   [Docker Desktop](https://www.docker.com/products/docker-desktop/)
-   A SQL Server instance (local or containerized)

### Installation
1.  Clone the repository:
    ```sh
    git clone https://github.com/Shafeli/3DPrinterJob.API.git
    ```
2.  Configure your database connection string in `appsettings.json`.
3.  Run the database migrations:
    ```sh
    dotnet ef database update
    ```
4.  Run the project:
    ```sh
    dotnet run
    ```

## Endpoints
You can explore the available API endpoints using the Swagger UI, which is accessible when you run the application.

## Author
-   **Shafeli** - [GitHub Profile](https://github.com/Shafeli)

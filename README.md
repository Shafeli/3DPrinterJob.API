# 3DPrinterJob.API

## Project Description

This repository contains the backend API for a family 3D printer task system. The API, built with ASP.NET Core and Entity Framework Core, handles creation, tracking, and management of 3D printing jobs. Users can log tasks with details such as download links, notes, status, and requester information. The application is containerized for easy deployment on a home lab server.

---

## Features

- RESTful API with full CRUD for print tasks  
- Job tracking with statuses (Not Started, In Progress, Ended)  
- Requester tracking for family members  
- Model download link storage  
- Health endpoints for quick status checks  
- Docker support for development and deployment  

---

## Technology Stack

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- Docker  

---

## Prerequisites

- .NET SDK  
- Docker Desktop  
- Git  

---

## Environment Variables

Copy `.env.example` to `.env` and update values before running the application.

```env
# Database connection string for local development
ConnectionStrings__DefaultConnection=Server=localhost,1433;Database=PrinterJobsDev;User Id=sa;Password=YourStrong!DevPassword;

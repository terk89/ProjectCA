# Instrument Management System - Calibration Database

## Project Overview
The **Instrument Management System** is a web application developed using **ASP.NET Core 6.0** (Razor Pages)
that allows users to manage instruments, track calibration records, and download calibration certificates in PDF format. 
This application ensures that only authenticated users can access the system and provides roles for administrators to 
manage calibration records.

Key features:
- User authentication and authorization using ASP.NET Core Identity
- Ability to add, edit, and view instruments
- Calibration record management with the ability to upload/download calibration certificates in PDF format
- Only registered and logged-in users can access the Instruments page
- Admin role for managing calibration records

## Features
- Instruments Management: Register and manage instruments.
- Calibration Records: Keep track of calibration records associated with each instrument.
- PDF Storage: Upload and download PDF calibration certificates.
- Role-based Access Control: Only authenticated users can access the system, and certain actions are restricted to admins.
- Responsive Interface: Works across different devices.

## Prerequisites
To run this project, you'll need the following tools installed:

- .NET SDK 6.0 or higher: [Install .NET SDK](https://dotnet.microsoft.com/download/dotnet)
- SQL Server (or any other relational database of your choice if you modify the application)
- Visual Studio 2022 or VS Code (or any IDE that supports .NET development)

## Installation

### Clone the Repository
Clone this repository to your local machine using Git:


## Configure Database
Open the appsettings.json file and configure the connection string to your database.
Run the Package Manager Console, perform Migration and update the database. 

## User Roles
Application supports the following roles:
- Admin - can Create, Edit and Delete Manufacturers, Instrument Types, Equipment Items and Calibration Records.
It has to be set up manually in the Database Junction Table AspNetUserRoles by providing UserId(AspNetUsers) and
role Id (AspNetRoles).
- Technician - can view and add new instruments and calibration records but cannot delete or modify records created by others. This is the default user type associated with new users.

## Equipment Items
- In order to add EquipmentItem (Admin only) the following items need to be added in advance:
- Manufacturer (Admin)
- InstrumentType(Admin)
- Once Added, Technician is able to add a new CalibrationRecord and edit basic EquipmentItem informations.

## Technologies Used
- ASP.NET Core 6.0 (Razor Pages)
- Entity Framework Core (for database management)
- ASP.NET Core Identity (for authentication and authorization)
- SQL Server (relational database)



Contact:
github: @terk89













# EncoreTIX

A web application that showcases attractions, provides details, and highlights upcoming events by integrating with the Ticketmaster API.

## Features

- Search functionality for attractions (bands, comedians, sports teams, etc.)
- Display of attraction cards with images and names
- Selection functionality to view details about a specific attraction
- Detailed view of attractions with:
  - Name and image
  - External links (social media, website)
  - Upcoming events listing with venue and date information
- "No results found" message when search returns no results

## Technology Stack

- ASP.NET Core MVC
- .NET Core (Backend)
- Bootstrap 5 (Styling)
- Ticketmaster Discovery API

## Setup Instructions

1. Clone the repository:

git clone https://github.com/yourusername/EncoreTIX.git

2. Open the solution in Visual Studio 2022

3. Update the Ticketmaster API key in `appsettings.json`:
```json
"Ticketmaster": {
  "ApiKey": "YOUR_API_KEY_HERE"
}

4. Build and run the application:

Press F5 in Visual Studio, or
Use the command line:
Copydotnet build
dotnet run

5. Access the application at https://localhost:5001 (or the port specified in your environment)

Project Structure

Controllers/: Contains the HomeController that handles the main functionality
Models/: Contains classes representing Ticketmaster API data structures
ViewModels/: Contains view-specific models for passing data to views
Views/: Contains the UI templates
Services/: Contains the TicketmasterService for API communication

API Integration
This project uses the Ticketmaster Discovery API v2. The key endpoints used are:

/attractions.json - For searching attractions
/attractions/{id}.json - For getting details about a specific attraction
/events.json - For getting events associated with an attraction

Requirements

.NET 8.0 SDK or later
A valid Ticketmaster API key
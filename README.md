# Playlist API

## Project Overview

This project is an ASP.NET Core 10 Web API that allows users to create playlists, create songs, add songs to playlists, and retrieve playlists with their songs.

The project uses Entity Framework Core with SQL Server and demonstrates a many-to-many relationship between Playlists and Songs.

---

## Technologies Used

- ASP.NET Core 10
- C#
- Entity Framework Core 10
- SQL Server
- Visual Studio 2022
- Git & GitHub
- Postman

---

## Why SQL Server?

SQL Server was chosen because:

- It integrates seamlessly with Entity Framework Core.
- It is reliable and widely used in enterprise applications.
- It provides excellent support for relational data and many-to-many relationships.
- It offers powerful management tools through SQL Server Management Studio (SSMS).

---

## Project Structure

```
PlaylistApi
│
├── Controllers
├── Data
├── Models
├── Migrations
├── Properties
├── Program.cs
├── appsettings.json
└── README.md
```

---

## Database Design

The project contains two main entities:

### Playlist

- Id
- Name

### Song

- Id
- Title
- Artist

A playlist can contain multiple songs, and a song can belong to multiple playlists.

This many-to-many relationship is managed automatically by Entity Framework Core through the `PlaylistSong` junction table.

---

## API Endpoints

### Create Playlist

POST

```
/Playlists
```

Example request

```json
{
  "name": "My Playlist"
}
```

---

### Get All Playlists

GET

```
/Playlists
```

---

### Create Song

POST

```
/Songs
```

Example request

```json
{
  "title": "Thunder",
  "artist": "Imagine Dragons"
}
```

---

### Add Song to Playlist

POST

```
/Playlists/{playlistId}/songs/{songId}
```

Example

```
POST /Playlists/1/songs/1
```

---

## Validation

The API validates required fields using Data Annotations.

Examples:

- Playlist Name is required.
- Song Title is required.
- Song Artist is required.

Invalid requests return **400 Bad Request**.

---

## How to Run the Project

### 1. Clone the repository

```bash
git clone https://github.com/hagerwaleed2020/PlaylistApi.git
```

### 2. Open the project in Visual Studio

### 3. Update the SQL Server connection string

Open:

```
appsettings.json
```

Update the SQL Server instance name if needed.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=PlaylistDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 4. Create the database

Run:

```bash
dotnet ef database update
```

### 5. Run the project

```bash
dotnet run
```

or simply press **F5** in Visual Studio.

---

## Testing

The API was tested using Postman.

---

## Author

Hager Waleed
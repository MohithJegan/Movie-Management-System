# Movie Management System

## Project Overview
The Movie Management System is a web application that allows users to manage movies, studios, and actors. It demonstrates the use of Entity Framework Core and ASP.NET Core Web API while efficiently handling one-to-many and many-to-many relationships.

## Controllers and Services

The application consists of three main controllers: **Actor**, **Movie**, and **Studio**. Each controller manages its respective entity and interacts with services to handle logic and data operations.

### 1. **Actor Controller**

- Manages CRUD operations for actors.
- Handles the many-to-many relationship between movies and actors.
- Supports listing actors associated with movie.

### 2. **Movie Controller**

- Manages CRUD operations for movies.
- Handles linking and unlinking of movies and actors.
- Supports listing movies associated with actor and studio.

### 3. **Studio Controller**

- Manages CRUD operations for studios.
- Supports listing of studio associated with movie


## Entity Models
- **Actor.cs**: Represents actors and their attributes.
- **Movie.cs**: Represents movies and their attributes.
- **Studio.cs**: Represents studios and their attributes.

## Interfaces
- **IActorService.cs**: Defines logic for actors.
- **IMovieService.cs**: Defines logic for movies.
- **IStudioService.cs**: Defines logic for studios.

## Services
- **ActorService.cs**: Implements logic for actors.
- **MovieService.cs**: Implements logic for movies, including linking/unlinking actors.
- **StudioService.cs**: Implements logic for studios.

## API Endpoints

### **Actor API**
- `GET /api/Actors/List` - Retrieves a list of all actors.
- `GET /api/Actors/Find/{id}` - Retrieves a specific actor by ID.
- `PUT /api/Actors/Update/{id}` - Updates an existing actor.
- `POST /api/Actors/Add` - Adds a new actor.
- `DELETE /api/Actors/Delete/{id}` - Deletes an actor by ID.
- `GET /api/Actors/ListActorsForMovie/{id}` - Retrieves actors associated with a specific movie.

### **Movie API**
- `GET /api/Movies/List` - Retrieves a list of all movies.
- `GET /api/Movies/Find/{id}` - Retrieves a specific movie by ID.
- `PUT /api/Movies/Update/{id}` - Updates an existing movie.
- `POST /api/Movies/Add` - Adds a new movie.
- `DELETE /api/Movies/Delete/{id}` - Deletes a movie by ID.
- `GET /api/Movies/ListMoviesForActor/{id}` - Retrieves movies associated with a specific actor.
- `GET /api/Movies/ListMoviesForStudio/{id}` - Retrieves movies associated with a specific studio.
- `POST /api/Movies/Link?movieId={id}&actorId={id}` - Links an actor to a movie.
- `DELETE /api/Movies/Unlink?movieId={id}&actorId={id}` - Unlinks an actor from a movie.

### **Studio API**
- `GET /api/Studios/List` - Retrieves a list of all studios.
- `GET /api/Studios/Find/{id}` - Retrieves a specific studio by ID.
- `PUT /api/Studios/Update/{id}` - Updates an existing studio.
- `POST /api/Studios/Add` - Adds a new studio.
- `DELETE /api/Studios/Delete/{id}` - Deletes a studio by ID.
- `GET /api/Studios/ListStudioForMovie/{id}` - Retrieves the studio associated with a specific movie.



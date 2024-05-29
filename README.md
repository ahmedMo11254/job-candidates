# Candidate API

This is a web API for storing and updating job candidate information.

## Setup

1. Clone the repository:
    ```sh
    git clone <your-repo-url>
    ```

2. Navigate to the project directory:
    ```sh
    cd CandidateApi
    ```

3. Open the solution in Visual Studio.

4. Run the application using Visual Studio (F5 or Ctrl+F5).

## Database Setup

The application uses SQL Server LocalDB. The connection string is provided in `appsettings.json`. The database will be created and updated automatically.

## Testing

Use tools like Postman or Swagger to test the API endpoints.

## API Endpoints

- `POST /api/candidates`: Add or update candidate information.
  
## Assumptions

- The application is designed to use a SQL database but can be extended to use other types of databases in the future.
- Email is used as a unique identifier for candidates.

## Improvements

- Add more detailed validation and error handling.

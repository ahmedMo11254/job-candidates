# job candidates
# Candidate API

This is a web API for storing and updating job candidate information.

## Assumptions
- The application is designed to use a SQL database, but can be extended to use other types of databases in the future.
- Email is used as a unique identifier for candidates.

## Improvements
- Implement caching for frequently accessed data.
- Add more detailed validation and error handling.
- Extend the API to support additional operations like deleting a candidate or retrieving a list of candidates.
- Implement logging for better tracking of operations and issues.
  
## Database Setup

- The application uses SQL Server LocalDB. The connection string is provided in `appsettings.json`. The database will be created and updated automatically.

## Setup
1. Clone the repository:
    ```sh
    git clone https://github.com/ahmedMo11254/job-candidates.git
    ```
2. Navigate to the project directory:
    ```sh
    cd CandidateApi
    ```
3. Run the application:
    ```sh
    dotnet run
    ```
4. Use tools like Postman or Swagger UI to test the API.

## Testing
To run the unit tests, navigate to the test project directory and run:
```sh
cd CandidateApi.Tests
dotnet test

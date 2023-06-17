# Driver Management System API

This API is built using C# and .NET 7 to perform CRUD operations on objects of type Driver. The results are stored in a file.

## Object Model
The Driver object has the following properties:
- `FirstName`: The first name of the driver.
- `LastName`: The last name of the driver.
- `Email`: The email address of the driver.
- `PhoneNumber`: The phone number of the driver.

## Dependencies
This project was built using .NET 7. You will need to have .NET 7 installed in order to build and run this project. You can download .NET 7 from the official [.NET website](https://dotnet.microsoft.com/download/dotnet/7.0).

This project also uses the following NuGet packages:
- `Microsoft.AspNetCore.Mvc`: Provides functionality for building web APIs using the Model-View-Controller (MVC) pattern.
- `Swashbuckle.AspNetCore`: Provides tools for generating Swagger/OpenAPI documentation for the API.

## Installation
1. Clone this repository to your local machine.
2. Open a command prompt or terminal window and navigate to the project directory.
3. Restore the NuGet packages by running the command `dotnet restore`.
4. Build the project by running the command `dotnet build`.

## Usage
To run the API, follow these steps:
1. Build the project (see Installation section above).
2. Run the project by running the command `dotnet run`.

The API provides the following endpoints:
- `GET /api/driver`: Returns a list of all drivers.
- `GET /api/driver/{id}`: Returns a driver with the specified ID.
- `POST /api/driver`: Creates a new driver.
- `PUT /api/driver/{id}`: Updates an existing driver with the specified ID.
- `DELETE /api/driver/{id}`: Deletes a driver with the specified ID.

You can use a tool like [Postman](https://www.postman.com/) to send requests to the API.

## Swagger/OpenAPI Documentation
This API uses Swagger/OpenAPI to generate documentation. To view the documentation, follow these steps:
1. Build and run the project (see Installation and Usage sections above).
2. Navigate to `https://localhost:{port}/swagger` in your web browser, where `{port}` is the port number assigned to the API (e.g. https://localhost:5000/swagger.

You can use the Swagger UI to explore the API endpoints and try them out.

## License
This project is licensed under the MIT License. See the [LICENSE.md](LICENSE.md) file for details.
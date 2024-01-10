# Asp Net Core Web application for bike renting :bike:

## Project description :open_book:

:man: Unregistered users can view all bikes along with their respective details and overall renting statistics.
The platform allows to sort bikes by newest, oldest, price (ascending), price (descending), as well as to filter  categorized bikes. Paginating and searching is introduced in order to ease finding the perfect bike.
All filters can be combined.

:green_circle: After a successfully register, users have access to a list showing bike details. They can rent unrented bikes and manage their rentals. 
Additionally, users could become agents.
In order to become an agent, user must not have any active rents. 
When registering as an agent you must provide a valid phone number. If an agent with the same number exists, a validation error will appear. Agents hold specific privileges - they can add bikes to the system, manage bike details, and edit or remove only the bikes they have added. 

:technologist: Admin area is introduced to hold specific functionalities for administrators.
The Admin has supreme access to all functionalities available to users and agents. This includes overseeing user registrations, monitoring all rental activities within the application.
Cumstom middleware keeps track of online users using a concurrent dictionary, updating their status based on activity, and managing their presence through cookies and caching.

:scroll: Categories and initial bikes are seeded.
First agent is seeded through database in order to seed initial bikes with the required agentId.
First admin is seed with an extension method.

:slightly_smiling_face: Custom error pages for status codes  400, 401 and 404 for production mode are set.

:cop: The application is secured against cross-site request forgery.
Guid IDs for bikes are used in order to restrict parameter tampering.
Different appsettings are set for production and development environment.


:1234: A Web Api which fetches data from database is introduced to show statistics on the home page. 


##  Structure :atom_symbol:

:file_folder: Data  
:gear: BikeRenting.Data - contains the DbContext, configurations for domain entities and migrations.  
:gear: BikeRenting.Data.Models - contains the domain entities.  

:file_folder: Services  
:gear: BikeRenting.Services.Data - contains service interfaces and services.  
:gear: BikeRenting.Services.Data.Models - containts services models (DTOs).  

:file_folder: Web  
:gear: BikeRenting.Web - Asp Net Core MVC web application.   
:gear: BikeRenting.Web.Infrastructure - contains extentions, middlewares and modelbinders.  
:gear: BikeRenting.Web.ViewModels - contains viewmodels used in the mvc web application.  
:gear: BikeRenting.WebApi - used to diplay statistics for rantals on the home page.  

:gear: BikeRenting.Common - contains general constants used in the entire application.

## Technologies used :hammer_and_wrench:  
:arrow_right:  Asp Net Core MVC 6.0  
:arrow_right: Asp Net Core Web Api 6.0  
:arrow_right: Swagger UI  
:arrow_right: SQL Server  
➡️ Entity Framework Core  
:arrow_right: SweetAlert2  
:arrow_right: Toastr notifications  
:arrow_right: Bootstrap  
:arrow_right: Bootstrap Icons  
:arrow_right: JavaScript  
:arrow_right: Jquery  
:arrow_right: AJAX  
:arrow_right: HTML  
:arrow_right: CSS  

## Screenshots :framed_picture:  


**Displaying all bikes for unregistered users :point_down:**`  
  
![](https://i.ibb.co/w726dfW/view-Unregistered.jpg)  
  
**Displaying all bikes for registered users :point_down:**`
  
![](https://i.ibb.co/X8qVxcd/view-Registered.jpg)  
  

**Displaying all bikes for agent :point_down:**`  

  ![](https://i.ibb.co/pP0JdTT/view-Agent.jpg)  
  
**Displaying admin's page :point_down:**`  
  
![](https://i.ibb.co/4ZRh8VY/Admin-View.jpg)  

**Displaying adding a bike :point_down:**`  

  ![](https://i.ibb.co/KGcwv4V/add-bike.jpg)  

**Displaying bike details :point_down:**` 

  ![](https://i.ibb.co/8gBWVrV/bike-details-page.jpg)  
**Displaying toastr notifications :point_down:**`  
  
![](https://i.ibb.co/48284PD/toastr1.jpg)  



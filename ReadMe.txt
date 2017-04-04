AgeRanger is a world leading application designed to identify person's age group!

Ageranger  does the following.
 - Allows user to add a new person - every person has the first name, last name, and age;
 - Displays a list of people in the DB with their First and Last names, age and their age group. The age group should be determened based on the AgeGroup DB table - a person belongs to the age group where person's age >= 
 than group's MinAge and < than group's MaxAge. Please note that MinAge and MaxAge can be null;
 - Allows user to search for a person by his/her first or last name and displays all relevant information for the person - first and last names, age, age group.

The application will also allow user to edit existing person records and expose a WEB API.

AgeRanger is a single page application technologies used are .Net MVC framework, Entity Framework 6,nInject Dependency Injection, Currently works works on SQLite DB, and any time it is flexible enough to use the desired database with minimum configurations and adding the required packages to support the entityframework data providers.

To migrate to SQL server in future please follow the below instructions.
1) configure the connection string for SQL DB.(can uncomment the commented connection string and change as per your settings. and please comment the SQLite connection string.)
2)Run the "Update-Database" command in package manager console to create a new database and insert default data to databasse to switch to SQL database. To do this the appconfig file in Models project should contain the Connection string.

PreRequisites
Visual Studio 2015
MVC5

Nuget packages
Entity framework6
nInject-for DI
nInject -for Webapi
Sqlite -for entity framework.





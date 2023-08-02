# EmployeeAzureFunctionsAPI
Pushing Updated Code



Steps to follow to run the project.


1) Download and Clone the project from Git (https://github.com/OwaisAlyas/EmployeeAzureFunctionsAPI_AwaisAlyasRathore)
2) Open The project 
3) Copp the DB script from Project file (EmployeeAzureFunctionsAPI.DataAccessLayer\EmployeeDbScripts) and Run t=in SQL Server
4) Configer the DB Connection string in project file (EmployeeAzureFunctionsAPI\local.settings.json)
5) Run the Project 
6) Use the PostMan Collection and test the cases (EmployeeAzureFunctionsAPI.Test\TestCasesWithPostmanCollection.json) 


Completed in the Assignment:

•	Multiple API endpoints should be created for retrieving data and creating new records (see below) ----> Done
•	An SQL Server Database should be used to store the data -----------------------------------------------> Done
•	Dapper should be used for data access -----------------------------------------------------------------> Done
•	The project should include scripts for table/view/sproc creation  ------------------------------------> Done
•	The repository pattern should be used  ----------------------------------------------------------------> Done
•	Please consider separation of concerns with regards to data access and business logic  ----------------> Done
•	The API should include required field validation  -----------------------------------------------------> Done
•	GIT should be used for version control   ---------------------------------------------------------------> Done
•	(Optional) Include unit tests    -----------------------------------------------------------------------> Done


The API should contain the following endpoints:
•	Search all employees with filtering (all fields)-------------------------------------------------------> Done
•	Get a single employee by their Id ---------------------------------------------------------------------> Done
•	Create an employee ------------------------------------------------------------------------------------> Done
•	Update an employee ------------------------------------------------------------------------------------> Done


Please use the following data structure for an employee:
•	Id (required)
•	FirstName (required)
•	Surname (required)
•	Email (required)
•	Start Date (required)
•	End Date
•	JobTitle (required)
•	ProfileImage

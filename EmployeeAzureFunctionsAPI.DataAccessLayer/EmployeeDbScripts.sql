USE [Employee]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/22/2023 8:43:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Employee]

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[SurName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[JobTitle] [nvarchar](100) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[ProfileImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[Employee] ( [FirstName], [SurName], [Email], [JobTitle], [StartDate], [EndDate], [ProfileImage]) VALUES ( N'Awais', N'Alyas', N'raja@gmail.com', N'SOftware ENginner', CAST(N'2023-07-22 00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Employee] ( [FirstName], [SurName], [Email], [JobTitle], [StartDate], [EndDate], [ProfileImage]) VALUES (N'MAlyas', N'Awais', N'MAlyas@Test.com', N'Software Engineer', CAST(N'2022-01-10 00:00:00.000' AS DateTime), CAST(N'2023-06-10 00:00:00.000' AS DateTime), N'asfadfsadjfhjadshfjadshfkjasdhfkjads')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateEmployee]    Script Date: 7/22/2023 8:43:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[CreateEmployee]
GO

Create proc [dbo].[CreateEmployee]

@FirstName nvarchar(100), 
@SurName nvarchar(100), 
@Email nvarchar(50), 
@JobTitle nvarchar(100), 
@StartDate datetime, 
@EndDate datetime null,
@ProfileImage nvarchar(max) null
as
begin 

INSERT INTO Employee (FirstName, SurName, Email, JobTitle, StartDate, EndDate,ProfileImage) 
VALUES (@FirstName, @SurName, @Email, @JobTitle, @StartDate, @EndDate,@ProfileImage)

End
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 7/22/2023 8:43:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetAllEmployees]
GO
Create proc [dbo].[GetAllEmployees]
as
begin 

SELECT Id,FirstName, SurName, Email, JobTitle, StartDate, EndDate,ProfileImage FROM Employee

End
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 7/22/2023 8:43:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


DROP PROCEDURE [dbo].[GetEmployeeById]
GO
Create proc [dbo].[GetEmployeeById]
@Id int
as
begin 

SELECT Id,FirstName, SurName, Email, JobTitle, StartDate, EndDate,ProfileImage FROM Employee WHERE Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 7/22/2023 8:43:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


DROP PROCEDURE [dbo].[UpdateEmployee]
GO
Create proc [dbo].[UpdateEmployee]  
@Id int,   
@FirstName nvarchar(100),   
@SurName nvarchar(100),   
@Email nvarchar(50),   
@JobTitle nvarchar(100),   
@StartDate datetime,   
@EndDate datetime null,  
@ProfileImage nvarchar(max) null  
as  
begin   
  
Update Employee set FirstName = @FirstName, SurName = @SurName, Email = @Email, JobTitle = @JobTitle, ProfileImage = @ProfileImage, StartDate = @StartDate, EndDate = @EndDate where Id = @Id 
  
End
GO

DROP PROCEDURE [dbo].[SearchEmployees]
GO
CREATE PROCEDURE SearchEmployees   
    @Id int = NULL,    
    @FirstName NVARCHAR(100) = NULL,    
    @SurName NVARCHAR(100) = NULL,    
    @Email NVARCHAR(100) = NULL,    
    @JobTitle NVARCHAR(100) = NULL,    
    @StartDate DATETIME = NULL,    
    @EndDate DATETIME = NULL    
AS    
BEGIN    
    SELECT *    
    FROM Employee    
    WHERE    
        (@Id IS NULL OR Id  = @Id)    
        AND (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')    
        AND (@SurName IS NULL OR SurName LIKE '%' + @SurName + '%')    
        AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')    
        AND (@JobTitle IS NULL OR JobTitle LIKE '%' + @JobTitle + '%')    
        AND (@StartDate IS NULL OR StartDate >= @StartDate)    
  AND (@EndDate IS NULL OR EndDate <= @EndDate)    
END
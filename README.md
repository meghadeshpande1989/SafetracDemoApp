# SafetracDemoApp
Run table Script

CREATE TABLE [dbo].[Users] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [first_name]    NVARCHAR (255) NOT NULL,
    [last_name]     NVARCHAR (255) NOT NULL,
    [user_password] NVARCHAR (255) NOT NULL,
    [email_address] NVARCHAR (255) NOT NULL,
    [date_created]  DATETIME2 (7)  NULL,
    [date_modified] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Areas] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [area_name] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
Run SP script
CREATE procedure [dbo].[AddNewUser]  
(  
   @FirstName nvarchar (255), 
    @LastName nvarchar (255), 
     @Password nvarchar(255),
   @EmailAddress nvarchar (255)  ,
   @DateCreated datetime2,
   @DateModified datetime2
)  
as  
begin  
   Insert into Users values(@FirstName,@LastName,@Password,@EmailAddress,@DateCreated,@DateModified)  
End
Create Procedure [dbo].[GetUserDetails]  
as  
begin  
   select * from Users
End

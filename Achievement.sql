CREATE DATABASE Users_Achievements_Ismaylova
COLLATE Cyrillic_General_CI_AS
GO

CREATE TABLE Users
(
[ID_User] [int] NOT NULL IDENTITY (1,1),
[Login] [nvarchar](50) NOT NULL,
[Password] [nvarchar](50) NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[DateOfBirth] [DateTime] NOT NULL,
[Age] [int] NOT NULL
)

GO

CREATE TABLE Achievements
(
[ID_Achievement] [int] NOT NULL IDENTITY (1,1),
[Title] [nvarchar](50) NOT NULL,
)
GO


CREATE TABLE User_Achievement
(
[ID_User] [int] NOT NULL,
[ID_Achievement] [int] NOT NULL,
)

GO

ALTER TABLE Users
ADD
PRIMARY KEY(ID_User)
GO
ALTER TABLE Achievements
ADD
PRIMARY KEY(ID_Achievement)
GO
ALTER TABLE User_Achievement
ADD
FOREIGN KEY (ID_User) REFERENCES Users (ID_User)
GO
ALTER TABLE User_Achievement
ADD
FOREIGN KEY (ID_Achievement) REFERENCES  Achievements (ID_Achievement)
GO
ALTER TABLE USERS ADD UNIQUE ([Login])
GO

create procedure addUser
	@ID_User int OUTPUT,
	@Login varchar(50),
	@Password varchar(50),
	@Name varchar(50),
	@Date date,
	@Age int
	AS
	insert into Users([Login], [Password], [Name], [DateOfBirth], [Age])
		values(@Login,@Password, @Name,@Date,@Age)
GO

CREATE PROCEDURE GetListUser
	AS
	SELECT ID_User, Name from Users
GO


CREATE PROCEDURE GetINFO_User
	@ID_User int
	AS
	SELECT ID_User, Name, DateOfBirth, Age from Users
	WHERE ID_User = @ID_User
GO

CREATE PROCEDURE LoginUser
	@Login varchar(50),
	@Password varchar(50)
	AS
	SELECT ID_User from Users
	WHERE [Login] = @Login AND [Password] = @Password
GO

CREATE PROCEDURE GetALL_INFO_User
	@ID_User int
	AS
	SELECT ID_User,[Login], [Password], Name, DateOfBirth, Age from Users
	WHERE ID_User = @ID_User
GO

CREATE PROCEDURE UpdateUser
	@id_user int,
	@Password varchar(50),
	@Name varchar(50),
	@DateOfBirth DateTime, 
	@Age int
	AS
	UPDATE Users SET [Password] = @Password, Name = @Name, DateOfBirth = @DateOfBirth, Age = @Age 
	WHERE ID_User = @id_user
GO
CREATE PROCEDURE RemoveUser
	@id int
	As
	DELETE FROM Users WHERE ID_User = @id
GO

create procedure addAchievement
	@Title nvarchar(50)
	
	AS
	insert into AchievementS(Title)
		values(@Title)
GO
CREATE PROCEDURE GetAllAchievements
	AS
	SELECT * FROM AchievementS
GO


CREATE PROCEDURE RemoveAchievement
	@id int
	AS
	DELETE FROM Achievements WHERE ID_Achievement = @id
GO

CREATE PROCEDURE UpdateAchievement
	@id int,
	@title nvarchar(50)
	AS
	UPDATE Achievements SET Title = @title WHERE ID_Achievement = @id
GO

CREATE PROCEDURE FindAchievement
	@title nvarchar(50)
	AS
	SELECT * FROM Achievements
	WHERE Title = @title
GO

create procedure addUser_Achievement
	@ID_User int,
	@ID_Achievement int
	AS
	insert into User_Achievement(ID_User,ID_Achievement)
		values(@ID_User,@ID_Achievement)
GO

CREATE PROCEDURE YOUR_Achievement
	@ID_User int
	as
	SELECT ID_Achievement, Title FROM UserAchievementView
	WHERE ID_User = @ID_User	
GO


create view UserAchievementView
as
	SELECT Users.*, Achievements.Title, User_Achievement.ID_Achievement From Users
	JOIN  User_Achievement On Users.ID_User = User_Achievement.ID_User
	JOIN Achievements On User_Achievement.ID_Achievement = Achievements.ID_Achievement
GO


create procedure DelUser_Achievement
	@ID_User int,
	@ID_Achievement int
	AS
	DELETE FROM User_Achievement WHERE ID_User = @ID_User AND ID_Achievement = @ID_Achievement
GO



CREATE PROCEDURE Exist_AchivementUser
	@ID_User int
	AS
	SELECT COUNT(ID_User) AS AchivementUser
	FROM User_Achievement
	Where ID_User = @ID_User
GO


CREATE PROCEDURE Exist_thisAchievement
	@title nvarchar(50)
	AS
	SELECT COUNT (ID_Achievement) AS CountAchievement
	FROM Achievements
	WHERE Title = @title
GO

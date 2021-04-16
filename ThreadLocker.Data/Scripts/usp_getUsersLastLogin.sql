if OBJECT_ID('dbo.usp_getUsersLastLogin') is Not NULL
BEGIN
	Drop Proc usp_getUsersLastLogin;
	Print 'Droped usp_getUsersLastLogin'
END;
Go
Create Procedure usp_getUsersLastLogin 
as
BEGIN
	
	Select UH.UserID,MAX(UH.DateTime) LoginTime  From UserLoginHistory UH (NOLOCK)
	GROUP BY UH.UserID
	
END
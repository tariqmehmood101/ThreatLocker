if OBJECT_ID('dbo.usp_updateUserLastLogin') is Not NULL
BEGIN
	Drop Proc usp_updateUserLastLogin;
	Print 'Droped usp_updateUserLastLogin'
END;
Go
Create Procedure usp_updateUserLastLogin 
@UserID INT,
@LogTime DateTime
AS
BEGIN
	
	Update U set U.LastLogin = @LogTime  From [User] U (NOLOCK) Where U.UserId = @UserID
	
END
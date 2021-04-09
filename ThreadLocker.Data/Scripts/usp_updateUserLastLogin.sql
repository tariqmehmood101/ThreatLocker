if OBJECT_ID('dbo.usp_updateUserLastLogin') is Not NULL
BEGIN
	Drop Proc usp_updateUserLastLogin;
	Print 'Droped usp_updateUserLastLogin'
END;
Go
Create Procedure usp_updateUserLastLogin 
as
BEGIN
	Update U Set U.LastLogin = LoginTime From [User] U (NOLOCK)
	JOIN 
	(
	Select UH.UserID,MAX(UH.DateTime) LoginTime  From UserLoginHistory UH (NOLOCK)
	GROUP BY UH.UserID
	) AS UHH ON U.UserId = UHH.UserID
END
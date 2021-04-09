if OBJECT_ID('dbo.usp_SearcAllUsers') is Not NULL
BEGIN
	Drop Proc usp_SearcAllUsers;
	Print 'Droped usp_SearcAllUsers'
END;
Go
--exec usp_SearcAllUsers 'Simon'
Create Procedure usp_SearcAllUsers 
@SearhText varchar(50) = null
as
BEGIN
	Select U.UserId, U.FirstName,U.LastName,U.PhoneNumber,U.CustomerNumber,U.PhoneNumber,U.EmailAddress from [User] U (NOLOCK)
	Where @SearhText IS NULL OR U.FirstName Like '%' + @SearhText +'%' 
	OR U.LastName Like '%' + @SearhText +'%' 
	OR U.CustomerNumber LIKE '%' + @SearhText + '%'
	OR U.PhoneNumber LIKE '%' + @SearhText + '%'
	OR U.EmailAddress LIKE '%' + @SearhText + '%'
END
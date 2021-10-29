select * from [dbo].[__EFMigrationsHistory]

select * from [Identity].Users
select * from [Identity].Roles
select * from [Identity].UserRoles

select c.Name as RoleName,a.*,b.RoleId from [Identity].Users as a,[Identity].UserRoles as b, [Identity].Roles as c
where a.Id=b.UserId and b.RoleId=c.Id

select a.id,a.FirstName,a.LastName,a.UserName,b.RoleId,c.Name from [Identity].Users as a,[Identity].UserRoles as b, [Identity].Roles as c
where a.Id=b.UserId and b.RoleId=c.Id


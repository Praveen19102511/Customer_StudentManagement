use master; -- database 


--Create Table-- 

create table Student 
(
Sid int primary key,
name varchar(50),
class int,
Fees Money,
PhotoName varchar (50) ,
PhotoBinary varBinary(MAX),
Status bit not null default 1
)


CREATE PROCEDURE sp_selectRecord
(
    @Sid INT
)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Sid, Name, Class, Fees, PhotoName, PhotoBinary
    FROM Student
    WHERE Status = 1 AND Sid = @Sid;
END
GO


CREATE PROCEDURE sp_InsertStudent
(
    @Sid INT,
    @Name VARCHAR(50),
    @Class INT,
    @Fees MONEY,
    @PhotoName VARCHAR(50),
    @PhotoBinary VARBINARY(MAX)
)
AS
BEGIN
    INSERT INTO Student (Sid, Name, Class, Fees, PhotoName, PhotoBinary)
    VALUES (@Sid, @Name, @Class, @Fees, @PhotoName, @PhotoBinary)
END
GO


CREATE PROCEDURE sp_UpdateStudent
(
    @Sid INT,
    @Name VARCHAR(50),
    @Class INT,
    @Fees MONEY,
    @PhotoName VARCHAR(50),
    @PhotoBinary VARBINARY(MAX)
)
AS
BEGIN
    Update Student Set  Name=@Name , Class=@Class, Fees=@Fees, PhotoName=@PhotoName, PhotoBinary=@PhotoBinary
	Where Sid=@Sid
END
GO



CREATE PROCEDURE sp_DeleteStudent
(
    @Sid INT
)
AS
BEGIN
    UPDATE Student
    SET Status = 0
    WHERE Sid = @Sid
END
GO

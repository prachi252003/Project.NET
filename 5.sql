CREATE PROC DeleteEmployee
(
    @EmpId INT
)
AS
BEGIN
    DELETE FROM Employee
    WHERE EmpId = @EmpId
END
GO
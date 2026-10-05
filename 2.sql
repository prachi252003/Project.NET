CREATE PROC DeleteTrainee
(
    @TrainingId INT,
    @EmpId INT
)
AS
BEGIN
    DELETE FROM Trainee
    WHERE TrainingId=@TrainingId
    AND EmpId=@EmpId
END
GO
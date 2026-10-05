CREATE PROC DeleteTraining
(
    @TrainingId INT
)
AS
BEGIN
    DELETE FROM Training
    WHERE TrainingId=@TrainingId
END
GO
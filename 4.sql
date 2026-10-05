CREATE PROC DeleteTrainer
(
    @TrainerId INT
)
AS
BEGIN
    DELETE FROM Trainer
    WHERE TrainerId=@TrainerId
END
GO
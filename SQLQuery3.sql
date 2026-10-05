CREATE PROC DeleteTechnology
(
    @TechnologyId INT
)
AS
BEGIN
    DELETE FROM Technology
    WHERE TechnologyId=@TechnologyId
END
GO

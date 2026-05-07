CREATE FUNCTION dbo.CheckIfFeeIsActive
(
    @EffectiveFrom DATETIME,
    @EffectiveTo DATETIME
)
RETURNS BIT
AS
BEGIN
    DECLARE @Now DATETIME = GETDATE();


    RETURN (
        CASE 
            WHEN @Now >= @EffectiveFrom 
                 AND (@EffectiveTo IS NULL OR @Now < @EffectiveTo)
            THEN 1
            ELSE 0
        END
    );
END;
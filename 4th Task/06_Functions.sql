CREATE FUNCTION GetPatientCount()
RETURNS INT AS
BEGIN
    DECLARE @Count INT;
    SELECT @Count = COUNT(*)
    FROM Patient;
    RETURN @Count;
END;
GO

CREATE FUNCTION GetDoctorSpecialization(
    @DoctorID INT)
RETURNS NVARCHAR(100) AS
BEGIN
    DECLARE @Spec NVARCHAR(100);
    SELECT @Spec = Specialization
    FROM Doctor
    WHERE DoctorID = @DoctorID;
    RETURN @Spec;
END;
GO

CREATE FUNCTION GetPatientStudies(
    @PatientID INT)
RETURNS TABLE AS
RETURN(
    SELECT
        StudyID,
        StudyDate,
        Result
    FROM Study
    WHERE PatientID = @PatientID
);
GO

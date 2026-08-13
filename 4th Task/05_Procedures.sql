CREATE PROCEDURE GetPatientsByDisease
    @Disease NVARCHAR(100) AS
BEGIN
    SELECT
        P.FullName,
        Pt.Disease
    FROM Person P
    JOIN Patient Pt
        ON P.PersonID = Pt.PersonID
    WHERE Pt.Disease = @Disease;
END;
GO

CREATE PROCEDURE AddPatient
    @PersonID INT,
    @Disease NVARCHAR(100) AS
BEGIN
    INSERT INTO Patient(PersonID,Disease)
    VALUES(@PersonID,@Disease);
END;
GO

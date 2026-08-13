CREATE VIEW PatientInfo AS
SELECT
    P.PersonID,
    P.FullName,
    P.Age,
    Pt.Disease
FROM Person P
JOIN Patient Pt
ON P.PersonID = Pt.PersonID;
GO

CREATE VIEW DoctorInfo AS
SELECT
    P.FullName,
    D.Specialization
FROM Person P
JOIN Doctor D
ON P.PersonID = D.PersonID;
GO

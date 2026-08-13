SELECT * FROM PatientInfo;

SELECT * FROM DoctorInfo;

EXEC GetPatientsByDisease 'Diabetes';

EXEC AddPatient 3,'Flu';

SELECT dbo.GetPatientCount();

SELECT dbo.GetDoctorSpecialization(1);

SELECT * FROM dbo.GetPatientStudies(1);

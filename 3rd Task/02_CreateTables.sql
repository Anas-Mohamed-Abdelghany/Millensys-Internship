CREATE TABLE Person(
    PersonID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Age INT,
    Gender NVARCHAR(10),
    Phone NVARCHAR(20)
);

CREATE TABLE Patient(
    PatientID INT PRIMARY KEY IDENTITY(1,1),
    PersonID INT,
    Disease NVARCHAR(100),
    FOREIGN KEY (PersonID) REFERENCES Person(PersonID)
);

CREATE TABLE Doctor(
    DoctorID INT PRIMARY KEY IDENTITY(1,1),
    PersonID INT,
    Specialization NVARCHAR(100),
    FOREIGN KEY (PersonID) REFERENCES Person(PersonID)
);

CREATE TABLE Study(
    StudyID INT PRIMARY KEY IDENTITY(1,1),
    DoctorID INT,
    PatientID INT,
    StudyDate DATE,
    Result NVARCHAR(200),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);

CREATE DATABASE SynechronTrainingDB;
GO

USE SynechronTrainingDB;
GO

CREATE TABLE Employee
(
    EmpId INT IDENTITY(1001,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Designation VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(15)
);

CREATE TABLE Technology
(
    TechnologyId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,

    Level CHAR(1) CHECK(Level IN ('B','I','A')),

    Duration INT
);

CREATE TABLE Trainer
(
    TrainerId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,

    Type CHAR(1) CHECK(Type IN ('I','E')),

    Email VARCHAR(100),
    Phone VARCHAR(15)
);

CREATE TABLE Training
(
    TrainingId INT IDENTITY(1,1) PRIMARY KEY,

    TrainerId INT NOT NULL,

    TechnologyId INT NOT NULL,

    StartDate DATE,

    EndDate DATE,

    FOREIGN KEY(TrainerId)
    REFERENCES Trainer(TrainerId),

    FOREIGN KEY(TechnologyId)
    REFERENCES Technology(TechnologyId)
);

CREATE TABLE Trainee
(
    TrainingId INT,
    EmpId INT,

    Status CHAR(1)
    CHECK(Status IN ('C','N')),

    PRIMARY KEY(TrainingId,EmpId),

    FOREIGN KEY(TrainingId)
    REFERENCES Training(TrainingId),

    FOREIGN KEY(EmpId)
    REFERENCES Employee(EmpId)
);

SELECT * FROM Employee;
SELECT * FROM Technology;
SELECT * FROM Trainer;
SELECT * FROM Training;
SELECT * FROM Trainee;

INSERT INTO Employee
VALUES
('Sara','Developer','sara@gmail.com','9876543210'),
('Veda','Tester','veda@gmail.com','9876543211'),
('Sneha','Manager','sneha@gmail.com','9876543212');

INSERT INTO Technology
VALUES
('C#','B',5),
('ASP.NET Core','I',10),
('Azure','A',15);

INSERT INTO Trainer
VALUES
('Rahul','I','rahul@gmail.com','9988776655'),
('Rishi','E','rishi@gmail.com','9988776656');

INSERT INTO Training
VALUES
(1,1,'2026-10-01','2026-10-05'),
(2,2,'2026-10-10','2026-10-20');

INSERT INTO Trainee
VALUES
(1,1001,'C'),
(1,1002,'N'),
(2,1003,'N');


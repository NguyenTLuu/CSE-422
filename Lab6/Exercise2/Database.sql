CREATE DATABASE Lab6DB;
GO

USE Lab6DB;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Teachers (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

INSERT INTO Students VALUES
(1, 'John'),
(2, 'Alice');

INSERT INTO Teachers VALUES
(1, 'Mr. Smith'),
(2, 'Ms. Anna');
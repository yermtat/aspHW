CREATE DATABASE TasksDB;
GO;

USE TaskSDB;
GO;

CREATE TABLE ToDoTasks (
    id INT PRIMARY KEY IDENTITY(1, 1),
    name NVARCHAR(MAX) NOT NULL CHECK(name != ''),
    isDone BIT NOT NULL DEFAULT 0,
    due DATE NOT NULL,
);
GO;


INSERT INTO ToDoTasks(name, isDone, due) VALUES ('cleaning', 1, '07-20-2014');
INSERT INTO  ToDoTasks(name, isDone, due) values ('homework', 0, '08-28-2024');
go;

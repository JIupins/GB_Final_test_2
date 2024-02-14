DROP DATABASE IF EXISTS FriendsOfMan;
CREATE DATABASE FriendsOfMan;
USE FriendsOfMan;

DROP TABLE IF EXISTS Animal_Class;
CREATE TABLE Animal_Class
(
	Id INT AUTO_INCREMENT PRIMARY KEY, 
	Class_name VARCHAR(22)
);

INSERT INTO Animal_Class (Class_name)
VALUES ('Вьючные животные'),
('Домашние животные');  

DROP TABLE IF EXISTS Pack_Animals;
CREATE TABLE Pack_Animals
(
	  Id INT AUTO_INCREMENT PRIMARY KEY,
    Genus_name VARCHAR (22),
    Class_id INT,
    FOREIGN KEY (Class_id) REFERENCES Animal_Class (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Pack_Animals (Genus_name, Class_id)
VALUES ('Лошади', 1),
('Ослики', 1),  
('Верблюды', 1); 

DROP TABLE IF EXISTS Pets_Animals;    
CREATE TABLE Pets_Animals
(
	  Id INT AUTO_INCREMENT PRIMARY KEY,
    Genus_name VARCHAR (22),
    Class_id INT,
    FOREIGN KEY (Class_id) REFERENCES Animal_Class (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Pets_Animals (Genus_name, Class_id)
VALUES ('Коши', 2),
('Собаки', 2),  
('Хомячки', 2); 

DROP TABLE IF EXISTS Сats;
CREATE TABLE Сats 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pets_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Сats (Name, Birthday, Commands, Genus_id)
VALUES ('Пумка', '2021-07-01', "котя-котя", 1),
('Тома', '2020-03-01', "кусь-кусь", 1),  
('Барсик', '2017-05-16', "мусь-мусь", 1); 

DROP TABLE IF EXISTS Dogs;
CREATE TABLE Dogs 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pets_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Dogs (Name, Birthday, Commands, Genus_id)
VALUES ('Клык', '2020-02-29', "сидеть, лапу, лежать, голос, фас", 1),
('Рекс', '2013-02-24', "сидеть, лапу, лежать, голос, фас", 1),  
('Дик', '2009-06-03', "сидеть, лапу, лежать, голос, фас", 1), 
('Шарик', '2015-05-12', "сидеть, лапу, лежать, голос, фас", 1);

DROP TABLE IF EXISTS Hamsters;
CREATE TABLE Hamsters 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pets_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Hamsters (Name, Birthday, Commands, Genus_id)
VALUES ('Пупс', '2022-11-21', "жрать", 2),
('Хорь', '2019-05-12', "спать", 2),  
('Хвостик', '2021-09-12', "какать", 2), 
('Боря', '2015-01-10', "лети", 2);

DROP TABLE IF EXISTS Horses;
CREATE TABLE Horses 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pack_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Horses (Name, Birthday, Commands, Genus_id)
VALUES ('Пегий', '2000-03-03', "рысь, оле, брр", 1),
('Сивка', '2020-01-19', "шагом, оле, хоп", 2),  
('Конь', '2005-07-10', "рысь, оле, брр", 1), 
('Игривый', '2001-10-15', "бегом, хоп, рысь", 3);

DROP TABLE IF EXISTS Donkeys;
CREATE TABLE Donkeys 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pack_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Donkeys (Name, Birthday, Commands, Genus_id)
VALUES ('Мерин', '2007-04-23', "сидеть, лежать, прыжок", 1),
('Каравай', '2023-01-11', "лежать, прыжок", 1),  
('Самец', '2017-11-07', "спать, молодец", 1), 
('Рокот', '2014-10-13', "сидеть, лежать, прыжок", 1);

DROP TABLE IF EXISTS Camels;
CREATE TABLE Camels 
(       
    Id INT AUTO_INCREMENT PRIMARY KEY, 
    Name VARCHAR(22), 
    Birthday DATE,
    Commands VARCHAR(50),
    Genus_id int,
    Foreign KEY (Genus_id) REFERENCES Pack_Animals (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Camels (Name, Birthday, Commands, Genus_id)
VALUES ('Табак', '2002-01-12', "галоп", 3),
('Гусь', '2019-06-02', "голос", 3),  
('Куча', '2015-08-16', "плюнь", 3), 
('Початок', '2003-12-11', "кусь", 3);

SET SQL_SAFE_UPDATES = 0;
DELETE FROM Camels;

SELECT Name, Birthday, Commands FROM Horses
UNION SELECT  Name, Birthday, Commands FROM Donkeys;

DROP TEMPORARY TABLE IF EXISTS Animals;
CREATE TEMPORARY TABLE Animals AS 
SELECT *, 'Лошади' as genus FROM Horses
UNION SELECT *, 'Ослики' AS genus FROM Donkeys
UNION SELECT *, 'Собаки' AS genus FROM Dogs
UNION SELECT *, 'Коши' AS genus FROM Сats
UNION SELECT *, 'Хомячки' AS genus FROM Hamsters;

DROP TABLE IF EXISTS Young_animals;
CREATE TABLE Young_animals AS
SELECT Name, Birthday, Commands, genus, TIMESTAMPDIFF(MONTH, Birthday, CURDATE()) AS Age_in_month
FROM Animals WHERE Birthday BETWEEN ADDDATE(curdate(), INTERVAL -3 YEAR) AND ADDDATE(CURDATE(), INTERVAL -1 YEAR);
 
SELECT * FROM Young_animals;

SELECT h.Name, h.Birthday, h.Commands, pa.Genus_name, ya.Age_in_month 
FROM Horses h
LEFT JOIN Young_animals ya ON ya.Name = h.Name
LEFT JOIN Pack_Animals pa ON pa.Id = h.Genus_id
UNION 
SELECT d.Name, d.Birthday, d.Commands, pa.Genus_name, ya.Age_in_month 
FROM Donkeys d 
LEFT JOIN Young_animals ya ON ya.Name = d.Name
LEFT JOIN Pack_Animals pa ON pa.Id = d.Genus_id
UNION
SELECT c.Name, c.Birthday, c.Commands, ha.Genus_name, ya.Age_in_month 
FROM Сats c
LEFT JOIN Young_animals ya ON ya.Name = c.Name
LEFT JOIN Pets_Animals ha ON ha.Id = c.Genus_id
UNION
SELECT d.Name, d.Birthday, d.Commands, ha.Genus_name, ya.Age_in_month 
FROM Dogs d
LEFT JOIN Young_animals ya ON ya.Name = d.Name
LEFT JOIN Pets_Animals ha ON ha.Id = d.Genus_id
UNION
SELECT hm.Name, hm.Birthday, hm.Commands, ha.Genus_name, ya.Age_in_month 
FROM Hamsters hm
LEFT JOIN Young_animals ya ON ya.Name = hm.Name
LEFT JOIN Pets_Animals ha ON ha.Id = hm.Genus_id;
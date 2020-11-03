/*UseCase1*/
use Payroll_Service

/*UseCase2*/
Create Table employee_payroll(
	id int identity(1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	salary DECIMAL(10,2) NOT NULL,
	start_date DATETIME NOT NULL );

/*UseCase3*/
Insert Into employee_payroll
	Values('Sunny',199,'2020-10-30');

/*UseCase4*/
Select * From employee_payroll;

--UseCase5
--Ability to retrieve salary data
Select salary from employee_payroll
	where lower(name) = 'Sunny'
Select salary from employee_payroll
	where start_Date between CAST('2020-10-30' As DATE) and GETDATE();

--UseCase6
--Ability to add gender
Alter table employee_payroll
	add gender varchar(10) NOT NULL DEFAULT(' ');
Update employee_payroll set gender = 'M'
	where lower(name) ='sunny';

select * from employee_payroll;

--usecase7
select sum(salary) from employee_payroll
	where gender='M' group by gender;

--Deleting duplicate records
DELETE TOP(2)
	FROM employee_payroll;

--View data after deleting duplicates
SELECT * FROM employee_payroll;

--Inserting data
Insert Into employee_payroll
	Values('Carry',899,'2020-09-30','M'),('Mishi',1799,'2014-08-08','F');

--View the table
SELECT * FROM employee_payroll;

--Cannot Update an identity field
UPDATE employee_payroll
	SET id=1 WHERE name='Sunny';

SELECT SUM(salary) AS TOTAL_SUM, AVG(salary) AS AVERAGE, MIN(salary) AS MINIMUM_SALARY FROM employee_payroll
	WHERE gender='M' GROUP BY gender;

SELECT COUNT(gender) AS GENDER FROM employee_payroll WHERE gender='M' GROUP BY gender;

SELECT @@version;

exec sp_help "employee_payroll";

--usecase8
--Extend employee payroll table
ALTER TABLE employee_payroll
	ADD phonenumber VARCHAR(10) NOT NULL DEFAULT(' ');
ALTER TABLE employee_payroll
	ADD address VARCHAR(50) NOT NULL DEFAULT(' ');
ALTER TABLE employee_payroll
	ADD department VARCHAR(50) NOT NULL DEFAULT(' ');
SELECT * FROM employee_payroll;

--usecase9
--Extend empployee payroll table
EXEC sp_RENAME 'employee_payroll.salary', 'basic_pay', 'COLUMN'
SELECT * FROM employee_payroll;

ALTER TABLE employee_payroll
	ADD deductions DECIMAL(10,2) NOT NULL DEFAULT(0);
ALTER TABLE employee_payroll
	ADD  taxable_pay DECIMAL(10,2) NOT NULL DEFAULT(0);
ALTER TABLE employee_payroll
	ADD  income_tax DECIMAL(10,2) NOT NULL DEFAULT(0);
ALTER TABLE employee_payroll
	ADD  net_pay DECIMAL(10,2) NOT NULL DEFAULT(0);
SELECT * FROM employee_payroll;

--usecase10
--Add the details for the changed field
SELECT * FROM employee_payroll WHERE name='Mishi';
INSERT INTO employee_payroll 
	VALUES('Mishi',15000,'2019-10-31','F',123456789,'Mumbai','Marketing',1000,14000,1400,12600);
SELECT * FROM employee_payroll WHERE name='Mishi';

SELECT HOST_NAME();

--UPDATING VALUES
UPDATE employee_payroll
	SET phonenumber='7898789878',address='3/41 chawk',department='.Net Rpa',
        deductions=500,taxable_pay=9500,income_tax=8550,net_pay=23
     WHERE LOWER(name)='sunny';

UPDATE employee_payroll
	SET phonenumber='7543614259',address='9/69 wayfare',department='Java',
        deductions=200,taxable_pay=799,income_tax=79.9,net_pay=700.1
     WHERE LOWER(name)='carry';

UPDATE employee_payroll
	SET phonenumber='8562214789',address='8/42 kayne rd',department='Sales',
        deductions=399,taxable_pay=1600,income_tax=160,net_pay=1640
     WHERE id=3;

SELECT * FROM employee_payroll;

--usecase11
--Add the tables according to ER Diagram
--DROP TABLE employee_payroll;

--Creating table Company
CREATE TABLE Company(
    company_id INT NOT NULL PRIMARY KEY,
    company_name VARCHAR(30) NOT NULL,
);
--Inserting data into table Company
INSERT INTO Company(company_id,company_name)
    VALUES(171,'BridgeLabz'),(206,'Capgemini'),(987,'Google');
--Creating table Employee
CREATE TABLE Employee(
    employee_id INT NOT NULL PRIMARY KEY,
    employee_name VARCHAR(30) NOT NULL,
    gender VARCHAR(10) NOT NULL,
    phone_no VARCHAR(15),
    address VARCHAR(100)
);
--Inserting data into table Employee
INSERT INTO Employee(employee_id,employee_name,gender,phone_no,address)
    VALUES(23,'Ross','M','9899125354','Mumbai'),(39,'Phoebe','F','7896534218','Delhi'),
            (78,'Joey','M','6578923546','Moscow'),(11,'Phoebe','F','8796345567','Central Park');
--Creating table Department
CREATE TABLE Department(
    department_id INT NOT NULL PRIMARY KEY,
    department_name VARCHAR(50) NOT NULL,
    employee_id INT FOREIGN KEY REFERENCES Employee(employee_id)
);
--Inserting into table Department
INSERT INTO Department(department_id,department_name,employee_id)
    VALUES(333,'.Net Rpa',23),(877,'Java',78),(121,'Sales',39),(809,'Marketing',11);
--Creating table Payroll
CREATE TABLE Payroll(
    payroll_id VARCHAR(20) NOT NULL PRIMARY KEY,
    basic_pay DECIMAL(10,2),
    deduction DECIMAL(10,2),
    taxable_pay DECIMAL(10,2),
    income_tax DECIMAL(10,2),
    net_pay DECIMAL(10,2),
    employee_id INT FOREIGN KEY REFERENCES Employee(employee_id)
);
--Inserting into table Payroll
INSERT INTO Payroll(payroll_id,basic_pay,deduction,taxable_pay,income_tax,net_pay,employee_id)
    VALUES('#1245',10000,500,9500,950,8550,23),('#8765',15000,750,14250,1425,12825,78),
            ('#7689',25000,3000,22000,2200,19800,39),('#9008',29000,3500,25500,2550,22950,11);

--LETS CHECK THE TABLE AND ITS FIELDS
SELECT * FROM employee_payroll;

--NORMALIZED PAYROLL TABLES
SELECT * FROM Company;
SELECT * FROM Department;
SELECT * FROM Employee;
SELECT * FROM Payroll;

--Redoing usecase7 to perform database functions and use group bu function
--Using joins
SELECT SUM(basic_pay) AS SALARY_F, AVG(taxable_pay) AS AVERAGE_F, 
        MIN(income_tax) AS MINIMUM_F, MAX(net_pay) AS MAXIMUM_F, COUNT(payroll_id) AS COUNT_PAYROLL
    FROM Payroll p INNER jOIN Employee e
    ON p.employee_id=e.employee_id
    WHERE e.gender = 'F' GROUP BY e.gender;

--usecase12
SELECT * FROM Payroll;

--ADO.NET 
--USECASE 3
--UPDATE BASIC PAY 
UPDATE employee_payroll SET basic_pay=3000000
    WHERE LOWER(name)='sunny';
SELECT * FROM employee_payroll;

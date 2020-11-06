SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE SALARY PROCEDURE
CREATE PROCEDURE spUpdateEmployeePayroll(
    --Add the parameters for the stored procedures here
    @salaryId INT,
    @salaryAmt INT,
    @Month VARCHAR(50),
    @empId INT
)AS
BEGIN 
SET XACT_ABORT ON;
BEGIN TRY 
BEGIN TRANSACTION;
    UPDATE salaryInfo SET salaryAmt= @salaryAmt
        WHERE salaryId=@salaryId AND 
        LOWER(Month)=@Month AND empId=@empId;
    SELECT e.empId,e.empName,e.designation,s.salaryAmt,s.Month,s.salaryId
    FROM employeeInfo e INNER JOIN salaryInfo s
    ON e.empId=s.empId WHERE s.salaryId =@salaryId;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
    BEGIN
        PRINT 'Transaction is in an uncommitable state.'+'Rolling back transaction'
        ROLLBACK TRANSACTION;
    END;
IF(XACT_STATE())=1
    BEGIN
        PRINT 'Transaction is commitable.'+'Commiting transaction'
        COMMIT TRANSACTION;
    END;
END CATCH
END



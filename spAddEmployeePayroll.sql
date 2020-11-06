SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Sunny Jha		
-- Create date: 
-- Description:	stored procedure of employee payroll 
-- =============================================
CREATE PROCEDURE spAddEmployeePayroll
(
	@employee_name varchar(30),
	@phone_no varchar(15),
	@address varchar(100),
	@gender varchar(10),
	@basic_pay decimal(10,2),	
	@deduction decimal(10,2),
    @taxable_pay decimal(10,2),
	@income_tax decimal(10,2),
    @net_pay decimal(10,2),
)
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRY
		BEGIN TRANSACTION;		
			INSERT INTO Employee values(@employee_name, @gender, @phone_no, @address);
			INSERT INTO Payroll values(@basic_pay, @deduction, @income_tax, @start_date, (SELECT employee_id FROM Employee WHERE employee_id=(SELECT MAX(employee_id) FROM Employee)));
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		select ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
		IF (XACT_STATE()) = -1
			BEGIN
				PRINT N'The transaction is in an uncommittable state' + 'Rolling back transaction.'
				ROLLBACK TRANSACTION
			END;
		IF (XACT_STATE()) = 1
			BEGIN
				PRINT N'The transaction is committable' + 'Committing transaction.'
				COMMIT TRANSACTION
			END;
	END CATCH
END
GO
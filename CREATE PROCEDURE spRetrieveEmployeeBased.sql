CREATE PROCEDURE spRetrieveEmployeeBasedOnStartDate(
    --Add the parameters for the stored procedures here
    @sdate DATE,
    @edate DATE
)AS
BEGIN 
    SELECT * FROM empdetail WHERE sdate=@sdate AND edate=@edate;
END



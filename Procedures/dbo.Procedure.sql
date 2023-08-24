CREATE PROCEDURE CreateTask
	 @param1 varchar(max),@param2 varchar(max),@param3 varchar(max),@param4 varchar(max),@param5 varchar(max)
AS BEGIN
	INSERT INTO Tasks ( TaskName, TaskCategory, Description, startDate, endDate) 
           VALUES (@param1,@param2,@param3,@param4,@param5);
END


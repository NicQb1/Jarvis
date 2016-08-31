DECLARE @POS1ID as int
DECLARE @POS1IDCount as int
DECLARE @POS1IDCount2 as int
DECLARE @relStrength as decimal(10,10)
DECLARE @POSTId as int


DECLARE db_cursor CURSOR FOR  
SELECT        POS1ID, COUNT(*) AS pos1Count
FROM            POSTupleN2
GROUP BY POS1ID
ORDER BY pos1Count DESC

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @POS1ID, @POS1IDCount   

WHILE @@FETCH_STATUS = 0   
	BEGIN   

		DECLARE db_cursor2 CURSOR FOR  
		SELECT      POSTupleN2ID, [count]
		FROM            POSTupleN2
		
		OPEN db_cursor2   
		FETCH NEXT FROM db_cursor2 INTO @POSTId, @POS1IDCount2   

		WHILE @@FETCH_STATUS = 0   
		BEGIN   
      
				  set @relStrength = @POS1IDCount2/ @POS1IDCount

				UPDATE [dbo].[POSTupleN2]
				   SET 
					  [relationshipStrength] = @relStrength
				 WHERE POSTupleN2ID = @POSTId




			 
		FETCH NEXT FROM db_cursor2 INTO @POSTId, @POS1IDCount2 
		END   

		CLOSE db_cursor2   
		DEALLOCATE db_cursor2
    
FETCH NEXT FROM db_cursor INTO @POS1ID, @POS1IDCount   
END   

CLOSE db_cursor   
DEALLOCATE db_cursor
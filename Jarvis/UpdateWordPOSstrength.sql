DECLARE @word as varchar(50)
DECLARE @wordCount as int
DECLARE @relStrength as decimal(10,10)


DECLARE db_cursor CURSOR FOR  
SELECT        word, COUNT(*) AS Expr1
FROM            Word
GROUP BY word
ORDER BY Expr1 DESC

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @word, @wordCount   

WHILE @@FETCH_STATUS = 0   
BEGIN   
      
	  set @relStrength = 1/ @wordCount

UPDATE [dbo].[Word]
   SET [relationshipStrength] = @relStrength
 WHERE word = @word


    
FETCH NEXT FROM db_cursor INTO @word, @wordCount   
END   

CLOSE db_cursor   
DEALLOCATE db_cursor
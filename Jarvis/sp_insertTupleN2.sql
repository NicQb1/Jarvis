USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2]    Script Date: 8/25/2016 3:58:29 PM ******/
DROP PROCEDURE [dbo].[sp_insertTupleN2]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2]    Script Date: 8/25/2016 3:58:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertTupleN2]
	@wordID1 int,
	@wordID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM TupleN2 WHERE word1ID= @wordID1 AND word2ID = @wordID2)))
   begin
  
	INSERT INTO [dbo].TupleN2
           (word1ID
           ,word2ID
		   ,[count])
     VALUES
           (@wordID1
           ,@wordID2
           ,1)
  end
  ELSE
  begin
	 UPDATE TupleN2 SET [count] = [count] + 1 WHERE word1ID= @wordID1 AND word2ID = @wordID2
  end


  SELECT TupleN2ID FROM TupleN2 WHERE word1ID= @wordID1 AND word2ID = @wordID2

END


GO



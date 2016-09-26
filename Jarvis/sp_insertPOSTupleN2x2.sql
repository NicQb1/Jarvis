USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x2]    Script Date: 8/25/2016 9:15:09 PM ******/
DROP PROCEDURE [dbo].[sp_insertPOSTupleN2x2]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x2]    Script Date: 8/25/2016 9:15:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertPOSTupleN2x2]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2x2 WHERE POSTuple1= @TupleID1 AND POSTuple2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2x2
           (POSTuple1
           ,POSTuple2
		   ,[count]
		   ,lastupdated)
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1
		   ,getdate())
  end
  ELSE
  begin
	 UPDATE dbo.POSTupleN2x2 SET [count] = [count] + 1, lastupdated = getdate() WHERE POSTuple1= @TupleID1 AND POSTuple2 = @TupleID2
  end


  SELECT POSTupleN2x2ID FROM POSTupleN2x2 WHERE POSTuple1= @TupleID1 AND POSTuple2 = @TupleID2

END

GO

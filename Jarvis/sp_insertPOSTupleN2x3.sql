USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x3]    Script Date: 8/25/2016 9:16:03 PM ******/
DROP PROCEDURE [dbo].[sp_insertPOSTupleN2x3]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x3]    Script Date: 8/25/2016 9:16:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertPOSTupleN2x3]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2x3 WHERE POSTuple2_1= @TupleID1 AND POSTuple2_2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2x3
           (POSTuple2_1
           ,POSTuple2_2
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
	 UPDATE dbo.POSTupleN2x3 SET [count] = [count] + 1, lastupdated = getdate() WHERE POSTuple2_1= @TupleID1 AND POSTuple2_2 = @TupleID2
  end


  SELECT POSTupleN2x3ID FROM POSTupleN2x3 WHERE POSTuple2_1= @TupleID1 AND POSTuple2_2 = @TupleID2

END

GO


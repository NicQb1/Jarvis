USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x4]    Script Date: 8/25/2016 9:16:16 PM ******/
DROP PROCEDURE [dbo].[sp_insertPOSTupleN2x4]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x4]    Script Date: 8/25/2016 9:16:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertPOSTupleN2x4]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2x4 WHERE POSTuple3_1= @TupleID1 AND POSTuple3_2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2x4
           (POSTuple3_1
           ,POSTuple3_2
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
	 UPDATE dbo.POSTupleN2x4 SET [count] = [count] + 1, lastupdated = getdate() WHERE POSTuple3_1= @TupleID1 AND POSTuple3_2 = @TupleID2
  end


  SELECT POSTupleN2x4ID FROM POSTupleN2x4 WHERE POSTuple3_1= @TupleID1 AND POSTuple3_2 = @TupleID2

END

GO


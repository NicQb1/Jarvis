USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2]    Script Date: 8/25/2016 9:14:52 PM ******/
DROP PROCEDURE [dbo].[sp_insertPOSTupleN2]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2]    Script Date: 8/25/2016 9:14:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertPOSTupleN2]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2 WHERE POS1Id= @TupleID1 AND POS2ID = @TupleID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2
           (POS1Id
           ,POS2Id
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
	 UPDATE dbo.POSTupleN2 SET [count] = [count] + 1, lastupdated = getdate() WHERE POS1Id= @TupleID1 AND POS2ID = @TupleID2
  end


  SELECT POSTupleN2ID FROM POSTupleN2 WHERE POS1Id= @TupleID1 AND POS2ID = @TupleID2

END

GO


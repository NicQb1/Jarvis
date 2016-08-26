USE [NLP_Statistic_db]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_Antonym]    Script Date: 8/25/2016 9:12:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_insert_Antonym]
	-- Add the parameters for the stored procedure here
	@wordId int,
	@ant varchar(50),
	@complexity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @antonymID as int


	IF (NOT(EXISTS (SELECT * FROM Antonym WHERE WordID= @wordId AND word = @ant)))
   begin
  
INSERT INTO [dbo].Antonym
           ([WordID]
           ,[complexity]
           ,[word])
     VALUES
           (@wordId
           ,@complexity
           ,@ant)
  end


  SELECT SynonymID FROM [Synonym]WHERE WordID= @wordId AND word = @ant

END

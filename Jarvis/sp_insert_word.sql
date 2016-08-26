USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_word]    Script Date: 8/25/2016 9:14:18 PM ******/
DROP PROCEDURE [dbo].[sp_insert_word]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_word]    Script Date: 8/25/2016 9:14:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_word]
	-- Add the parameters for the stored procedure here
	@word varchar(30),
	@PartOfSpeech varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @partOfSpeechID as int

	SELECT @partOfSpeechID = partOfSpeechID FROM PartOfSpeech WHERE PartOfSpeech = @PartOfSpeech

	IF (NOT(EXISTS (SELECT * FROM Word WHERE word= @word AND PartOfSpeechID = @partOfSpeechID)))

   begin
   INSERT INTO [dbo].[Word]
           ([word]
           ,[PartOfSpeechID]
           ,[DefinitionID]
		   ,lastUpdated)
     VALUES
           (@word
           ,@partOfSpeechID
           ,NULL
		   ,getdate())
  end

  SELECT WordID FROM Word WHERE word= @word AND PartOfSpeechID = @partOfSpeechID

END

GO


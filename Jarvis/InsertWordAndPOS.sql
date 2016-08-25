USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_word_and_POS]    Script Date: 8/25/2016 3:57:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_word_and_POS]
	-- Add the parameters for the stored procedure here
	@word varchar(30),
	@PartOfSpeech int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	IF (NOT(EXISTS (SELECT * FROM Word WHERE word= @word AND PartOfSpeechID = @PartOfSpeech)))

   begin
   INSERT INTO [dbo].[Word]
           ([word]
           ,[PartOfSpeechID]
           ,[DefinitionID])
     VALUES
           (@word
           ,@PartOfSpeech
           ,NULL)
  end

  SELECT WordID FROM Word WHERE word= @word AND PartOfSpeechID = @PartOfSpeech

END


GO



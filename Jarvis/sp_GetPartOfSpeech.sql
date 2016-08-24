USE [NLP_Statistic_db]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_word]    Script Date: 8/24/2016 3:53:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].sp_GetPartOfSpeech
	-- Add the parameters for the stored procedure here
	@POS varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	IF (NOT(EXISTS (SELECT * FROM PartOfSpeech WHERE   PartOfSpeech = @POS)))

   begin
   INSERT INTO [dbo].PartOfSpeech
           (PartOfSpeech)
     VALUES
           (@POS)
  end

  SELECT PartOfSpeechId FROM PartOfSpeech WHERE   PartOfSpeech = @POS

END


USE [NLP_Statistic_db]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPartOfSpeech]    Script Date: 8/25/2016 9:12:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetPartOfSpeech]
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
           (PartOfSpeech,
		   lastUpdated)
     VALUES
           (@POS,
		   getdate())
  end

  SELECT PartOfSpeechId FROM PartOfSpeech WHERE   PartOfSpeech = @POS

END


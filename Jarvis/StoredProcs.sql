USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Antonym]    Script Date: 8/23/2016 10:35:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_Antonym]
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

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_Synonym]    Script Date: 8/23/2016 10:35:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_Synonym]
	-- Add the parameters for the stored procedure here
	@wordId int,
	@syn varchar(50),
	@complexity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @synonymIdID as int


	IF (NOT(EXISTS (SELECT * FROM [Synonym] WHERE WordID= @wordId AND word = @syn)))
   begin
  
INSERT INTO [dbo].[Synonym]
           ([WordID]
           ,[complexity]
           ,[word])
     VALUES
           (@wordId
           ,@complexity
           ,@syn)
  end


  SELECT SynonymID FROM [Synonym] WHERE WordID= @wordId AND word = @syn

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_word]    Script Date: 8/23/2016 10:36:01 PM ******/
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
           ,[DefinitionID])
     VALUES
           (@word
           ,@partOfSpeechID
           ,NULL)
  end

  SELECT WordID FROM Word WHERE word= @word AND PartOfSpeechID = @partOfSpeechID

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2]    Script Date: 8/23/2016 10:36:06 PM ******/
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
	@POSwordID1 int,
	@POSwordID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2 WHERE POS1Id= @POSwordID1 AND POS2ID = @POSwordID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2
           (POS1Id
           ,POS2Id
		   ,[count])
     VALUES
           (@POSwordID1
           ,@POSwordID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.POSTupleN2 SET [count] = [count] + 1 WHERE POS1Id= @POSwordID1 AND POS2ID = @POSwordID2
  end


  SELECT POSTupleN2ID FROM POSTupleN2 WHERE POS1Id= @POSwordID1 AND POS2ID = @POSwordID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x2]    Script Date: 8/23/2016 10:36:12 PM ******/
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
	@POSTupleID1 int,
	@POSTupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.POSTupleN2x2 WHERE POSTuple1= @POSTupleID1 AND POSTuple2 = @POSTupleID2)))
   begin
  
	INSERT INTO [dbo].POSTupleN2x2
           (POSTuple1
           ,POSTuple2
		   ,[count])
     VALUES
           (@POSTupleID1
           ,@POSTupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.POSTupleN2x2 SET [count] = [count] + 1 WHERE POSTuple1= @POSTupleID1 AND POSTuple2 = @POSTupleID2
  end


  SELECT POSTupleN2x2ID FROM POSTupleN2x2 WHERE POSTuple1= @POSTupleID1 AND POSTuple2 = @POSTupleID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x3]    Script Date: 8/23/2016 10:36:17 PM ******/
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
		   ,[count])
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.POSTupleN2x3 SET [count] = [count] + 1 WHERE POSTuple2_1= @TupleID1 AND POSTuple2_2 = @TupleID2
  end


  SELECT POSTupleN2x3ID FROM POSTupleN2x3 WHERE POSTuple2_1= @TupleID1 AND POSTuple2_2 = @TupleID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertPOSTupleN2x4]    Script Date: 8/23/2016 10:36:26 PM ******/
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
		   ,[count])
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.POSTupleN2x4 SET [count] = [count] + 1 WHERE POSTuple3_1= @TupleID1 AND POSTuple3_2 = @TupleID2
  end


  SELECT POSTupleN2x4ID FROM POSTupleN2x4 WHERE POSTuple3_1= @TupleID1 AND POSTuple3_2 = @TupleID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2]    Script Date: 8/23/2016 10:36:32 PM ******/
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


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2x2]    Script Date: 8/23/2016 10:36:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertTupleN2x2]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.TupleN2x2 WHERE Tuple1= @TupleID1 AND Tuple2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].TupleN2x2
           (Tuple1
           ,Tuple2
		   ,[count])
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.TupleN2x2 SET [count] = [count] + 1 WHERE Tuple1= @TupleID1 AND Tuple1 = @TupleID2
  end


  SELECT TupleN2x2ID FROM TupleN2x2 WHERE Tuple1= @TupleID1 AND Tuple1 = @TupleID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2x3]    Script Date: 8/23/2016 10:36:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertTupleN2x3]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.TupleN2x3 WHERE Tuple2_1= @TupleID1 AND Tuple2_2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].TupleN2x3
           (Tuple2_1
           ,Tuple2_2
		   ,[count])
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.TupleN2x3 SET [count] = [count] + 1 WHERE Tuple2_1= @TupleID1 AND Tuple2_2 = @TupleID2
  end


  SELECT TupleN2x3ID FROM TupleN2x3 WHERE Tuple2_1= @TupleID1 AND Tuple2_2 = @TupleID2

END

GO


USE [NLP_Statistic_db]
GO

/****** Object:  StoredProcedure [dbo].[sp_insertTupleN2x4]    Script Date: 8/23/2016 10:36:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertTupleN2x4]
	@TupleID1 int,
	@TupleID2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	


	IF (NOT(EXISTS (SELECT * FROM dbo.TupleN2x4 WHERE Tuple3_1= @TupleID1 AND Tuple3_2 = @TupleID2)))
   begin
  
	INSERT INTO [dbo].TupleN2x4
           (Tuple3_1
           ,Tuple3_2
		   ,[count])
     VALUES
           (@TupleID1
           ,@TupleID2
           ,1)
  end
  ELSE
  begin
	 UPDATE dbo.TupleN2x4 SET [count] = [count] + 1 WHERE Tuple3_1= @TupleID1 AND Tuple3_2 = @TupleID2
  end


  SELECT TupleN2x4ID FROM TupleN2x4 WHERE Tuple3_1= @TupleID1 AND Tuple3_2 = @TupleID2

END

GO



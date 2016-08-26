USE [NLP_Statistic_db]
GO

/****** Object:  Table [dbo].[Antonym]    Script Date: 8/25/2016 8:49:08 PM ******/
DROP TABLE [dbo].[Antonym]
GO

/****** Object:  Table [dbo].[Antonym]    Script Date: 8/25/2016 8:49:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Antonym](
	[AntonymID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NULL,
	[complexity] [int] NULL,
	[word] [nchar](30) NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_Antonym] PRIMARY KEY CLUSTERED 
(
	[AntonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Definition]    Script Date: 8/25/2016 8:49:21 PM ******/
DROP TABLE [dbo].[Definition]
GO

/****** Object:  Table [dbo].[Definition]    Script Date: 8/25/2016 8:49:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Definition](
	[DefinitionID] [int] IDENTITY(1,1) NOT NULL,
	[Definition] [text] NOT NULL,
	[lastUpdated] date not null,

 CONSTRAINT [PK_Definition] PRIMARY KEY CLUSTERED 
(
	[DefinitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PartOfSpeech]    Script Date: 8/25/2016 8:49:42 PM ******/
DROP TABLE [dbo].[PartOfSpeech]
GO

/****** Object:  Table [dbo].[PartOfSpeech]    Script Date: 8/25/2016 8:49:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PartOfSpeech](
	[PartOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[PartOfSpeech] [varchar](15) NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_PartOfSpeech2_1] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[POSTupleN2] DROP CONSTRAINT [DF_POSTupleN2_count]
GO

/****** Object:  Table [dbo].[POSTupleN2]    Script Date: 8/25/2016 8:50:08 PM ******/
DROP TABLE [dbo].[POSTupleN2]
GO

/****** Object:  Table [dbo].[POSTupleN2]    Script Date: 8/25/2016 8:50:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSTupleN2](
	[POSTupleN2ID] [int] IDENTITY(1,1) NOT NULL,
	[POS1ID] [int] NOT NULL,
	[POS2ID] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_POSTupleN2] PRIMARY KEY CLUSTERED 
(
	[POSTupleN2ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[POSTupleN2] ADD  CONSTRAINT [DF_POSTupleN2_count]  DEFAULT ((0)) FOR [count]
GO


ALTER TABLE [dbo].[POSTupleN2x2] DROP CONSTRAINT [DF_POSTupleN2x2_count]
GO

/****** Object:  Table [dbo].[POSTupleN2x2]    Script Date: 8/25/2016 8:50:41 PM ******/
DROP TABLE [dbo].[POSTupleN2x2]
GO

/****** Object:  Table [dbo].[POSTupleN2x2]    Script Date: 8/25/2016 8:50:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSTupleN2x2](
	[POSTupleN2x2ID] [int] IDENTITY(1,1) NOT NULL,
	[POSTuple1] [int] NOT NULL,
	[POSTuple2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_POSTupleN2x2] PRIMARY KEY CLUSTERED 
(
	[POSTupleN2x2ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[POSTupleN2x2] ADD  CONSTRAINT [DF_POSTupleN2x2_count]  DEFAULT ((0)) FOR [count]
GO

ALTER TABLE [dbo].[POSTupleN2x3] DROP CONSTRAINT [DF_POSTupleN2x3_count]
GO

/****** Object:  Table [dbo].[POSTupleN2x3]    Script Date: 8/25/2016 8:50:55 PM ******/
DROP TABLE [dbo].[POSTupleN2x3]
GO

/****** Object:  Table [dbo].[POSTupleN2x3]    Script Date: 8/25/2016 8:50:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSTupleN2x3](
	[POSTupleN2x3ID] [int] IDENTITY(1,1) NOT NULL,
	[POSTuple2_1] [int] NOT NULL,
	[POSTuple2_2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_POSTupleN2x3] PRIMARY KEY CLUSTERED 
(
	[POSTupleN2x3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[POSTupleN2x3] ADD  CONSTRAINT [DF_POSTupleN2x3_count]  DEFAULT ((0)) FOR [count]
GO


ALTER TABLE [dbo].[POSTupleN2x4] DROP CONSTRAINT [DF_POSTupleN2x4_count]
GO

/****** Object:  Table [dbo].[POSTupleN2x4]    Script Date: 8/25/2016 8:51:15 PM ******/
DROP TABLE [dbo].[POSTupleN2x4]
GO

/****** Object:  Table [dbo].[POSTupleN2x4]    Script Date: 8/25/2016 8:51:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POSTupleN2x4](
	[POSTupleN2x4ID] [int] IDENTITY(1,1) NOT NULL,
	[POSTuple3_1] [int] NOT NULL,
	[POSTuple3_2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_POSTupleN2x4] PRIMARY KEY CLUSTERED 
(
	[POSTupleN2x4ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[POSTupleN2x4] ADD  CONSTRAINT [DF_POSTupleN2x4_count]  DEFAULT ((0)) FOR [count]
GO


/****** Object:  Table [dbo].[Synonym]    Script Date: 8/25/2016 8:51:38 PM ******/
DROP TABLE [dbo].[Synonym]
GO

/****** Object:  Table [dbo].[Synonym]    Script Date: 8/25/2016 8:51:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Synonym](
	[SynonymID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NOT NULL,
	[complexity] [int] NOT NULL,
	[word] [nchar](30) NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_Synonym] PRIMARY KEY CLUSTERED 
(
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[TupleN2] DROP CONSTRAINT [DF_TupleN2_count]
GO

/****** Object:  Table [dbo].[TupleN2]    Script Date: 8/25/2016 8:51:52 PM ******/
DROP TABLE [dbo].[TupleN2]
GO

/****** Object:  Table [dbo].[TupleN2]    Script Date: 8/25/2016 8:51:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TupleN2](
	[TupleN2ID] [int] IDENTITY(1,1) NOT NULL,
	[word1ID] [int] NOT NULL,
	[word2ID] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_TupleN2] PRIMARY KEY CLUSTERED 
(
	[TupleN2ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TupleN2] ADD  CONSTRAINT [DF_TupleN2_count]  DEFAULT ((0)) FOR [count]
GO


ALTER TABLE [dbo].[TupleN2x2] DROP CONSTRAINT [DF_TupleN2x2_count]
GO

/****** Object:  Table [dbo].[TupleN2x2]    Script Date: 8/25/2016 8:52:05 PM ******/
DROP TABLE [dbo].[TupleN2x2]
GO

/****** Object:  Table [dbo].[TupleN2x2]    Script Date: 8/25/2016 8:52:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TupleN2x2](
	[TupleN2x2ID] [int] IDENTITY(1,1) NOT NULL,
	[Tuple1] [int] NOT NULL,
	[Tuple2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_TupleN2x2] PRIMARY KEY CLUSTERED 
(
	[TupleN2x2ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TupleN2x2] ADD  CONSTRAINT [DF_TupleN2x2_count]  DEFAULT ((0)) FOR [count]
GO



ALTER TABLE [dbo].[TupleN2x3] DROP CONSTRAINT [DF_TupleN2x3_count]
GO

/****** Object:  Table [dbo].[TupleN2x3]    Script Date: 8/25/2016 8:52:18 PM ******/
DROP TABLE [dbo].[TupleN2x3]
GO

/****** Object:  Table [dbo].[TupleN2x3]    Script Date: 8/25/2016 8:52:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TupleN2x3](
	[TupleN2x3ID] [int] IDENTITY(1,1) NOT NULL,
	[Tuple2_1] [int] NOT NULL,
	[Tuple2_2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_TupleN2x3] PRIMARY KEY CLUSTERED 
(
	[TupleN2x3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TupleN2x3] ADD  CONSTRAINT [DF_TupleN2x3_count]  DEFAULT ((0)) FOR [count]
GO



ALTER TABLE [dbo].[TupleN2x4] DROP CONSTRAINT [DF_TupleN2x4_count]
GO

/****** Object:  Table [dbo].[TupleN2x4]    Script Date: 8/25/2016 8:52:28 PM ******/
DROP TABLE [dbo].[TupleN2x4]
GO

/****** Object:  Table [dbo].[TupleN2x4]    Script Date: 8/25/2016 8:52:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TupleN2x4](
	[TupleN2x4ID] [int] IDENTITY(1,1) NOT NULL,
	[Tuple3_1] [int] NOT NULL,
	[Tuple3_2] [int] NOT NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_TupleN2x4] PRIMARY KEY CLUSTERED 
(
	[TupleN2x4ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TupleN2x4] ADD  CONSTRAINT [DF_TupleN2x4_count]  DEFAULT ((0)) FOR [count]
GO



/****** Object:  Table [dbo].[Word]    Script Date: 8/25/2016 8:52:48 PM ******/
DROP TABLE [dbo].[Word]
GO

/****** Object:  Table [dbo].[Word]    Script Date: 8/25/2016 8:52:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Word](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[word] [nchar](40) NOT NULL,
	[PartOfSpeechID] [int] NOT NULL,
	[DefinitionID] [int] NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[WordVector]    Script Date: 8/25/2016 8:53:04 PM ******/
DROP TABLE [dbo].[WordVector]
GO

/****** Object:  Table [dbo].[WordVector]    Script Date: 8/25/2016 8:53:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WordVector](
	[WordVectorID] [int] IDENTITY(1,1) NOT NULL,
	[word1ID] [int] NOT NULL,
	[word2ID] [int] NOT NULL,
	[vector] [decimal](10, 10) NULL,
	[count] [int] NOT NULL,
	[lastUpdated] date not null,

 CONSTRAINT [PK_WordVector] PRIMARY KEY CLUSTERED 
(
	[WordVectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




/****** Object:  Table [dbo].[Subject]    Script Date: 8/26/2016 3:17:36 PM ******/
DROP TABLE [dbo].[Subject]
GO

/****** Object:  Table [dbo].[Subject]    Script Date: 8/26/2016 3:17:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](50) NULL,
	[tag] [varchar](50) NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Parameters]    Script Date: 8/26/2016 3:17:30 PM ******/
DROP TABLE [dbo].[Parameters]
GO

/****** Object:  Table [dbo].[Parameters]    Script Date: 8/26/2016 3:17:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Parameters](
	[ParameterID] [int] IDENTITY(1,1) NOT NULL,
	[ParameterName] [varchar](50) NULL,
	[TableName] [varchar](50) NULL,
	[CommandID] [int] NOT NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[ParameterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[Location]    Script Date: 8/26/2016 3:17:25 PM ******/
DROP TABLE [dbo].[Location]
GO

/****** Object:  Table [dbo].[Location]    Script Date: 8/26/2016 3:17:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Location](
	[LocationID] [int] NULL,
	[LocationName] [varchar](50) NULL,
	[lastUpdated] date not null,
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[CommandTrainer]    Script Date: 8/26/2016 3:17:20 PM ******/
DROP TABLE [dbo].[CommandTrainer]
GO

/****** Object:  Table [dbo].[CommandTrainer]    Script Date: 8/26/2016 3:17:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CommandTrainer](
	[CommandTrainerID] [int] IDENTITY(1,1) NOT NULL,
	[CommandID] [int] NULL,
	[CommandTrainingPhrase] [varchar](max) NULL,
	[ExpectedOutPut] [varchar](max) NULL,
	[lastUpdated] date not null,
 CONSTRAINT [PK_CommandTrainer] PRIMARY KEY CLUSTERED 
(
	[CommandTrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Commands]    Script Date: 8/26/2016 3:17:16 PM ******/
DROP TABLE [dbo].[Commands]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 8/26/2016 3:17:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Commands](
	[CommandID] [int] IDENTITY(1,1) NOT NULL,
	[CommandName] [varchar](50) NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Action]    Script Date: 8/26/2016 3:17:06 PM ******/
DROP TABLE [dbo].[Action]
GO

/****** Object:  Table [dbo].[Action]    Script Date: 8/26/2016 3:17:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Action](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionName] [varchar](50) NULL,
	[CommandID] [int] NULL,
	[sequence] [int] NULL,
	[ParameterList] [varchar](max) NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO












USE [shoe_stores_test]
GO
/****** Object:  Table [dbo].[brands]    Script Date: 3/4/16 10:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[store_brand]    Script Date: 3/4/16 10:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[store_brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[store_id] [int] NULL,
	[brand_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stores]    Script Date: 3/4/16 10:30:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

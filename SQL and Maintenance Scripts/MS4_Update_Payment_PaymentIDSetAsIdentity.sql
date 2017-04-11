USE [ShufflepuffBang]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 4/11/2017 6:25:46 PM ******/
DROP TABLE [dbo].[Payment]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 4/11/2017 6:25:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](250) NULL,
	[CustomerId] [int] NULL,
	[AccountNumber] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


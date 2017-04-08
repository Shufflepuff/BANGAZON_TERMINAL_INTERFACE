USE [ShufflepuffBang]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2017 12:07:49 PM ******/
DROP TABLE [dbo].[Invoice]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2017 12:07:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NULL
) ON [PRIMARY]

GO



USE [ShufflepuffBang]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2017 12:24:35 PM ******/
DROP TABLE [dbo].[Invoice]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/8/2017 12:24:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


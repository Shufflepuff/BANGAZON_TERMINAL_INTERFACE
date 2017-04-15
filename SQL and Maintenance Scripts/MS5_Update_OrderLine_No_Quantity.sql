USE [ShufflepuffBang]
GO

/****** Object:  Table [dbo].[OrderLine]    Script Date: 4/12/2017 7:17:15 PM ******/
DROP TABLE [dbo].[OrderLine]
GO

/****** Object:  Table [dbo].[OrderLine]    Script Date: 4/12/2017 7:17:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderLine](
	[OrderLineId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[ProductId] [int] NULL,
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[OrderLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


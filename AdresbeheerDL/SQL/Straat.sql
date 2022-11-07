﻿CREATE TABLE [dbo].[Straat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StraatNaam] [varchar](250) NOT NULL,
	[NIScode] [int] NOT NULL,
 CONSTRAINT [PK_Straat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Straat]  WITH CHECK ADD  CONSTRAINT [FK_Straat_Gemeente] FOREIGN KEY([NIScode])
REFERENCES [dbo].[Gemeente] ([NIScode])
GO
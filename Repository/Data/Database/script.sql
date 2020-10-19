IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'MachineMonitoring')
  BEGIN
    CREATE DATABASE [MachineMonitoring]
  END
    GO
       USE [MachineMonitoring]
   GO
/****** Object:  Table [dbo].[MachineProductions]    Script Date: 04/10/2020 16:06:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MachineProductions')
  BEGIN
	CREATE TABLE [dbo].[MachineProductions](
		[MachineProductionId] [int] IDENTITY(1,1) NOT NULL,
		[MachineId] [int] NOT NULL,
		[TotalProduction] [int] NOT NULL DEFAULT ((0)),
	 CONSTRAINT [PK_MachineProductions] PRIMARY KEY CLUSTERED 
	(
		[MachineProductionId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
  END
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 04/10/2020 16:06:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Machines')
  BEGIN
	CREATE TABLE [dbo].[Machines](
		[MachineId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](50) NOT NULL,
		[Description] [varchar](250) NULL,
	 CONSTRAINT [PK_Machines] PRIMARY KEY CLUSTERED 
	(
		[MachineId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
  END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_MachineProductions_Machines_MachineId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
  BEGIN
   
	ALTER TABLE [dbo].[MachineProductions]  WITH CHECK ADD  CONSTRAINT [FK_MachineProductions_Machines_MachineId] FOREIGN KEY([MachineId])
	REFERENCES [dbo].[Machines] ([MachineId])
	ON DELETE CASCADE
  ALTER TABLE [dbo].[MachineProductions] CHECK CONSTRAINT [FK_MachineProductions_Machines_MachineId]
  END
GO


USE [MachineMonitoring]
GO

INSERT INTO [dbo].[Machines]
           ([Name]
           ,[Description])
     VALUES
           ('Machine 1','Some description for Machine 1')

INSERT INTO [dbo].[MachineProductions]
           ([MachineId]
           ,[TotalProduction])
     VALUES
           (SCOPE_IDENTITY(),CAST(RAND(CHECKSUM(NEWID())) * 10 as INT) + 1)

INSERT INTO [dbo].[Machines]
           ([Name]
           ,[Description])
     VALUES
           ('Machine 2','Some description for Machine 2')


INSERT INTO [dbo].[MachineProductions]
           ([MachineId]
           ,[TotalProduction])
     VALUES
           (SCOPE_IDENTITY(),CAST(RAND(CHECKSUM(NEWID())) * 10 as INT) + 1)


    GO
--You need to check if the table exists

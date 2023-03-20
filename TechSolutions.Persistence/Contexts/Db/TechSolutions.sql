CREATE DATABASE TechSolutions
GO
USE [TechSolutions]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 3/20/2023 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [nvarchar](50) NOT NULL,
	[ApellidosEmpleado] [nvarchar](50) NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [datetime] NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermiso]    Script Date: 3/20/2023 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_TipoPermiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso], [Created], [LastModified]) VALUES (1, N'Jose', N'Manuel', 1, CAST(N'2023-03-18T00:00:00.000' AS DateTime), CAST(N'2023-03-18T13:45:38.483' AS DateTime), CAST(N'2023-03-19T17:19:36.083' AS DateTime))
INSERT [dbo].[Permiso] ([Id], [NombreEmpleado], [ApellidosEmpleado], [TipoPermiso], [FechaPermiso], [Created], [LastModified]) VALUES (39, N'Jose', N'Pedro', 4, CAST(N'2023-03-26T00:00:00.000' AS DateTime), CAST(N'2023-03-20T15:23:54.447' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPermiso] ON 

INSERT [dbo].[TipoPermiso] ([Id], [Descripcion], [Created], [LastModified]) VALUES (1, N'Enfermedad', CAST(N'2023-03-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion], [Created], [LastModified]) VALUES (3, N'Diligencias', CAST(N'2023-03-18T18:21:22.993' AS DateTime), NULL)
INSERT [dbo].[TipoPermiso] ([Id], [Descripcion], [Created], [LastModified]) VALUES (4, N'Otros', CAST(N'2023-03-19T14:06:36.773' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TipoPermiso] OFF
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermiso] ([Id])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_TipoPermiso]
GO

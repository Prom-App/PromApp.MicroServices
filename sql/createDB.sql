USE [master]
GO
/****** Object:  Database [dbPromApp]    Script Date: 26/10/2023 11:29:07 p. m. ******/
CREATE DATABASE [dbPromApp]
GO
USE [dbPromApp]
GO
/****** Object:  Table [dbo].[Agencia]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[LaFiesta] [nvarchar](5) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IdCiudad] [int] NULL,
	[IdUniversidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaracteristicasXUniversidad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaracteristicasXUniversidad](
	[IdCaracteristica] [int] NOT NULL,
	[IdUniversidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Url] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarreraRelacionada]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarreraRelacionada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IdCarrera] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarreraXUniverdad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarreraXUniverdad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUniversidad] [int] NULL,
	[IdCarrera] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Iso2] [nvarchar](2) NULL,
	[IdDepartamento] [int] NOT NULL,
	[IdDemografia] [int] NULL,
 CONSTRAINT [PK__Ciudad__3214EC0788BA0839] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colegio]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colegio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IdCiudad] [int] NOT NULL,
	[EsPrivado] [bit] NOT NULL,
 CONSTRAINT [PK__Colegio__3214EC070467BE71] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[Correo] [nvarchar](250) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[IdParentesco] [int] NOT NULL,
	[IdUsuario] [nvarchar](100) NOT NULL,
	[IdUsuarioContacto] [nvarchar](100) NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demografia]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demografia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tamaño] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Tamaño] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Iso2] [nvarchar](2) NULL,
	[IdPais] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoGenero] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Geografia]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Geografia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Caracteristica] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK__Geografi__3214EC075AEA5D34] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Geografi__88F0CE98C391498D] UNIQUE NONCLUSTERED 
(
	[Caracteristica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Idioma] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdiomaXUniversidad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdiomaXUniversidad](
	[IdIdioma] [int] NOT NULL,
	[IdUniversidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Iso2] [nvarchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parentesco]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parentesco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoParentesco] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilUsuario](
	[Id] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Direccion] [nvarchar](500) NULL,
	[Telefono] [nvarchar](15) NULL,
	[IdCiudad] [int] NULL,
	[IdColegio] [int] NULL,
	[IdGenero] [int] NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAcreditacion]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAcreditacion](
	[Id] [int] NOT NULL,
	[TipoAcreditacion] [nvarchar](100) NOT NULL,
	[EsInternacional] [bit] NOT NULL,
 CONSTRAINT [PK_TipoAcreditacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAcreditacionXColegio]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAcreditacionXColegio](
	[IdAcreditacion] [int] NOT NULL,
	[IdColegio] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoActividad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoActividad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoActividad] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TipoActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoActividadXUniversidad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoActividadXUniversidad](
	[IdTipoActividad] [int] NOT NULL,
	[IdUniversidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAplicacion]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAplicacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoAplicacion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TipoAplicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPrograma]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPrograma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoPrograma] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TipoPrograma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProgramaXUniversidad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProgramaXUniversidad](
	[IdTipoPrograma] [int] NOT NULL,
	[IdUniversidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universidad]    Script Date: 26/10/2023 11:29:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Ranking] [nvarchar](50) NULL,
	[Url] [nvarchar](max) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[IdPais] [int] NULL,
	[IdTipoAplicacion] [int] NULL,
	[EsPrivada] [bit] NOT NULL,
	[IdAgencia] [int] NULL,
 CONSTRAINT [PK__Universi__3214EC0780722E96] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_Ciudad] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_Ciudad]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_Universidad]
GO
ALTER TABLE [dbo].[CaracteristicasXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_CaracteristicasXUniversidad_Geografia] FOREIGN KEY([IdCaracteristica])
REFERENCES [dbo].[Geografia] ([Id])
GO
ALTER TABLE [dbo].[CaracteristicasXUniversidad] CHECK CONSTRAINT [FK_CaracteristicasXUniversidad_Geografia]
GO
ALTER TABLE [dbo].[CaracteristicasXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_CaracteristicasXUniversidad_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[CaracteristicasXUniversidad] CHECK CONSTRAINT [FK_CaracteristicasXUniversidad_Universidad]
GO
ALTER TABLE [dbo].[CarreraRelacionada]  WITH CHECK ADD FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([Id])
GO
ALTER TABLE [dbo].[CarreraXUniverdad]  WITH CHECK ADD  CONSTRAINT [FK_CarreraXUniverdad_Carrera] FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([Id])
GO
ALTER TABLE [dbo].[CarreraXUniverdad] CHECK CONSTRAINT [FK_CarreraXUniverdad_Carrera]
GO
ALTER TABLE [dbo].[CarreraXUniverdad]  WITH CHECK ADD  CONSTRAINT [FK_CarreraXUniverdad_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[CarreraXUniverdad] CHECK CONSTRAINT [FK_CarreraXUniverdad_Universidad]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK__Ciudad__IdDepart__2A4B4B5E] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([Id])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK__Ciudad__IdDepart__2A4B4B5E]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Demografia] FOREIGN KEY([IdDemografia])
REFERENCES [dbo].[Demografia] ([Id])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [FK_Ciudad_Demografia]
GO
ALTER TABLE [dbo].[Colegio]  WITH CHECK ADD  CONSTRAINT [FK__Colegio__IdCiuda__32E0915F] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[Colegio] CHECK CONSTRAINT [FK__Colegio__IdCiuda__32E0915F]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Parentesco] FOREIGN KEY([IdParentesco])
REFERENCES [dbo].[Parentesco] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Parentesco]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_PerfilUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[PerfilUsuario] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_PerfilUsuario]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_PerfilUsuario1] FOREIGN KEY([IdUsuarioContacto])
REFERENCES [dbo].[PerfilUsuario] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_PerfilUsuario1]
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[IdiomaXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaXUniversidad_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([Id])
GO
ALTER TABLE [dbo].[IdiomaXUniversidad] CHECK CONSTRAINT [FK_IdiomaXUniversidad_Idioma]
GO
ALTER TABLE [dbo].[IdiomaXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaXUniversidad_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[IdiomaXUniversidad] CHECK CONSTRAINT [FK_IdiomaXUniversidad_Universidad]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Ciudad] FOREIGN KEY([IdCiudad])
REFERENCES [dbo].[Ciudad] ([Id])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Ciudad]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Colegio] FOREIGN KEY([IdColegio])
REFERENCES [dbo].[Colegio] ([Id])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Colegio]
GO
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Genero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([Id])
GO
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Genero]
GO
ALTER TABLE [dbo].[TipoAcreditacionXColegio]  WITH CHECK ADD  CONSTRAINT [FK_TipoAcreditacionXColegio_Colegio] FOREIGN KEY([IdColegio])
REFERENCES [dbo].[Colegio] ([Id])
GO
ALTER TABLE [dbo].[TipoAcreditacionXColegio] CHECK CONSTRAINT [FK_TipoAcreditacionXColegio_Colegio]
GO
ALTER TABLE [dbo].[TipoAcreditacionXColegio]  WITH CHECK ADD  CONSTRAINT [FK_TipoAcreditacionXColegio_TipoAcreditacion] FOREIGN KEY([IdAcreditacion])
REFERENCES [dbo].[TipoAcreditacion] ([Id])
GO
ALTER TABLE [dbo].[TipoAcreditacionXColegio] CHECK CONSTRAINT [FK_TipoAcreditacionXColegio_TipoAcreditacion]
GO
ALTER TABLE [dbo].[TipoActividadXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_TipoActividadXUniversidad_TipoActividad] FOREIGN KEY([IdTipoActividad])
REFERENCES [dbo].[TipoActividad] ([Id])
GO
ALTER TABLE [dbo].[TipoActividadXUniversidad] CHECK CONSTRAINT [FK_TipoActividadXUniversidad_TipoActividad]
GO
ALTER TABLE [dbo].[TipoActividadXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_TipoActividadXUniversidad_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[TipoActividadXUniversidad] CHECK CONSTRAINT [FK_TipoActividadXUniversidad_Universidad]
GO
ALTER TABLE [dbo].[TipoProgramaXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_TipoProgramaXUniversidad_TipoPrograma] FOREIGN KEY([IdTipoPrograma])
REFERENCES [dbo].[TipoPrograma] ([Id])
GO
ALTER TABLE [dbo].[TipoProgramaXUniversidad] CHECK CONSTRAINT [FK_TipoProgramaXUniversidad_TipoPrograma]
GO
ALTER TABLE [dbo].[TipoProgramaXUniversidad]  WITH CHECK ADD  CONSTRAINT [FK_TipoProgramaXUniversidad_Universidad] FOREIGN KEY([IdUniversidad])
REFERENCES [dbo].[Universidad] ([Id])
GO
ALTER TABLE [dbo].[TipoProgramaXUniversidad] CHECK CONSTRAINT [FK_TipoProgramaXUniversidad_Universidad]
GO
ALTER TABLE [dbo].[Universidad]  WITH CHECK ADD  CONSTRAINT [FK__Universid__IdPai__35BCFE0A] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[Universidad] CHECK CONSTRAINT [FK__Universid__IdPai__35BCFE0A]
GO
ALTER TABLE [dbo].[Universidad]  WITH CHECK ADD  CONSTRAINT [FK_Universidad_Agencia] FOREIGN KEY([IdAgencia])
REFERENCES [dbo].[Agencia] ([Id])
GO
ALTER TABLE [dbo].[Universidad] CHECK CONSTRAINT [FK_Universidad_Agencia]
GO
ALTER TABLE [dbo].[Universidad]  WITH CHECK ADD  CONSTRAINT [FK_Universidad_TipoAplicacion] FOREIGN KEY([IdTipoAplicacion])
REFERENCES [dbo].[TipoAplicacion] ([Id])
GO
ALTER TABLE [dbo].[Universidad] CHECK CONSTRAINT [FK_Universidad_TipoAplicacion]
GO
USE [master]
GO
ALTER DATABASE [dbPromApp] SET  READ_WRITE 
GO

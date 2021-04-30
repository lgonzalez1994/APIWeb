CREATE DATABASE [webapi];				
GO

USE [webapi];				
GO			
CREATE TABLE [webapi].[dbo].[usuarios] (				
    [id]        INT  NOT NULL,				
    [nombre]    VARCHAR (30) NOT NULL,				
    [apellido]  VARCHAR (30) NOT NULL,				
    [email]     VARCHAR (30) NOT NULL,				
	[password]     VARCHAR (250) NOT NULL,			
    PRIMARY KEY  (id ASC)				
);					
GO

INSERT INTO [dbo].[usuarios]
           ([id]
           ,[nombre]
           ,[apellido]
           ,[email]
           ,[password]) VALUES
(1, 'Luis','Gonzalez','lfg_1994@gmail.com.ar', 'ae2b1fca515949e5d54fb22b8ed95575'),				
(2, 'Pedro','Perez','pedro.perez@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(3, 'Juan','Lozano','juan.lozano@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(4, 'Marcelo','Tinelli','marcelo.tinelli@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(5, 'Lionel','Messi','lionel.messi@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(6, 'Andres','Iniesta','andres.iniesta@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(7, 'Roman','Riquelme','juan.riquelme@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(8, 'Mariano','Iudica','mariano.iudica@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(9, 'Federico','Bueno','federico.bueno@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575'),		
(10, 'Cristian','Perez','cristian.perez@gmail.com', 'ae2b1fca515949e5d54fb22b8ed95575');		

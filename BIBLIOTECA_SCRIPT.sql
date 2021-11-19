
CREATE DATABASE Biblioteca;
CREATE TABLE TipoIdentificacion(
	IdTipoIdentificacion INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NombreTipoIdentificacion VARCHAR(50) NOT NULL
 );
 
CREATE TABLE Usuario(
	idUsuario INT IDENTITY(1,1) NOT NULL,
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	NumeroIdentificacion VARCHAR(20) UNIQUE NOT NULL,
	CorreoElectronico VARCHAR(50) UNIQUE NOT NULL,
	FechaNacimiento DATE NOT NULL,
	Direccion VARCHAR(70) NOT NULL,
	Telefono VARCHAR(11) NOT NULL,
	PaisOrigen VARCHAR(50) NOT NULL,
	IdTipoIdentificacion INT NOT NULL,
	PRIMARY KEY(idUsuario),
	CONSTRAINT FK_TipoIdentificacionUsuario FOREIGN KEY(IdTipoIdentificacion) REFERENCES TipoIdentificacion(IdTipoIdentificacion),
);

CREATE TABLE Autor(
	IdAutor INT IDENTITY(1,1) NOT NULL,
	NombreAutor VARCHAR(50) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	PaisOrigen VARCHAR(50) NOT NULL,
	PRIMARY KEY(IdAutor)
);

CREATE TABLE Editorial(
	IdEditorial INT IDENTITY(1,1) NOT NULL,
	NombreEditorial VARCHAR(50) NOT NULL,
	PRIMARY KEY(IdEditorial)
);
CREATE TABLE Libro(
	IdLibro INT IDENTITY(1,1) NOT NULL,
	NombreLibro VARCHAR(50) NOT NULL,
	FechaLanzamiento DATE NOT NULL,
	CantidadPaginas VARCHAR(5) NOT NULL,
	Disponible BIT NOT NULL,
	IdEditorial INT NOT NULL,
	IdAutor INT NOT NULL,
	PRIMARY KEY(IdLibro),
	CONSTRAINT FK_EditorialLibro FOREIGN KEY(IdEditorial) REFERENCES Editorial(IdEditorial),
	CONSTRAINT FK_AutorLibro FOREIGN KEY(IdAutor) REFERENCES Autor(IdAutor)
);

CREATE TABLE PrestamoLibro(
	IdPrestamoLibro INT IDENTITY(1,1),
	FechaPrestamo DATE NOT NULL,
	FueDvuelto BIT NOT NULL,
	ObservacionEntrega VARCHAR(50),
	ObservacionPrestamo VARCHAR(50),
	IdLibro INT NOT NULL,
	IdUsuario INT NOT NULL,
	PRIMARY KEY(IdPrestamoLibro),
	CONSTRAINT FK_UsuarioPrestamoLibro FOREIGN KEY(IdUsuario) REFERENCES Usuario(IdUsuario),
	CONSTRAINT FK_LibroPrestamoLibro FOREIGN KEY(IdLibro) REFERENCES Libro(IdLibro)
);
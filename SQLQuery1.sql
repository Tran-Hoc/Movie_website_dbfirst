
drop database Movie_DbFirst

create database Movie_DbFirst

use Movie_DbFirst
go

go
create table Genre (
	Id UNIQUEIDENTIFIER NOT NULL Primary key,
	Name nvarchar(500)
)
create table GenreOfMovie(
	Id int NOT NULL Identity(1,1) Primary key,
	MovieId UNIQUEIDENTIFIER not null,
	GenreId UNIQUEIDENTIFIER not null
)
create table Episode(
	Id UNIQUEIDENTIFIER  NOT NULL Primary key,
	NameEp nvarchar(max),
)
go

create table EpisodeOf(
	Id int NOT NULL Identity(1,1) Primary key,
	MovieId UNIQUEIDENTIFIER  not null,
	EpisodeId UNIQUEIDENTIFIER  not null,
	Num_ep int 
)
go

create table AccUser(
	Id UNIQUEIDENTIFIER NOT NULL Primary key,
	UserName nvarchar(100),
	Password nvarchar(max),
	Name nvarchar(max),
	DateOfBirht DateTime,
	Gender tinyint
)

go 
create table Rate(
	Id int NOT NULL Identity(1,1) Primary key,
	Num_rate tinyint,
	verbal_rate nvarchar(max),
	MovieId UNIQUEIDENTIFIER  not null,
	UserId UNIQUEIDENTIFIER  not null
	)
go
create table Producer(
	Id UNIQUEIDENTIFIER  NOT NULL Primary key,	
	Name nvarchar(max),
)

create table Director(
	Id UNIQUEIDENTIFIER  NOT NULL primary key,	
	Name nvarchar(max),
	DateOfBirht DateTime,
	Gender tinyint
)
go
create table Actor(
	Id UNIQUEIDENTIFIER  NOT NULL Primary key,	
	Name nvarchar(max),
	DateOfBirht DateTime,
	Gender tinyint
)
go

create table Acted(
	Id int NOT NULL Identity(1,1) Primary key,	
	Roles tinyint,
	MovieId UNIQUEIDENTIFIER not null,
	ActorId UNIQUEIDENTIFIER not null
)
go

create table Directed(
	Id int NOT NULL Identity(1,1) Primary key,	
	MovieId UNIQUEIDENTIFIER not null,
	DirectorId UNIQUEIDENTIFIER not null
)
go

create table Produced(
	Id int NOT NULL Identity(1,1) Primary key,	
	MovieId UNIQUEIDENTIFIER not null,
	ProducerId UNIQUEIDENTIFIER not null
)
go
Create table Movie(
	Id UNIQUEIDENTIFIER NOT NULL Primary key,	
	NameMovie nvarchar(max),
	ReleaseDate DateTime,
	Title nvarchar(max),
	Avg_rating float,
	Img_path nvarchar(max),
	Movie_path nvarchar(max)
)
go
create table Monthly_revenue(
	Id int NOT NULL Identity(1,1) Primary key,	
	income money,
	arg_rating float,
	Time_year_month DateTime,
	MovieId UNIQUEIDENTIFIER not null
)
go

create table Statistical(
	Id int NOT NULL Identity(1,1) Primary key,	
	UserId UNIQUEIDENTIFIER,
	MovieId UNIQUEIDENTIFIER,
	TimeVisit Datetime,
	TimeView float,

)

go

alter table Acted
Add constraint FK_Acted_Movie foreign key (MovieId)
references Movie (Id)
go

alter table Acted
Add constraint FK_Acted_Actor foreign key (ActorId)
references Actor(Id)
go


alter table Directed
Add constraint FK_Directed_Movie foreign key (MovieId)
references Movie (Id)
go

alter table Directed
Add constraint FK_Directed_Director foreign key (DirectorId)
references Director(Id)
go

alter table Produced
Add constraint FK_Produced_Movie foreign key (MovieId)
references Movie (Id)
go

alter table Produced
Add constraint FK_Produced_Producer foreign key (ProducerId)
references Producer(Id)
go

alter table GenreOfMovie
add constraint Fk_GenreOf_Movie foreign key (MovieId)
references Movie(Id)
go

alter table GenreOfMovie
add constraint Fk_GenreOf_Genre foreign key (GenreId)
references Genre(Id)
go

alter table EpisodeOf
add constraint Fk_EpisodeOf_Movie foreign key(MovieId)
references Movie(Id)
go

alter table EpisodeOf
add constraint Fk_EpisodeOf_Episode foreign key(EpisodeId)
references Episode(Id)
go

alter table Rate
add constraint Fk_Rate_AccUser foreign key(UserId)
references AccUser(Id)
go

alter table Rate
add constraint Fk_Rate_Movieforeign foreign key(MovieId)
references Movie(Id)
go

alter table Monthly_revenue
add constraint Fk_Monreve_Movie foreign key(MovieId)
references Movie(Id)
go

alter table Statistical
add constraint Fk_Statistical_Movie foreign key(MovieId)
references Movie(id)
go

alter table Statistical
add constraint Fk_Statistical_User foreign key(UserId)
references AccUser(Id)

Select id, Name from genre


Select Id, NameEp from Episode

insert into Episode values ('Phim 1');
insert into Episode values ('Phim 2');
insert into Episode values ('Phim 3');
insert into Episode values ('Phim 4');


drop database Movie_DbFirst

create database Movie_DbFirst

use Movie_DbFirst
go

go
create table Genre (
	Id int NOT NULL Identity(1,1) Primary key,
	Name nvarchar(500)
)
create table GenreOfMovie(
	Id int NOT NULL Identity(1,1) Primary key,
	MovieId int not null,
	GenreId int not null
)
create table Episode(
	Id int NOT NULL Identity(1,1) Primary key,
	NameEp nvarchar(max),
)
go
create table EpisodeOf(
	Id int NOT NULL Identity(1,1) Primary key,
	MovieId int not null,
	EpisodeId int not null
)
go

create table AccUser(
	Id int NOT NULL Identity(1,1) Primary key,
	UserName nvarchar(100),
	Password nvarchar(max),
	PersonId int not null
)

go 
create table Rate(
	Id int NOT NULL Identity(1,1) Primary key,
	Num_rate tinyint,
	verbal_rate nvarchar(max),
	MovieId int not null,
	UserId int not null
	)
go
create table Producer(
	Id int NOT NULL Identity(1,1) Primary key,	
	PersonId int not null,

)
go
create table Director(
	Id int NOT NULL Identity(1,1) Primary key,	
	PersonId int not null
)
go
create table Actor(
	Id int NOT NULL Identity(1,1) Primary key,	
	PersonId int not null
)
go
create table Person(
	Id int NOT NULL Identity(1,1) Primary key,	
	Name nvarchar(max),
	DateOfBirht DateTime,
	Gender tinyint
)
go

create table Acted(
	Id int NOT NULL Identity(1,1) Primary key,	
	Roles tinyint,
	MovieId int not null,
	ActorId int not null
)
go

create table Directed(
	Id int NOT NULL Identity(1,1) Primary key,	
	MovieId int not null,
	DirectorId int not null
)
go

create table Produced(
	Id int NOT NULL Identity(1,1) Primary key,	
	MovieId int not null,
	ProducerId int not null
)
go
create table Monthly_revenue(
	Id int NOT NULL Identity(1,1) Primary key,	
	income money,
	arg_rating float,
	Time_year_month DateTime,
	MovieId int not null
)
go

Create table Movie(
	Id int NOT NULL Identity(1,1) Primary key,	
	NameMovie nvarchar(max),
	ReleaseDate DateTime,
	Title nvarchar(max),
	Avg_rating float,

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

alter table AccUser
add constraint Fk_AccUser_Person foreign key(PersonId)
references Person(Id)
go

alter table Producer
add constraint Fk_Producer_Person foreign key(PersonId)
references Person(Id)
go

alter table Director
add constraint Fk_Director_Person foreign key(PersonId)
references Person(Id)
go

alter table Actor
add constraint Fk_Actor_Person foreign key(PersonId)
references Person(Id)
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

alter table Movie
add Img_path nvarchar(max)
go

alter table Movie
add Movie_path nvarchar(max)
go

alter table EpisodeOf
add Num_ep int 
go

Select Name from genre

Select p.Name from actor a, Person p where a.PersonId = p.Id

Select p.Name from Director d, Person p where d.PersonId = p.Id

Select p.Name from Producer pr, Person p where pr.PersonId = p.Id

Select p.Name from AccUser a, Person p where a.PersonId = p.Id





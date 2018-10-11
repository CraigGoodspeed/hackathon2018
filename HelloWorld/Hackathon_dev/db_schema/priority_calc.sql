create table priority_calculation(
	ID uniqueidentifier primary key default newid(),
	project_id uniqueidentifier not null,
	priority_id uniqueidentifier not null
);


create table priority_definition(
	id uniqueidentifier primary key default newid(),
	description varchar(500) not null,
	priority_score int not null
);



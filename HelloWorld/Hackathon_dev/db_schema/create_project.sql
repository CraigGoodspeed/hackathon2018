create table project(
ID uniqueidentifier primary key default newid(),
[name] varchar(100) not null,
description varchar(max),
date_created datetime not null default getdate(),
category_id uniqueidentifier null,
funding_id uniqueidentifier,
status_id uniqueidentifier,
status_updated datetime 
);

create table category(
	ID uniqueidentifier primary key default newid(),
	description varchar(100) not null,
	priority_calc int not null
);

create table funding(
	ID uniqueidentifier primary key default newid(),
	parent_id uniqueidentifier null,
	amount decimal(18,2),
	description varchar(max)
);

create table status(
	ID uniqueidentifier primary key default newid(),
	description varchar(max) not null
);


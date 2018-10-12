create table contractor_specialisation(
	id uniqueidentifier primary key default newid(),
	category_id uniqueidentifier not null,
	contractor_id uniqueidentifier not null
);
insert into contractor_specialisation (category_id, contractor_id) values('445A0C46-9DEE-4807-9C26-24E0A75AB023','4C1016C1-83AD-42B4-AEED-297DD6ADB76E');
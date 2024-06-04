-- migrate:up
alter table "user"
	add column login varchar(50) not null;

alter table "user"
	add column password varchar(300) not null;

comment on column "user".login is 'Логин пользователя';
comment on column "user".password is 'Пароль пользователя';

-- migrate:down
alter table "user"
	drop column login;

alter table "user"
	drop column password;
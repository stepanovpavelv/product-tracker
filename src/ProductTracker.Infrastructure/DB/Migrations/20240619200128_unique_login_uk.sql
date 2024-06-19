-- migrate:up
alter table "user"
	add constraint unique_login_user_uq unique (login);

-- migrate:down
alter table "user"
	drop constraint unique_login_user_uq;
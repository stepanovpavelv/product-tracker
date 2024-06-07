-- migrate:up
create table user_xref_refresh_token (
	id bigint generated by default as identity
		constraint user_xref_refresh_token_id_pkey primary key,

	user_id bigint not null
		constraint user_refresh_id_fkey
		references "user"(id)
		on delete cascade,

	refresh_token varchar(50) null
);

comment on table user_xref_refresh_token IS 'Хранилище refresh-токенов пользователей';
comment on column user_xref_refresh_token.id IS 'Уникальный идентификатор записи';
comment on column user_xref_refresh_token.user_id IS 'Идентификатор пользователя';
comment on column user_xref_refresh_token.refresh_token IS 'Refresh-токен пользователя';


-- migrate:down
drop table user_xref_refresh_token;
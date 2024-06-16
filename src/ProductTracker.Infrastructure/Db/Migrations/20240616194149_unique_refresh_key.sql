-- migrate:up
alter table user_xref_refresh_token
	add constraint unique_refresh_key_uq unique (user_id);

-- migrate:down
alter table user_xref_refresh_token
	drop constraint unique_refresh_key_uq;
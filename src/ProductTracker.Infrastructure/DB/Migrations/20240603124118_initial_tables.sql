-- migrate:up

create table "user" (
	id bigint generated by default as identity
		constraint user_id_pkey primary key,

	first_name varchar(75) not null,
	last_name varchar(75) not null,
	birth_day timestamp not null
);

create table goods (
	id bigint generated by default as identity
		constraint goods_id_pkey primary key,

	name varchar(200) not null,
	description text null
);

create table house (
	id bigint generated by default as identity
		constraint house_id_pkey primary key,

	short_name varchar(100) not null,
	full_address text null
);

create table house_xref_user (
	id bigint generated by default as identity
		constraint house_xref_user_id_pkey primary key,

	house_id bigint not null
		constraint house_xref_id_fkey
		references house(id),
	user_id bigint not null
		constraint user_id_fkey
		references "user"(id)
		on delete cascade
);

create table purchase (
	id bigint generated by default as identity
		constraint purchase_id_pkey primary key,

	bought_date timestamp not null,
	house_id bigint not null
		constraint house_purchase_id_fkey
		references house(id)
		on delete cascade
);

create table purchase_xref_goods (
	id bigint generated by default as identity
		constraint purchase_xref_goods_id_pkey primary key,

	purchase_id bigint not null
		constraint purchase_id_fkey
		references purchase(id)
		on delete cascade,
	goods_id bigint not null
		constraint goods_id_fkey
		references goods(id),
	expire_date timestamp not null
);

create table recycle (
	id bigint generated by default as identity
		constraint recycle_id_pkey primary key,

	purchase_xref_goods_id bigint not null,
	util_date timestamp not null
);

alter table recycle
	add constraint purchase_xref_goods_id_fkey 
	foreign key (purchase_xref_goods_id) references purchase_xref_goods(id)
	on delete cascade;

comment on table "user" is 'Пользователь';
comment on column "user".id is 'Уникальный идентификатор';
comment on column "user".first_name is 'Имя';
comment on column "user".last_name is 'Фамилия';
comment on column "user".birth_day is 'Дата рождения';

comment on table goods is 'Продукт';
comment on column goods.id is 'Уникальный идентификатор';
comment on column goods.name is 'Название';
comment on column goods.description is 'Краткое описание';

comment on table house is 'Дом (локация)';
comment on column house.id is 'Уникальный идентификатор';
comment on column house.short_name is 'Краткое описание локации';
comment on column house.full_address is 'Полный адрес';

comment on table house_xref_user is 'Жильцы в доме (в локации)';
comment on column house_xref_user.id is 'Уникальный идентификатор';
comment on column house_xref_user.house_id is 'Идентификатор дома';
comment on column house_xref_user.user_id is 'Идентификатор пользователя';

comment on table purchase is 'Информация о покупке в магазине';
comment on column purchase.id is 'Уникальный идентификатор';
comment on column purchase.bought_date is 'Дата покупки';
comment on column purchase.house_id is 'Идентификатор дома, для которого совершена покупка';

comment on table purchase_xref_goods is 'Детализация покупки';
comment on column purchase_xref_goods.id is 'Уникальный идентификатор';
comment on column purchase_xref_goods.purchase_id is 'Идентификатор покупки';
comment on column purchase_xref_goods.goods_id is 'Идентификатор товара';
comment on column purchase_xref_goods.expire_date is 'Срок годности';

comment on table recycle is 'Утилизация';
comment on column recycle.id is 'Уникальный идентификатор';
comment on column recycle.purchase_xref_goods_id is 'Ссылка на продукт из покупки';
comment on column recycle.util_date is 'Дата утилизации / употребления';

alter table "user" owner to postgres;
alter table goods owner to postgres;
alter table house owner to postgres;
alter table house_xref_user owner to postgres;
alter table purchase owner to postgres;
alter table purchase_xref_goods owner to postgres;
alter table recycle owner to postgres;

-- migrate:down
drop table recycle;
drop table purchase;
drop table "user";
drop table house;
drop table goods;
USE master
GO
--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END
CREATE DATABASE final_capstone
GO
USE final_capstone
GO
--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)

)
CREATE TABLE party (
	party_id int IDENTITY(1,1) NOT NULL,
	location varchar(50) NOT NULL,
	date timestamp NOT NULL,
	owner int NOT NULL,
	description varchar(50),
	name_of_party varchar(50) NOT NULL,
	PRIMARY KEY (party_id),
	FOREIGN KEY (owner) REFERENCES users (user_id)
)
CREATE TABLE restaurant (
	restaurant_id int IDENTITY (1,1) NOT NULL,
	party_id int NOT NULL,
	name varchar(50) NOT NULL,
	Api_address varchar(200) NOT NULL,
	PRIMARY KEY (restaurant_id),
	FOREIGN KEY (party_id) REFERENCES party (party_id)
)
CREATE TABLE guest (
	guest_id int IDENTITY (1,1) NOT NULL,
	name varchar(50) NOT NULL,
	party_id int NOT NULL,
	PRIMARY KEY (guest_id),
	FOREIGN KEY (party_id) REFERENCES party (party_id)
)
CREATE TABLE liked_disliked (
	liked_disliked_id int IDENTITY (1,1) NOT NULL,
	guest_id int NOT NULL,
	restaurant_id int NOT NULL,
	like_or_dislike varchar(10) NOT NULL,
	PRIMARY KEY (liked_disliked_id),
	FOREIGN KEY (restaurant_id) REFERENCES restaurant (restaurant_id),
	FOREIGN KEY (guest_id) REFERENCES guest(guest_id)
)


--TODOs:
--> link party w/ user table
--> party w/ guests
--> party w/ restaurant
--> guest w/ like_dislike
--> restaurant w/ like_dislike
--populate default data

--CREATE UNIQUE INDEX users ON users(username)

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Peri','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Alex','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Kevin','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nick','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Colin','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--INSERT INTO party (location, date, owner, description, name_of_party) VALUES ('1234 Party Drive','2022-12-25th 19:00:00', ,'user');
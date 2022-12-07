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
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE party (
	party_id int IDENTITY(1,1) NOT NULL,
	location varchar(50) NOT NULL,
	date int NOT NULL,
	owner varchar(50) NOT NULL,
	description varchar(50),
	name_of_party varchar(50) NOT NULL
)

CREATE TABLE restaurant (
	restaurant_id int IDENTITY (1,1) NOT NULL,
	party_id int IDENTITY (1,1) NOT NULL,
	name varchar(50) NOT NULL,
	Api_address varchar(200) NOT NULL,
	CONSTRAINT fk_

)

CREATE TABLE guest (
	guest_id int IDENTITY (1,1) NOT NULL,
	name varchar(50) NOT NULL,
	party_id int IDENTITY (1,1) NOT NULL,
)

CREATE TABLE liked_disliked (
	like_disliked_id int IDENTITY (1,1) NOT NULL,
	guest_id int IDENTITY (1,1) NOT NULL,
	restaurant_id int IDENTITY (1,1) NOT NULL,
	like_or_dislike varchar(10) NOT NULL
)

--TODOs: 
--> link party w/ user table 
--> party w/ guests
--> party w/ restaurant
--> guest w/ like_dislike
--> restaurant w/ like_dislike


--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO
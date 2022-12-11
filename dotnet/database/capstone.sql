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
	location varchar(512) NOT NULL,
	--date timestamp NOT NULL,
	date datetime,
	owner int NOT NULL,
	description varchar(512),
	name_of_party varchar(64) NOT NULL,
	invite_link varchar(100),
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
--create default users for testing
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Peri','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Alex','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Kevin','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nick','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Colin','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Create 10 default parties for testing, invite link is https://localhost:44315/tinder/ + party_id and all parties are different dates, locations, and descriptions and names, but all have the owner 1.
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Tech Elevator 7100 Euclid Ave, Cleveland, OH 44103', '2022-12-12 12:00:00', 1, 'Tech Elevator Graduation Party', 'Tech Elevator Graduation Party', 'https://localhost:44315/tinder/1');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Chuck E Cheese, 7601 W Ridgewood Dr, Parma, OH 44129', '2024-12-12 12:00:00', 1, 'Kevin`s Pizza party', 'Kevin`s Pizza party', 'https://localhost:44315/tinder/2');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Museum of Art, 11150 East Blvd, Cleveland, OH 44106', '2022-12-12 12:00:00', 1, 'Alex`s Art Adventure', 'Alex`s Art Adventure', 'https://localhost:44315/tinder/3');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Museum of Natural History, 1 Wade Oval Dr, Cleveland, OH 44106', '2023-12-12 12:00:00', 1, 'Nick`s Natural History Trip', 'Nick`s Natural History Trip', 'https://localhost:44315/tinder/4');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Metroparks Zoo, 3900 Wildlife Way, Cleveland, OH 44109', '2025-12-12 12:00:00', 1, 'Colin`s Zoo Bug out', 'Colin`s Zoo Bug out', 'https://localhost:44315/tinder/5');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Botanical Garden, 11030 East Blvd, Cleveland, OH 44106', '2022-12-17 12:00:00', 1, 'Peri`s Botanical Garden date', 'Peri`s Botanical Garden date', 'https://localhost:44315/tinder/6');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Kalahari Resorts & Conventions, 7000 Kalahari Dr, Sandusky, OH 44870', '2023-01-13 12:00:00', 1, 'CodeMash 2023', 'Codemash 2023', 'https://localhost:44315/tinder/7');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Browns Stadium, 100 Alfred Lerner Way, Cleveland, OH 44114', '2022-12-18 12:00:00', 1, 'Cleveland Browns Game', 'Cleveland Browns Game', 'https://localhost:44315/tinder/8');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Indians Stadium, 2401 Ontario St, Cleveland, OH 44115', '2022-12-12 12:00:00', 1, 'Cleveland Indians Game', 'Cleveland Indians Game', 'https://localhost:44315/tinder/9');
INSERT INTO party (location, date, owner, description, name_of_party, invite_link) VALUES ('Cleveland Cavaliers Stadium, 1 Center Ct, Cleveland, OH 44115', '2022-12-12 12:00:00', 1, 'Cleveland Cavaliers Game', 'Cleveland Cavaliers Game', 'https://localhost:44315/tinder/10');


--Create 10 default restaurants for testing, all restaurants are different names and addresses, but all have the party_id 1.
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Tech Elevator', 'yelp.com/biz/tech-elevator-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Chuck E Cheese', 'yelp.com/biz/chuck-e-cheese-parma');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Museum of Art', 'yelp.com/biz/cleveland-museum-of-art-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Museum of Natural History', 'yelp.com/biz/cleveland-museum-of-natural-history-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Metroparks Zoo', 'yelp.com/biz/cleveland-metroparks-zoo-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Botanical Garden', 'yelp.com/biz/cleveland-botanical-garden-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Kalahari Resorts & Conventions', 'yelp.com/biz/kalahari-resorts-and-conventions-sandusky');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Browns Stadium', 'yelp.com/biz/cleveland-browns-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Indians Stadium', 'yelp.com/biz/cleveland-indians-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Cavaliers Stadium', 'yelp.com/biz/cleveland-cavaliers-stadium-cleveland');

--Create 10 default guests for party 1, all guests have different names
INSERT INTO guest (party_id, name) VALUES (1, 'Alex');
INSERT INTO guest (party_id, name) VALUES (1, 'Nick');
INSERT INTO guest (party_id, name) VALUES (1, 'Colin');
INSERT INTO guest (party_id, name) VALUES (1, 'Peri');
INSERT INTO guest (party_id, name) VALUES (1, 'Kevin');
--Create 10 default guests for party 2, all guests have different names
INSERT INTO guest (party_id, name) VALUES (2, 'Alex');
INSERT INTO guest (party_id, name) VALUES (2, 'Nick');
INSERT INTO guest (party_id, name) VALUES (2, 'Colin');
INSERT INTO guest (party_id, name) VALUES (2, 'Peri');
INSERT INTO guest (party_id, name) VALUES (2, 'Kevin');

INSERT INTO guest (party_id, name) VALUES (3, 'Alex');
INSERT INTO guest (party_id, name) VALUES (3, 'Nick');
INSERT INTO guest (party_id, name) VALUES (3, 'Colin');
INSERT INTO guest (party_id, name) VALUES (3, 'Peri');
INSERT INTO guest (party_id, name) VALUES (3, 'Kevin');


INSERT INTO guest (party_id, name) VALUES (4, 'Alex');
INSERT INTO guest (party_id, name) VALUES (4, 'Nick');
INSERT INTO guest (party_id, name) VALUES (4, 'Colin');
INSERT INTO guest (party_id, name) VALUES (4, 'Peri');
INSERT INTO guest (party_id, name) VALUES (4, 'Kevin');


INSERT INTO guest (party_id, name) VALUES (5, 'Alex');
INSERT INTO guest (party_id, name) VALUES (5, 'Nick');
INSERT INTO guest (party_id, name) VALUES (5, 'Colin');
INSERT INTO guest (party_id, name) VALUES (5, 'Peri');
INSERT INTO guest (party_id, name) VALUES (5, 'Kevin');


INSERT INTO guest (party_id, name) VALUES (6, 'Alex');
INSERT INTO guest (party_id, name) VALUES (6, 'Nick');
INSERT INTO guest (party_id, name) VALUES (6, 'Colin');
INSERT INTO guest (party_id, name) VALUES (6, 'Peri');
INSERT INTO guest (party_id, name) VALUES (6, 'Kevin');


INSERT INTO guest (party_id, name) VALUES (7, 'Tori');
INSERT INTO guest (party_id, name) VALUES (7, 'Taylor');
INSERT INTO guest (party_id, name) VALUES (7, 'John');
INSERT INTO guest (party_id, name) VALUES (7, 'Chelsea');
INSERT INTO guest (party_id, name) VALUES (7, 'Brianna');
INSERT INTO guest (party_id, name) VALUES (7, 'Kaitlyn');
INSERT INTO guest (party_id, name) VALUES (7, 'Ben');
INSERT INTO guest (party_id, name) VALUES (7, 'Alex');
INSERT INTO guest (party_id, name) VALUES (7, 'Nick');
INSERT INTO guest (party_id, name) VALUES (7, 'Colin');
INSERT INTO guest (party_id, name) VALUES (7, 'Peri');
INSERT INTO guest (party_id, name) VALUES (7, 'Kevin');

INSERT INTO guest (party_id, name) VALUES (9, 'Alex');
INSERT INTO guest (party_id, name) VALUES (9, 'Nick');
INSERT INTO guest (party_id, name) VALUES (9, 'Colin');
INSERT INTO guest (party_id, name) VALUES (9, 'Peri');
INSERT INTO guest (party_id, name) VALUES (9, 'Kevin');
INSERT INTO guest (party_id, name) VALUES (9, 'Tori');
INSERT INTO guest (party_id, name) VALUES (9, 'David');
INSERT INTO guest (party_id, name) VALUES (9, 'Taylor');
INSERT INTO guest (party_id, name) VALUES (9, 'John');
INSERT INTO guest (party_id, name) VALUES (9, 'Chelsea');
INSERT INTO guest (party_id, name) VALUES (9, 'Brianna');
INSERT INTO guest (party_id, name) VALUES (9, 'Kaitlyn');
INSERT INTO guest (party_id, name) VALUES (9, 'Ben');

--create 10 default restaurants for party 2, all restaurants have different names
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Metroparks Zoo', 'yelp.com/biz/cleveland-metroparks-zoo-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Botanical Garden', 'yelp.com/biz/cleveland-botanical-garden-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Kalahari Resorts & Conventions', 'yelp.com/biz/kalahari-resorts-and-conventions-sandusky');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cedar Point', 'yelp.com/biz/cedar-point-sandusky');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Browns Stadium', 'yelp.com/biz/cleveland-browns-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Indians Stadium', 'yelp.com/biz/cleveland-indians-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Cavaliers Stadium', 'yelp.com/biz/cleveland-cavaliers-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Rock and Roll Hall of Fame', 'yelp.com/biz/rock-and-roll-hall-of-fame-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Great Lakes Science Center', 'yelp.com/biz/great-lakes-science-center-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Museum of Art', 'yelp.com/biz/cleveland-museum-of-art-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Museum of Natural History', 'yelp.com/biz/cleveland-museum-of-natural-history-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Museum of Contemporary Art', 'yelp.com/biz/cleveland-museum-of-contemporary-art-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Tech Elevator', 'yelp.com/biz/tech-elevator-cleveland')
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Cleveland Public Library', 'yelp.com/biz/cleveland-public-library-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Gallouchis', 'yelp.com/biz/gallouchis-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'Melt Bar and Grilled', 'yelp.com/biz/melt-bar-and-grilled-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'The Greenhouse Tavern', 'yelp.com/biz/the-greenhouse-tavern-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'The Plum Bistro', 'yelp.com/biz/the-plum-bistro-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'The Velvet Tango Room', 'yelp.com/biz/the-velvet-tango-room-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'The West Side Market', 'yelp.com/biz/the-west-side-market-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (2, 'The Wine Spot', 'yelp.com/biz/the-wine-spot-cleveland');

INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Metroparks Zoo', 'yelp.com/biz/cleveland-metroparks-zoo-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Botanical Garden', 'yelp.com/biz/cleveland-botanical-garden-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Kalahari Resorts & Conventions', 'yelp.com/biz/kalahari-resorts-and-conventions-sandusky');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cedar Point', 'yelp.com/biz/cedar-point-sandusky');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Browns Stadium', 'yelp.com/biz/cleveland-browns-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Indians Stadium', 'yelp.com/biz/cleveland-indians-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Cavaliers Stadium', 'yelp.com/biz/cleveland-cavaliers-stadium-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Rock and Roll Hall of Fame', 'yelp.com/biz/rock-and-roll-hall-of-fame-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Great Lakes Science Center', 'yelp.com/biz/great-lakes-science-center-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Museum of Art', 'yelp.com/biz/cleveland-museum-of-art-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Museum of Natural History', 'yelp.com/biz/cleveland-museum-of-natural-history-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Museum of Contemporary Art', 'yelp.com/biz/cleveland-museum-of-contemporary-art-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Tech Elevator', 'yelp.com/biz/tech-elevator-cleveland')
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Cleveland Public Library', 'yelp.com/biz/cleveland-public-library-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Gallouchis', 'yelp.com/biz/gallouchis-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'Melt Bar and Grilled', 'yelp.com/biz/melt-bar-and-grilled-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'The Greenhouse Tavern', 'yelp.com/biz/the-greenhouse-tavern-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'The Plum Bistro', 'yelp.com/biz/the-plum-bistro-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'The Velvet Tango Room', 'yelp.com/biz/the-velvet-tango-room-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'The West Side Market', 'yelp.com/biz/the-west-side-market-cleveland');
INSERT INTO restaurant (party_id, name, Api_address) VALUES (1, 'The Wine Spot', 'yelp.com/biz/the-wine-spot-cleveland');



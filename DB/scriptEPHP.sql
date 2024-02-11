DROP DATABASE IF EXISTS phpMYSQL;

CREATE DATABASE phpMYSQL;

USE phpMYSQL;

DROP TABLE IF EXISTS adminlogin ;
CREATE TABLE adminlogin (uid_Admin INT AUTO_INCREMENT NOT NULL,
username_admin VARCHAR(30),
password_admin TEXT,
PRIMARY KEY (uid_Admin));

INSERT INTO adminlogin (uid_Admin, username_admin, password_admin) VALUES ('1', 'liliane', 'bruno');
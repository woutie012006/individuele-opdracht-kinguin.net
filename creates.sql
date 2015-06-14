DROP TABLE website CASCADE CONSTRAINTS;
DROP TABLE advertentie CASCADE CONSTRAINTS;
DROP TABLE lid CASCADE CONSTRAINTS;
DROP TABLE mandje CASCADE CONSTRAINTS;
DROP TABLE inlogpoging CASCADE CONSTRAINTS;
DROP TABLE klant CASCADE CONSTRAINTS;
DROP TABLE verkoper CASCADE CONSTRAINTS;
DROP TABLE game CASCADE CONSTRAINTS;
DROP TABLE verkoopobject CASCADE CONSTRAINTS;
DROP TABLE bestelling CASCADE CONSTRAINTS;
DROP TABLE betaling CASCADE CONSTRAINTS;
DROP TABLE bestelregel CASCADE CONSTRAINTS;
DROP VIEW KLANTEN CASCADE CONSTRAINTS;
DROP VIEW VERKOPERS CASCADE CONSTRAINTS;
DROP VIEW SLECHTVERKOPEND CASCADE CONSTRAINTS;


----------------------------------------------------------------------------create database------------------------------------------------------------------------------------------------------------
-------------------------------------------drop table
CREATE TABLE website
  (
    bedrijfsnaam VARCHAR2(20) NOT NULL,
    adres        VARCHAR2(30) NOT NULL,
    email        VARCHAR2(50) NOT NULL,
    telnr        VARCHAR2(11) NOT NULL,
    url          VARCHAR2(30) NOT NULL,
    PRIMARY KEY(bedrijfsnaam)
  );
CREATE TABLE advertentie
  (
    ID                   NUMBER(10) NOT NULL,
    website_bedrijfsnaam VARCHAR2(30),
    foto                 VARCHAR2(50),
    url                  VARCHAR2(50),
    description          VARCHAR(100),
    PRIMARY KEY(ID),
    FOREIGN KEY(website_bedrijfsnaam) REFERENCES website(bedrijfsnaam)
  );
CREATE TABLE lid
  (
    lidnr          NUMBER(10) NOT NULL,
    naam           VARCHAR2(30) NOT NULL,
    adres          VARCHAR2(50) NOT NULL,
    telefoonnr     VARCHAR2(11) NOT NULL,
    soort          VARCHAR2(9),
    kinguinbalance NUMBER(5,2) ,
    email          varchar2(50) not null,
    PRIMARY KEY(lidnr),
    CONSTRAINT CHECK_KLANT_VERKOPER CHECK (upper(SOORT)= 'VERKOPER'
  OR upper(SOORT)                                      = 'KLANT'),
    CONSTRAINT CHECK_NOT_0 CHECK (KINGUINBALANCE      >=0),
    
    CONSTRAINT CHECK_EMAIL_SYNTHAX CHECK (email like '%@%.%')
  );
CREATE TABLE game
  (
    gamenr NUMBER(10) NOT NULL PRIMARY KEY,
    naam   VARCHAR2(30) NOT NULL,
	beschrijving varchar(300) not null,
    datum   date not null,
    foto   VARCHAR2(50),
	specificatie varchar2(200),
	platform varchar2(50) not null check(upper(platform) in ('PC','XBOX','PS')),
	categorie varchar(20) not null
  );
CREATE TABLE mandje
  (
    game   NUMBER(10) NOT NULL,
    aantal NUMBER(3) NOT NULL,
    lidnr  NUMBER(10) NOT NULL,
    relevant varchar(1)default 'Y' NOT NULL,
    FOREIGN KEY(lidnr) REFERENCES lid(lidnr),
    FOREIGN KEY(game) REFERENCES game(gamenr),
    
    CONSTRAINT CHECK_MANDJE_SYNTHAX CHECK (upper(relevant)= 'Y'
  OR upper(relevant)                                       = 'N')
  );
CREATE TABLE inlogpoging
  (
    inlognr  VARCHAR2(10) NOT NULL,
    lidnr    NUMBER(10) NOT NULL,
    ip       VARCHAR2(15) NOT NULL,
    tijdstip DATE NOT NULL,
    mislukt  VARCHAR2(1) default 'N',
    PRIMARY KEY(inlognr),
    FOREIGN KEY(lidnr) REFERENCES lid(lidnr),
    CONSTRAINT CHECK_MISLUKT_SYNTHAX CHECK (upper(mislukt)= 'Y'
  OR upper(mislukt)                                       = 'N')
  );
CREATE TABLE klant
  (
    nickname VARCHAR2(50),
    lidnr    NUMBER(10) NOT NULL,
    FOREIGN KEY(lidnr) REFERENCES lid(lidnr)
  );
CREATE TABLE verkoper
  (
    verkopernaam VARCHAR2(20),
    bankreking   VARCHAR2(30),
    lidnr        NUMBER(10) NOT NULL,
    FOREIGN KEY(lidnr) REFERENCES lid(lidnr)
  );
CREATE TABLE verkoopobject
  (
    objectnr      NUMBER(10) NOT NULL,
    gamenr        NUMBER(10) NOT NULL,
    prijs         NUMBER(4,2) NOT NULL CHECK(prijs > 0),
    verkoopsdatum DATE,
    code          VARCHAR2(20) NOT NULL,
    PRIMARY KEY(objectnr),
    FOREIGN KEY(gamenr) REFERENCES game(gamenr)
  );
CREATE TABLE bestelling
  (
    bestellingnr NUMBER(10) NOT NULL,
    lidNr        NUMBER(10) NOT NULL,
    PRIMARY KEY(bestellingnr),
    FOREIGN KEY(lidNr) REFERENCES Lid(Lidnr)
  );
CREATE TABLE betaling
  (
    betalingnr     NUMBER(10) NOT NULL,
    bankrekeningnr VARCHAR2(20) NOT NULL,
    bedrag         NUMBER(5) NOT NULL CHECK(bedrag > 0),
    BestellingNr   NUMBER(10) NOT NULL,
    PRIMARY KEY(betalingnr),
    FOREIGN KEY(BestellingNr) REFERENCES Bestelling(BestellingNr)
  );
CREATE TABLE bestelregel
  (
    bestelnr NUMBER(10) NOT NULL,
    objectnr NUMBER(10) NOT NULL,
    FOREIGN KEY(bestelnr) REFERENCES bestelling(bestellingnr),
    FOREIGN KEY(objectnr) REFERENCES verkoopobject(objectnr)
  );
  
   
  
  
  drop table verkoopobject cascade constraints;
  
CREATE TABLE verkoopobject
  (
    objectnr      NUMBER(10) NOT NULL,
    gamenr        NUMBER(10) NOT NULL,
    prijs         NUMBER(4,2) NOT NULL CHECK(prijs > 0),
    verkoopsdatum DATE,
    code          VARCHAR2(20) NOT NULL,
    eigenaar_lidnr number(10) not null,
    PRIMARY KEY(objectnr),
    FOREIGN KEY(gamenr) REFERENCES game(gamenr)
  );
  
  ALTER TABLE LID
  ADD ( password varchar2(45));
  
  ALTER TABLE Game
  ADD ( Beschrijving varchar2(200));
  
  drop table game cascade constraints;
  
  CREATE TABLE game
  (
    gamenr NUMBER(10) NOT NULL,
    naam   VARCHAR2(30) NOT NULL,
    datum   date not null,
    foto   VARCHAR2(50),
    PRIMARY KEY(gamenr)
  );
  
ALTER TABLE advertentie
  MODIFY foto varchar2(255);
  
ALTER TABLE advertentie
  MODIFY url varchar2(255);
  
  drop table mandje cascade constraints;
  
  CREATE TABLE mandje
  (
    verkoopObject   NUMBER(10) NOT NULL,
    lidnr  NUMBER(10) NOT NULL,
    relevant varchar(1)default 'Y' NOT NULL,
    FOREIGN KEY(lidnr) REFERENCES lid(lidnr),
    FOREIGN KEY(verkoopObject) REFERENCES verkoopObject(objectnr),
    
    CONSTRAINT CHECK_MANDJE_SYNTHAX CHECK (upper(relevant)= 'Y'
  OR upper(relevant)                                       = 'N')
  );
  
  drop table lid cascade constraints;
  
  CREATE TABLE lid
  (
    lidnr          NUMBER(10) NOT NULL,
    naam           VARCHAR2(30) NOT NULL,
    adres          VARCHAR2(50) NOT NULL,
    telefoonnr     VARCHAR2(11) NOT NULL,
    soort          VARCHAR2(9),
    kinguinbalance NUMBER(5,2) ,
    email          varchar2(50) not null,
    PRIMARY KEY(lidnr),
    CONSTRAINT CHECK_KLANT_VERKOPER CHECK (upper(SOORT)= 'VERKOPER'
  OR upper(SOORT)                                      = 'KLANT' OR upper(soort) = 'ADMIN'),
    CONSTRAINT CHECK_NOT_0 CHECK (KINGUINBALANCE      >=0),
    
    CONSTRAINT CHECK_EMAIL_SYNTHAX CHECK (email like '%@%.%')
  );
  
  drop sequence SEQ_GAME;

  CREATE  SEQUENCE SEQ_GAME
  MINVALUE 10
  MAXVALUE 99999999999
  START WITH 10
  INCREMENT BY 1;
    
	
  drop SEQUENCE SEQ_Klant;

  CREATE  SEQUENCE SEQ_KLANT
  MINVALUE 10
  MAXVALUE 99999999999
  START WITH 10
  INCREMENT BY 1;
  
    
  
  drop SEQUENCE SEQ_LID;

  CREATE  SEQUENCE SEQ_LID
  MINVALUE 10
  MAXVALUE 99999999999
  START WITH 10
  INCREMENT BY 1;
  
  
  drop sequence "KINGUIN"."SEQ_VerkoopObject"

  CREATE SEQUENCE SEQ_VERKOOPOBJECT INCREMENT BY 1 START WITH 10 MINVALUE 10;

  
  
INSERT INTO LID (LIDNR, NAAM, ADRES, TELEFOONNR, SOORT, KINGUINBALANCE, EMAIL, PASSWORD) VALUES ('9', 'Admin', 'adminroad 12', '0000000', 'ADMIN', '0', 'admin@kinguin.net', 'Password123')
INSERT INTO KLANT (NICKNAME, LIDNR) VALUES ('Admin', '9')

  
  
  
  
  
  
  
  
  

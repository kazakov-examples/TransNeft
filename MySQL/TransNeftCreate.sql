drop database if exists Points;
create database Points;
USE Points;

CREATE table Counters (
	NAME CHAR(20) PRIMARY KEY 
);

CREATE table TransCurr (
	NAME CHAR(20) PRIMARY KEY
);

CREATE table TransVolt (
	NAME CHAR(20) PRIMARY KEY	
);

CREATE table Points (
	ID   INT PRIMARY KEY,
        
	COUNTER CHAR(20),
    COUNTER_DATE DATE,
    
    TRANSCURR CHAR(20),
    TRANSVOLT CHAR(20),
    
    FOREIGN KEY (COUNTER) REFERENCES Counters(NAME),
    FOREIGN KEY (TRANSCURR) REFERENCES TransCurr(NAME),
	FOREIGN KEY (TRANSVOLT) REFERENCES TransVolt(NAME)
);

insert into Counters (NAME) values ('HOT'), ('COLD');
insert into TransCurr (NAME) values ('IL'), ('IH');
insert into TransVolt (NAME) values ('VL'), ('VH');

insert into Points (ID, COUNTER, COUNTER_DATE, TRANSCURR, TRANSVOLT) 
values	(1, 'HOT',  '2023-04-01', 'IL', 'VL'), 
        (2, 'COLD', '2023-04-02','IH', 'VH'),
        (3, 'COLD', '2023-04-19','IL', 'VH');
        





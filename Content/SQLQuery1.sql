create table usersHotel(
email nvarchar(50) not null unique ,
password nvarchar(50) not null,
username nvarchar(50) not null unique ,
primary key (email,username)
);

select *
from usersHotel


INSERT INTO usersHotel (email, password, username)
VALUES 
(
'admin@gmail.com',
'123',
'admin'
),
(
'u1@gmail.com',
'123',
'u1'
),
(
'u2@gmail.com',
'123',
'u2'
),
(
'u3@gmail.com',
'123',
'u3'
);

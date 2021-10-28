USE [KicksKollector];
GO

set identity_insert [UserProfile] on
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (1, 'John@Bar.com', 'John', 'Bar', 'FtxL9hwuxdRncMJAzCzlyylxZn03')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (2, 'Matt@Xiong.com', 'Matt', 'Xiong', 'rwJdV8Z5qTNIAKYKG7GlUFVJAan1')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (3, 'Jeff@Gordon.com', 'Jeff', 'Gordon', 'UDwA7aamlFV7HjKonILdxj69Qea2')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (4, 'kyle@kyle.com', 'Kyle', 'Kyle', 'O4Uxz0Q5vlRbbsbrXorh4YjNxFF2')
set identity_insert [UserProfile] off

set identity_insert [Post] on
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (1, '1 Mocha', 11, '555088-105', 2, 170, 300, 2, 8);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (2, 'NMD Pharell Williams Human Race Scarlet', 11, 'BB0616', 1, 240, 650, 2, 2);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (3, 'Dunk Low Georgetown', 11, 'DD1391-003', 4, 100, 260, 1, 1);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (4, 'Dunk ', 11, 'DD1391-003', 4, 100, 260, 1, 1);
set identity_insert [Post] off

set identity_insert [Brand] on
insert into [Brand] ([Id], [Name]) values (1, 'Nike')
insert into [Brand] ([Id], [Name]) values (2, 'Adidas') 
insert into [Brand] ([Id], [Name]) values (3, 'NikeSB')
insert into [Brand] ([Id], [Name]) values (4, 'Puma')
insert into [Brand] ([Id], [Name]) values (5, 'Balenciaga')
insert into [Brand] ([Id], [Name]) values (6, 'Timberland')
insert into [Brand] ([Id], [Name]) values (7, 'Alexander McQueen')
insert into [Brand] ([Id], [Name]) values (8, 'Air Jordan')
insert into [Brand] ([Id], [Name]) values (9, 'New Balance')
insert into [Brand] ([Id], [Name]) values (10, 'Dior')
set identity_insert [Brand] off

set identity_insert [Comment] on
insert into Comment (Id, PostId, UserProfileId, Content) values (1, 1, 3, 'Sed sagittis.');
insert into Comment (Id, PostId, UserProfileId, Content) values (2, 2, 3, 'Pellentesque viverra pede ac diam.');
insert into Comment (Id, PostId, UserProfileId, Content) values (3, 3, 3, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.');
set identity_insert [Comment] off

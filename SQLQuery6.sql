USE [KicksKollector];
GO

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


set identity_insert [UserProfile] on
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (1, 'John@Bar.com', 'John', 'Bar', 'FtxL9hwuxdRncMJAzCzlyylxZn03')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (2, 'Matt@Xiong.com', 'Matt', 'Xiong', 'rwJdV8Z5qTNIAKYKG7GlUFVJAan1')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (3, 'Jeff@Gordon.com', 'Jeff', 'Gordon', 'UDwA7aamlFV7HjKonILdxj69Qea2')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (4, 'josh@josh.com', 'Josh', 'Josh', 'nb6AvjhfBhcV2fESfcKAyxgYEW32')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (5, 'don@don.com', 'Don', 'Don', 'oV9nfiFEMVZuHMf8CKjMQCb2MoE3')
insert into UserProfile (Id, Email, FirstName, LastName, FirebaseUserId) values (6, 'chris@chris.com', 'Chris', 'Chris', '3bVtYcnxyoe2RyKhFQfeI5PRDm62')
set identity_insert [UserProfile] off

set identity_insert [Post] on
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (1, '1 Mocha', 11, '555088-105', 2, 170, 300, 2, 8);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (2, 'NMD Pharell Williams Human Race Scarlet', 11, 'BB0616', 1, 240, 650, 2, 2);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (3, 'Dunk Low Georgetown', 11, 'DD1391-003', 4, 100, 260, 1, 1);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (4, '3 Retro Pine Green', 7, 'CT8532-030', 2, 190, 200, 6, 8);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (5, '4 Retro Lightning', 6, 'CT8527-700', 3, 220, 260, 3, 8);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (6, 'Yeezy Boost 350 V2', 11, 'GX3791', 10, 220, 280, 4, 2);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (7, 'Speed Trainer', 11, '645056W2DBQ1015', 2, 695, 600, 4, 5);
insert into Post (Id, Name, Size, StyleCode, Quantity, PurchasePrice, SoldPrice, UserProfileId, BrandId) values (8, 'Dunk Low Travis Scott', 10, 'CT5053-001', 2, 150, 2100, 4, 3);
set identity_insert [Post] off

set identity_insert [Comment] on
insert into Comment (Id, PostId, UserProfileId, Content) values (1, 1, 3, 'Sed sagittis.');
insert into Comment (Id, PostId, UserProfileId, Content) values (2, 2, 3, 'Pellentesque viverra pede ac diam.');
insert into Comment (Id, PostId, UserProfileId, Content) values (3, 3, 3, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.');
set identity_insert [Comment] off

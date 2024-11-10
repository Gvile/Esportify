INSERT INTO "public"."Role" ("Name") VALUES
('Visiteur'),
('Joueur'),
('Organisateur'),
('Administrateur');

INSERT INTO "public"."EventStatus" ("Name") VALUES
('Non validé'),
('Validé'),
('En cours'),
('Terminé');







INSERT INTO "User" ("Email", "Password", "Pseudo", "RoleId") VALUES
('john.doe@example.com', 'password123', 'john_doe', 1),
('jane.smith@example.com', 'password123', 'jane_smith', 2),
('alex.lee@example.com', 'password123', 'alex_lee', 1),
('emily.johnson@example.com', 'password123', 'emily_johnson', 3);



INSERT INTO "Event" ("EventStatusId", "Title", "Description", "MaxUser", "StartDate", "EndDate", "OwnerUserId") VALUES
(1, 'Esport Tournament 2024', 'A major esports tournament for multiple games', 100, '2024-11-15 10:00:00', '2024-11-15 18:00:00', 1),
(2, 'Casual Gaming Night', 'A relaxed evening of casual gaming with friends', 50, '2024-11-20 18:00:00', '2024-11-20 23:59:59', 2),
(3, 'Annual Game Expo', 'The biggest gaming expo with the latest games and technologies', 200, '2024-12-01 09:00:00', '2024-12-01 18:00:00', 3),
(1, 'Charity Speedrun Event', 'A speedrun event where all proceeds go to charity', 75, '2024-12-05 15:00:00', '2024-12-05 22:00:00', 1);

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
(1, 'Online Duel Masters', 'An intense 1v1 tournament for duel enthusiasts', 50, '2024-11-10 14:00:00', '2024-11-10 18:00:00', 1),
(2, 'Retro Gaming Night', 'Join us for a night of classic games and nostalgia', 30, '2024-11-09 20:00:00', '2024-11-09 23:59:59', 2),
(3, 'Winter Championship', 'A month-end championship featuring the top competitive games', 150, '2024-12-20 10:00:00', '2024-12-20 22:00:00', 3),
(1, 'Holiday Showdown', 'A festive tournament with prizes and holiday-themed events', 100, '2024-12-15 12:00:00', '2024-12-15 20:00:00', 4),
(1, 'December Open LAN', 'An open LAN event welcoming players of all levels', 200, '2024-12-10 09:00:00', '2024-12-10 18:00:00', 5);

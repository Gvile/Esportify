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







-- Insertion des utilisateurs avec des mots de passe diversifiés
INSERT INTO "User" ("Email", "Password", "Pseudo", "RoleId") VALUES
('john.doe@example.com', 'securePwd#21', 'john doe', 1),
('jane.smith@example.com', 'smiths4life!', 'jane smith', 2),
('alex.lee@example.com', 'Alex$Best123', 'alex lee', 1),
('emily.johnson@example.com', 'johnson_Emily98!', 'emily johnson', 3),
('michael.brown@example.com', 'Brown_Mike!34', 'michael brown', 2);

-- Insertion des événements avec des heures entre 6h et 18h
INSERT INTO "Event" ("EventStatusId", "Title", "Description", "MaxUser", "StartDate", "EndDate", "OwnerUserId") VALUES
(1, 'Online Duel Masters', 'An intense 1v1 tournament for duel enthusiasts', 50, '2024-11-10 09:00:00', '2024-11-10 13:00:00', 1),
(2, 'Retro Gaming Afternoon', 'Join us for an afternoon of classic games and nostalgia', 30, '2024-11-09 14:00:00', '2024-11-09 17:00:00', 2),
(3, 'Winter Championship', 'A month-end championship featuring the top competitive games', 150, '2024-12-20 08:00:00', '2024-12-20 17:00:00', 3),
(1, 'Holiday Showdown', 'A festive tournament with prizes and holiday-themed events', 100, '2024-12-15 11:00:00', '2024-12-15 18:00:00', 4),
(1, 'December Open LAN', 'An open LAN event welcoming players of all levels', 200, '2024-12-10 07:00:00', '2024-12-10 17:30:00', 5);


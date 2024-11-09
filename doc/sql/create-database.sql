DROP TABLE IF EXISTS "User";
DROP TABLE IF EXISTS "Event";
DROP TABLE IF EXISTS "EventImage";
DROP TABLE IF EXISTS "EventStatus";
DROP TABLE IF EXISTS "EventUser";
DROP TABLE IF EXISTS "Role";

CREATE TABLE "User" (
                        "Id" SERIAL PRIMARY KEY,
                        "Email" varchar(255),
                        "Password" varchar(255),
                        "Pseudo" varchar(20),
                        "RoleId" int
);

CREATE TABLE "Event" (
                         "Id" SERIAL PRIMARY KEY,
                         "EventStatusIs" int,
                         "Title" varchar(255),
                         "Description" varchar(255),
                         "MaxUser" int,
                         "StartDate" timestamp,
                         "EndDate" timestamp,
                         "OwnerUserId" int
);

CREATE TABLE "EventImage" (
                              "EventId" int,
                              "Image" text
);

CREATE TABLE "EventStatus" (
                               "Id" SERIAL PRIMARY KEY,
                               "Name" varchar(100)
);

CREATE TABLE "EventUser" (
                             "EventId" int,
                             "User" int
);

CREATE TABLE "Role" (
                        "Id" SERIAL PRIMARY KEY,
                        "Name" varchar(20)
);

ALTER TABLE "User" ADD FOREIGN KEY ("RoleId") REFERENCES "Role" ("Id");
ALTER TABLE "Event" ADD FOREIGN KEY ("EventStatusIs") REFERENCES "EventStatus" ("Id");

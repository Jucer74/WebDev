
-- create databases
CREATE DATABASE IF NOT EXISTS `MoviesDB`;
CREATE DATABASE IF NOT EXISTS `UsersDB`;

USE MoviesDB;
--
-- Table structure for table `roles`
--
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Table structure for table `movies`
--
DROP TABLE IF EXISTS `movies`;
CREATE TABLE `movies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `description` varchar(300) NOT NULL,
  `stars` decimal(2,1) NOT NULL,
  `year` year(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Table structure for table `persons`
--
DROP TABLE IF EXISTS `persons`;
CREATE TABLE `persons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Table structure for table `full_cast_by_movie`
--
CREATE TABLE `full_cast_by_movie` (
  `id_person` int(11) NOT NULL,
  `id_role` int(11) NOT NULL,
  `id_movie` int(11) NOT NULL,
  `character` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_person`,`id_role`,`id_movie`),
  KEY `fk_full_cast_by_movie_1_idx` (`id_role`),
  KEY `fk_full_cast_by_movie_2_idx` (`id_movie`),
  KEY `fk_full_cast_by_movie_3_idx` (`id_person`),
  CONSTRAINT `fk_full_cast_by_movie_1` FOREIGN KEY (`id_movie`) REFERENCES `movies` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_full_cast_by_movie_2` FOREIGN KEY (`id_person`) REFERENCES `persons` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_full_cast_by_movie_3` FOREIGN KEY (`id_role`) REFERENCES `roles` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


--
-- Dumping data for table `movies`
--
INSERT INTO movies VALUES 
(1,'Forrest Gump','The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75. ',8.8,1994);
--
-- Dumping data for table `roles`
--
INSERT INTO roles (`id`, `name`) VALUES 
(1,'Director'),
(2,'Actor'),
(3,'Producer'),
(4,'Writer'),
(5,'Music Composer'),
(6,'Casting Director'),
(7,'Associate Producer'),
(8,'Production Designer'),
(9,'Director of Photography'),
(10,'Executive Producer'),
(11,'First Assistant Director');
--
-- Dumping data for table `persons`
--
INSERT INTO persons (`id`, `name`,`phone`, `email`) VALUES 
(1,'Tom Hanks',NULL,NULL),
(2,'Robert Zemeckis ',NULL,NULL),
(3,'Winston Groom ',NULL,NULL),
(4,'Eric Roth ',NULL,NULL),
(5,'Sally Field ',NULL,NULL),
(6,'Robin Wright ',NULL,NULL);

--
-- Dumping data for table `full_cast_by_movie`
--
INSERT INTO full_cast_by_movie (`id_person`, `id_role`,`id_movie`, `character`) VALUES 
(1,2,1,'Forrest Gump'),
(2,1,1,NULL),
(3,4,1,NULL),
(4,4,1,NULL),
(5,2,1,'Mrs. Gump'),
(6,2,1,'Jenny Curran');


USE UsersDB;

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `UsersDB`.`user` 
CHANGE COLUMN `id` `id` INT(11) NOT NULL AUTO_INCREMENT ;


--
-- Dumping data for table `user`
--
INSERT INTO `UsersDB`.`user` (`id`, `email`, `name`, `password`, `username`) VALUES ('1', 'mrblue@javerianacali.edu.co', 'Blue Perez', '123456', 'blue');

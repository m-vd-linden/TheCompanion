CREATE DATABASE  IF NOT EXISTS `dbi408831` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dbi408831`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: dbi408831
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `challenge`
--

DROP TABLE IF EXISTS `challenge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `challenge` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Progress` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `challenge`
--

LOCK TABLES `challenge` WRITE;
/*!40000 ALTER TABLE `challenge` DISABLE KEYS */;
/*!40000 ALTER TABLE `challenge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `module`
--

DROP TABLE IF EXISTS `module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `module` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `ScriptLocation` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `module`
--

LOCK TABLES `module` WRITE;
/*!40000 ALTER TABLE `module` DISABLE KEYS */;
/*!40000 ALTER TABLE `module` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robot`
--

DROP TABLE IF EXISTS `robot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `robot` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robot`
--

LOCK TABLES `robot` WRITE;
/*!40000 ALTER TABLE `robot` DISABLE KEYS */;
INSERT INTO `robot` VALUES (1,'Henk'),(2,'Wall-E'),(4,'Mortimer'),(5,'Optimus');
/*!40000 ALTER TABLE `robot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robot_challenge`
--

DROP TABLE IF EXISTS `robot_challenge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `robot_challenge` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RobotID` int(11) NOT NULL,
  `ChallengeID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `RobotID` (`RobotID`),
  KEY `ChallengeID` (`ChallengeID`),
  CONSTRAINT `robot_challenge_ibfk_1` FOREIGN KEY (`ChallengeID`) REFERENCES `challenge` (`id`),
  CONSTRAINT `robot_challenge_ibfk_2` FOREIGN KEY (`RobotID`) REFERENCES `robot` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robot_challenge`
--

LOCK TABLES `robot_challenge` WRITE;
/*!40000 ALTER TABLE `robot_challenge` DISABLE KEYS */;
/*!40000 ALTER TABLE `robot_challenge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robot_module`
--

DROP TABLE IF EXISTS `robot_module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `robot_module` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RobotID` int(11) NOT NULL,
  `ModuleID` int(11) NOT NULL,
  `SkillLvl` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `RobotID` (`RobotID`),
  KEY `ModuleID` (`ModuleID`),
  CONSTRAINT `robot_module_ibfk_1` FOREIGN KEY (`RobotID`) REFERENCES `robot` (`id`),
  CONSTRAINT `robot_module_ibfk_2` FOREIGN KEY (`ModuleID`) REFERENCES `module` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robot_module`
--

LOCK TABLES `robot_module` WRITE;
/*!40000 ALTER TABLE `robot_module` DISABLE KEYS */;
/*!40000 ALTER TABLE `robot_module` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robot_user`
--

DROP TABLE IF EXISTS `robot_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `robot_user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RobotID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `RobotID` (`RobotID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `robot_user_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `user` (`id`),
  CONSTRAINT `robot_user_ibfk_2` FOREIGN KEY (`RobotID`) REFERENCES `robot` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robot_user`
--

LOCK TABLES `robot_user` WRITE;
/*!40000 ALTER TABLE `robot_user` DISABLE KEYS */;
INSERT INTO `robot_user` VALUES (1,1,1),(2,2,1),(4,4,2),(5,5,2);
/*!40000 ALTER TABLE `robot_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Admin','E3AFED0047B08059D0FADA10F400C1E5','Admin'),(2,'Martijn','DC647EB65E6711E155375218212B3964','Martijn');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-01-18  8:14:22

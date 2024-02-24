-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: newschema
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `addresses` (
  `Address_Address` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Address_CityName` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Address_PostalCode` int NOT NULL,
  `Address_State` varchar(80) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Address_Country` varchar(80) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `User_Id` int NOT NULL,
  KEY `Fk_User_Id` (`User_Id`),
  CONSTRAINT `Fk_User_Id` FOREIGN KEY (`User_Id`) REFERENCES `users` (`User_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `addresses`
--

LOCK TABLES `addresses` WRITE;
/*!40000 ALTER TABLE `addresses` DISABLE KEYS */;
INSERT INTO `addresses` VALUES ('495 Celine Forge Apt. 691\nNorth Ted, WY 70376','Ernserside',91018,'New Mexico','Seychelles',1),('40258 Kozey Crest Suite 089\nAgustinashire, WI 49922-1515','New Orvalville',8807,'New York','Liechtenstein',2),('485 Esteban Lake Apt. 427\nHuelsfurt, OK 04307','Vickiechester',80628,'South Carolina','Malta',3),('6485 Gregg Passage\nEast Jaren, NJ 41140','Littelton',26774,'New Jersey','Switzerland',4),('74561 Roman Shores Suite 888\nLake Kenshire, NV 01741','Darwinstad',49858,'Arizona','Sudan',5),('42574 Lorena Crossing Suite 816\nDeanland, MN 84647-9360','Camdenborough',25603,'Florida','Uzbekistan',6),('1974 Destiney Valleys\nBergnaumfurt, GA 12587','Rogahnfort',49829,'Missouri','Montenegro',7),('2952 Lolita Camp\nSusanatown, TN 84602-0511','Dickinsonfort',19356,'Georgia','Cape Verde',8),('37039 Wisozk Mission Suite 517\nPort Norristown, MS 53578','Kristoferborough',53899,'Ohio','Mauritius',9),('24346 Torp Corner Apt. 022\nHudsonbury, CA 74402','Reginaldburgh',34723,'Pennsylvania','Suriname',10);
/*!40000 ALTER TABLE `addresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carts`
--

DROP TABLE IF EXISTS `carts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carts` (
  `Shoplist_Id` int DEFAULT NULL,
  `Product_Id` int DEFAULT NULL,
  `Cart_Total` int NOT NULL,
  `Cart_ProductCount` int NOT NULL,
  KEY `Shoplist_Id` (`Shoplist_Id`),
  KEY `Product_Id` (`Product_Id`),
  CONSTRAINT `carts_ibfk_1` FOREIGN KEY (`Shoplist_Id`) REFERENCES `shoplists` (`Shoplist_Id`),
  CONSTRAINT `carts_ibfk_2` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Product_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carts`
--

LOCK TABLES `carts` WRITE;
/*!40000 ALTER TABLE `carts` DISABLE KEYS */;
INSERT INTO `carts` VALUES (1,1,221,7),(1,1,117,23),(1,3,61,14),(4,4,105,16),(4,2,330,17),(1,6,349,7),(1,7,36,22),(1,3,358,6),(7,1,447,6),(10,4,50,33);
/*!40000 ALTER TABLE `carts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commands`
--

DROP TABLE IF EXISTS `commands`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commands` (
  `Command_Id` int NOT NULL AUTO_INCREMENT,
  `Shoplist_Id` int DEFAULT NULL,
  `Command_OrderDate` date NOT NULL,
  PRIMARY KEY (`Command_Id`),
  KEY `Shoplist_Id` (`Shoplist_Id`),
  CONSTRAINT `commands_ibfk_1` FOREIGN KEY (`Shoplist_Id`) REFERENCES `shoplists` (`Shoplist_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commands`
--

LOCK TABLES `commands` WRITE;
/*!40000 ALTER TABLE `commands` DISABLE KEYS */;
INSERT INTO `commands` VALUES (1,1,'1983-05-21'),(2,2,'2017-06-11'),(3,3,'1979-05-13'),(4,4,'2011-04-23'),(5,5,'2021-01-18'),(6,6,'2003-07-06'),(7,7,'1970-01-12'),(8,8,'1983-12-27'),(9,9,'1992-02-25'),(10,10,'2001-11-10');
/*!40000 ALTER TABLE `commands` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoices`
--

DROP TABLE IF EXISTS `invoices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoices` (
  `Invoices_Id` int NOT NULL AUTO_INCREMENT,
  `Command_Id` int DEFAULT NULL,
  `Invoice_Date` date NOT NULL,
  PRIMARY KEY (`Invoices_Id`),
  KEY `Command_Id` (`Command_Id`),
  CONSTRAINT `invoices_ibfk_1` FOREIGN KEY (`Command_Id`) REFERENCES `commands` (`Command_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoices`
--

LOCK TABLES `invoices` WRITE;
/*!40000 ALTER TABLE `invoices` DISABLE KEYS */;
INSERT INTO `invoices` VALUES (1,1,'1984-11-02'),(2,2,'1998-10-27'),(3,3,'2018-11-15'),(4,4,'2010-07-01'),(5,5,'2010-03-11'),(6,6,'2020-02-17'),(7,7,'1972-07-23'),(8,8,'1971-12-23'),(9,9,'1987-10-11'),(10,10,'2001-02-14');
/*!40000 ALTER TABLE `invoices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payements`
--

DROP TABLE IF EXISTS `payements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payements` (
  `User_Id` int DEFAULT NULL,
  `Payement_CartNumber` int NOT NULL,
  `Payement_ExpirationDate` date NOT NULL,
  `Payement_Name` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Payement_SafeCode` int NOT NULL,
  KEY `User_Id` (`User_Id`),
  CONSTRAINT `payements_ibfk_1` FOREIGN KEY (`User_Id`) REFERENCES `users` (`User_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payements`
--

LOCK TABLES `payements` WRITE;
/*!40000 ALTER TABLE `payements` DISABLE KEYS */;
INSERT INTO `payements` VALUES (1,79539,'2018-03-21','Ortiz',79642164),(2,79673,'2010-01-14','Rogahn',170078),(3,12774794,'2004-09-03','Armstrong',78895),(4,97488946,'1975-03-28','Mosciski',4979799),(5,8119,'1972-11-15','Bartoletti',1113303),(6,79,'1992-09-13','Krajcik',57254885),(7,858,'1973-12-27','Skiles',7999519),(8,0,'1994-07-12','Connelly',8),(9,187653,'2019-09-21','Sanford',832),(10,315428,'2014-06-12','Feil',3776);
/*!40000 ALTER TABLE `payements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `photos`
--

DROP TABLE IF EXISTS `photos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `photos` (
  `User_Id` int DEFAULT NULL,
  `Product_Id` int DEFAULT NULL,
  `Photo_Photo` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Photo_Id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Photo_Id`),
  KEY `User_Id` (`User_Id`),
  KEY `Product_Id` (`Product_Id`),
  CONSTRAINT `photos_ibfk_1` FOREIGN KEY (`User_Id`) REFERENCES `users` (`User_Id`),
  CONSTRAINT `photos_ibfk_2` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Product_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `photos`
--

LOCK TABLES `photos` WRITE;
/*!40000 ALTER TABLE `photos` DISABLE KEYS */;
INSERT INTO `photos` VALUES (1,NULL,'South Eldora.jpeg',1),(NULL,1,'New Delphine.jpeg',2),(NULL,3,'East Tyriquemouth.jpeg',3),(1,NULL,'Cecileport.jpeg',4),(NULL,2,'West Noble.jpeg',5),(3,NULL,'Aidenhaven.jpeg',6),(NULL,7,'Lake Shaunberg.jpeg',7),(7,NULL,'New Ursulahaven.jpeg',8),(5,NULL,'North Newell.jpeg',9),(3,NULL,'North Tyrelborough.jpeg',10);
/*!40000 ALTER TABLE `photos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Product_Id` int NOT NULL AUTO_INCREMENT,
  `Product_Name` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Product_Description` varchar(120) COLLATE utf8mb4_general_ci NOT NULL,
  `Product_Type` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `Product_Price` int NOT NULL,
  `Product_NumberLeft` int NOT NULL,
  PRIMARY KEY (`Product_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'beer','Voluptatem iure magni sed nam et nulla. Nisi reprehenderit ipsum est esse. Mollitia nostrum earum velit qui id corporis ','PaleVioletRed',808669476,830472),(2,'thiel','Tempora voluptatem nobis maiores nam quae. Vitae quibusdam fugit culpa esse. Minima animi error eaque accusantium et exc','Peru',39,16587062),(3,'denesik','Maiores dignissimos sint sequi molestiae numquam numquam laboriosam. Nobis harum commodi sunt nostrum sint iusto. Volupt','LightSteelBlue',0,865383),(4,'greenholt','Et deserunt quod non nostrum aperiam. Voluptates ad nisi placeat non doloremque repellendus iure. Eum sapiente sint vel ','DodgerBlue',812,14363),(5,'rempel','Cumque dolor veritatis quae consequatur eius illum. Sapiente velit explicabo dolor facere consequatur. Quis quod quia re','Maroon',56156635,86),(6,'frami','Illum voluptas consequatur et velit sit. Voluptatem et asperiores ullam labore ea. Consequatur consequatur voluptatem es','PowderBlue',17013,45012),(7,'marquardt','Consectetur accusantium quia nobis sed. Pariatur non et dolores soluta. Tenetur quaerat optio quae perspiciatis. Corpori','LightCyan',9,915961461),(8,'roberts','Omnis sequi laboriosam quo unde dolores. Rerum ut assumenda quod sint eos. Non id quibusdam explicabo placeat.','Peru',6032,277698926),(9,'gusikowski','Est illo rem quaerat quis suscipit voluptatem eaque eaque. Sunt ipsa est ut et pariatur aut ullam. At maiores qui quis n','LightSkyBlue',2665,412007354),(10,'reichel','Sit alias minus rem perferendis nihil dignissimos fugiat numquam. Voluptas natus vel fuga non. Et illo numquam dicta err','LightGray',67009,77733);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rates`
--

DROP TABLE IF EXISTS `rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rates` (
  `Rate_Rate` int NOT NULL,
  `User_Id` int DEFAULT NULL,
  `Product_Id` int DEFAULT NULL,
  `Rate_Id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Rate_Id`),
  KEY `User_Id` (`User_Id`),
  KEY `Product_Id` (`Product_Id`),
  CONSTRAINT `rates_ibfk_1` FOREIGN KEY (`User_Id`) REFERENCES `users` (`User_Id`),
  CONSTRAINT `rates_ibfk_2` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Product_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rates`
--

LOCK TABLES `rates` WRITE;
/*!40000 ALTER TABLE `rates` DISABLE KEYS */;
INSERT INTO `rates` VALUES (4,1,1,1),(1,1,1,2),(5,2,3,3),(1,1,4,4),(4,5,2,5),(3,3,6,6),(4,2,7,7),(1,7,3,8),(2,5,1,9),(4,3,4,10);
/*!40000 ALTER TABLE `rates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shoplists`
--

DROP TABLE IF EXISTS `shoplists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shoplists` (
  `Shoplist_Id` int NOT NULL AUTO_INCREMENT,
  `User_Id` int DEFAULT NULL,
  PRIMARY KEY (`Shoplist_Id`),
  KEY `User_Id` (`User_Id`),
  CONSTRAINT `shoplists_ibfk_1` FOREIGN KEY (`User_Id`) REFERENCES `users` (`User_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shoplists`
--

LOCK TABLES `shoplists` WRITE;
/*!40000 ALTER TABLE `shoplists` DISABLE KEYS */;
INSERT INTO `shoplists` VALUES (1,1),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7),(8,8),(9,9),(10,10);
/*!40000 ALTER TABLE `shoplists` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `User_Id` int NOT NULL AUTO_INCREMENT,
  `User_FirstName` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `User_LastName` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `User_Email` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `User_Password` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  `User_Phone` varchar(80) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`User_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'NouveauPrénom','NouveauNom','kling.kenneth@kilback.com','v9kEF&JrX@<*4X','+1 (952) 367-0147'),(2,'Bryce','Koelpin','ibogisich@schowalter.net','lagnqd>`+{~C&kw','407.570.5610'),(3,'Catherine','Stroman','queenie05@wisozk.com','ah.+hJ]<m','(386) 501-5060'),(4,'Burnice','Hessel','destin96@blick.com','mE\"LSA','434.784.9960'),(5,'duncanchanman','bbb','aaa','eee','06'),(6,'Bennie','Baumbach','maximillia26@hotmail.com','0A`^iDTva','+1-914-234-8198'),(7,'Sydnie','Gottlieb','cordelia.runolfsdottir@larson.com','{r%Ss.*^njWjz>_e)x','+1-364-383-8180'),(8,'Leone','Nikolaus','dickinson.sylvia@yahoo.com','+vs\"-a.n|','(360) 242-5232'),(9,'Rickie','Berge','bogisich.jennyfer@von.net','G2\"o8~VJu?<4.Ot','+17476684440'),(10,'Cielo','Kuvalis','rosanna94@gleason.com','uS04yS?g2Z*x','(820) 812-8297'),(11,'','','','',''),(12,'ccc','bbb','aaa','eee','06'),(13,'ccc','bbb','aaa','eee','06'),(14,'ccc','bbb','aaa','eee','06'),(15,'TRY','myname','yo@live.fr','eee','06'),(16,'OOO','bbb','aaa','eee','06'),(17,'TRY','bbb','aaa','eee','06'),(21,'OKITS','bbb','aaa','eee','06'),(22,'OKITS','bbb','aaa','eee','06'),(25,'tibo','bbb','aaa','eee','06'),(26,'OOO','bbb','aaa','eee','06');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-04 13:28:31

CREATE DATABASE  IF NOT EXISTS `recousr` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `recousr`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: recousr
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `ets_tre_base`
--

DROP TABLE IF EXISTS `ets_tre_base`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base` (
  `CUSTOMER` bigint(20) DEFAULT NULL,
  `SUBSCRIBER_TYPE` bigint(20) DEFAULT NULL,
  `TARIFF_NAME` varchar(200) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `STATUS` bigint(20) DEFAULT NULL,
  `HANDSET_TYPE` varchar(200) DEFAULT NULL,
  `A_VCE_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `B_VCE_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_VCE_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `D_VCE_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `A_VCE_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `B_VCE_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_VCE_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `D_VCE_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `A_VCE_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `B_VCE_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_VCE_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `D_VCE_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `A_SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `B_SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `D_SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `A_SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `B_SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `D_SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `A_DATA_REV` bigint(20) DEFAULT NULL,
  `B_DATA_REV` bigint(20) DEFAULT NULL,
  `X_DATA_REV` bigint(20) DEFAULT NULL,
  `D_DATA_REV` bigint(20) DEFAULT NULL,
  `A_ARPU` bigint(20) DEFAULT NULL,
  `B_ARPU` bigint(20) DEFAULT NULL,
  `X_ARPU` bigint(20) DEFAULT NULL,
  `D_ARPU` bigint(20) DEFAULT NULL,
  `A_TOT_RCHG` bigint(20) DEFAULT NULL,
  `B_TOT_RCHG` bigint(20) DEFAULT NULL,
  `X_TOT_RCHG` bigint(20) DEFAULT NULL,
  `D_TOT_RCHG` bigint(20) DEFAULT NULL,
  `A_VCE_OFFNET_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `B_VCE_OFFNET_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `X_VCE_OFFNET_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `D_VCE_OFFNET_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `A_VCE_OFFNET_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `B_VCE_OFFNET_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `X_VCE_OFFNET_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `D_VCE_OFFNET_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `A_VCE_INT_MTC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `B_VCE_INT_MTC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `X_VCE_INT_MTC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `D_VCE_INT_MTC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `A_VCE_INT_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `B_VCE_INT_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `X_VCE_INT_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `D_VCE_INT_MOC_BILLED_DRTN` bigint(20) DEFAULT NULL,
  `A_VCE_INT_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `B_VCE_INT_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `X_VCE_INT_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `D_VCE_INT_MOC_FREE_DRTN` bigint(20) DEFAULT NULL,
  `A_SMS_ONNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_ONNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_ONNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_ONNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `A_SMS_ONNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_ONNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_ONNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_ONNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `A_SMS_OFFNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_OFFNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_OFFNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_OFFNET_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `A_SMS_OFFNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_OFFNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_OFFNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_OFFNET_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `A_SMS_INT_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_INT_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_INT_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_INT_MOC_BILLED_CNT` bigint(20) DEFAULT NULL,
  `A_SMS_INT_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `B_SMS_INT_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `X_SMS_INT_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `D_SMS_INT_MOC_FREE_CNT` bigint(20) DEFAULT NULL,
  `A_TOTAL_DATA_B` bigint(20) DEFAULT NULL,
  `B_TOTAL_DATA_B` bigint(20) DEFAULT NULL,
  `X_TOTAL_DATA_B` bigint(20) DEFAULT NULL,
  `D_TOTAL_DATA_B` bigint(20) DEFAULT NULL,
  `A_BALANCE_LAST_DAY` bigint(20) DEFAULT NULL,
  `B_BALANCE_LAST_DAY` bigint(20) DEFAULT NULL,
  `X_BALANCE_LAST_DAY` bigint(20) DEFAULT NULL,
  `D_BALANCE_LAST_DAY` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ets_tre_base`
--

LOCK TABLES `ets_tre_base` WRITE;
/*!40000 ALTER TABLE `ets_tre_base` DISABLE KEYS */;
/*!40000 ALTER TABLE `ets_tre_base` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opportunity`
--

DROP TABLE IF EXISTS `opportunity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opportunity` (
  `OPPORTUNITY_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `OPP_NAME` varchar(100) DEFAULT NULL,
  `DESCRIPTION` varchar(500) DEFAULT NULL,
  `FORMULA` varchar(500) DEFAULT NULL,
  `CREATEDDATE` date DEFAULT NULL,
  `CREATEDBY` int(11) DEFAULT NULL,
  `PROJECT_ID` int(11) DEFAULT NULL,
  `PTNL_FORMULA` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`OPPORTUNITY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opportunity`
--

LOCK TABLES `opportunity` WRITE;
/*!40000 ALTER TABLE `opportunity` DISABLE KEYS */;
/*!40000 ALTER TABLE `opportunity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `project_id` int(11) NOT NULL AUTO_INCREMENT,
  `NAME` varchar(50) DEFAULT NULL,
  `DESCRIPTION` varchar(200) DEFAULT NULL,
  `CREATEDBY` varchar(50) DEFAULT NULL,
  `CREATEDON` date DEFAULT NULL,
  PRIMARY KEY (`project_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (1,'xyz','Recousr','1','2019-10-27'),(2,'s','Recousr','1','2019-10-27'),(3,'ssss','ee','1','2019-10-27');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tre_calculated_columns`
--

DROP TABLE IF EXISTS `tre_calculated_columns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_calculated_columns` (
  `COLNAME` varchar(50) DEFAULT NULL,
  `COMBINE_COLUMNS` varchar(100) DEFAULT NULL,
  `TABLENAME` varchar(100) DEFAULT NULL,
  `COLDATATYPE` varchar(100) DEFAULT NULL,
  `PROJECT_ID` bigint(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tre_calculated_columns`
--

LOCK TABLES `tre_calculated_columns` WRITE;
/*!40000 ALTER TABLE `tre_calculated_columns` DISABLE KEYS */;
/*!40000 ALTER TABLE `tre_calculated_columns` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tre_mapping`
--

DROP TABLE IF EXISTS `tre_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_mapping` (
  `COLNAME` varchar(100) DEFAULT NULL,
  `ISREQUIRED` int(11) DEFAULT '0',
  `TYPE` int(11) DEFAULT '0',
  `COLDATATYPE` varchar(50) DEFAULT NULL,
  `TABLENAME` varchar(50) DEFAULT NULL,
  `ProjectId` bigint(20) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ProjectId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tre_mapping`
--

LOCK TABLES `tre_mapping` WRITE;
/*!40000 ALTER TABLE `tre_mapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `tre_mapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `User_ID` bigint(20) NOT NULL,
  `FIRST_NAME` varchar(50) DEFAULT NULL,
  `LAST_NAME` varchar(50) DEFAULT NULL,
  `USERTYPE_ID` int(11) DEFAULT NULL,
  `PASSWORD` varchar(10) DEFAULT NULL,
  `EMAIL` varchar(20) DEFAULT NULL,
  `AUTOLOGIN` int(11) DEFAULT NULL,
  `USERNAME` varchar(20) DEFAULT NULL,
  `ISACTIVE` int(11) DEFAULT NULL,
  `USEWINDOWSPASSWORD` int(11) DEFAULT NULL,
  PRIMARY KEY (`User_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Recoengine','usr',1,'Recousr','RecoUsr@gmail.com',0,'Recousr',1,0);
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

-- Dump completed on 2019-10-27 23:50:19

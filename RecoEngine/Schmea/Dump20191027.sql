CREATE DATABASE  IF NOT EXISTS `recousr` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `recousr`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: recousr
-- ------------------------------------------------------
-- Server version	5.7.28

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
-- Table structure for table `action_lookup`
--

DROP TABLE IF EXISTS `action_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `action_lookup` (
  `CODE` varchar(5) DEFAULT NULL,
  `DESCRIPTION` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `business_axe_lookup`
--

DROP TABLE IF EXISTS `business_axe_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `business_axe_lookup` (
  `CODE` varchar(3) DEFAULT NULL,
  `DESCRIPTION` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `camp_temp2`
--

DROP TABLE IF EXISTS `camp_temp2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `camp_temp2` (
  `CUSTOMER` double DEFAULT NULL,
  `PROJECTID` double DEFAULT NULL,
  `CAMPPTNL` double DEFAULT NULL,
  `CAMPAIGN_RANKING1` char(11) DEFAULT NULL,
  `CAMPAIGN_RANKING2` char(11) DEFAULT NULL,
  `CAMPAIGN_RANKING3` char(11) DEFAULT NULL,
  `CAMPAIGN_RANKING4` char(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `campaign_ranking`
--

DROP TABLE IF EXISTS `campaign_ranking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaign_ranking` (
  `CUSTOMER` decimal(20,0) DEFAULT NULL,
  `CAMPAIGN_RANKING1` varchar(50) DEFAULT NULL,
  `CAMPAIGN_RANKING2` varchar(50) DEFAULT NULL,
  `CAMPAIGN_RANKING3` varchar(50) DEFAULT NULL,
  `CAMPAIGN_RANKING4` varchar(50) DEFAULT NULL,
  `PROJECTID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `campaigns`
--

DROP TABLE IF EXISTS `campaigns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaigns` (
  `CAMPAIGN_ID` double DEFAULT NULL,
  `PROJECT_ID` double DEFAULT NULL,
  `NAME` varchar(50) DEFAULT NULL,
  `CODE` varchar(100) DEFAULT NULL,
  `OPPORTUNITY_ID` double DEFAULT NULL,
  `OFFER_ID` double DEFAULT NULL,
  `CHANNEL` varchar(10) DEFAULT NULL,
  `DESCRIPTION` varchar(3000) DEFAULT NULL,
  `TAKE_UP_RATE` decimal(18,2) DEFAULT NULL,
  `ELIGIBILITY` varchar(1000) DEFAULT NULL,
  `ACCOUNTS` double DEFAULT NULL,
  `TOTAL_POTENTIAL` decimal(18,2) DEFAULT NULL,
  `ISACTIVE` double DEFAULT NULL,
  `CREATEDBY` double DEFAULT NULL,
  `CREATEDDATE` datetime DEFAULT NULL,
  `OPP_RANK` double DEFAULT NULL,
  `SEGMENT_TYPE` varchar(50) DEFAULT NULL,
  `SEGMENT_DESCRIPTION` varchar(1000) DEFAULT NULL,
  UNIQUE KEY `CAMPAIGN_ID_UNIQUE` (`CAMPAIGN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `category_lookup`
--

DROP TABLE IF EXISTS `category_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category_lookup` (
  `CODE` varchar(3) DEFAULT NULL,
  `DESCRIPTION` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `channel_lookup`
--

DROP TABLE IF EXISTS `channel_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `channel_lookup` (
  `CODE` varchar(3) DEFAULT NULL,
  `DESCRIPTION` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `customer_pntl`
--

DROP TABLE IF EXISTS `customer_pntl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_pntl` (
  `OPP_NAME` varchar(30) DEFAULT NULL,
  `OPP_PNTL` decimal(20,0) DEFAULT NULL,
  `OPP_STATUS` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a10`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a10`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a10` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a11`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a11`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a11` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a12`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a12`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a12` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a13`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a13`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a13` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a14`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a14` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a15`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a15` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_a17`
--

DROP TABLE IF EXISTS `ets_adm_weekly_a17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_a17` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b10`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b10`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b10` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b11`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b11`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b11` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b12`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b12`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b12` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b13`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b13`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b13` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b14`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b14` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b15`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b15` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_adm_weekly_b17`
--

DROP TABLE IF EXISTS `ets_adm_weekly_b17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_adm_weekly_b17` (
  `TIMEPERIOD_ID` int(11) DEFAULT NULL,
  `customer` bigint(20) DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base14`
--

DROP TABLE IF EXISTS `ets_tre_base14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base14` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base15`
--

DROP TABLE IF EXISTS `ets_tre_base15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base15` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base17`
--

DROP TABLE IF EXISTS `ets_tre_base17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base17` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base2`
--

DROP TABLE IF EXISTS `ets_tre_base2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base2` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base3`
--

DROP TABLE IF EXISTS `ets_tre_base3`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base3` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `P_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `P_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_OFFNET` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_base_d`
--

DROP TABLE IF EXISTS `ets_tre_base_d`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_base_d` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `S_ON_NET_OUTGOING_SECS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `S_OFF_NET_OUTGOING_SECS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `S_INT_OUTGOING_SECS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `S_RCH_ALL_AMOUNT` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `S_ARPU` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  KEY `ETS_TRE_BASE_D_IX` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_based14`
--

DROP TABLE IF EXISTS `ets_tre_based14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_based14` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_based15`
--

DROP TABLE IF EXISTS `ets_tre_based15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_based15` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_based17`
--

DROP TABLE IF EXISTS `ets_tre_based17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_based17` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_basep14`
--

DROP TABLE IF EXISTS `ets_tre_basep14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_basep14` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `P_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `P_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `P_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `P_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `P_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  `P_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_basep15`
--

DROP TABLE IF EXISTS `ets_tre_basep15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_basep15` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `P_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `P_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `P_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `P_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `P_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  `P_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_basep17`
--

DROP TABLE IF EXISTS `ets_tre_basep17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_basep17` (
  `customer` bigint(20) DEFAULT NULL,
  `DECILE` bigint(20) DEFAULT NULL,
  `A_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `B_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `D_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `S_TOTAL_BALANCE_INITIAL` varchar(200) DEFAULT NULL,
  `P_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `A_ARPU` double DEFAULT NULL,
  `B_ARPU` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `D_ARPU` double DEFAULT NULL,
  `S_ARPU` varchar(200) DEFAULT NULL,
  `P_ARPU` double DEFAULT NULL,
  `A_REV_VCE_ONNET` double DEFAULT NULL,
  `B_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `D_REV_VCE_ONNET` double DEFAULT NULL,
  `S_REV_VCE_ONNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_ONNET` double DEFAULT NULL,
  `A_REV_VCE_OFFNET` double DEFAULT NULL,
  `B_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `D_REV_VCE_OFFNET` double DEFAULT NULL,
  `S_REV_VCE_OFFNET` varchar(200) DEFAULT NULL,
  `P_REV_VCE_OFFNET` double DEFAULT NULL,
  `A_REV_VCE_INT` double DEFAULT NULL,
  `B_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `D_REV_VCE_INT` double DEFAULT NULL,
  `S_REV_VCE_INT` varchar(200) DEFAULT NULL,
  `P_REV_VCE_INT` double DEFAULT NULL,
  `A_REV_DATA` double DEFAULT NULL,
  `B_REV_DATA` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `D_REV_DATA` double DEFAULT NULL,
  `S_REV_DATA` varchar(200) DEFAULT NULL,
  `P_REV_DATA` double DEFAULT NULL,
  `A_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_ON_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `B_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `D_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `S_OFF_NET_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_OUTGOING_SECS` double DEFAULT NULL,
  `B_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `D_INT_OUTGOING_SECS` double DEFAULT NULL,
  `S_INT_OUTGOING_SECS` varchar(200) DEFAULT NULL,
  `P_INT_OUTGOING_SECS` double DEFAULT NULL,
  `A_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MOC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `B_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `D_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `S_INT_MTC_COUNTRIES` varchar(200) DEFAULT NULL,
  `P_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `A_DATA_ALL_KB` double DEFAULT NULL,
  `B_DATA_ALL_KB` double DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `D_DATA_ALL_KB` double DEFAULT NULL,
  `S_DATA_ALL_KB` varchar(200) DEFAULT NULL,
  `P_DATA_ALL_KB` double DEFAULT NULL,
  `A_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `B_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `D_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `S_RCH_ALL_AMOUNT` varchar(200) DEFAULT NULL,
  `P_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `customer` (`customer`,`DECILE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_x_sell_pntl`
--

DROP TABLE IF EXISTS `ets_tre_x_sell_pntl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_x_sell_pntl` (
  `TIMEPERIOD` bigint(11) NOT NULL,
  `SegmentColName` varchar(200) DEFAULT NULL,
  `CURRENTSEGMENT` varchar(200) DEFAULT NULL,
  `X_ARPU` decimal(18,2) DEFAULT NULL,
  `X_VCE_ONNET_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `X_VCE_OFFNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `X_VCE_OFFNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `X_VCE_OFFNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `X_OFFNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `X_OFFNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `X_OFFNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `X_VCE_OFFNET_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `X_VCE_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_VCE_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_VCE_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_SMS_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `X_DATA_REV` bigint(20) DEFAULT NULL,
  `X_TOT_RCHG` bigint(20) DEFAULT NULL,
  `X_TOP_IC_COUNTRY_DRTN_SECS` bigint(20) DEFAULT NULL,
  `X_TOTAL_DATA_B` bigint(20) DEFAULT NULL,
  `X_VCE_ONNET_MOC_SECS` double DEFAULT NULL,
  `X_VCE_INT_MOC_SECS` double DEFAULT NULL,
  `X_SMS_ONNET_MOC_CNT` double DEFAULT NULL,
  `X_SMS_OFFNET_MOC_CNT` double DEFAULT NULL,
  `X_SMS_INT_MOC_CNT` double DEFAULT NULL,
  `X_VCE_OFFNET_MOC_SECS` double DEFAULT NULL,
  `X_STATUS` varchar(200) DEFAULT NULL,
  `X_CUSTOMER_NATIONALITY` varchar(200) DEFAULT NULL,
  `X_LAST_DATE_DATA` varchar(200) DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_HIST_DATA_FLAG` varchar(200) DEFAULT NULL,
  `X_HIST_VOICE_MOC_INTL_FLAG` varchar(200) DEFAULT NULL,
  `X_OFFNET_15_MOC_DRTN_SECS` bigint(20) DEFAULT NULL,
  `X_SN_TOP_INT_MOC_CALLS1` bigint(20) DEFAULT NULL,
  `X_SN_TOP_INT_MOC_CALLS2` bigint(20) DEFAULT NULL,
  `X_BENEFIT_ACC_BAL` bigint(20) DEFAULT NULL,
  `X_VOLUME_ACC_BAL` bigint(20) DEFAULT NULL,
  `X_DECILE` bigint(20) DEFAULT NULL,
  `X_LAST_DATE_VCE_INT` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_x_sell_pntl14`
--

DROP TABLE IF EXISTS `ets_tre_x_sell_pntl14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_x_sell_pntl14` (
  `TIMEPERIOD` varchar(50) DEFAULT NULL,
  `SEGMENTCOLNAME` varchar(50) DEFAULT NULL,
  `CURRENTSEGMENT` varchar(50) DEFAULT NULL,
  `X_STATUS` varchar(200) DEFAULT NULL,
  `X_CUSTOMER_NATIONALITY` varchar(200) DEFAULT NULL,
  `X_LAST_DATE_VCE_INT` varchar(200) DEFAULT NULL,
  `X_LAST_DATE_DATA` varchar(200) DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_HIST_VOICE_MOC_INTL_FLAG` varchar(200) DEFAULT NULL,
  `X_HIST_DATA_FLAG` varchar(200) DEFAULT NULL,
  KEY `CURRENTSEGMENT` (`CURRENTSEGMENT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_x_sell_pntl15`
--

DROP TABLE IF EXISTS `ets_tre_x_sell_pntl15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_x_sell_pntl15` (
  `TIMEPERIOD` varchar(50) DEFAULT NULL,
  `SEGMENTCOLNAME` varchar(50) DEFAULT NULL,
  `CURRENTSEGMENT` varchar(50) DEFAULT NULL,
  `X_STATUS` varchar(200) DEFAULT NULL,
  `X_CUSTOMER_NATIONALITY` varchar(200) DEFAULT NULL,
  `X_LAST_DATE_VCE_INT` varchar(200) DEFAULT NULL,
  `X_LAST_DATE_DATA` varchar(200) DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  KEY `CURRENTSEGMENT` (`CURRENTSEGMENT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ets_tre_x_sell_pntl17`
--

DROP TABLE IF EXISTS `ets_tre_x_sell_pntl17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ets_tre_x_sell_pntl17` (
  `TIMEPERIOD` varchar(50) DEFAULT NULL,
  `SEGMENTCOLNAME` varchar(50) DEFAULT NULL,
  `CURRENTSEGMENT` varchar(50) DEFAULT NULL,
  `X_STATUS` varchar(200) DEFAULT NULL,
  `X_HISTORICAL_VOICE_MOC_INTL_FLAG` varchar(200) DEFAULT NULL,
  `X_CUSTOMER_NATIONALITY` varchar(200) DEFAULT NULL,
  `X_TOTAL_BALANCE_INITIAL` double DEFAULT NULL,
  `X_ARPU` double DEFAULT NULL,
  `X_REV_VCE_ONNET` double DEFAULT NULL,
  `X_REV_VCE_OFFNET` double DEFAULT NULL,
  `X_REV_VCE_INT` double DEFAULT NULL,
  `X_REV_DATA` double DEFAULT NULL,
  `X_ON_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_OFF_NET_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_OUTGOING_SECS` double DEFAULT NULL,
  `X_INT_MOC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_INT_MTC_COUNTRIES` bigint(20) DEFAULT NULL,
  `X_DATA_ALL_KB` double DEFAULT NULL,
  `X_RCH_ALL_AMOUNT` double DEFAULT NULL,
  `X_HISTORICAL_DATA_FLAG` varchar(200) DEFAULT NULL,
  KEY `CURRENTSEGMENT` (`CURRENTSEGMENT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `export`
--

DROP TABLE IF EXISTS `export`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `export` (
  `ID` double unsigned DEFAULT NULL,
  `PROJECT_ID` double DEFAULT NULL,
  `CAMPAIGN_ID` double DEFAULT NULL,
  `CUSTOMER` double DEFAULT NULL,
  `CG` varchar(1) DEFAULT 'Y'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `export_settings`
--

DROP TABLE IF EXISTS `export_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `export_settings` (
  `PROJECT_ID` double DEFAULT NULL,
  `RANKING` varchar(200) DEFAULT NULL,
  `EXPORT_FILE` char(1) DEFAULT NULL,
  `ISFIXEDCUSTOMER` char(1) DEFAULT NULL,
  `BASECUSTOMERS` varchar(50) DEFAULT NULL,
  `ISCONTROLGROUP` varchar(50) DEFAULT NULL,
  `MINLIMIT` varchar(20) DEFAULT NULL,
  `MAXLIMIT` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `filter_main`
--

DROP TABLE IF EXISTS `filter_main`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `filter_main` (
  `FILTER` varchar(200) DEFAULT NULL,
  `Project_ID` bigint(80) NOT NULL,
  `filter_maincol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Project_ID`),
  UNIQUE KEY `Project_ID_UNIQUE` (`Project_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `new_table`
--

DROP TABLE IF EXISTS `new_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `new_table` (
  `COUNTRY` text,
  `OPCO` text,
  `Customer` bigint(20) DEFAULT NULL,
  `CHANNEL_CODE` text,
  `SUBSCRIBER_TYPE` text,
  `TARIFF_ID` bigint(20) DEFAULT NULL,
  `TARIFF_NAME` text,
  `CURRENT_SEGMENT` text,
  `DECILE` bigint(20) DEFAULT NULL,
  `NETWORKTYPE` text,
  `LAST_RGE_DT` text,
  `LAST_EVENT_DT` text,
  `LAST_RCHG_DT` text,
  `ACTIVATION_DT` text,
  `EXPECTED_CHURN_DT` text,
  `STATUS` text,
  `YEAR` bigint(20) DEFAULT NULL,
  `WEEK` int(11) DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `ROAM_OUTGOING_REV` bigint(20) DEFAULT NULL,
  `ROAM_INCOMING_REV` bigint(20) DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `DATA_REV` bigint(20) DEFAULT NULL,
  `VAS_REV` bigint(20) DEFAULT NULL,
  `PRICE_PLAN_TOTAL` bigint(20) DEFAULT NULL,
  `PRICE_PLANS_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN` text,
  `TOP1_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP2_PLAN` text,
  `TOP2_PLAN_COUNT` int(11) DEFAULT NULL,
  `TOP2_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP3_PLAN` text,
  `TOP3_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP3_PLAN_REV` bigint(20) DEFAULT NULL,
  `ALL_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `ARPU` double DEFAULT NULL,
  `TOT_RCHG` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CODE` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CODE` double DEFAULT NULL,
  `COUNTRIES_MOC` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_OG_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `COUNTRIES_MTC` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_CALLS` double DEFAULT NULL,
  `ROAM_MOC_SECS` double DEFAULT NULL,
  `ROAM_MOC_COUNTER` double DEFAULT NULL,
  `ROAM_MOC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MOC_FREE_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_SECS` double DEFAULT NULL,
  `ROAM_MTC_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MTC_FREE_COUNTER` double DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_ONNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_FREE_CNT` double DEFAULT NULL,
  `MMS_REV` double DEFAULT NULL,
  `TOTAL_DATA_FREE_B` double DEFAULT NULL,
  `DATA_IN_FREE_B` double DEFAULT NULL,
  `DATA_OUT_FREE_B` double DEFAULT NULL,
  `DATA_FREE_DRTN_SECS` double DEFAULT NULL,
  `TOTAL_DATA_B` double DEFAULT NULL,
  `DATA_IN_BUNDLE_B` double DEFAULT NULL,
  `DATA_OUT_BUNDLE_B` double DEFAULT NULL,
  `DATA_SESSION_CNT` double DEFAULT NULL,
  `DATA_SESSION_DRTN_SECS` double DEFAULT NULL,
  `CRBT_CNT` double DEFAULT NULL,
  `CRBT_REV` double DEFAULT NULL,
  `ME2U_CNT` double DEFAULT NULL,
  `ME2U_REV` double DEFAULT NULL,
  `BT_I_CNT` double DEFAULT NULL,
  `BT_I_TOT` double DEFAULT NULL,
  `BT_O_CNT` double DEFAULT NULL,
  `BT_O_TOT` double DEFAULT NULL,
  `RCHG_ERECHARGE_CNT` double DEFAULT NULL,
  `RCHG_ERECHARGE_REV` double DEFAULT NULL,
  `RCHG_DIRECT_CNT` double DEFAULT NULL,
  `RCHG_DIRECT_REV` double DEFAULT NULL,
  `RCHG_CNT_VOUCHER` double DEFAULT NULL,
  `RCHG_REV_VOUCHER` double DEFAULT NULL,
  `RCHG_200_REV` double DEFAULT NULL,
  `RCHG_500_REV` double DEFAULT NULL,
  `RCHG_1000_REV` double DEFAULT NULL,
  `RCHG_2000_REV` double DEFAULT NULL,
  `RCHG_3000_REV` double DEFAULT NULL,
  `RCHG_5000_REV` double DEFAULT NULL,
  `RCHG_10000_REV` double DEFAULT NULL,
  `RCHG_200_CNT` double DEFAULT NULL,
  `RCHG_500_CNT` double DEFAULT NULL,
  `RCHG_1000_CNT` double DEFAULT NULL,
  `RCHG_2000_CNT` double DEFAULT NULL,
  `RCHG_3000_CNT` double DEFAULT NULL,
  `RCHG_5000_CNT` double DEFAULT NULL,
  `RCHG_10000_CNT` double DEFAULT NULL,
  `TOTAL_MAIN_COUNT` double DEFAULT NULL,
  `TOTAL_MAIN_RCHG` double DEFAULT NULL,
  `TOTAL_BONUS_COUNT` double DEFAULT NULL,
  `TOTAL_BONUS_RCHG` double DEFAULT NULL,
  `TOTAL_BENEFIT_COUNT` double DEFAULT NULL,
  `TOTAL_BENEFIT_RCHG` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_DATA` double DEFAULT NULL,
  `ONNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_MON_DRTN_SECS` double DEFAULT NULL,
  `ONNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `ONNET_WED_DRTN_SECS` double DEFAULT NULL,
  `ONNET_THU_DRTN_SECS` double DEFAULT NULL,
  `ONNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_MON_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_WED_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_THU_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `INT_MON_DRTN_SECS` double DEFAULT NULL,
  `INT_TUE_DRTN_SECS` double DEFAULT NULL,
  `INT_WED_DRTN_SECS` double DEFAULT NULL,
  `INT_THU_DRTN_SECS` double DEFAULT NULL,
  `INT_FRI_DRTN_SECS` double DEFAULT NULL,
  `INT_SAT_DRTN_SECS` double DEFAULT NULL,
  `INT_SUN_DRTN_SECS` double DEFAULT NULL,
  `SN_TOTAL_MOC` double DEFAULT NULL,
  `SN_TOTAL_MTC` double DEFAULT NULL,
  `SN_ONNET_MOC` double DEFAULT NULL,
  `SN_ONNET_MTC` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN2` bigint(20) DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAU_MOC` double DEFAULT NULL,
  `SN_MAU_MTC` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAT_MOC` double DEFAULT NULL,
  `SN_MAT_MTC` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS2` double DEFAULT NULL,
  `SN_INT_MOC` double DEFAULT NULL,
  `SN_INT_MTC` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS2` double DEFAULT NULL,
  `MAIN_ACC_BAL` double DEFAULT NULL,
  `MAIN_ACC_EXP` text,
  `BONUS_ACC_BAL` double DEFAULT NULL,
  `BONUS_ACC_EXP` text,
  `BENEFIT_ACC_BAL` double DEFAULT NULL,
  `BENEFIT_ACC_EXP` text,
  `NATIONAL_BONUS_BAL` double DEFAULT NULL,
  `NATIONAL_BONUS_EXP` text,
  `RETURNEE_ACC_BAL` double DEFAULT NULL,
  `RETURNEE_ACC_EXP` text,
  `INTERNATIONAL_BENEFIT_BAL` double DEFAULT NULL,
  `INTERNATIONAL_BENEFIT_EXP` text,
  `ONNET_HOURS_BAL` double DEFAULT NULL,
  `ONNET_HOURS_EXP` text,
  `OFFNET_HOURS_BAL` double DEFAULT NULL,
  `OFFNET_HOURS_EXP` text,
  `DEDUCTION_BENEFIT_BAL` double DEFAULT NULL,
  `DEDUCTION_BENEFIT_EXP` text,
  `GIVEN_SMS_BAL` double DEFAULT NULL,
  `GIVEN_SMS_EXP` text,
  `DEDUCTION_SMS_BAL` double DEFAULT NULL,
  `DEDUCTION_SMS_EXP` text,
  `VOLUME_ACC_BAL` double DEFAULT NULL,
  `VOLUME_ACC_EXP` text,
  `VOLUME_3G_ACC_BAL` double DEFAULT NULL,
  `VOLUME_3G_ACC_EXP` text,
  `DEDUCTION_DATA_BAL` double DEFAULT NULL,
  `DEDUCTION_DATA_EXP` text,
  `NATIONAL_MONEY` double DEFAULT NULL,
  `ONNET_MONEY_ACC` double DEFAULT NULL,
  `ONNET_DURATION` double DEFAULT NULL,
  `GPRS_VOLUME` double DEFAULT NULL,
  `CELLID` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `offers`
--

DROP TABLE IF EXISTS `offers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `offers` (
  `OFFER_ID` double unsigned NOT NULL AUTO_INCREMENT,
  `PROJECT_ID` double DEFAULT NULL,
  `NAME` varchar(50) DEFAULT NULL,
  `CODE` varchar(50) DEFAULT NULL,
  `DESCRIPTION` varchar(3000) DEFAULT NULL,
  `LEVEL1` varchar(50) DEFAULT NULL,
  `LEVEL2` varchar(50) DEFAULT NULL,
  `LEVEL3` varchar(50) DEFAULT NULL,
  `LEVEL4` varchar(50) DEFAULT NULL,
  `CREATEDBY` double DEFAULT NULL,
  `CREATEDDATE` datetime DEFAULT NULL,
  `ISACTIVE` double DEFAULT '0',
  PRIMARY KEY (`OFFER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `opportunity`
--

DROP TABLE IF EXISTS `opportunity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opportunity` (
  `OPPORTUNITY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `OPP_NAME` varchar(100) DEFAULT NULL,
  `DESCRIPTION` varchar(500) DEFAULT NULL,
  `FORMULA` varchar(2000) DEFAULT NULL,
  `CREATEDDATE` datetime DEFAULT NULL,
  `CREATEDBY` double DEFAULT NULL,
  `PROJECT_ID` double DEFAULT NULL,
  `PTNL_FORMULA` varchar(2000) DEFAULT NULL,
  `ISONMAIN` double DEFAULT '0',
  `ISACTIVE` double DEFAULT '0',
  `ELGBL_FORMULA` varchar(2000) DEFAULT NULL,
  `OPP_ACTION` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`OPPORTUNITY_ID`),
  UNIQUE KEY `OPPORTUNITY_ID_UNIQUE` (`OPPORTUNITY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `opportunity_ranking`
--

DROP TABLE IF EXISTS `opportunity_ranking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opportunity_ranking` (
  `PROJECT_ID` int(11) DEFAULT NULL,
  `TYPE` varchar(200) DEFAULT NULL,
  `RANK1` varchar(200) DEFAULT NULL,
  `RANK2` varchar(200) DEFAULT NULL,
  `RANK3` varchar(200) DEFAULT NULL,
  `RANK4` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `opportunity_values`
--

DROP TABLE IF EXISTS `opportunity_values`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opportunity_values` (
  `OPPORTUNITY_ID` int(11) DEFAULT NULL,
  `OPP_DELTA_SUM` double DEFAULT NULL,
  `OPP_PTNL_SUM` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `opt_lookup`
--

DROP TABLE IF EXISTS `opt_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opt_lookup` (
  `CODE` varchar(5) DEFAULT NULL,
  `DESCRIPTION` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `product_lookup`
--

DROP TABLE IF EXISTS `product_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_lookup` (
  `CODE` varchar(4) DEFAULT NULL,
  `DESCRIPTION` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `project_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `NAME` varchar(50) DEFAULT NULL,
  `DESCRIPTION` varchar(200) DEFAULT NULL,
  `CREATEDBY` varchar(50) DEFAULT NULL,
  `CREATEDON` date DEFAULT NULL,
  PRIMARY KEY (`project_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `revenue_lookup`
--

DROP TABLE IF EXISTS `revenue_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `revenue_lookup` (
  `CODE` varchar(3) DEFAULT NULL,
  `DESCRIPTION` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `status_breakdown`
--

DROP TABLE IF EXISTS `status_breakdown`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status_breakdown` (
  `OPPORTUNITY_ID` double DEFAULT NULL,
  `FLAT_CUTOFF` decimal(18,2) DEFAULT NULL,
  `DROPPERS_CUTOFF` decimal(18,2) DEFAULT NULL,
  `STOPPERS_CUTOFF` decimal(18,2) DEFAULT NULL,
  `GROWERS_CUTOFF` decimal(18,2) DEFAULT NULL,
  `NONUSERS_CUTOFF` decimal(18,2) DEFAULT NULL,
  `NEWUSERS_CUTOFF` decimal(18,2) DEFAULT NULL,
  `FLAT_COUNT` decimal(38,0) DEFAULT NULL,
  `DROPPERS_COUNT` decimal(38,0) DEFAULT NULL,
  `STOPPERS_COUNT` decimal(38,0) DEFAULT NULL,
  `GROWERS_COUNT` decimal(38,0) DEFAULT NULL,
  `NONUSERS_COUNT` decimal(38,0) DEFAULT NULL,
  `NEWUSERS_COUNT` decimal(38,0) DEFAULT NULL,
  `FLAT_AVG` decimal(18,2) DEFAULT NULL,
  `DROPPERS_AVG` decimal(18,2) DEFAULT NULL,
  `STOPPERS_AVG` decimal(18,2) DEFAULT NULL,
  `GROWERS_AVG` decimal(18,2) DEFAULT NULL,
  `NONUSERS_AVG` decimal(18,2) DEFAULT NULL,
  `NEWUSERS_AVG` decimal(18,2) DEFAULT NULL,
  `T1` varchar(200) DEFAULT NULL,
  `T2` varchar(200) DEFAULT NULL,
  `CURRENTSEGMENT` varchar(30) DEFAULT NULL,
  `SEGMENTISACTIVE` double DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `temp_calaculated`
--

DROP TABLE IF EXISTS `temp_calaculated`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `temp_calaculated` (
  `HIST_DATA_FLAG` int(1) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_details`
--

DROP TABLE IF EXISTS `tre_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_details` (
  `COUNTRY` text,
  `OPCO` text,
  `Customer` bigint(20) DEFAULT NULL,
  `CHANNEL_CODE` text,
  `SUBSCRIBER_TYPE` text,
  `TARIFF_ID` bigint(20) DEFAULT NULL,
  `TARIFF_NAME` text,
  `CURRENT_SEGMENT` text,
  `DECILE` bigint(20) DEFAULT NULL,
  `NETWORKTYPE` text,
  `LAST_RGE_DT` text,
  `LAST_EVENT_DT` text,
  `LAST_RCHG_DT` text,
  `ACTIVATION_DT` text,
  `EXPECTED_CHURN_DT` text,
  `STATUS` text,
  `YEAR` bigint(20) DEFAULT NULL,
  `WEEK` int(11) DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `ROAM_OUTGOING_REV` bigint(20) DEFAULT NULL,
  `ROAM_INCOMING_REV` bigint(20) DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `DATA_REV` bigint(20) DEFAULT NULL,
  `VAS_REV` bigint(20) DEFAULT NULL,
  `PRICE_PLAN_TOTAL` bigint(20) DEFAULT NULL,
  `PRICE_PLANS_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN` text,
  `TOP1_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP2_PLAN` text,
  `TOP2_PLAN_COUNT` int(11) DEFAULT NULL,
  `TOP2_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP3_PLAN` text,
  `TOP3_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP3_PLAN_REV` bigint(20) DEFAULT NULL,
  `ALL_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `ARPU` double DEFAULT NULL,
  `TOT_RCHG` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CODE` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CODE` double DEFAULT NULL,
  `COUNTRIES_MOC` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_OG_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `COUNTRIES_MTC` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_CALLS` double DEFAULT NULL,
  `ROAM_MOC_SECS` double DEFAULT NULL,
  `ROAM_MOC_COUNTER` double DEFAULT NULL,
  `ROAM_MOC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MOC_FREE_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_SECS` double DEFAULT NULL,
  `ROAM_MTC_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MTC_FREE_COUNTER` double DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_ONNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_FREE_CNT` double DEFAULT NULL,
  `MMS_REV` double DEFAULT NULL,
  `TOTAL_DATA_FREE_B` double DEFAULT NULL,
  `DATA_IN_FREE_B` double DEFAULT NULL,
  `DATA_OUT_FREE_B` double DEFAULT NULL,
  `DATA_FREE_DRTN_SECS` double DEFAULT NULL,
  `TOTAL_DATA_B` double DEFAULT NULL,
  `DATA_IN_BUNDLE_B` double DEFAULT NULL,
  `DATA_OUT_BUNDLE_B` double DEFAULT NULL,
  `DATA_SESSION_CNT` double DEFAULT NULL,
  `DATA_SESSION_DRTN_SECS` double DEFAULT NULL,
  `CRBT_CNT` double DEFAULT NULL,
  `CRBT_REV` double DEFAULT NULL,
  `ME2U_CNT` double DEFAULT NULL,
  `ME2U_REV` double DEFAULT NULL,
  `BT_I_CNT` double DEFAULT NULL,
  `BT_I_TOT` double DEFAULT NULL,
  `BT_O_CNT` double DEFAULT NULL,
  `BT_O_TOT` double DEFAULT NULL,
  `RCHG_ERECHARGE_CNT` double DEFAULT NULL,
  `RCHG_ERECHARGE_REV` double DEFAULT NULL,
  `RCHG_DIRECT_CNT` double DEFAULT NULL,
  `RCHG_DIRECT_REV` double DEFAULT NULL,
  `RCHG_CNT_VOUCHER` double DEFAULT NULL,
  `RCHG_REV_VOUCHER` double DEFAULT NULL,
  `RCHG_200_REV` double DEFAULT NULL,
  `RCHG_500_REV` double DEFAULT NULL,
  `RCHG_1000_REV` double DEFAULT NULL,
  `RCHG_2000_REV` double DEFAULT NULL,
  `RCHG_3000_REV` double DEFAULT NULL,
  `RCHG_5000_REV` double DEFAULT NULL,
  `RCHG_10000_REV` double DEFAULT NULL,
  `RCHG_200_CNT` double DEFAULT NULL,
  `RCHG_500_CNT` double DEFAULT NULL,
  `RCHG_1000_CNT` double DEFAULT NULL,
  `RCHG_2000_CNT` double DEFAULT NULL,
  `RCHG_3000_CNT` double DEFAULT NULL,
  `RCHG_5000_CNT` double DEFAULT NULL,
  `RCHG_10000_CNT` double DEFAULT NULL,
  `TOTAL_MAIN_COUNT` double DEFAULT NULL,
  `TOTAL_MAIN_RCHG` double DEFAULT NULL,
  `TOTAL_BONUS_COUNT` double DEFAULT NULL,
  `TOTAL_BONUS_RCHG` double DEFAULT NULL,
  `TOTAL_BENEFIT_COUNT` double DEFAULT NULL,
  `TOTAL_BENEFIT_RCHG` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_DATA` double DEFAULT NULL,
  `ONNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_MON_DRTN_SECS` double DEFAULT NULL,
  `ONNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `ONNET_WED_DRTN_SECS` double DEFAULT NULL,
  `ONNET_THU_DRTN_SECS` double DEFAULT NULL,
  `ONNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_MON_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_WED_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_THU_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `INT_MON_DRTN_SECS` double DEFAULT NULL,
  `INT_TUE_DRTN_SECS` double DEFAULT NULL,
  `INT_WED_DRTN_SECS` double DEFAULT NULL,
  `INT_THU_DRTN_SECS` double DEFAULT NULL,
  `INT_FRI_DRTN_SECS` double DEFAULT NULL,
  `INT_SAT_DRTN_SECS` double DEFAULT NULL,
  `INT_SUN_DRTN_SECS` double DEFAULT NULL,
  `SN_TOTAL_MOC` double DEFAULT NULL,
  `SN_TOTAL_MTC` double DEFAULT NULL,
  `SN_ONNET_MOC` double DEFAULT NULL,
  `SN_ONNET_MTC` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN2` bigint(20) DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAU_MOC` double DEFAULT NULL,
  `SN_MAU_MTC` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAT_MOC` double DEFAULT NULL,
  `SN_MAT_MTC` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS2` double DEFAULT NULL,
  `SN_INT_MOC` double DEFAULT NULL,
  `SN_INT_MTC` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS2` double DEFAULT NULL,
  `MAIN_ACC_BAL` double DEFAULT NULL,
  `MAIN_ACC_EXP` text,
  `BONUS_ACC_BAL` double DEFAULT NULL,
  `BONUS_ACC_EXP` text,
  `BENEFIT_ACC_BAL` double DEFAULT NULL,
  `BENEFIT_ACC_EXP` text,
  `NATIONAL_BONUS_BAL` double DEFAULT NULL,
  `NATIONAL_BONUS_EXP` text,
  `RETURNEE_ACC_BAL` double DEFAULT NULL,
  `RETURNEE_ACC_EXP` text,
  `INTERNATIONAL_BENEFIT_BAL` double DEFAULT NULL,
  `INTERNATIONAL_BENEFIT_EXP` text,
  `ONNET_HOURS_BAL` double DEFAULT NULL,
  `ONNET_HOURS_EXP` text,
  `OFFNET_HOURS_BAL` double DEFAULT NULL,
  `OFFNET_HOURS_EXP` text,
  `DEDUCTION_BENEFIT_BAL` double DEFAULT NULL,
  `DEDUCTION_BENEFIT_EXP` text,
  `GIVEN_SMS_BAL` double DEFAULT NULL,
  `GIVEN_SMS_EXP` text,
  `DEDUCTION_SMS_BAL` double DEFAULT NULL,
  `DEDUCTION_SMS_EXP` text,
  `VOLUME_ACC_BAL` double DEFAULT NULL,
  `VOLUME_ACC_EXP` text,
  `VOLUME_3G_ACC_BAL` double DEFAULT NULL,
  `VOLUME_3G_ACC_EXP` text,
  `DEDUCTION_DATA_BAL` double DEFAULT NULL,
  `DEDUCTION_DATA_EXP` text,
  `NATIONAL_MONEY` double DEFAULT NULL,
  `ONNET_MONEY_ACC` double DEFAULT NULL,
  `ONNET_DURATION` double DEFAULT NULL,
  `GPRS_VOLUME` double DEFAULT NULL,
  `CELLID` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_details2`
--

DROP TABLE IF EXISTS `tre_details2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_details2` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` bigint(19) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `OPERATOR` varchar(100) DEFAULT NULL,
  `SUBSCRIBER_TYPE` varchar(100) DEFAULT NULL,
  `SIM_TYPE` varchar(100) DEFAULT NULL,
  `DECILE` bigint(19) DEFAULT NULL,
  `YEAR_WEEK` varchar(10) DEFAULT NULL,
  `ACTIVATION_DATE` timestamp NULL DEFAULT NULL,
  `SUB_DETAIL` varchar(50) DEFAULT NULL,
  `DEALER_CODE` varchar(50) DEFAULT NULL,
  `DISTRIBUTOR_CODE` varchar(100) DEFAULT NULL,
  `CUSTOMER_ID` varchar(50) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `CC_GPS_LAT` float(15,0) DEFAULT NULL,
  `CC_GPS_LONG` float(15,0) DEFAULT NULL,
  `LAST_EVENT_DATE` date DEFAULT NULL,
  `LAST_DATE_VCE_NAT` date DEFAULT NULL,
  `LAST_DATE_VCE_ONNET` date DEFAULT NULL,
  `LAST_DATE_VCE_OFFNET` date DEFAULT NULL,
  `LAST_DATE_VCE_INT` date DEFAULT NULL,
  `LAST_DATE_VCE_FIX` date DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MOC` date DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MTC` date DEFAULT NULL,
  `LAST_DATE_SMS_ONNET` date DEFAULT NULL,
  `LAST_DATE_SMS_OFFNET` date DEFAULT NULL,
  `LAST_DATE_SMS_INT` date DEFAULT NULL,
  `LAST_DATE_SMS_ROAM` date DEFAULT NULL,
  `LAST_DATE_DATA` date DEFAULT NULL,
  `LAST_DATE_DATA_LCL` date DEFAULT NULL,
  `LAST_DATE_DATA_ROAM` date DEFAULT NULL,
  `LAST_RECHARGE_DATE` date DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_NAT` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_VCE_FIX` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ROAM_MOC` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ROAM_MTC` decimal(24,6) DEFAULT NULL,
  `REV_VCE` decimal(24,6) DEFAULT NULL,
  `REV_VCE_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_VCE_MOC` decimal(24,6) DEFAULT NULL,
  `REV_VCE_MOC_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_SMS` decimal(24,6) DEFAULT NULL,
  `REV_SMS_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_SMS_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_SMS_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_SMS_INT` decimal(24,6) DEFAULT NULL,
  `REV_SMS_ROAM` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `REV_DATA_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_DATA_UPFRONT_BUNDLE` decimal(24,6) DEFAULT NULL,
  `REV_DATA_USAGE_BUNDLE` decimal(24,6) DEFAULT NULL,
  `REV_DATA_EXPIRED` decimal(24,6) DEFAULT NULL,
  `SEC_VCE_ALL_PAYG` decimal(36,18) DEFAULT NULL,
  `SEC_MOC_VCE` decimal(36,18) DEFAULT NULL,
  `SEC_MOC_PAYG` decimal(36,18) DEFAULT NULL,
  `ON_NET_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `ON_NET_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `OFF_NET_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `INT_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `INT_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `INT_MOC_COUNTRIES` bigint(19) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MTC_COUNTRIES` bigint(19) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `FIX_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `ROAM_MOC_SECS` decimal(36,18) DEFAULT NULL,
  `ROAM_MOC_COUNTER` bigint(19) DEFAULT NULL,
  `ROAM_MOC_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ROAM_MOC_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `ROAM_MTC_SECS` decimal(36,18) DEFAULT NULL,
  `ROAM_MTC_COUNTER` bigint(19) DEFAULT NULL,
  `ROAM_MTC_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ROAM_MTC_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `SMS_COUNT` bigint(19) DEFAULT NULL,
  `SMS_COUNT_PAYG` bigint(19) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT` bigint(19) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT_FREE` bigint(19) DEFAULT NULL,
  `VAS_REV` decimal(24,6) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_REV` decimal(24,6) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_REV` decimal(24,6) DEFAULT NULL,
  `VAS_CONTENT_S_REV` decimal(24,6) DEFAULT NULL,
  `VAS_ADVANCED_CR_REV` decimal(24,6) DEFAULT NULL,
  `VAS_VANITY_EX_REV` decimal(24,6) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_REV` decimal(24,6) DEFAULT NULL,
  `VAS_DONATION_REV` decimal(24,6) DEFAULT NULL,
  `VAS_COUNT` bigint(19) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_COUNT` bigint(19) DEFAULT NULL,
  `VAS_CONTENT_S_COUNT` bigint(19) DEFAULT NULL,
  `VAS_ADVANCED_CR_COUNT` bigint(19) DEFAULT NULL,
  `VAS_VANITY_EX_COUNT` bigint(19) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_COUNT` bigint(19) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_COUNT` bigint(19) DEFAULT NULL,
  `VAS_DONATION_COUNT` bigint(19) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `DATA_ALL_KB_PAYG` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_KB` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_CNT` bigint(19) DEFAULT NULL,
  `DATA_LOCAL_KB_FREE` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_CNT_FREE` bigint(19) DEFAULT NULL,
  `DATA_ROAM_KB` decimal(36,18) DEFAULT NULL,
  `DATA_ROAM_CNT` bigint(19) DEFAULT NULL,
  `DATA_ROAM_KB_FREE` decimal(36,18) DEFAULT NULL,
  `DATA_ROAM_CNT_FREE` bigint(19) DEFAULT NULL,
  `RCH_ALL_COUNT` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_SADAD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_SADAD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_CREDITCARD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_CREDITCARD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_ELOAD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_ELOAD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_STORE_COUNT` bigint(19) DEFAULT NULL,
  `RCH_STORE_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_VOUCHER_COUNT` bigint(19) DEFAULT NULL,
  `RCH_VOUCHER_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_10SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_10SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_20SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_20SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_30SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_30SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_50SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_50SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_100SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_100SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_SUN` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SUN` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_MON` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_MON` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_TUE` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_TUE` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_WED` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_WED` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_THU` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_THU` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_FRI` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_FRI` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_SAT` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SAT` decimal(24,6) DEFAULT NULL,
  `ACT_DAYS_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_NAT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_FIX` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_NAT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_FIX` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MOC` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MTC` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_ROAM` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA_LOCAL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA_ROAM` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `DATA_KB_SUN` decimal(36,18) DEFAULT NULL,
  `DATA_KB_MON` decimal(36,18) DEFAULT NULL,
  `DATA_KB_TUE` decimal(36,18) DEFAULT NULL,
  `DATA_KB_WED` decimal(36,18) DEFAULT NULL,
  `DATA_KB_THU` decimal(36,18) DEFAULT NULL,
  `DATA_KB_FRI` decimal(36,18) DEFAULT NULL,
  `DATA_KB_SAT` decimal(36,18) DEFAULT NULL,
  `INT_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `NAT_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `BOOSTER_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `REV_INTL_VCE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_NATIONAL_VOICE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_BOOSTER_VCE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `DATA_REGULAR_BUNDLES` bigint(19) DEFAULT NULL,
  `DATA_MIXED_BUNDLES` bigint(19) DEFAULT NULL,
  `DATA_BOOSTER_BUNDLES` bigint(19) DEFAULT NULL,
  `REV_DATA_REGULAR_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_DATA_MIXED_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_DATA_BOOSTER_BUNDLES` decimal(24,6) DEFAULT NULL,
  KEY `week_idx` (`WEEK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_details3`
--

DROP TABLE IF EXISTS `tre_details3`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_details3` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` bigint(19) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `OPERATOR` varchar(100) DEFAULT NULL,
  `SUBSCRIBER_TYPE` varchar(100) DEFAULT NULL,
  `SIM_TYPE` varchar(100) DEFAULT NULL,
  `DECILE` bigint(19) DEFAULT NULL,
  `YEAR_WEEK` varchar(10) DEFAULT NULL,
  `ACTIVATION_DATE` varchar(100) DEFAULT NULL,
  `SUB_DETAIL` varchar(50) DEFAULT NULL,
  `DEALER_CODE` varchar(50) DEFAULT NULL,
  `DISTRIBUTOR_CODE` varchar(100) DEFAULT NULL,
  `CUSTOMER_ID` varchar(50) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `CC_GPS_LAT` float(15,0) DEFAULT NULL,
  `CC_GPS_LONG` float(15,0) DEFAULT NULL,
  `LAST_EVENT_DATE` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_NAT` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_ONNET` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_OFFNET` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_FIX` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MOC` varchar(100) DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MTC` varchar(100) DEFAULT NULL,
  `LAST_DATE_SMS_ONNET` varchar(100) DEFAULT NULL,
  `LAST_DATE_SMS_OFFNET` varchar(100) DEFAULT NULL,
  `LAST_DATE_SMS_INT` varchar(100) DEFAULT NULL,
  `LAST_DATE_SMS_ROAM` varchar(100) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(100) DEFAULT NULL,
  `LAST_DATE_DATA_LCL` varchar(100) DEFAULT NULL,
  `LAST_DATE_DATA_ROAM` varchar(100) DEFAULT NULL,
  `LAST_RECHARGE_DATE` varchar(100) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_NAT` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_VCE_FIX` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ROAM_MOC` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ROAM_MTC` decimal(24,6) DEFAULT NULL,
  `REV_VCE` decimal(24,6) DEFAULT NULL,
  `REV_VCE_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_VCE_MOC` decimal(24,6) DEFAULT NULL,
  `REV_VCE_MOC_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_SMS` decimal(24,6) DEFAULT NULL,
  `REV_SMS_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_SMS_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_SMS_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_SMS_INT` decimal(24,6) DEFAULT NULL,
  `REV_SMS_ROAM` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `REV_DATA_PAYG` decimal(24,6) DEFAULT NULL,
  `REV_DATA_UPFRONT_BUNDLE` decimal(24,6) DEFAULT NULL,
  `REV_DATA_USAGE_BUNDLE` decimal(24,6) DEFAULT NULL,
  `REV_DATA_EXPIRED` decimal(24,6) DEFAULT NULL,
  `SEC_VCE_ALL_PAYG` decimal(36,18) DEFAULT NULL,
  `SEC_MOC_VCE` decimal(36,18) DEFAULT NULL,
  `SEC_MOC_PAYG` decimal(36,18) DEFAULT NULL,
  `ON_NET_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `ON_NET_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `OFF_NET_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `INT_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `INT_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `INT_MOC_COUNTRIES` bigint(19) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MTC_COUNTRIES` bigint(19) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY` varchar(255) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_CALLS` bigint(19) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_INCOMING_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_INCOMING_COUNTER` bigint(19) DEFAULT NULL,
  `FIX_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER` bigint(19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `ROAM_MOC_SECS` decimal(36,18) DEFAULT NULL,
  `ROAM_MOC_COUNTER` bigint(19) DEFAULT NULL,
  `ROAM_MOC_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ROAM_MOC_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `ROAM_MTC_SECS` decimal(36,18) DEFAULT NULL,
  `ROAM_MTC_COUNTER` bigint(19) DEFAULT NULL,
  `ROAM_MTC_SECS_FREE` decimal(36,18) DEFAULT NULL,
  `ROAM_MTC_COUNTER_FREE` bigint(19) DEFAULT NULL,
  `SMS_COUNT` bigint(19) DEFAULT NULL,
  `SMS_COUNT_PAYG` bigint(19) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT` bigint(19) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT_FREE` bigint(19) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT` bigint(19) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT_FREE` bigint(19) DEFAULT NULL,
  `VAS_REV` decimal(24,6) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_REV` decimal(24,6) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_REV` decimal(24,6) DEFAULT NULL,
  `VAS_CONTENT_S_REV` decimal(24,6) DEFAULT NULL,
  `VAS_ADVANCED_CR_REV` decimal(24,6) DEFAULT NULL,
  `VAS_VANITY_EX_REV` decimal(24,6) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_REV` decimal(24,6) DEFAULT NULL,
  `VAS_DONATION_REV` decimal(24,6) DEFAULT NULL,
  `VAS_COUNT` bigint(19) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_COUNT` bigint(19) DEFAULT NULL,
  `VAS_CONTENT_S_COUNT` bigint(19) DEFAULT NULL,
  `VAS_ADVANCED_CR_COUNT` bigint(19) DEFAULT NULL,
  `VAS_VANITY_EX_COUNT` bigint(19) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_COUNT` bigint(19) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_COUNT` bigint(19) DEFAULT NULL,
  `VAS_DONATION_COUNT` bigint(19) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `DATA_ALL_KB_PAYG` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_KB` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_CNT` bigint(19) DEFAULT NULL,
  `DATA_LOCAL_KB_FREE` decimal(36,18) DEFAULT NULL,
  `DATA_LOCAL_CNT_FREE` bigint(19) DEFAULT NULL,
  `DATA_ROAM_KB` decimal(36,18) DEFAULT NULL,
  `DATA_ROAM_CNT` bigint(19) DEFAULT NULL,
  `DATA_ROAM_KB_FREE` decimal(36,18) DEFAULT NULL,
  `DATA_ROAM_CNT_FREE` bigint(19) DEFAULT NULL,
  `RCH_ALL_COUNT` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_SADAD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_SADAD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_CREDITCARD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_CREDITCARD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_ELOAD_COUNT` bigint(19) DEFAULT NULL,
  `RCH_ELOAD_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_STORE_COUNT` bigint(19) DEFAULT NULL,
  `RCH_STORE_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_VOUCHER_COUNT` bigint(19) DEFAULT NULL,
  `RCH_VOUCHER_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_10SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_10SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_20SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_20SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_30SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_30SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_50SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_50SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_100SR_COUNT` bigint(19) DEFAULT NULL,
  `RCH_100SR_AMOUNT` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_SUN` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SUN` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_MON` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_MON` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_TUE` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_TUE` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_WED` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_WED` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_THU` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_THU` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_FRI` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_FRI` decimal(24,6) DEFAULT NULL,
  `RCH_ALL_COUNT_SAT` bigint(19) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SAT` decimal(24,6) DEFAULT NULL,
  `ACT_DAYS_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_NAT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_FIX` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ALL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_NAT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_FIX` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MOC` bigint(19) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MTC` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_ONNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_OFFNET` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_INT` bigint(19) DEFAULT NULL,
  `ACT_DAYS_SMS_ROAM` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA_LOCAL` bigint(19) DEFAULT NULL,
  `ACT_DAYS_DATA_ROAM` bigint(19) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SUN` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_MON` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_TUE` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_WED` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_THU` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FRI` decimal(36,18) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SAT` decimal(36,18) DEFAULT NULL,
  `DATA_KB_SUN` decimal(36,18) DEFAULT NULL,
  `DATA_KB_MON` decimal(36,18) DEFAULT NULL,
  `DATA_KB_TUE` decimal(36,18) DEFAULT NULL,
  `DATA_KB_WED` decimal(36,18) DEFAULT NULL,
  `DATA_KB_THU` decimal(36,18) DEFAULT NULL,
  `DATA_KB_FRI` decimal(36,18) DEFAULT NULL,
  `DATA_KB_SAT` decimal(36,18) DEFAULT NULL,
  `INT_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `NAT_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `BOOSTER_VCE_BUNDLES` bigint(19) DEFAULT NULL,
  `REV_INTL_VCE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_NATIONAL_VOICE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_BOOSTER_VCE_BUNDLES` decimal(24,6) DEFAULT NULL,
  `DATA_REGULAR_BUNDLES` bigint(19) DEFAULT NULL,
  `DATA_MIXED_BUNDLES` bigint(19) DEFAULT NULL,
  `DATA_BOOSTER_BUNDLES` bigint(19) DEFAULT NULL,
  `REV_DATA_REGULAR_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_DATA_MIXED_BUNDLES` decimal(24,6) DEFAULT NULL,
  `REV_DATA_BOOSTER_BUNDLES` decimal(24,6) DEFAULT NULL,
  KEY `week_idx` (`WEEK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_details4`
--

DROP TABLE IF EXISTS `tre_details4`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_details4` (
  `YEAR` int(4) DEFAULT NULL,
  `WEEK` int(2) DEFAULT NULL,
  `customer` int(7) DEFAULT NULL,
  `STATUS` varchar(6) DEFAULT NULL,
  `OPERATOR` varchar(13) DEFAULT NULL,
  `SUBSCRIBER_TYPE` varchar(15) DEFAULT NULL,
  `SIM_TYPE` varchar(8) DEFAULT NULL,
  `DECILE` int(2) DEFAULT NULL,
  `YEAR_WEEK` int(6) DEFAULT NULL,
  `ACTIVATION_DATE` varchar(0) DEFAULT NULL,
  `SUB_DETAIL` varchar(26) DEFAULT NULL,
  `DEALER_CODE` varchar(9) DEFAULT NULL,
  `DISTRIBUTOR_CODE` varchar(10) DEFAULT NULL,
  `CUSTOMER_ID` varchar(17) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(12) DEFAULT NULL,
  `CC_GPS_LAT` varchar(9) DEFAULT NULL,
  `CC_GPS_LONG` varchar(9) DEFAULT NULL,
  `LAST_EVENT_DATE` varchar(0) DEFAULT NULL,
  `LAST_DATE_VCE_NAT` varchar(0) DEFAULT NULL,
  `LAST_DATE_VCE_ONNET` varchar(10) DEFAULT NULL,
  `LAST_DATE_VCE_OFFNET` varchar(0) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(10) DEFAULT NULL,
  `LAST_DATE_VCE_FIX` varchar(10) DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MOC` varchar(10) DEFAULT NULL,
  `LAST_DATE_VCE_ROAM_MTC` varchar(10) DEFAULT NULL,
  `LAST_DATE_SMS_ONNET` varchar(10) DEFAULT NULL,
  `LAST_DATE_SMS_OFFNET` varchar(10) DEFAULT NULL,
  `LAST_DATE_SMS_INT` varchar(10) DEFAULT NULL,
  `LAST_DATE_SMS_ROAM` varchar(10) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(0) DEFAULT NULL,
  `LAST_DATE_DATA_LCL` varchar(10) DEFAULT NULL,
  `LAST_DATE_DATA_ROAM` varchar(0) DEFAULT NULL,
  `LAST_RECHARGE_DATE` varchar(10) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` float(8,7) DEFAULT NULL,
  `ARPU` float(10,9) DEFAULT NULL,
  `REV_VCE_NAT` float(10,9) DEFAULT NULL,
  `REV_VCE_ONNET` float(9,8) DEFAULT NULL,
  `REV_VCE_OFFNET` float(10,9) DEFAULT NULL,
  `REV_VCE_INT` float(8,7) DEFAULT NULL,
  `REV_VCE_FIX` float(8,7) DEFAULT NULL,
  `REV_VCE_ROAM_MOC` float(8,7) DEFAULT NULL,
  `REV_VCE_ROAM_MTC` float(8,7) DEFAULT NULL,
  `REV_VCE` float(10,9) DEFAULT NULL,
  `REV_VCE_PAYG` float(9,8) DEFAULT NULL,
  `REV_VCE_MOC` float(10,9) DEFAULT NULL,
  `REV_VCE_MOC_PAYG` float(9,8) DEFAULT NULL,
  `REV_SMS` float(9,8) DEFAULT NULL,
  `REV_SMS_PAYG` float(9,8) DEFAULT NULL,
  `REV_SMS_ONNET` float(8,7) DEFAULT NULL,
  `REV_SMS_OFFNET` float(8,7) DEFAULT NULL,
  `REV_SMS_INT` float(9,8) DEFAULT NULL,
  `REV_SMS_ROAM` float(8,7) DEFAULT NULL,
  `REV_DATA` float(10,9) DEFAULT NULL,
  `REV_DATA_PAYG` float(10,9) DEFAULT NULL,
  `REV_DATA_UPFRONT_BUNDLE` float(9,8) DEFAULT NULL,
  `REV_DATA_USAGE_BUNDLE` float(9,8) DEFAULT NULL,
  `REV_DATA_EXPIRED` float(8,7) DEFAULT NULL,
  `SEC_VCE_ALL_PAYG` float(24,20) DEFAULT NULL,
  `SEC_MOC_VCE` float(24,21) DEFAULT NULL,
  `SEC_MOC_PAYG` float(24,21) DEFAULT NULL,
  `ON_NET_INCOMING_SECS` float(23,22) DEFAULT NULL,
  `ON_NET_INCOMING_COUNTER` int(2) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` float(24,23) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER` int(2) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FREE` float(24,23) DEFAULT NULL,
  `ON_NET_OUTGOING_COUNTER_FREE` int(2) DEFAULT NULL,
  `OFF_NET_INCOMING_SECS` float(23,20) DEFAULT NULL,
  `OFF_NET_INCOMING_COUNTER` int(3) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` float(24,21) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER` int(3) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FREE` float(23,22) DEFAULT NULL,
  `OFF_NET_OUTGOING_COUNTER_FREE` int(2) DEFAULT NULL,
  `INT_INCOMING_SECS` float(23,22) DEFAULT NULL,
  `INT_INCOMING_COUNTER` int(1) DEFAULT NULL,
  `INT_OUTGOING_SECS` float(21,20) DEFAULT NULL,
  `INT_OUTGOING_COUNTER` int(1) DEFAULT NULL,
  `INT_OUTGOING_SECS_FREE` float(21,20) DEFAULT NULL,
  `INT_OUTGOING_COUNTER_FREE` int(1) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(1) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY` varchar(8) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_CALLS` int(1) DEFAULT NULL,
  `INT_TOP1_MOC_COUNTRY_SECS` float(21,20) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY` varchar(5) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_CALLS` int(1) DEFAULT NULL,
  `INT_TOP2_MOC_COUNTRY_SECS` float(21,20) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(1) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY` varchar(14) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_CALLS` int(1) DEFAULT NULL,
  `INT_TOP1_MTC_COUNTRY_SECS` float(23,22) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY` varchar(8) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_CALLS` int(1) DEFAULT NULL,
  `INT_TOP2_MTC_COUNTRY_SECS` float(20,19) DEFAULT NULL,
  `FIX_INCOMING_SECS` float(22,21) DEFAULT NULL,
  `FIX_INCOMING_COUNTER` int(1) DEFAULT NULL,
  `FIX_OUTGOING_SECS` float(22,21) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER` int(1) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FREE` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_COUNTER_FREE` int(1) DEFAULT NULL,
  `ROAM_MOC_SECS` float(20,19) DEFAULT NULL,
  `ROAM_MOC_COUNTER` int(1) DEFAULT NULL,
  `ROAM_MOC_SECS_FREE` float(20,19) DEFAULT NULL,
  `ROAM_MOC_COUNTER_FREE` int(1) DEFAULT NULL,
  `ROAM_MTC_SECS` float(20,19) DEFAULT NULL,
  `ROAM_MTC_COUNTER` int(1) DEFAULT NULL,
  `ROAM_MTC_SECS_FREE` float(20,19) DEFAULT NULL,
  `ROAM_MTC_COUNTER_FREE` int(1) DEFAULT NULL,
  `SMS_COUNT` int(5) DEFAULT NULL,
  `SMS_COUNT_PAYG` int(2) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT` int(1) DEFAULT NULL,
  `SMS_ONNET_OUTGOING_COUNT_FREE` int(1) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT` int(5) DEFAULT NULL,
  `SMS_OFFNET_OUTGOING_COUNT_FREE` int(5) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT` int(2) DEFAULT NULL,
  `SMS_INT_OUTGOING_COUNT_FREE` int(2) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT` int(1) DEFAULT NULL,
  `SMS_ROAM_MOC_COUNT_FREE` int(1) DEFAULT NULL,
  `VAS_REV` float(8,7) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_REV` float(8,7) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_REV` float(8,7) DEFAULT NULL,
  `VAS_CONTENT_S_REV` float(8,7) DEFAULT NULL,
  `VAS_ADVANCED_CR_REV` float(8,7) DEFAULT NULL,
  `VAS_VANITY_EX_REV` float(8,7) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_REV` float(8,7) DEFAULT NULL,
  `VAS_DONATION_REV` float(8,7) DEFAULT NULL,
  `VAS_COUNT` int(1) DEFAULT NULL,
  `VAS_GOOGLE_PLAY_COUNT` int(1) DEFAULT NULL,
  `VAS_CONTENT_S_COUNT` int(1) DEFAULT NULL,
  `VAS_ADVANCED_CR_COUNT` int(1) DEFAULT NULL,
  `VAS_VANITY_EX_COUNT` int(1) DEFAULT NULL,
  `VAS_INTL_CREDIT_T_COUNT` int(1) DEFAULT NULL,
  `VAS_LOCAL_CREDIT_T_COUNT` int(1) DEFAULT NULL,
  `VAS_DONATION_COUNT` int(1) DEFAULT NULL,
  `DATA_ALL_KB` float(26,25) DEFAULT NULL,
  `DATA_ALL_KB_PAYG` float(26,25) DEFAULT NULL,
  `DATA_LOCAL_KB` float(26,25) DEFAULT NULL,
  `DATA_LOCAL_CNT` int(3) DEFAULT NULL,
  `DATA_LOCAL_KB_FREE` float(26,25) DEFAULT NULL,
  `DATA_LOCAL_CNT_FREE` int(3) DEFAULT NULL,
  `DATA_ROAM_KB` float(20,19) DEFAULT NULL,
  `DATA_ROAM_CNT` int(1) DEFAULT NULL,
  `DATA_ROAM_KB_FREE` float(20,19) DEFAULT NULL,
  `DATA_ROAM_CNT_FREE` int(1) DEFAULT NULL,
  `RCH_ALL_COUNT` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT` float(10,9) DEFAULT NULL,
  `RCH_SADAD_COUNT` int(1) DEFAULT NULL,
  `RCH_SADAD_AMOUNT` float(10,9) DEFAULT NULL,
  `RCH_CREDITCARD_COUNT` int(1) DEFAULT NULL,
  `RCH_CREDITCARD_AMOUNT` float(8,7) DEFAULT NULL,
  `RCH_ELOAD_COUNT` int(1) DEFAULT NULL,
  `RCH_ELOAD_AMOUNT` float(8,7) DEFAULT NULL,
  `RCH_STORE_COUNT` int(1) DEFAULT NULL,
  `RCH_STORE_AMOUNT` float(8,7) DEFAULT NULL,
  `RCH_VOUCHER_COUNT` int(1) DEFAULT NULL,
  `RCH_VOUCHER_AMOUNT` float(9,8) DEFAULT NULL,
  `RCH_10SR_COUNT` int(1) DEFAULT NULL,
  `RCH_10SR_AMOUNT` float(9,8) DEFAULT NULL,
  `RCH_20SR_COUNT` int(1) DEFAULT NULL,
  `RCH_20SR_AMOUNT` float(9,8) DEFAULT NULL,
  `RCH_30SR_COUNT` int(1) DEFAULT NULL,
  `RCH_30SR_AMOUNT` float(8,7) DEFAULT NULL,
  `RCH_50SR_COUNT` int(1) DEFAULT NULL,
  `RCH_50SR_AMOUNT` float(9,8) DEFAULT NULL,
  `RCH_100SR_COUNT` int(1) DEFAULT NULL,
  `RCH_100SR_AMOUNT` float(10,9) DEFAULT NULL,
  `RCH_ALL_COUNT_SUN` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SUN` float(10,9) DEFAULT NULL,
  `RCH_ALL_COUNT_MON` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_MON` float(9,8) DEFAULT NULL,
  `RCH_ALL_COUNT_TUE` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_TUE` float(10,9) DEFAULT NULL,
  `RCH_ALL_COUNT_WED` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_WED` float(9,8) DEFAULT NULL,
  `RCH_ALL_COUNT_THU` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_THU` float(10,9) DEFAULT NULL,
  `RCH_ALL_COUNT_FRI` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_FRI` float(8,7) DEFAULT NULL,
  `RCH_ALL_COUNT_SAT` int(1) DEFAULT NULL,
  `RCH_ALL_AMOUNT_SAT` float(8,7) DEFAULT NULL,
  `ACT_DAYS_ALL` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ALL` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_NAT` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_FIX` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ALL` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_NAT` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_FIX` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MOC` int(1) DEFAULT NULL,
  `ACT_DAYS_VCE_ROAM_MTC` int(1) DEFAULT NULL,
  `ACT_DAYS_SMS_ONNET` int(1) DEFAULT NULL,
  `ACT_DAYS_SMS_OFFNET` int(1) DEFAULT NULL,
  `ACT_DAYS_SMS_INT` int(1) DEFAULT NULL,
  `ACT_DAYS_SMS_ROAM` int(1) DEFAULT NULL,
  `ACT_DAYS_DATA` int(1) DEFAULT NULL,
  `ACT_DAYS_DATA_LOCAL` int(1) DEFAULT NULL,
  `ACT_DAYS_DATA_ROAM` int(1) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SUN` float(23,22) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_MON` float(22,21) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_TUE` float(22,21) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_WED` float(23,22) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_THU` float(23,22) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_FRI` float(23,22) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS_SAT` float(22,21) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SUN` float(23,22) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_MON` float(23,22) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_TUE` float(23,22) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_WED` float(23,22) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_THU` float(23,21) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_FRI` float(22,20) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS_SAT` float(23,20) DEFAULT NULL,
  `INT_OUTGOING_SECS_SUN` float(20,19) DEFAULT NULL,
  `INT_OUTGOING_SECS_MON` float(21,20) DEFAULT NULL,
  `INT_OUTGOING_SECS_TUE` float(21,20) DEFAULT NULL,
  `INT_OUTGOING_SECS_WED` float(20,19) DEFAULT NULL,
  `INT_OUTGOING_SECS_THU` float(21,20) DEFAULT NULL,
  `INT_OUTGOING_SECS_FRI` float(20,19) DEFAULT NULL,
  `INT_OUTGOING_SECS_SAT` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SUN` float(22,21) DEFAULT NULL,
  `FIX_OUTGOING_SECS_MON` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_TUE` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_WED` float(21,20) DEFAULT NULL,
  `FIX_OUTGOING_SECS_THU` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_FRI` float(20,19) DEFAULT NULL,
  `FIX_OUTGOING_SECS_SAT` float(21,20) DEFAULT NULL,
  `DATA_KB_SUN` float(25,24) DEFAULT NULL,
  `DATA_KB_MON` float(25,24) DEFAULT NULL,
  `DATA_KB_TUE` float(25,24) DEFAULT NULL,
  `DATA_KB_WED` float(25,24) DEFAULT NULL,
  `DATA_KB_THU` float(25,24) DEFAULT NULL,
  `DATA_KB_FRI` float(25,24) DEFAULT NULL,
  `DATA_KB_SAT` float(25,24) DEFAULT NULL,
  `INT_VCE_BUNDLES` int(1) DEFAULT NULL,
  `NAT_VCE_BUNDLES` int(1) DEFAULT NULL,
  `BOOSTER_VCE_BUNDLES` int(1) DEFAULT NULL,
  `REV_INTL_VCE_BUNDLES` float(8,7) DEFAULT NULL,
  `REV_NATIONAL_VOICE_BUNDLES` float(8,7) DEFAULT NULL,
  `REV_BOOSTER_VCE_BUNDLES` float(9,8) DEFAULT NULL,
  `DATA_REGULAR_BUNDLES` int(1) DEFAULT NULL,
  `DATA_MIXED_BUNDLES` int(1) DEFAULT NULL,
  `DATA_BOOSTER_BUNDLES` int(1) DEFAULT NULL,
  `REV_DATA_REGULAR_BUNDLES` float(9,8) DEFAULT NULL,
  `REV_DATA_MIXED_BUNDLES` float(8,7) DEFAULT NULL,
  `REV_DATA_BOOSTER_BUNDLES` float(8,7) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_details_test`
--

DROP TABLE IF EXISTS `tre_details_test`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_details_test` (
  `COUNTRY` text,
  `OPCO` text,
  `Customer` bigint(20) DEFAULT NULL,
  `CHANNEL_CODE` text,
  `SUBSCRIBER_TYPE` text,
  `TARIFF_ID` bigint(20) DEFAULT NULL,
  `TARIFF_NAME` text,
  `CURRENT_SEGMENT` text,
  `DECILE` bigint(20) DEFAULT NULL,
  `NETWORKTYPE` text,
  `LAST_RGE_DT` text,
  `LAST_EVENT_DT` text,
  `LAST_RCHG_DT` text,
  `ACTIVATION_DT` text,
  `EXPECTED_CHURN_DT` text,
  `STATUS` text,
  `YEAR` bigint(20) DEFAULT NULL,
  `WEEK` int(11) DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_REV` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `ROAM_OUTGOING_REV` bigint(20) DEFAULT NULL,
  `ROAM_INCOMING_REV` bigint(20) DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `SMS_INT_MOC_BILLED_REV` bigint(20) DEFAULT NULL,
  `DATA_REV` bigint(20) DEFAULT NULL,
  `VAS_REV` bigint(20) DEFAULT NULL,
  `PRICE_PLAN_TOTAL` bigint(20) DEFAULT NULL,
  `PRICE_PLANS_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN` text,
  `TOP1_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP1_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP2_PLAN` text,
  `TOP2_PLAN_COUNT` int(11) DEFAULT NULL,
  `TOP2_PLAN_REV` bigint(20) DEFAULT NULL,
  `TOP3_PLAN` text,
  `TOP3_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `TOP3_PLAN_REV` bigint(20) DEFAULT NULL,
  `ALL_PLAN_COUNT` bigint(20) DEFAULT NULL,
  `ARPU` double DEFAULT NULL,
  `TOT_RCHG` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_ONNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_OFFNET_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_OFFNET_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_BILLED_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CODE` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CODE` double DEFAULT NULL,
  `COUNTRIES_MOC` double DEFAULT NULL,
  `TOP_OG_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_OG_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `COUNTRIES_MTC` double DEFAULT NULL,
  `TOP_IC_COUNTRY_CALLS` double DEFAULT NULL,
  `TOP_IC_COUNTRY_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_INT_MOC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MTC_FREE_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_DRTN_SEC` double DEFAULT NULL,
  `VCE_FIXED_MOC_BILLED_CALLS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_DRTN_SECS` double DEFAULT NULL,
  `VCE_FIXED_MOC_FREE_CALLS` double DEFAULT NULL,
  `ROAM_MOC_SECS` double DEFAULT NULL,
  `ROAM_MOC_COUNTER` double DEFAULT NULL,
  `ROAM_MOC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MOC_FREE_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_SECS` double DEFAULT NULL,
  `ROAM_MTC_COUNTER` double DEFAULT NULL,
  `ROAM_MTC_FREE_SECS` double DEFAULT NULL,
  `ROAM_MTC_FREE_COUNTER` double DEFAULT NULL,
  `SMS_ONNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_ONNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_OFFNET_MOC_FREE_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_BILLED_CNT` double DEFAULT NULL,
  `SMS_INT_MOC_FREE_CNT` double DEFAULT NULL,
  `MMS_REV` double DEFAULT NULL,
  `TOTAL_DATA_FREE_B` double DEFAULT NULL,
  `DATA_IN_FREE_B` double DEFAULT NULL,
  `DATA_OUT_FREE_B` double DEFAULT NULL,
  `DATA_FREE_DRTN_SECS` double DEFAULT NULL,
  `TOTAL_DATA_B` double DEFAULT NULL,
  `DATA_IN_BUNDLE_B` double DEFAULT NULL,
  `DATA_OUT_BUNDLE_B` double DEFAULT NULL,
  `DATA_SESSION_CNT` double DEFAULT NULL,
  `DATA_SESSION_DRTN_SECS` double DEFAULT NULL,
  `CRBT_CNT` double DEFAULT NULL,
  `CRBT_REV` double DEFAULT NULL,
  `ME2U_CNT` double DEFAULT NULL,
  `ME2U_REV` double DEFAULT NULL,
  `BT_I_CNT` double DEFAULT NULL,
  `BT_I_TOT` double DEFAULT NULL,
  `BT_O_CNT` double DEFAULT NULL,
  `BT_O_TOT` double DEFAULT NULL,
  `RCHG_ERECHARGE_CNT` double DEFAULT NULL,
  `RCHG_ERECHARGE_REV` double DEFAULT NULL,
  `RCHG_DIRECT_CNT` double DEFAULT NULL,
  `RCHG_DIRECT_REV` double DEFAULT NULL,
  `RCHG_CNT_VOUCHER` double DEFAULT NULL,
  `RCHG_REV_VOUCHER` double DEFAULT NULL,
  `RCHG_200_REV` double DEFAULT NULL,
  `RCHG_500_REV` double DEFAULT NULL,
  `RCHG_1000_REV` double DEFAULT NULL,
  `RCHG_2000_REV` double DEFAULT NULL,
  `RCHG_3000_REV` double DEFAULT NULL,
  `RCHG_5000_REV` double DEFAULT NULL,
  `RCHG_10000_REV` double DEFAULT NULL,
  `RCHG_200_CNT` double DEFAULT NULL,
  `RCHG_500_CNT` double DEFAULT NULL,
  `RCHG_1000_CNT` double DEFAULT NULL,
  `RCHG_2000_CNT` double DEFAULT NULL,
  `RCHG_3000_CNT` double DEFAULT NULL,
  `RCHG_5000_CNT` double DEFAULT NULL,
  `RCHG_10000_CNT` double DEFAULT NULL,
  `TOTAL_MAIN_COUNT` double DEFAULT NULL,
  `TOTAL_MAIN_RCHG` double DEFAULT NULL,
  `TOTAL_BONUS_COUNT` double DEFAULT NULL,
  `TOTAL_BONUS_RCHG` double DEFAULT NULL,
  `TOTAL_BENEFIT_COUNT` double DEFAULT NULL,
  `TOTAL_BENEFIT_RCHG` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_VCE_MTC_INT` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_ONNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_OFFNET` double DEFAULT NULL,
  `ACT_DAYS_SMS_MOC_INT` double DEFAULT NULL,
  `ACT_DAYS_DATA` double DEFAULT NULL,
  `ONNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_01_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_02_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_03_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_04_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_05_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_06_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_07_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_08_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_09_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_10_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_11_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_12_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_13_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_14_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_15_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_16_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_17_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_18_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_19_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_20_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_21_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_22_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_23_MOC_DRTN_SECS` double DEFAULT NULL,
  `INT_00_MOC_DRTN_SECS` double DEFAULT NULL,
  `ONNET_MON_DRTN_SECS` double DEFAULT NULL,
  `ONNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `ONNET_WED_DRTN_SECS` double DEFAULT NULL,
  `ONNET_THU_DRTN_SECS` double DEFAULT NULL,
  `ONNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `ONNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_MON_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_TUE_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_WED_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_THU_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_FRI_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SAT_DRTN_SECS` double DEFAULT NULL,
  `OFFNET_SUN_DRTN_SECS` double DEFAULT NULL,
  `INT_MON_DRTN_SECS` double DEFAULT NULL,
  `INT_TUE_DRTN_SECS` double DEFAULT NULL,
  `INT_WED_DRTN_SECS` double DEFAULT NULL,
  `INT_THU_DRTN_SECS` double DEFAULT NULL,
  `INT_FRI_DRTN_SECS` double DEFAULT NULL,
  `INT_SAT_DRTN_SECS` double DEFAULT NULL,
  `INT_SUN_DRTN_SECS` double DEFAULT NULL,
  `SN_TOTAL_MOC` double DEFAULT NULL,
  `SN_TOTAL_MTC` double DEFAULT NULL,
  `SN_ONNET_MOC` double DEFAULT NULL,
  `SN_ONNET_MTC` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_ONNET_MSISDN2` bigint(20) DEFAULT NULL,
  `SN_TOP_ONNET_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_ONNET_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAU_MOC` double DEFAULT NULL,
  `SN_MAU_MTC` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAU_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAU_MOC_CALLS2` double DEFAULT NULL,
  `SN_MAT_MOC` double DEFAULT NULL,
  `SN_MAT_MTC` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_MAT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_MAT_MOC_CALLS2` double DEFAULT NULL,
  `SN_INT_MOC` double DEFAULT NULL,
  `SN_INT_MTC` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS1` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS1` double DEFAULT NULL,
  `SN_TOP_INT_MSISDN2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_DRTN_SECS2` double DEFAULT NULL,
  `SN_TOP_INT_MOC_CALLS2` double DEFAULT NULL,
  `MAIN_ACC_BAL` double DEFAULT NULL,
  `MAIN_ACC_EXP` text,
  `BONUS_ACC_BAL` double DEFAULT NULL,
  `BONUS_ACC_EXP` text,
  `BENEFIT_ACC_BAL` double DEFAULT NULL,
  `BENEFIT_ACC_EXP` text,
  `NATIONAL_BONUS_BAL` double DEFAULT NULL,
  `NATIONAL_BONUS_EXP` text,
  `RETURNEE_ACC_BAL` double DEFAULT NULL,
  `RETURNEE_ACC_EXP` text,
  `INTERNATIONAL_BENEFIT_BAL` double DEFAULT NULL,
  `INTERNATIONAL_BENEFIT_EXP` text,
  `ONNET_HOURS_BAL` double DEFAULT NULL,
  `ONNET_HOURS_EXP` text,
  `OFFNET_HOURS_BAL` double DEFAULT NULL,
  `OFFNET_HOURS_EXP` text,
  `DEDUCTION_BENEFIT_BAL` double DEFAULT NULL,
  `DEDUCTION_BENEFIT_EXP` text,
  `GIVEN_SMS_BAL` double DEFAULT NULL,
  `GIVEN_SMS_EXP` text,
  `DEDUCTION_SMS_BAL` double DEFAULT NULL,
  `DEDUCTION_SMS_EXP` text,
  `VOLUME_ACC_BAL` double DEFAULT NULL,
  `VOLUME_ACC_EXP` text,
  `VOLUME_3G_ACC_BAL` double DEFAULT NULL,
  `VOLUME_3G_ACC_EXP` text,
  `DEDUCTION_DATA_BAL` double DEFAULT NULL,
  `DEDUCTION_DATA_EXP` text,
  `NATIONAL_MONEY` double DEFAULT NULL,
  `ONNET_MONEY_ACC` double DEFAULT NULL,
  `ONNET_DURATION` double DEFAULT NULL,
  `GPRS_VOLUME` double DEFAULT NULL,
  `CELLID` double DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  `ProjectId` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_opp_temp`
--

DROP TABLE IF EXISTS `tre_opp_temp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_opp_temp` (
  `CUSTOMER` bigint(20) DEFAULT NULL,
  `week` int(11) DEFAULT NULL,
  `DELTA` double DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_opportunity`
--

DROP TABLE IF EXISTS `tre_opportunity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_opportunity` (
  `CUSTOMER` varchar(50) DEFAULT NULL,
  `WEEK` int(11) DEFAULT NULL,
  `BO_DATA_DELTA` bigint(20) DEFAULT NULL,
  `BO_DATA_STATUS` varchar(50) DEFAULT NULL,
  `BO_DATA_PNTL` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_ONT_DELTA` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_ONT_STATUS` varchar(50) DEFAULT NULL,
  `BO_VOI_MOC_ONT_PNTL` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_OFT_DELTA` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_OFT_STATUS` varchar(50) DEFAULT NULL,
  `BO_VOI_MOC_OFT_PNTL` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_INT_DELTA` bigint(20) DEFAULT NULL,
  `BO_VOI_MOC_INT_STATUS` varchar(50) DEFAULT NULL,
  `BO_VOI_MOC_INT_PNTL` bigint(20) DEFAULT NULL,
  `BO_RCHG_DELTA` bigint(20) DEFAULT NULL,
  `BO_RCHG_STATUS` varchar(50) DEFAULT NULL,
  `BO_RCHG_PNTL` bigint(20) DEFAULT NULL,
  `BO_RETENTION_DELTA` bigint(20) DEFAULT NULL,
  `BO_RETENTION_STATUS` varchar(50) DEFAULT NULL,
  `BO_RETENTION_PNTL` bigint(20) DEFAULT NULL,
  KEY `customer` (`CUSTOMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_opportunityexport`
--

DROP TABLE IF EXISTS `tre_opportunityexport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_opportunityexport` (
  `customer` bigint(20) DEFAULT NULL,
  `Week` int(2) NOT NULL DEFAULT '0',
  `BO_DATA_DELTA` double DEFAULT NULL,
  `BO_DATA_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_DATA_PNTL` double DEFAULT NULL,
  `BO_VOI_MOC_ONT_DELTA` double DEFAULT NULL,
  `BO_VOI_MOC_ONT_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_VOI_MOC_ONT_PNTL` double DEFAULT NULL,
  `BO_VOI_MOC_OFT_DELTA` double DEFAULT NULL,
  `BO_VOI_MOC_OFT_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_VOI_MOC_OFT_PNTL` double DEFAULT NULL,
  `BO_VOI_MOC_INT_DELTA` double DEFAULT NULL,
  `BO_VOI_MOC_INT_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_VOI_MOC_INT_PNTL` double DEFAULT NULL,
  `BO_RCHG_DELTA` double DEFAULT NULL,
  `BO_RCHG_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_RCHG_PNTL` double DEFAULT NULL,
  `BO_RETENTION_DELTA` double DEFAULT NULL,
  `BO_RETENTION_STATUS` varchar(8) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `BO_RETENTION_PNTL` double DEFAULT NULL,
  KEY `TRE_OPPORTUNITYEXPORT` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_random`
--

DROP TABLE IF EXISTS `tre_random`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_random` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `HIST_DATA_FLAG` int(1) NOT NULL DEFAULT '0',
  `HIST_VOICE_MOC_INTL_FLAG` int(1) NOT NULL DEFAULT '0',
  KEY `ix_randomcustomer` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_random14`
--

DROP TABLE IF EXISTS `tre_random14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_random14` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(50) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `HIST_VOICE_MOC_INTL_FLAG` int(1) NOT NULL DEFAULT '0',
  `HIST_DATA_FLAG` int(1) NOT NULL DEFAULT '0',
  KEY `idx_randomcust` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_random15`
--

DROP TABLE IF EXISTS `tre_random15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_random15` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(50) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  KEY `idx_randomcust` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_random17`
--

DROP TABLE IF EXISTS `tre_random17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_random17` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `HISTORICAL_VOICE_MOC_INTL_FLAG` int(1) NOT NULL DEFAULT '0',
  `HISTORICAL_DATA_FLAG` int(1) NOT NULL DEFAULT '0',
  KEY `idx_randomcust` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_ranking`
--

DROP TABLE IF EXISTS `tre_ranking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_ranking` (
  `CUSTOMER` varchar(100) DEFAULT NULL,
  `RANK1_ACTION` varchar(100) DEFAULT NULL,
  `RANK2_ACTION` varchar(100) DEFAULT NULL,
  `RANK3_ACTION` varchar(100) DEFAULT NULL,
  `RANK4_ACTION` varchar(100) DEFAULT NULL,
  `RANK2` int(11) DEFAULT NULL,
  `RANK3` int(11) DEFAULT NULL,
  `RANK4` int(11) DEFAULT NULL,
  `RANK1` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_ranking0`
--

DROP TABLE IF EXISTS `tre_ranking0`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_ranking0` (
  `CUSTOMER` varchar(100) DEFAULT NULL,
  `RANK1_ACTION` varchar(100) DEFAULT NULL,
  `RANK2_ACTION` varchar(100) DEFAULT NULL,
  `RANK3_ACTION` varchar(100) DEFAULT NULL,
  `RANK4_ACTION` varchar(100) DEFAULT NULL,
  `RANK1` int(11) DEFAULT NULL,
  `RANK2` int(11) DEFAULT NULL,
  `RANK3` int(11) DEFAULT NULL,
  `RANK4` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_ranking14`
--

DROP TABLE IF EXISTS `tre_ranking14`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_ranking14` (
  `CUSTOMER` varchar(100) DEFAULT NULL,
  `RANK1_ACTION` varchar(100) DEFAULT NULL,
  `RANK2_ACTION` varchar(100) DEFAULT NULL,
  `RANK3_ACTION` varchar(100) DEFAULT NULL,
  `RANK4_ACTION` varchar(100) DEFAULT NULL,
  `RANK1` int(11) DEFAULT NULL,
  `RANK2` int(11) DEFAULT NULL,
  `RANK3` int(11) DEFAULT NULL,
  `RANK4` int(11) DEFAULT NULL,
  KEY `idx_rankingcust` (`CUSTOMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_ranking15`
--

DROP TABLE IF EXISTS `tre_ranking15`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_ranking15` (
  `CUSTOMER` varchar(100) DEFAULT NULL,
  `RANK1_ACTION` varchar(100) DEFAULT NULL,
  `RANK2_ACTION` varchar(100) DEFAULT NULL,
  `RANK3_ACTION` varchar(100) DEFAULT NULL,
  `RANK4_ACTION` varchar(100) DEFAULT NULL,
  `RANK1` int(11) DEFAULT NULL,
  `RANK2` int(11) DEFAULT NULL,
  `RANK3` int(11) DEFAULT NULL,
  `RANK4` int(11) DEFAULT NULL,
  KEY `idx_rankingcust` (`CUSTOMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_ranking17`
--

DROP TABLE IF EXISTS `tre_ranking17`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_ranking17` (
  `CUSTOMER` varchar(100) DEFAULT NULL,
  `RANK1_ACTION` varchar(100) DEFAULT NULL,
  `RANK2_ACTION` varchar(100) DEFAULT NULL,
  `RANK3_ACTION` varchar(100) DEFAULT NULL,
  `RANK4_ACTION` varchar(100) DEFAULT NULL,
  `RANK1` int(11) DEFAULT NULL,
  `RANK2` int(11) DEFAULT NULL,
  `RANK3` int(11) DEFAULT NULL,
  `RANK4` int(11) DEFAULT NULL,
  KEY `idx_rankingcust` (`CUSTOMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tre_timeperiod`
--

DROP TABLE IF EXISTS `tre_timeperiod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tre_timeperiod` (
  `TIMEPERIOD_ID` int(11) NOT NULL AUTO_INCREMENT,
  `T1` varchar(50) DEFAULT NULL,
  `T2` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`TIMEPERIOD_ID`),
  UNIQUE KEY `TIMEPERIOD_ID_UNIQUE` (`TIMEPERIOD_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `type_lookup`
--

DROP TABLE IF EXISTS `type_lookup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_lookup` (
  `CODE` varchar(3) DEFAULT NULL,
  `DESCRIPTION` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  PRIMARY KEY (`User_ID`),
  UNIQUE KEY `User_ID_UNIQUE` (`User_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vmksa_tre_details`
--

DROP TABLE IF EXISTS `vmksa_tre_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vmksa_tre_details` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(50) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vmksa_tre_details_v`
--

DROP TABLE IF EXISTS `vmksa_tre_details_v`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vmksa_tre_details_v` (
  `YEAR` varchar(10) DEFAULT NULL,
  `WEEK` varchar(6) DEFAULT NULL,
  `customer` int(11) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT NULL,
  `DECILE` int(11) DEFAULT NULL,
  `CUSTOMER_NATIONALITY` varchar(50) DEFAULT NULL,
  `LAST_DATE_VCE_INT` varchar(50) DEFAULT NULL,
  `LAST_DATE_DATA` varchar(50) DEFAULT NULL,
  `TOTAL_BALANCE_INITIAL` decimal(24,6) DEFAULT NULL,
  `ARPU` decimal(24,6) DEFAULT NULL,
  `REV_VCE_ONNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_OFFNET` decimal(24,6) DEFAULT NULL,
  `REV_VCE_INT` decimal(24,6) DEFAULT NULL,
  `REV_DATA` decimal(24,6) DEFAULT NULL,
  `ON_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `OFF_NET_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_OUTGOING_SECS` decimal(36,18) DEFAULT NULL,
  `INT_MOC_COUNTRIES` int(11) DEFAULT NULL,
  `INT_MTC_COUNTRIES` int(11) DEFAULT NULL,
  `DATA_ALL_KB` decimal(36,18) DEFAULT NULL,
  `RCH_ALL_AMOUNT` decimal(24,6) DEFAULT NULL,
  `HISTORICAL_VOICE_MOC_INTL_FLAG` int(1) NOT NULL DEFAULT '0',
  `HISTORICAL_DATA_FLAG` int(1) NOT NULL DEFAULT '0',
  `HIST_DATA_FLAG` int(1) NOT NULL DEFAULT '0',
  KEY `VMKSA_TRE_DETAILS_V_IX` (`customer`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'recousr'
--

--
-- Dumping routines for database 'recousr'
--
/*!50003 DROP FUNCTION IF EXISTS `CUSTOM_AUTH` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CUSTOM_AUTH`(p_username VARCHAR(4000), p_password VARCHAR(4000)) RETURNS tinyint(1)
begin
  declare l_password varchar(4000);
  declare l_stored_password varchar(4000);
  declare l_expires_on datetime;
  declare l_count double;
 

select count(*) into l_count from demo_users where user_name = p_username;
if l_count > 0 then
  
  select password, expires_on into l_stored_password, l_expires_on
   from demo_users where user_name = p_username;

  
  
  if l_expires_on > sysdate() or l_expires_on is null then

    
    
    set l_password = custom_hash(p_username, p_password);

    
    
    if l_password = l_stored_password then
      return true;
    else
      return false;
    end if;
  else
    return false;
  end if;
else
  
  return false;
end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `CUSTOM_HASH` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CUSTOM_HASH`(p_username varchar(4000), p_password varchar(4000)) RETURNS varchar(4000) CHARSET utf8mb4
begin
  declare l_password varchar(4000);
  declare l_salt varchar(4000)  DEFAULT  '3RNIWESWNSKHY0E04IV4ZHR1MJYTT0';
 






set l_password = MD5(concat(ifnull(p_password, '') , ifnull(substr(l_salt,10,13), '') , ifnull(p_username, '') ,
    ifnull(substr(l_salt, 4,10), '')));
return l_password;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `customranking` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `customranking`(IN `ProjectId` INT)
BEGIN
DECLARE oppname  varchar(50);
   DECLARE oppaction  varchar(50);
   DECLARE opp_cursor CURSOR FOR
   SELECT opp_name,opp_action  
   FROM opportunity  ot
   where ot.opp_name in
   (select rank1 from opportunity_ranking    where project_id=ProjectId 
   union 
   select rank2 from opportunity_ranking    where project_id=ProjectId 
   union
   select rank3 from opportunity_ranking    where project_id=ProjectId 
   union
   select rank4 from opportunity_ranking    where project_id=ProjectId 
   )
   and project_id=ProjectId;
   
   OPEN opp_cursor;
    Begin
  DECLARE finished int default 0;
     DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
    SET @sqlq:='';
   opp_loop: LOOP
	FETCH  opp_cursor INTO oppname,oppaction;
      IF finished THEN LEAVE opp_loop;
        END IF;
     SET @sqlq:= CONCAT( @sqlq ,' SELECT customer,',oppname,'_PNTL as ''Value'',');
	 SET @sqlq:= CONCAT( @sqlq,' Case  ',oppname, '_PNTL');
       SET @sqlq:= CONCAT( @sqlq,' WHEN NULL THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' WHEN 0 THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' ELSE CASE ');
	 SET @sqlq:= CONCAT( @sqlq,' WHEN  ''',oppaction,'''= ''STIMULATION''');
     SET @sqlq:= CONCAT( @sqlq,' THEN    CASE ' ,oppname,'_STATUS');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NON USER'' Then ''X-SELL-',oppname,'''');
     SET @sqlq:= CONCAT( @sqlq,'  WHEN	 ''DROPPER'' Then ''MITIGATE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''STOPPER'' Then ''REVIVE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''GROWER'' Then ''NO-ACTION-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''FLAT'' Then ''UP-SELL-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NEW USER'' Then ''NO ACTION''');
     SET @sqlq:=CONCAT( @sqlq,'  END');
	 SET @sqlq:=CONCAT( @sqlq,'  ELSE ');
     SET @sqlq:= CONCAT( @sqlq,'''',oppaction ,'-',oppname ,''' END   END AS RankAction  FROM  TRE_OPPORTUNITYEXPORT ');
     SET @sqlq:=CONCAT( @sqlq,' UNION ALL ');
	 END LOOP opp_loop;
     close opp_cursor;
     END;
	 SET @sqlq:=SUBSTRING(@sqlq, 1,LENGTH(@sqlq)-10);
 select @sqlq;
  SET @sql:='create temporary table TotalCustomRankTemp (INDEX TotalRankTemp_IX (Customer)) as Select A.customer,A.Value,A.Rankaction,Ranking from  ( SELECT b.customer,b.Value,B.Rankaction,@country_rank := IF(@current_country = customer,  @country_rank + 1,  1 ) AS Ranking, @current_country := customer  from (';
 SET @sql:=CONCAT(@sql,@sqlq,' )B order by customer');
 select @sql;
  
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CUSTOMRANK_SELECTION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CUSTOMRANK_SELECTION`(
      in customer int,
      out oppRank1 int,
      out oppRank2 int,
      out oppRank3 int,
      out oppRank4 int,
       INOUT Cntr int ,
      INOUT oppRankName1 varchar(100),
      INOUT oppRankName2 varchar(100),
      INOUT oppRankName3 varchar(100),
      INOUT oppRankName4  varchar(100),
      out oppRank1Status varchar(100),
      out oppRank2Status varchar(100),
      out oppRank3Status varchar(100),
      out oppRank4Status varchar(100)
  )
Begin
    Set Cntr=0;
            Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
        SET oppRank1=0;
        SET oppRankName1='';
        END;
         select case when Opp_Pntl IS NULL then 0 else Opp_Pntl end INTO oppRank1 from  CUSTOMER_PnTl  where Opp_Name=oppRankName1;
                 end;
         if oppRank1=0 then Set Cntr= Cntr+1; end if;
             Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
        SET oppRank2=0;
        SET oppRankName2='';
        END; 
         select case when OPP_pntl IS NULL then 0 else Opp_Pntl end INTO oppRank2 from  CUSTOMER_PnTl where Opp_Name=oppRankName2;
               end;
               if oppRank2=0 then Set Cntr= Cntr+1; end if;
            Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
        SET oppRank3=0;
        SET oppRankName3='';
        END; select case when Opp_Pntl IS NULL then 0 else Opp_Pntl end INTO oppRank3 from  CUSTOMER_PnTl where Opp_Name=oppRankName3;
                end;
                 if oppRank3=0 then Set Cntr= Cntr+1; end if;
                 Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
        SET oppRank4=0;
        SET oppRankName4='';
        END;
        select case when Opp_Pntl IS NULL then 0 else Opp_Pntl end INTO oppRank4 from  CUSTOMER_PnTl where Opp_Name=oppRankName4;
                end;
         if oppRank4=0 then Set Cntr= Cntr+1; end if;
      
       Begin
      CASE 
      
      when Cntr = 0  Then
          SET oppRankName1=oppRankName1;
           SET oppRank1=oppRank1;
           SET oppRankName2=oppRankName2;
            SET oppRank2=oppRank2;
           SET oppRankName3=oppRankName3;
            SET oppRank3=oppRank3;
           SET oppRankName4=oppRankName4;
            SET oppRank4=oppRank4;
      
        when Cntr =  1   Then
            
      if( OppRank1=0 and OppRank2!=0 and OppRank3!=0 and OppRank4!=0 )Then
           SET oppRankName1=oppRankName2;
           SET oppRank1=oppRank2;
           SET oppRankName2=oppRankName3;
            SET oppRank2=oppRank3;
           SET oppRankName3=oppRankName4;
            SET oppRank3=oppRank4;
           
      ELSEIF ( OppRank1!=0 and OppRank2=0 and OppRank3!=0 and OppRank4!=0 )Then
           SET oppRankName2=oppRankName3;
            SET oppRank2=oppRank3;
           SET oppRankName3=oppRankName4;
            SET oppRank3=oppRank4;
     
      ELSEIF ( OppRank1!=0 and OppRank2!=0 and OppRank3=0 and OppRank4!=0 )Then
        SET oppRankName3=oppRankName4;
        SET oppRank3=oppRank4;
           end if;
          Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
        SET oppRank4=0;
        SET oppRankName4='';
        END;
        select Opp_Pntl,Opp_Name INTO oppRank4, oppRankName4  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1,oppRankName2,oppRankName3)  order by Opp_Pntl  desc)
         s2 
limit 1)as rm where rm >= 1;
                END;
        
       
        when Cntr =  2   Then
       if( OppRank1=0 and OppRank2=0 and OppRank3!=0 and OppRank4!=0 )Then
          SET oppRankName1=oppRankName3;
           SET oppRank1=oppRank3;
         SET oppRankName2=oppRankName4;
           SET oppRank2=oppRank4;
      ELSEIF ( OppRank1=0 and OppRank2!=0 and OppRank3=0 and OppRank4!=0 )Then
        SET oppRankName1=oppRankName2;
         SET oppRank1=oppRank2;
       SET oppRankName2=oppRankName4;
        SET oppRank2=oppRank4;
       ELSEIF ( OppRank1=0 and OppRank2!=0 and OppRank3!=0 and OppRank4=0 )Then
         SET oppRankName1=oppRankName2;
         SET oppRank1=oppRank2;
         SET oppRankName2=oppRankName3;
         SET oppRank2=oppRank3;
      ELSEIF ( OppRank1!=0 and OppRank2=0 and OppRank3=0 and OppRank4!=0 )Then
         SET oppRankName2=oppRankName4;
         SET oppRank2=oppRank4;
      ELSEIF ( OppRank1!=0  and OppRank2=0 and OppRank3!=0 and OppRank4=0 )Then
         SET oppRankName2=oppRankName3;
         SET oppRank2=oppRank3;
       end if;
       Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
       SET oppRank3=0;
       SET oppRankName3='';
        END;
      select Opp_Pntl,Opp_Name INTO oppRank3, oppRankName3  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1,oppRankName2)  order by Opp_Pntl  desc)
        s2 
limit 1)as rm where rm >= 1;
               END;
           Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
       SET oppRank4=0;
       SET oppRankName4='';
        END;
      select Opp_Pntl,Opp_Name INTO oppRank4, oppRankName4  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1,oppRankName2)  order by Opp_Pntl  desc)
        s2 
limit 2)as rm where rm >= 2;
               END;
           
     when Cntr = 3 then
      
        if( OppRank1=0 and OppRank2=0 and OppRank3=0 and OppRank4!=0 )Then
          SET oppRankName1=oppRankName4;
          SET oppRank1=oppRank4;
                   
       ELSEIF ( OppRank1=0 and OppRank2=0 and OppRank3!=0 and OppRank4=0 )Then
        SET oppRankName1=oppRankName3;
        SET oppRank1=oppRank3;
             
       ELSEIF ( OppRank1=0 and OppRank2!=0 and OppRank3=0 and OppRank4=0 )Then
         SET oppRankName1=oppRankName2;
          SET oppRank1=oppRank2;
         
         End  if;
          Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
       SET oppRank2=0;
       SET oppRankName2='';
        END;
      select Opp_Pntl,Opp_Name INTO oppRank2, oppRankName2 from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1)  order by Opp_Pntl  desc)
        s2 
limit 1)as rm where rm >= 1;
               END;
           Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
       SET oppRank4=0;
       SET oppRankName4='';
        END;
      select Opp_Pntl,Opp_Name INTO oppRank3, oppRankName3  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1)  order by Opp_Pntl  desc)
        s2 
limit 2) as rm where rm >= 2;
               END;
       Begin
        DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
       SET oppRank4=0;
       SET oppRankName4='';
        END;
      select Opp_Pntl,Opp_Name INTO oppRank4, oppRankName4  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
        (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0 and Opp_Name NOT IN (oppRankName1)  order by Opp_Pntl  desc)
        s2 
limit 3)as rm where rm >= 3;
               END;
      when Cntr =  4   Then  
            Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank1=0;
     SET oppRankName1='';
      END;
      select Opp_Pntl,Opp_Name INTO oppRank1, oppRankName1  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
      (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc)
      s2 
limit 1)as rm where rm >= 1;
           END;
      Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank2=0;
     SET oppRankName2='';
      END;
      select  Opp_Pntl,Opp_Name INTO oppRank2, oppRankName2  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
      (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc)
      s2 
limit 2)as rm where rm >= 2;
           END;
         Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank3=0;
     SET oppRankName3='';
      END;
      select  Opp_Pntl,Opp_Name INTO oppRank3, oppRankName3  from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
      (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc)
      s2 
limit 3)as rm where rm >= 3;
           END;
      Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank4=0;
     SET oppRankName4='';
      END;
      select  Opp_Pntl,Opp_Name INTO oppRank4, oppRankName4 from (select s2.Opp_Pntl,s2.Opp_Name,rownum rm from
      (select  Opp_Pntl,Opp_Name from CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc)
      s2 
limit 4)as rm where rm >= 4;
           END;
    END CASE;
    END;
     if oppRank1=0 then SET oppRank1Status = 'No Opportunity';
      Else 
      SELECT OPP_ACTION  INTO oppRank1Status  FROM Opportunity WHERE OPP_NAME= oppRankName1;      END IF;
      if oppRank2=0 then SET oppRank2Status = 'No Opportunity';
      Else 
         SELECT OPP_ACTION  INTO oppRank2Status  FROM Opportunity WHERE OPP_NAME= oppRankName2;      END IF;
      if oppRank3=0 then SET oppRank3Status = 'No Opportunity';
      Else 
       SELECT OPP_ACTION  INTO oppRank3Status  FROM Opportunity WHERE OPP_NAME= oppRankName3;      END IF;
      if oppRank4=0 then SET oppRank4Status = 'No Opportunity';
      Else 
      SELECT OPP_ACTION  INTO oppRank4Status  FROM Opportunity WHERE OPP_NAME= oppRankName4;      END IF;
      
      if oppRank1Status='STIMULATION' then
      Select Opp_Status into oppRank1Status from CUSTOMER_Pntl where Opp_NAME=oppRankName1;
      elseif oppRank1Status='RECOMMEND' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='REPLICATE' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('REPLICATE','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='REACTIVATE' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='RETAIN' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('RETAIN','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='SATISFY' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('SATISFY','-',IFNULL(oppRankName1, ''));
      end if;
      if oppRank2Status='STIMULATION' then
      Select Opp_Status into oppRank2Status from CUSTOMER_Pntl where Opp_NAME=oppRankName2;
      elseif oppRank2Status='RECOMMEND' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName2, ''));
      elseif oppRank1Status='REPLICATE' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('REPLICATE','-',IFNULL(oppRankName2, ''));
      elseif oppRank1Status='REACTIVATE' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName2, ''));
      elseif oppRank2Status='RETAIN' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('RETAIN','-',IFNULL(oppRankName2, ''));
      elseif oppRank2Status='SATISFY' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('SATISFY','-',IFNULL(oppRankName2, ''));
      end if;
      if oppRank3Status='STIMULATION' then
      Select Opp_Status into oppRank3Status from CUSTOMER_Pntl where Opp_NAME=oppRankName3;
      elseif oppRank3Status='RECOMMEND' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='REPLICATE' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('REPLICATE','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='REACTIVATE' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='RETAIN' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('RETAIN','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='SATISFY' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('SATISFY','-',IFNULL(oppRankName3, ''));
      end if;
      if oppRank4Status='STIMULATION' then
      Select Opp_Status into oppRank4Status from CUSTOMER_Pntl where Opp_NAME=oppRankName4;
      elseif oppRank4Status='RECOMMEND' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='REPLICATE' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('REPLICATE','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='REACTIVATE' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='RETAIN' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('RETAIN','-',IFNULL(oppRankName4, ''));
      elseif oppRank1Status='SATISFY' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('SATISFY','-',IFNULL(oppRankName4, ''));
      end if;
      Insert into Tre_Ranking (CUSTOMER,RANK1,RANK1_ACTION,RANK2,RANK2_ACTION,RANK3,RANK3_ACTION,RANK4,RANK4_ACTION) Values
      (customer,oppRank1,oppRank1Status,oppRank2,oppRank2Status,oppRank3,oppRank3Status,oppRank4,oppRank4Status);
      end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertTreRanking` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertTreRanking`(IN `ProjectId` INT)
BEGIN
   DECLARE oppname  varchar(50);
   DECLARE oppaction  varchar(50);
   DECLARE opp_cursor CURSOR FOR
   SELECT opp_name,opp_action  FROM opportunity where project_id=ProjectId;
   OPEN opp_cursor;
    Begin
  DECLARE finished int default 0;
     DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
    SET @sqlq:='';
   opp_loop: LOOP
	FETCH  opp_cursor INTO oppname,oppaction;
      IF finished THEN LEAVE opp_loop;
        END IF;
     SET @sqlq:= CONCAT( @sqlq ,' SELECT customer,',oppname,'_PNTL as ''Value'',');
	 SET @sqlq:= CONCAT( @sqlq,' Case  ',oppname, '_PNTL');
       SET @sqlq:= CONCAT( @sqlq,' WHEN NULL THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' WHEN 0 THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' ELSE CASE ');
	 SET @sqlq:= CONCAT( @sqlq,' WHEN  ''',oppaction,'''= ''STIMULATION''');
     SET @sqlq:= CONCAT( @sqlq,' THEN    CASE ' ,oppname,'_STATUS');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NON_USER'' Then ''X-SELL-',oppname,'''');
     SET @sqlq:= CONCAT( @sqlq,'  WHEN	 ''DROPPER'' Then ''MITIGATE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''STOPPER'' Then ''REVIVE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''GROWER'' Then ''NO-ACTION-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''FLAT'' Then ''UP-SELL-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NEW_USER'' Then ''NO ACTION''');
     SET @sqlq:=CONCAT( @sqlq,'  END');
	 SET @sqlq:=CONCAT( @sqlq,'  ELSE ');
     SET @sqlq:= CONCAT( @sqlq,'''',oppaction ,'-',oppname ,''' END   END AS RankAction  FROM  TRE_OPPORTUNITY ');
     SET @sqlq:=CONCAT( @sqlq,' UNION ALL ');
	 END LOOP opp_loop;
     close opp_cursor;
     END;
	 SET @sqlq:=SUBSTRING(@sqlq, 1,LENGTH(@sqlq)-10);

  SET @sql:='create temporary table TotalRankTemp (INDEX TotalRankTemp_IX (Customer)) as Select A.customer,A.Value,A.Rankaction,Ranking from  ( SELECT b.customer,b.Value,B.Rankaction,@country_rank := IF(@current_country = customer,  @country_rank + 1,  1 ) AS Ranking, @current_country := customer  from (';
 SET @sql:=CONCAT(@sql,@sqlq,' )B order by customer, Value desc ) A where Ranking <=4');
 select @sql;
  PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;

create temporary table Rank1Temp (INDEX Rank1Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =1;

create temporary table Rank2Temp (INDEX Rank2Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =2;

create temporary table Rank3Temp (INDEX Rank3Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =3;

create temporary table Rank4Temp (INDEX Rank4Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =4;

TRUNCATE TABLE TRE_RANKING;

insert into recousr.tre_ranking( 
SELECT ed.customer,ed.Rankaction as Rank1_Action,emd.Rankaction as Rank2_Action,
 te.Rankaction as Rank3_Action,temp.Rankaction as Rank4_Action,
emd.value as Rank2,
 te.value as Rank3,
 temp.value as Rank4,
  ed.value as Rank1
FROM recousr.Rank1Temp AS ed
LEFT JOIN recousr.Rank2Temp AS emd ON emd.customer = ed.customer 
LEFT JOIN recousr.Rank3Temp AS te ON te.customer = ed.customer
LEFT JOIN recousr.Rank4Temp AS temp ON temp.customer = ed.customer
);
drop table  TotalRankTemp;
drop table  Rank1Temp;
drop table  Rank2Temp;
drop table  Rank3Temp;
drop table  Rank4Temp;

 END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertTreRanking_base` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertTreRanking_base`(IN `ProjectId` INT)
BEGIN
   DECLARE oppname  varchar(50);
   DECLARE oppaction  varchar(50);
   DECLARE opp_cursor CURSOR FOR
   SELECT opp_name,opp_action  FROM opportunity where project_id=ProjectId;
   OPEN opp_cursor;
    Begin
  DECLARE finished int default 0;
     DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
    SET @sqlq:='';
   opp_loop: LOOP
	FETCH  opp_cursor INTO oppname,oppaction;
      IF finished THEN LEAVE opp_loop;
        END IF;
     SET @sqlq:= CONCAT( @sqlq ,' SELECT customer,',oppname,'_PNTL as ''Value'',');
	 SET @sqlq:= CONCAT( @sqlq,' Case  ',oppname, '_PNTL');
	 SET @sqlq:= CONCAT( @sqlq,' WHEN NULL THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' WHEN 0 THEN ''No Opportunity''');
     SET @sqlq:= CONCAT( @sqlq,' ELSE CASE ');
	 SET @sqlq:= CONCAT( @sqlq,' WHEN  ''',oppaction,'''= ''STIMULATION''');
     SET @sqlq:= CONCAT( @sqlq,' THEN    CASE ' ,oppname,'_STATUS');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NON USER'' Then ''X-SELL-',oppname,'''');
     SET @sqlq:= CONCAT( @sqlq,'  WHEN	 ''DROPPER'' Then ''MITIGATE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''STOPPER'' Then ''REVIVE-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''GROWER'' Then ''NO-ACTION-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''FLAT'' Then ''UP-SELL-',oppname,'''');
	 SET @sqlq:=CONCAT( @sqlq,'  WHEN	 ''NEW USER'' Then ''NO ACTION''');
     SET @sqlq:=CONCAT( @sqlq,'  END');
	 SET @sqlq:=CONCAT( @sqlq,'  ELSE ');
     SET @sqlq:= CONCAT( @sqlq,'''',oppaction ,'-',oppname ,''' END   END AS RankAction  FROM  TRE_OPPORTUNITYEXPORT ');
     SET @sqlq:=CONCAT( @sqlq,' UNION ALL ');
	 END LOOP opp_loop;
     close opp_cursor;
     END;
	 SET @sqlq:=SUBSTRING(@sqlq, 1,LENGTH(@sqlq)-10);

  SET @sql:='create temporary table TotalRankTemp (INDEX TotalRankTemp_IX (Customer)) as Select A.customer,A.Value,A.Rankaction,Ranking from  ( SELECT b.customer,b.Value,B.Rankaction,@country_rank := IF(@current_country = customer,  @country_rank + 1,  1 ) AS Ranking, @current_country := customer  from (';
 SET @sql:=CONCAT(@sql,@sqlq,' )B order by customer, Value desc ) A where Ranking <=4');
 select @sql;
  PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;

create temporary table Rank1Temp (INDEX Rank1Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =1;

create temporary table Rank2Temp (INDEX Rank2Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =2;

create temporary table Rank3Temp (INDEX Rank3Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =3;

create temporary table Rank4Temp (INDEX Rank4Temp_IX (Customer)) as
select * from TotalRankTemp where Ranking =4;
SET @sql:=CONCAT( 'TRUNCATE TABLE TRE_RANKING',ProjectId);
   PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;

   SET @sql:=CONCAT( 'insert into recousr.tre_ranking',ProjectId,'(');
   SET @sql:=CONCAT(@sql,' SELECT ed.customer,ed.Rankaction as Rank1_Action,emd.Rankaction as Rank2_Action,te.Rankaction as Rank3_Action,temp.Rankaction as Rank4_Action, ed.Value as Rank1, emd.Value as Rank2, te.Value as Rank3, temp.Value as Rank4 FROM recousr.Rank1Temp AS ed LEFT JOIN recousr.Rank2Temp AS emd ON emd.customer = ed.customer');
   SET @sql:=CONCAT(@sql,' LEFT JOIN recousr.Rank3Temp AS te ON te.customer = ed.customer');
    SET @sql:=CONCAT(@sql,' LEFT JOIN recousr.Rank4Temp AS temp ON temp.customer = ed.customer',')');
PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;
drop table  TotalRankTemp;
drop table  Rank1Temp;
drop table  Rank2Temp;
drop table  Rank3Temp;
drop table  Rank4Temp;
 END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertTreRanking_export` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertTreRanking_export`(IN `ProjectId` INT)
BEGIN
    DECLARE oppRank1 int;
    DECLARE oppRank2 int;
    DECLARE oppRank3 int;
    DECLARE oppRank4 int;
    DECLARE oppRankName1 varchar(100);
    DECLARE oppRankName2 varchar(100);
    DECLARE oppRankName3 varchar(100);
    DECLARE oppRankName4  varchar(100);
	DECLARE oppRank1Status varchar(100);
    DECLARE oppRank2Status varchar(100);
    DECLARE oppRank3Status varchar(100);
    DECLARE oppRank4Status varchar(100);
   
   DECLARE oppname  varchar(50);
   DECLARE custmr  bigint;
DECLARE  ttl_cursor  CURSOR FOR   
     SELECT CUSTOMER FROM Tre_OpportunityExport;
   DECLARE opp_cursor CURSOR FOR
     SELECT opp_name FROM opportunity where project_id=ProjectId;
 OPEN opp_cursor;
OPEN ttl_cursor;
  begin
  DECLARE finished int default 0;
     DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = 1;
    SET @sql:='';
  
      opp_loop: LOOP
     
     FETCH  opp_cursor INTO oppname;
      IF finished THEN LEAVE opp_loop;
        END IF;
    SET @table_name:=oppname;
	SET @sql:=CONCAT( @sql ,'  ','  SELECT ''',@table_name,''', ',@table_name,'_Pntl , ');
	SET @sql:=CONCAT(@sql,'   CASE  When ',@table_name,'_STATUS= ''NON_USER'' Then ''X-SELL-',@table_name,'''');
	SET @sql:=CONCAT(@sql,'   When ',@table_name,'_STATUS= ''DROPPER'' Then ''MITIGATE-',@table_name,'''');
	SET @sql:=CONCAT(@sql,'   When ',@table_name,'_STATUS= ''STOPPER'' Then ''REVIVE-',@table_name,'''');
	SET @sql:=CONCAT(@sql,'   When ',@table_name,'_STATUS= ''GROWER'' Then ''NO ACTION-',@table_name,'''');
	SET @sql:=CONCAT(@sql,'   When ',@table_name,'_STATUS= ''FLAT'' Then ''UP-SELL-',@table_name,'''');
	SET @sql:=CONCAT(@sql,'   When ',@table_name,'_STATUS= ''NEW_USER'' Then ''NO ACTION'' END');
	SET @sql:=CONCAT(@sql,'  FROM TRE_OPPORTUNITYEXPORT WHERE CUSTOMER=@customer');
	SET @sql:=CONCAT(@sql,' UNION ');
	END LOOP opp_loop;
	SET @sql:=CONCAT(' Insert into CUSTOMER_PNTL (OPP_NAME,OPP_PNTL,Opp_Status)  ',@sql);
      SET @sql:=SUBSTRING(@sql, 1,LENGTH(@sql)-6);

Begin
   DECLARE done int default 0;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
   ttl_loop: LOOP
      FETCH  ttl_cursor INTO custmr;
      IF done THEN leave ttl_loop;
        END IF;
         set @customer=custmr;
   PREPARE dynamic_statement FROM @sql;  
	EXECUTE dynamic_statement;
	DEALLOCATE PREPARE dynamic_statement;
    call RANK_SELECTION(@customer,oppRank1,oppRank2,oppRank3,oppRank4,oppRankName1,oppRankName2,oppRankName3,oppRankName4,oppRank1Status,oppRank2Status,oppRank3Status,oppRank4Status);
   Delete from Customer_pntl;
   END LOOP ttl_loop;
  end;
  end;
close ttl_cursor;
close opp_cursor;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RANK_SELECTION` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RANK_SELECTION`(
      in customer bigint,
      out oppRank1 int,
      out oppRank2 int,
      out oppRank3 int,
      out oppRank4 int,
      out oppRankName1 varchar(100),
      out oppRankName2 varchar(100),
      out oppRankName3 varchar(100),
      out oppRankName4  varchar(100),
      out oppRank1Status varchar(100),
      out oppRank2Status varchar(100),
      out oppRank3Status varchar(100),
      out oppRank4Status varchar(100)
      )
Begin
      Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank1=0;
     SET oppRankName1='';
      END;
      select Opp_Pntl,Opp_Name INTO oppRank1, oppRankName1  from 
      CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc limit 0,1;
           END;
     Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank2=0;
     SET oppRankName2='';
      END;
       select Opp_Pntl,Opp_Name INTO oppRank2, oppRankName2  from 
      CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc limit 1,1;

           END;
         Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank3=0;
     SET oppRankName3='';
      END;
       select Opp_Pntl,Opp_Name INTO oppRank3, oppRankName3  from 
      CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc limit 2,1;
           END;
      
       Begin
      DECLARE EXIT HANDLER FOR NOT FOUND BEGIN
     SET oppRank4=0;
     SET oppRankName4='';
      END;
     select Opp_Pntl,Opp_Name INTO oppRank4, oppRankName4  from 
      CUSTOMER_PnTl where Opp_Pntl!=0   order by Opp_Pntl  desc limit 3,1;
           END;
         
      if oppRank1=0 then SET oppRank1Status = 'No Opportunity';
      Else 
      SELECT OPP_ACTION  INTO oppRank1Status  FROM Opportunity WHERE OPP_NAME= oppRankName1;     
      END IF;
      if oppRank2=0 then SET oppRank2Status = 'No Opportunity';
      Else 
         SELECT OPP_ACTION  INTO oppRank2Status  FROM Opportunity WHERE OPP_NAME= oppRankName2;    
         END IF;
      if oppRank3=0 then SET oppRank3Status = 'No Opportunity';
      Else 
       SELECT OPP_ACTION  INTO oppRank3Status  FROM Opportunity WHERE OPP_NAME= oppRankName3;    
       END IF;
      if oppRank4=0 then SET oppRank4Status = 'No Opportunity';
      Else 
           SELECT OPP_ACTION  INTO oppRank4Status  FROM Opportunity WHERE OPP_NAME= oppRankName4;    
           END IF;
      
     if oppRank1Status='STIMULATION' then
      Select Opp_Status into oppRank1Status from CUSTOMER_Pntl where Opp_NAME=oppRankName1;
      elseif oppRank1Status='RECOMMEND' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='REPLICATE' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('REPLICATE','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='REACTIVATE' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='RETAIN' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('RETAIN','-',IFNULL(oppRankName1, ''));
      elseif oppRank1Status='SATISFY' then
      SET oppRank1Status='';
      SET oppRank1Status=CONCAT('SATISFY','-',IFNULL(oppRankName1, ''));
      end if;
      if oppRank2Status='STIMULATION' then
      Select Opp_Status into oppRank2Status from CUSTOMER_Pntl where Opp_NAME=oppRankName2;
      elseif oppRank2Status='RECOMMEND' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName2, ''));
      elseif oppRank1Status='REPLICATE' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('REPLICATE','-',IFNULL(oppRankName2, ''));
      elseif oppRank1Status='REACTIVATE' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName2, ''));
      elseif oppRank2Status='RETAIN' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('RETAIN','-',IFNULL(oppRankName2, ''));
      elseif oppRank2Status='SATISFY' then
      SET oppRank2Status='';
      SET oppRank2Status=CONCAT('SATISFY','-',IFNULL(oppRankName2, ''));
      end if;
      if oppRank3Status='STIMULATION' then
      Select Opp_Status into oppRank3Status from CUSTOMER_Pntl where Opp_NAME=oppRankName3;
      elseif oppRank3Status='RECOMMEND' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='REPLICATE' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('REPLICATE','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='REACTIVATE' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='RETAIN' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('RETAIN','-',IFNULL(oppRankName3, ''));
      elseif oppRank3Status='SATISFY' then
      SET oppRank3Status='';
      SET oppRank3Status=CONCAT('SATISFY','-',IFNULL(oppRankName3, ''));
      end if;
      if oppRank4Status='STIMULATION' then
      Select Opp_Status into oppRank4Status from CUSTOMER_Pntl where Opp_NAME=oppRankName4;
      elseif oppRank4Status='RECOMMEND' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('RECOMMEND','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='REPLICATE' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('REPLICATE','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='REACTIVATE' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('REACTIVATE','-',IFNULL(oppRankName4, ''));
      elseif oppRank4Status='RETAIN' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('RETAIN','-',IFNULL(oppRankName4, ''));
      elseif oppRank1Status='SATISFY' then
      SET oppRank4Status='';
      SET oppRank4Status=CONCAT('SATISFY','-',IFNULL(oppRankName4, ''));
      end if;
      
      Insert into Tre_Ranking (CUSTOMER,RANK1,RANK1_ACTION,RANK2,RANK2_ACTION,RANK3,RANK3_ACTION,RANK4,RANK4_ACTION) Values
      (customer,oppRank1,oppRank1Status,oppRank2,oppRank2Status,oppRank3,oppRank3Status,oppRank4,oppRank4Status);
      end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_CAMPAIGNRANKING` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_CAMPAIGNRANKING`(
              in Customer int,
              in Campaignid int,
              in ProjectId int,
              in CurrentSegment varchar(10000),
              in CurrentCmpgnRank1 varchar(4000),
              in CurrentCmpgnRank2 varchar(4000),
              in CurrentCmpgnRank3 varchar(4000),
              in CurrentCmpgnRank4 varchar(4000),
              in RankAction1  varchar(4000),
              in RankAction2  varchar(4000),
              in RankAction3  varchar(4000),
              in RankAction4  varchar(4000),
              OUT CampaignRank1   varchar(10000),
              OUT CampaignRank2     varchar(10000),
              OUT CampaignRank3     varchar(10000),
              OUT CampaignRank4     varchar(10000)
              )
Begin
         BEGIN
           CASE WHEN CampaignExist(RankAction1,CurrentSegment)>0 THEN SET CampaignRank1 =Campaignid; else SET CampaignRank1 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(RankAction2,CurrentSegment)>0 THEN SET CampaignRank2 =Campaignid; else SET CampaignRank2 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(RankAction3,CurrentSegment)>0 THEN SET CampaignRank3 =Campaignid; else SET CampaignRank3 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(RankAction4,CurrentSegment)>0 THEN SET CampaignRank4 =Campaignid; else SET CampaignRank4 ='No Campaign' ;   END CASE;
               END;
           Begin
               if CampaignRank1='No Campaign'
               then
                 SET CampaignRank1=CurrentCmpgnRank1;
             
               elseif CurrentCmpgnRank1!='No Campaign' 
               then   SET CampaignRank1= CONCAT(IFNULL(CurrentCmpgnRank1, '') , ',' , IFNULL(CampaignRank1, ''))  ;
               end if;
               END;

                       Begin
               if CampaignRank2='No Campaign'
               then
                 SET CampaignRank2=CurrentCmpgnRank2;
                
          
              elseif CurrentCmpgnRank2!='No Campaign' then   SET CampaignRank2=CONCAT(IFNULL(CurrentCmpgnRank2, '') , ',' , IFNULL(CampaignRank2, ''))  ;
              
               end if;
             
               END;

                      Begin
               if CampaignRank3='No Campaign'
               then
                 SET CampaignRank3=CurrentCmpgnRank3;
           
              elseif CurrentCmpgnRank3!='No Campaign' then    SET CampaignRank3=CONCAT(IFNULL(CurrentCmpgnRank3, '') , ',' , IFNULL(CampaignRank3, ''))  ;
             end if;
             
               END;

                  Begin
               if CampaignRank4='No Campaign' 
               then
                 SET CampaignRank4=CurrentCmpgnRank4;
              
               elseif CurrentCmpgnRank4!='No Campaign'
               then
               SET CampaignRank4=CONCAT(IFNULL(CurrentCmpgnRank4, '') , ',' , IFNULL(CampaignRank4, '')) ;
            
             end if;
               END;
               Begin
             Insert into  CAMPAIGN_RANKING
             (Customer,Campaign_Ranking1, Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4,PROJECTID)
                       VALUES
            (Customer, CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4,ProjectId);
 
           END;
     END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_DELETECAMPAIGNRANKING` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_DELETECAMPAIGNRANKING`(
              in Customer int,
              in Campaignid varchar(4000),
              in CurrentCmpgnRank1 varchar(4000),
              in CurrentCmpgnRank2 varchar(4000),
              in CurrentCmpgnRank3 varchar(4000),
              in CurrentCmpgnRank4 varchar(4000),
              OUT CampaignRank1   varchar(5000),
              OUT CampaignRank2   varchar(5000),
              OUT CampaignRank3   varchar(5000),
              OUT CampaignRank4   varchar(5000)
              )
Begin
             Begin
               if CurrentCmpgnRank1='No Campaign'
               then
                 SET CampaignRank1=CurrentCmpgnRank1;
                 elseif CurrentCmpgnRank1=Campaignid
               then   SET CampaignRank1= 'No Campaign';
               ELSE
              
                SET CampaignRank1= REPLACE(CurrentCmpgnRank1,  Concat(',' , Ifnull(Campaignid, '')), '');
             
               end if;
               
               END;
                 Begin
               if CurrentCmpgnRank2='No Campaign'
               then
                 SET CampaignRank2=CurrentCmpgnRank2;
             
               elseif CurrentCmpgnRank2=Campaignid 
               then   SET CampaignRank2= 'No Campaign';
               ELSE
                 SET CampaignRank2= REPLACE(CurrentCmpgnRank2, Concat(',' , Ifnull(Campaignid, '')), '');
            
               end if;
               END;
                   Begin
               if CurrentCmpgnRank3='No Campaign'
               then
                 SET CampaignRank3=CurrentCmpgnRank3;
             
               elseif CurrentCmpgnRank3=Campaignid 
               then   SET CampaignRank3= 'No Campaign';
               ELSE
                SET CampaignRank3=  REPLACE(CurrentCmpgnRank3, Concat(',' , Ifnull(Campaignid, '')), '');
              
               end if;
               END;

                  Begin
               if CurrentCmpgnRank4='No Campaign'
               then
                 SET CampaignRank4=CurrentCmpgnRank4;
               elseif CurrentCmpgnRank4=Campaignid 
               then   SET CampaignRank4= 'No Campaign';
               ELSE
                SET CampaignRank4= REPLACE(CurrentCmpgnRank4, Concat(',' , Ifnull(Campaignid, '')), '');
           
               end if;
               END;
               Begin
             Insert into  CAMPAIGN_RANKING
             (Customer,Campaign_Ranking1, Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4)
                       VALUES
            (Customer, CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4);
            END;
     END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_TRE1_CAMPAIGNRANKING` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_TRE1_CAMPAIGNRANKING`(          
              in Campaignid int,
              in ProjectId int,
              in CurrentSegment varchar(4000),
              in Eligibilty varchar(4000),
              in MainFilter varchar(4000),
              in CurrentCmpgnRank1 varchar(4000),
              in CurrentCmpgnRank2 varchar(4000),
              in CurrentCmpgnRank3 varchar(4000),
              in CurrentCmpgnRank4 varchar(4000),          
              OUT CampaignRank1   varchar(4000),
              OUT CampaignRank2   varchar(4000),
              OUT CampaignRank3   varchar(4000),
              OUT CampaignRank4   varchar(4000)
              
              )
BEGIN
              DECLARE ttl_customer CURSOR FOR
               (SELECT A.CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION    FROM  TRE_OPPORTUNITYEXPORT A  
               LEFT JOIN (SELECT * FROM TRE_DETAILS_NEW_C_V ) D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK  
               LEFT JOIN (SELECT CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION  FROM Tre_Ranking ) R ON A.CUSTOMER=R.CUSTOMER  
               WHERE   
                (RANK1_ACTION IN (CurrentSegment) OR 
               RANK2_ACTION IN (CurrentSegment)  OR 
               RANK3_ACTION IN (CurrentSegment)  OR 
				RANK4_ACTION IN (CurrentSegment)));
 
               
              
             begin
             DECLARE v_Sql VARCHAR(2000);
             DECLARE v_Sql1 VARCHAR(2000);
             set v_Sql= 'SELECT Campaign_Ranking1,Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4 INTO 
              CurrentCmpgnRank1,CurrentCmpgnRank2 ,CurrentCmpgnRank3,CurrentCmpgnRank4 
              from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER'; 
             set v_Sql1='Delete from Campaign_Ranking  WHERE  Campaign_Ranking.Customer=cust_rec.CUSTOMER';
             begin DECLARE cust_rec CURSOR for select * from  ttl_customer;
              LOOP 
          EXECUTE  v_Sql; 
        EXECUTE  v_Sql1  ;    
              
         BEGIN
           CASE WHEN CampaignExist(cust_rec.RANK1_ACTION,CurrentSegment)>0 THEN SET CampaignRank1 =Campaignid; else SET CampaignRank1 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(cust_rec.RANK2_ACTION,CurrentSegment)>0 THEN SET CampaignRank2 =Campaignid; else SET CampaignRank2 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(cust_rec.RANK3_ACTION,CurrentSegment)>0 THEN SET CampaignRank3 =Campaignid; else SET CampaignRank3 ='No Campaign' ;   END CASE;
           CASE WHEN CampaignExist(cust_rec.RANK4_ACTION,CurrentSegment)>0 THEN SET CampaignRank4 =Campaignid; else SET CampaignRank4 ='No Campaign' ;   END CASE;
         END;
           Begin
               if CampaignRank1='No Campaign'
               then
                 SET CampaignRank1=CurrentCmpgnRank1;
             
               elseif CurrentCmpgnRank1!='No Campaign' 
               then   SET CampaignRank1= CONCAT(IFNULL(CurrentCmpgnRank1, '') , ',' , IFNULL(CampaignRank1, ''))  ;
               end if;
            END;

            Begin
               if CampaignRank2='No Campaign'
               then
                 SET CampaignRank2=CurrentCmpgnRank2;
                
          
              elseif CurrentCmpgnRank2!='No Campaign' then   SET CampaignRank2=CONCAT(IFNULL(CurrentCmpgnRank2, '') , ',' , IFNULL(CampaignRank2, ''))  ;
              
               end if;
             
            END;

            Begin
               if CampaignRank3='No Campaign'
               then
                 SET CampaignRank3=CurrentCmpgnRank3;
           
              elseif CurrentCmpgnRank3!='No Campaign' then    SET CampaignRank3=CONCAT(IFNULL(CurrentCmpgnRank3, '') , ',' , IFNULL(CampaignRank3, ''))  ;
             end if;
             
            END;

            Begin
               if CampaignRank4='No Campaign' 
               then
                 SET CampaignRank4=CurrentCmpgnRank4;
              
               elseif CurrentCmpgnRank4!='No Campaign'
               then
               SET CampaignRank4=CONCAT(IFNULL(CurrentCmpgnRank4, '') , ',' , IFNULL(CampaignRank4, '')) ;
            
             end if;
            END;
            Begin
            declare v_sql2 varchar(4000);
            set v_sql2 ='Insert into  CAMPAIGN_RANKING
             (Customer,Campaign_Ranking1, Campaign_Ranking2,Campaign_Ranking3,Campaign_Ranking4,PROJECTID)
                       VALUES
            (Customer, CampaignRank1,CampaignRank2,CampaignRank3,CampaignRank4,ProjectId)';
            EXECUTE  v_sql2;
           END;
           end loop;
           end;
          END;  
     END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TRE_CAMPAIGN_RANKING` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `TRE_CAMPAIGN_RANKING`(   
              in PROJECTID int,
              in MAINFILTER varchar(4000)  ,
              in ISAVGPTNL int
            )
BEGIN 
 DECLARE sqlQ varchar(14000)  DEFAULT '';  
 DECLARE TABCount DOUBLE  DEFAULT 0;  

DECLARE l_c2_CAMPPNTL varchar(4000);
  DECLARE l_c2_CAMPID varchar(4000);
  DECLARE l_c2_ELIGIBILITY varchar(4000);
  DECLARE v_Sql1 VARCHAR(2000);   
  DECLARE v_Sql VARCHAR(2000);
DECLARE NOT_FOUND INT DEFAULT 0;

DECLARE cuCampID CURSOR FOR
      SELECT CAMPAIGN_ID as CAMPID ,
      CASE WHEN ISAVGPTNL=1 THEN      
          CASE WHEN ACCOUNTS IS NULL OR TOTAL_POTENTIAL IS NULL THEN 0 ELSE ROUND(TOTAL_POTENTIAL/ACCOUNTS, 2) END 
      ELSE
          TAKE_UP_RATE
      END  as CAMPPNTL,
IFNULL(ELIGIBILITY,'1=1') as ELIGIBILITY FROM CAMPAIGNS;
 
            DECLARE CONTINUE HANDLER FOR NOT FOUND SET NOT_FOUND = 1;      
 
SELECT COUNT(*) INTO TABCount FROM USER_TABLES WHERE TABLE_NAME = 'CAMP_TEMP2';
IF (TABCount >0)
 THEN
	 set v_Sql1='DROP TABLE PRIORITIZED_TEMP';
	execute  v_Sql1 ;
END IF;    

SELECT COUNT(*) INTO TABCount FROM USER_TABLES WHERE TABLE_NAME = 'PRIORITIZED_TEMP';
IF (TABCount >0) THEN
	 set v_Sql='DROP TABLE PRIORITIZED_TEMP';
    execute   v_sql;
END IF;    



SET sqlQ =  ' CREATE TABLE CAMP_TEMP2 as (SELECT 0 as CUSTOMER,0 as PROJECTID,0.00 as CAMPPTNL,''NO CAMPAIGN'' as CAMPAIGN_RANKING1,''NO CAMPAIGN'' as CAMPAIGN_RANKING2,''NO CAMPAIGN'' as CAMPAIGN_RANKING3,''NO CAMPAIGN'' as CAMPAIGN_RANKING4 from dual) ';
EXECUTE  sqlQ ;

  OPEN cuCampID;
   loop_label:
   LOOP
     FETCH cuCampID into l_c2_CAMPPNTL, l_c2_CAMPID, l_c2_ELIGIBILITY;
     IF NOT_FOUND = 1 THEN LEAVE loop_label; END IF;            
            call TRE_CAMPAIGN_RANKING_INSERT(PROJECTID, MAINFILTER,l_c2_CAMPPNTL,l_c2_CAMPID,l_c2_ELIGIBILITY);                                 
   END LOOP;
   set v_Sql='DELETE FROM CAMP_TEMP2 WHERE CUSTOMER=0';
 execute v_sql;
 
 SELECT COUNT(*) INTO TABCount FROM USER_TABLES WHERE TABLE_NAME = 'CAMP_TEMP';
IF (TABCount >0) THEN
set v_sql='DROP TABLE CAMP_TEMP' ;
    execute v_sql  ;
END IF; 
 
 
SET sqlQ = ' CREATE TABLE PRIORITIZED_TEMP as 
WITH R1 AS
(
SELECT
    CUSTOMER,PROJECTID, CAMPAIGN_RANKING1
,   CAMPPTNL
,   ROW_NUMBER() OVER (PARTITION BY CUSTOMER ORDER BY CAMPPTNL DESC) AS rn
FROM
    CAMP_TEMP2 WHERE CAMPAIGN_RANKING1 != ''NO CAMPAIGN''
),
R2 AS
(
SELECT
    CUSTOMER,PROJECTID, CAMPAIGN_RANKING2
,   CAMPPTNL
,   ROW_NUMBER() OVER (PARTITION BY CUSTOMER ORDER BY CAMPPTNL DESC) AS rn
FROM
    CAMP_TEMP2 WHERE CAMPAIGN_RANKING2 != ''NO CAMPAIGN''
),
R3 AS
(
SELECT
    CUSTOMER,PROJECTID, CAMPAIGN_RANKING3
,   CAMPPTNL
,   ROW_NUMBER() OVER (PARTITION BY CUSTOMER ORDER BY CAMPPTNL DESC) AS rn
FROM
    CAMP_TEMP2 WHERE CAMPAIGN_RANKING3 != ''NO CAMPAIGN''
),
R4 AS
(
SELECT
    CUSTOMER,PROJECTID, CAMPAIGN_RANKING4
,   CAMPPTNL
,   ROW_NUMBER() OVER (PARTITION BY CUSTOMER ORDER BY CAMPPTNL DESC) AS rn
FROM
    CAMP_TEMP2 WHERE CAMPAIGN_RANKING4 != ''NO CAMPAIGN''
)

SELECT
 distinct  T1.CUSTOMER,T1.PROJECTID, NVL(R1.CAMPAIGN_RANKING1,''NO CAMPAIGN'') as PR_RANK1,
 NVL(R2.CAMPAIGN_RANKING2,''NO CAMPAIGN'') as PR_RANK2,
 NVL(R3.CAMPAIGN_RANKING3,''NO CAMPAIGN'') as PR_RANK3,
 NVL(R4.CAMPAIGN_RANKING4,''NO CAMPAIGN'') as PR_RANK4
FROM
    CAMP_TEMP2 T1
    LEFT JOIN R1 on T1.CUSTOMER=R1.CUSTOMER and R1.rn = 1
    LEFT JOIN R2 on T1.CUSTOMER=R2.CUSTOMER and R2.rn = 1
    LEFT JOIN R3 on T1.CUSTOMER=R3.CUSTOMER and R3.rn = 1
    LEFT JOIN R4 on T1.CUSTOMER=R4.CUSTOMER and R4.rn = 1  
    order by T1.CUSTOMER' ;

execute  sqlQ;

INSERT INTO PRIORITIZED_TEMP
SELECT TT.CUSTOMER,PROJECTID,'NO CAMPAIGN','NO CAMPAIGN','NO CAMPAIGN','NO CAMPAIGN'
FROM TRE_RANKING TT WHERE CUSTOMER NOT IN (SELECT CUSTOMER FROM PRIORITIZED_TEMP);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TRE_CAMPAIGN_RANKING_INSERT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `TRE_CAMPAIGN_RANKING_INSERT`(             
              in PROJECTID double,             
              in MAINFILTER varchar(4000), 
              in CAMPPNTL double,
              in CAMPID double,
              in ELIGIBILITY varchar(5000)
            )
BEGIN 
 DECLARE sqlQ varchar(2000)  DEFAULT  '';

       
 
 SET sqlQ =  CONCAT(' INSERT INTO CAMP_TEMP2   with tmp as (
                        SELECT A.CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION,D.ARPU,
                        (select segment_description  from campaigns where campaign_id=' , IFNULL(CAMPID, '') , ') as CurrentSegment    FROM  TRE_OPPORTUNITYEXPORT A  
                                     LEFT JOIN TRE_DETAILS_NEW_C_V  D ON A.CUSTOMER=D.CUSTOMER AND A.WEEK=D.WEEK  
                                     LEFT JOIN (SELECT CUSTOMER,RANK1_ACTION,RANK2_ACTION,RANK3_ACTION,RANK4_ACTION  FROM Tre_Ranking ) R ON A.CUSTOMER=R.CUSTOMER )
                                     
                         select CUSTOMER,', IFNULL(PROJECTID, '') , ' as PROJECTID,', IFNULL(CAMPPNTL, '') , ' as CAMPPTNL,   
                         CASE WHEN CurrentSegment like ''%'' || RANK1_ACTION || ''%'' THEN CAST(' , IFNULL(CAMPID, '')  , ' as varchar2(10)) ELSE ''NO CAMPAIGN'' END as CAMPAIGN_RANKING1,  
                         CASE WHEN CurrentSegment like ''%'' || RANK2_ACTION || ''%'' THEN CAST(' , IFNULL(CAMPID, '')  , ' as varchar2(10)) ELSE ''NO CAMPAIGN'' END as CAMPAIGN_RANKING2,  
                         CASE WHEN CurrentSegment like ''%'' || RANK3_ACTION || ''%'' THEN CAST(' , IFNULL(CAMPID, '')  , ' as varchar2(10)) ELSE ''NO CAMPAIGN'' END as CAMPAIGN_RANKING3,  
                         CASE WHEN CurrentSegment like ''%'' || RANK4_ACTION || ''%'' THEN CAST(' , IFNULL(CAMPID, '')  , ' as varchar2(10)) ELSE ''NO CAMPAIGN'' END as CAMPAIGN_RANKING4  
                        from tmp 
                                     WHERE   ' , IFNULL(ELIGIBILITY, '') , ' AND ' , IFNULL(MAINFILTER, '') ,
                                      ' AND ( ( CurrentSegment  ) like ''%'' || RANK1_ACTION || ''%'' OR 
                                        ( CurrentSegment  ) like ''%'' || RANK2_ACTION || ''%'' OR
                                        ( CurrentSegment  ) like ''%'' || RANK3_ACTION || ''%'' OR
                                        ( CurrentSegment  ) like ''%'' || RANK4_ACTION || ''%'' )');                  
                                       
                                     
                         
                       EXECUTE  sqlQ ;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TRE_GET_DELTASTATUS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `TRE_GET_DELTASTATUS`(
in BaseTable varchar(4000),
in ProjectId int
)
BEGIN

DECLARE sql_b varchar(1000)  DEFAULT  'create table ets_tre_base_D  as select a.* ';
DECLARE sql_a varchar(1000)  DEFAULT  Concat(' from ', BaseTable, ' a');
DECLARE sql_code_final longtext  DEFAULT  '';
DECLARE sql_c longtext;
DECLARE v_message varchar(1000);

      DECLARE l_c1_formula varchar(10000);
  DECLARE l_c1_stoppers_cutoff varchar(12000);
  DECLARE l_c1_droppers_cutoff varchar(12000);
  DECLARE l_c1_growers_cutoff varchar(12000);
  declare vsql varchar(2000);
DECLARE NOT_FOUND INT DEFAULT 0;

declare c1 cursor for
     select 
    b.formula,
    a.droppers_cutoff,
    A.STOPPERS_CUTOFF,
    A.GROWERS_CUTOFF
    from 
    status_breakdown a,
    opportunity b
    where a.opportunity_id = b.opportunity_id
    and b.project_id=ProjectId;

DECLARE CONTINUE HANDLER FOR NOT FOUND SET NOT_FOUND = 1;  
declare exit handler for sqlexception begin
     
 end;
 select sql_a;
select sql_b;
   open c1;
      loop_label:
      loop
   fetch c1 into l_c1_formula,l_c1_droppers_cutoff, l_c1_stoppers_cutoff,l_c1_growers_cutoff;
   select l_c1_formula;
   IF NOT_FOUND = 1 THEN LEAVE loop_label; END IF;
      SET sql_code_final = concat(sql_code_final,', Case When A_',l_c1_formula,'+B_',l_c1_formula,' =0 then ''NON USER'' 
                When A_',l_c1_formula,'=0 And B_',l_c1_formula,'>0 then ''NEW USER''   when D_',l_c1_formula,' <= ',
      l_c1_stoppers_cutoff,' 
      then ''STOPPER'' when D_',l_c1_formula,' <=',l_c1_droppers_cutoff,' then ''DROPPER'' 
      when D_',l_c1_formula,' > ',l_c1_growers_cutoff,
      ' then ''GROWER'' else ''FLAT'' end S_',l_c1_formula);
   END LOOP;
      Close c1;
SET @sql:= concat(sql_b,sql_code_final,sql_a);
select @sql;
 PREPARE dynamic_statement FROM @sql;   
 EXECUTE dynamic_statement;
set @sql:='CREATE INDEX ETS_TRE_BASE_D_IX ON ETS_TRE_BASE_D(CUSTOMER)';
 PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;

   END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TRE_GET_PTNL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `TRE_GET_PTNL`(
in MainTableName varchar(4000),
in Week INTEGER,
in ProjectId INTEGER
)
BEGIN
DECLARE sql_b varchar(4000)  DEFAULT  CONCAT('create table TRE_OPPORTUNITYEXPORT  as select Distinct(a.customer),',Ifnull(Week, ''),' as Week ');
DECLARE sql_a varchar(4000)  DEFAULT  Concat(' from ets_tre_base_d a,', IFNULL(MainTableName, ''),' b where a.customer = b.customer and b.week = ',ifnull(week, ''),'');
DECLARE sql_code_final longtext  DEFAULT  '';
DECLARE sql_c longtext  DEFAULT  null;
DECLARE v_message varchar(4000)  DEFAULT null;
DECLARE v_rows_count double;
DECLARE v_msg varchar(4000);
DECLARE vsql varchar(2000);
  DECLARE v_seq integer;
  DECLARE v_date datetime;
     

    DECLARE l_c2_formula varchar(10000);
  DECLARE l_c2_opp_name varchar(10000);
  DECLARE l_c2_elgbl_formula varchar(10000);
  DECLARE l_c2_ptnl_formula varchar(10000);
DECLARE NOT_FOUND INT DEFAULT 0;

declare c2 cursor for
    select 
    formula,    
    opp_name,
    elgbl_formula,
    ptnl_formula
    from
    recousr.opportunity where project_id=ProjectId;


DECLARE CONTINUE HANDLER FOR NOT FOUND SET NOT_FOUND = 1; 


   open c2;
   
   loop_label:
   loop
   fetch c2 into l_c2_formula, l_c2_opp_name, l_c2_elgbl_formula, l_c2_ptnl_formula;
   IF NOT_FOUND = 1 THEN LEAVE loop_label; END IF;
      SET sql_code_final= concat(sql_code_final,', a.D_',l_c2_formula,' as ',l_c2_opp_name,'_DELTA',',
                                           a.S_',l_c2_formula,' as ',l_c2_opp_name,'_STATUS',',
                                             ',case when l_c2_elgbl_formula != ''   then 
                                             Concat('case when b.',l_c2_elgbl_formula,' then ',
                                             l_c2_ptnl_formula,' ',
                                             case when l_c2_elgbl_formula != '' then 'end ' 
                                             else null 
                                             end) 
                                             else l_c2_ptnl_formula 
                                             end,' ',l_c2_opp_name,'_PNTL ') ;
   END LOOP;
select sql_code_final;
set  @sql:= concat(sql_b,sql_code_final,sql_a);
select @sql;
 PREPARE dynamic_statement FROM @sql;   
EXECUTE dynamic_statement;
set  @sql:='CREATE INDEX TRE_OPPORTUNITYEXPORT ON TRE_OPPORTUNITYEXPORT(CUSTOMER)';
PREPARE dynamic_statement FROM @sql;
EXECUTE dynamic_statement ;
commit;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-12  7:39:26

-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 09-Jul-2023 às 17:51
-- Versão do servidor: 10.5.19-MariaDB-cll-lve
-- versão do PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `u540973516_app_esk`
--
CREATE DATABASE IF NOT EXISTS `db_app_esk` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `u540973516_app_esk`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `Customers`
--

DROP TABLE IF EXISTS `Customers`;
CREATE TABLE IF NOT EXISTS `Customers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(150) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `Phone` longtext NOT NULL,
  `PersonType` int(11) NOT NULL,
  `CPF_CNPJ` varchar(14) NOT NULL,
  `StateRegistration` varchar(12) NOT NULL,
  `IsExempt` tinyint(1) NOT NULL,
  `Gender` int(11) NOT NULL,
  `DateOfBirth` datetime(6) NOT NULL,
  `IsBlocked` tinyint(1) NOT NULL,
  `Password` varchar(15) NOT NULL,
  `ConfirmPassword` longtext NOT NULL,
  `RegistrationDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

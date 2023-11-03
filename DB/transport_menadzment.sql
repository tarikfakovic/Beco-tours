-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 24, 2023 at 12:09 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `beco_tours`
--

-- --------------------------------------------------------

--
-- Table structure for table `lokacije`
--

CREATE TABLE `lokacije` (
  `LokacijaID` int(11) NOT NULL,
  `Grad` longtext DEFAULT NULL,
  `Naziv` longtext DEFAULT NULL,
  `Adresa` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lokacije`
--

INSERT INTO `lokacije` (`LokacijaID`, `Grad`, `Naziv`, `Adresa`) VALUES
(1, 'Beograd', 'Aerodrom', 'Nikola Tesla'),
(2, 'Nis', 'Aerodrom', 'Konstantin Veliki'),
(3, 'Novi Pazar', 'Pumpa', 'Sadovic pumpa'),
(4, 'Kraljevo', 'Autobuska stanica', 'Oktobarskih zrtava, Kraljevo');

-- --------------------------------------------------------

--
-- Table structure for table `putnike`
--

CREATE TABLE `putnike` (
  `PutnikID` int(11) NOT NULL,
  `Ime` longtext DEFAULT NULL,
  `Prezime` longtext DEFAULT NULL,
  `Adresa` longtext DEFAULT NULL,
  `Telefon` longtext DEFAULT NULL,
  `Godine` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `putnike`
--

INSERT INTO `putnike` (`PutnikID`, `Ime`, `Prezime`, `Adresa`, `Telefon`, `Godine`) VALUES
(1, 'Ahmed', 'Susterac', 'Lug', '634346345', 22),
(2, 'Edin', 'Kolasianc', 'Spomenik', '45435', 21),
(3, 'Mersudin', 'Muric', 'Rozaje', '643435543', 21),
(4, 'Ilhan', 'Mujevic', 'Rozaje', '534354', 22),
(5, 'Emrah', 'Hajdarevic', 'Trnava', '0643324233', 21);

-- --------------------------------------------------------

--
-- Table structure for table `rezervacije`
--

CREATE TABLE `rezervacije` (
  `RezervacijaID` int(11) NOT NULL,
  `PutnikID` int(11) NOT NULL,
  `Cena` decimal(65,30) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `PovratnaKarta` tinyint(1) NOT NULL,
  `TuraID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rezervacije`
--

INSERT INTO `rezervacije` (`RezervacijaID`, `PutnikID`, `Cena`, `CreatedAt`, `PovratnaKarta`, `TuraID`) VALUES
(1, 1, 30.000000000000000000000000000000, '2023-06-12 18:53:12.587578', 1, 1),
(2, 2, 30.000000000000000000000000000000, '2023-06-12 18:53:17.568272', 1, 1),
(3, 3, 30.000000000000000000000000000000, '2023-06-12 18:53:23.282168', 1, 2),
(4, 4, 30.000000000000000000000000000000, '2023-06-12 18:53:26.771935', 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `ture`
--

CREATE TABLE `ture` (
  `TuraID` int(11) NOT NULL,
  `VremePolaska` datetime(6) NOT NULL,
  `VremeUkrcavanja` datetime(6) NOT NULL,
  `VremeStizanja` datetime(6) NOT NULL,
  `VoziloID` int(11) NOT NULL,
  `VozacID` int(11) NOT NULL,
  `PolaznaLokacijaID` int(11) NOT NULL,
  `ZavrsnaLokacijaID` int(11) NOT NULL,
  `Status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ture`
--

INSERT INTO `ture` (`TuraID`, `VremePolaska`, `VremeUkrcavanja`, `VremeStizanja`, `VoziloID`, `VozacID`, `PolaznaLokacijaID`, `ZavrsnaLokacijaID`, `Status`) VALUES
(1, '2023-06-12 17:26:50.235000', '2023-06-12 17:26:50.235000', '2023-06-12 17:26:50.235000', 1, 1, 1, 3, 1),
(2, '2023-06-12 16:49:52.276000', '2023-06-12 16:49:52.276000', '2023-06-12 16:49:52.276000', 2, 2, 1, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `vozace`
--

CREATE TABLE `vozace` (
  `VozacID` int(11) NOT NULL,
  `Ime` longtext DEFAULT NULL,
  `Godine` int(11) NOT NULL,
  `Telefon` longtext DEFAULT NULL,
  `Kategorija` longtext DEFAULT NULL,
  `ZaposljenAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vozace`
--

INSERT INTO `vozace` (`VozacID`, `Ime`, `Godine`, `Telefon`, `Kategorija`, `ZaposljenAt`) VALUES
(1, 'Siljo', 35, '3454345', 'B', '2023-06-12 18:49:17.860431'),
(2, 'Tarik', 24, '534345345', 'B', '2023-06-12 18:49:23.909737');

-- --------------------------------------------------------

--
-- Table structure for table `vozila`
--

CREATE TABLE `vozila` (
  `VoziloID` int(11) NOT NULL,
  `Brend` longtext DEFAULT NULL,
  `Tip` longtext DEFAULT NULL,
  `Boja` longtext DEFAULT NULL,
  `BrojSedista` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vozila`
--

INSERT INTO `vozila` (`VoziloID`, `Brend`, `Tip`, `Boja`, `BrojSedista`) VALUES
(1, 'Mercedes', 'Kombi', 'Bordo', 9),
(2, 'Mercedes', 'Kombi', 'Plava', 9),
(3, 'Mercedes', 'Kombi', 'Bela', 9),
(4, 'Mercedes', 'Kombi', 'Siva', 9);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230612164207_ListeIObjekti', '7.0.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `lokacije`
--
ALTER TABLE `lokacije`
  ADD PRIMARY KEY (`LokacijaID`);

--
-- Indexes for table `putnike`
--
ALTER TABLE `putnike`
  ADD PRIMARY KEY (`PutnikID`);

--
-- Indexes for table `rezervacije`
--
ALTER TABLE `rezervacije`
  ADD PRIMARY KEY (`RezervacijaID`),
  ADD KEY `IX_Rezervacije_PutnikID` (`PutnikID`),
  ADD KEY `IX_Rezervacije_TuraID` (`TuraID`);

--
-- Indexes for table `ture`
--
ALTER TABLE `ture`
  ADD PRIMARY KEY (`TuraID`),
  ADD KEY `IX_Ture_PolaznaLokacijaID` (`PolaznaLokacijaID`),
  ADD KEY `IX_Ture_VozacID` (`VozacID`),
  ADD KEY `IX_Ture_VoziloID` (`VoziloID`),
  ADD KEY `IX_Ture_ZavrsnaLokacijaID` (`ZavrsnaLokacijaID`);

--
-- Indexes for table `vozace`
--
ALTER TABLE `vozace`
  ADD PRIMARY KEY (`VozacID`);

--
-- Indexes for table `vozila`
--
ALTER TABLE `vozila`
  ADD PRIMARY KEY (`VoziloID`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `lokacije`
--
ALTER TABLE `lokacije`
  MODIFY `LokacijaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `putnike`
--
ALTER TABLE `putnike`
  MODIFY `PutnikID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `rezervacije`
--
ALTER TABLE `rezervacije`
  MODIFY `RezervacijaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `ture`
--
ALTER TABLE `ture`
  MODIFY `TuraID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `vozace`
--
ALTER TABLE `vozace`
  MODIFY `VozacID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `vozila`
--
ALTER TABLE `vozila`
  MODIFY `VoziloID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `rezervacije`
--
ALTER TABLE `rezervacije`
  ADD CONSTRAINT `FK_Rezervacije_Putnike_PutnikID` FOREIGN KEY (`PutnikID`) REFERENCES `putnike` (`PutnikID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Rezervacije_Ture_TuraID` FOREIGN KEY (`TuraID`) REFERENCES `ture` (`TuraID`) ON DELETE CASCADE;

--
-- Constraints for table `ture`
--
ALTER TABLE `ture`
  ADD CONSTRAINT `FK_Ture_Lokacije_PolaznaLokacijaID` FOREIGN KEY (`PolaznaLokacijaID`) REFERENCES `lokacije` (`LokacijaID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ture_Lokacije_ZavrsnaLokacijaID` FOREIGN KEY (`ZavrsnaLokacijaID`) REFERENCES `lokacije` (`LokacijaID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ture_Vozace_VozacID` FOREIGN KEY (`VozacID`) REFERENCES `vozace` (`VozacID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ture_Vozila_VoziloID` FOREIGN KEY (`VoziloID`) REFERENCES `vozila` (`VoziloID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

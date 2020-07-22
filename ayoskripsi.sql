-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 22, 2020 at 07:17 PM
-- Server version: 8.0.19
-- PHP Version: 7.4.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ayoskripsi`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int NOT NULL,
  `username` varchar(16) NOT NULL,
  `password` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1, 'admin', '5ebe2294ecd0e0f08eab7690d2a6ee69');

-- --------------------------------------------------------

--
-- Table structure for table `dosen`
--

CREATE TABLE `dosen` (
  `nidn` varchar(20) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `jk` char(1) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`nidn`, `nama`, `jk`, `password`) VALUES
('180511021', 'Ajay Budiman', 'L', '5ebe2294ecd0e0f08eab7690d2a6ee69'),
('180511022', 'Syahrul Amin', 'P', '5ebe2294ecd0e0f08eab7690d2a6ee69'),
('180511023', 'Syamsir Alam', 'L', '5ebe2294ecd0e0f08eab7690d2a6ee69');

-- --------------------------------------------------------

--
-- Stand-in structure for view `laporan`
-- (See below for the actual view)
--
CREATE TABLE `laporan` (
`fakultas` varchar(50)
,`idskripsi` int
,`jk` char(1)
,`judul` varchar(255)
,`nama` varchar(255)
,`nama_pembimbing1` varchar(50)
,`nama_pembimbing2` varchar(50)
,`nidn_pembimbing1` varchar(20)
,`nidn_pembimbing2` varchar(20)
,`nim` varchar(20)
,`prodi` varchar(50)
,`tanggal` date
,`waktu` time
);

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `nim` varchar(20) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `jk` char(1) NOT NULL,
  `fakultas` varchar(50) NOT NULL,
  `prodi` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`nim`, `nama`, `jk`, `fakultas`, `prodi`, `password`) VALUES
('180511022', 'Kemal Reno', 'L', 'Teknik', 'Teknik Informatika', '5ebe2294ecd0e0f08eab7690d2a6ee69');

-- --------------------------------------------------------

--
-- Table structure for table `skripsi`
--

CREATE TABLE `skripsi` (
  `idskripsi` int NOT NULL,
  `tanggal` date DEFAULT NULL,
  `waktu` time DEFAULT NULL,
  `nim` varchar(20) NOT NULL,
  `nidn_pembimbing1` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `nidn_pembimbing2` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `judul` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `skripsi`
--

INSERT INTO `skripsi` (`idskripsi`, `tanggal`, `waktu`, `nim`, `nidn_pembimbing1`, `nidn_pembimbing2`, `judul`) VALUES
(1, '2020-07-24', '14:30:00', '180511022', '180511021', '180511022', 'Sistem Informasi Akademik UMC');

-- --------------------------------------------------------

--
-- Structure for view `laporan`
--
DROP TABLE IF EXISTS `laporan`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `laporan`  AS  select `skripsi`.`idskripsi` AS `idskripsi`,`skripsi`.`tanggal` AS `tanggal`,`skripsi`.`waktu` AS `waktu`,`skripsi`.`judul` AS `judul`,`mahasiswa`.`nim` AS `nim`,`mahasiswa`.`nama` AS `nama`,`mahasiswa`.`jk` AS `jk`,`mahasiswa`.`fakultas` AS `fakultas`,`mahasiswa`.`prodi` AS `prodi`,`pembimbing1`.`nidn` AS `nidn_pembimbing1`,`pembimbing1`.`nama` AS `nama_pembimbing1`,`pembimbing2`.`nidn` AS `nidn_pembimbing2`,`pembimbing2`.`nama` AS `nama_pembimbing2` from (((`skripsi` join `mahasiswa` on((`skripsi`.`nim` = `mahasiswa`.`nim`))) left join `dosen` `pembimbing1` on((`skripsi`.`nidn_pembimbing1` <=> `pembimbing1`.`nidn`))) left join `dosen` `pembimbing2` on((`skripsi`.`nidn_pembimbing2` <=> `pembimbing2`.`nidn`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `dosen`
--
ALTER TABLE `dosen`
  ADD PRIMARY KEY (`nidn`);

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`nim`);

--
-- Indexes for table `skripsi`
--
ALTER TABLE `skripsi`
  ADD PRIMARY KEY (`idskripsi`),
  ADD KEY `nidn_pembimbing2` (`nidn_pembimbing2`),
  ADD KEY `nidn_pembimbing1` (`nidn_pembimbing1`),
  ADD KEY `nim` (`nim`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `skripsi`
--
ALTER TABLE `skripsi`
  MODIFY `idskripsi` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `skripsi`
--
ALTER TABLE `skripsi`
  ADD CONSTRAINT `skripsi_ibfk_1` FOREIGN KEY (`nidn_pembimbing1`) REFERENCES `dosen` (`nidn`),
  ADD CONSTRAINT `skripsi_ibfk_2` FOREIGN KEY (`nidn_pembimbing2`) REFERENCES `dosen` (`nidn`),
  ADD CONSTRAINT `skripsi_ibfk_3` FOREIGN KEY (`nim`) REFERENCES `mahasiswa` (`nim`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

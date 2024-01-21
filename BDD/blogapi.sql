-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : sam. 20 jan. 2024 à 22:43
-- Version du serveur : 10.4.28-MariaDB
-- Version de PHP : 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `blogapi`
--

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

CREATE TABLE `categorie` (
  `id_categ` int(11) NOT NULL,
  `nom_categ` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `categorie`
--

INSERT INTO `categorie` (`id_categ`, `nom_categ`) VALUES
(22, 'Cakes0'),
(23, 'Cakes1'),
(24, 'Cakes2'),
(25, 'Cakes3'),
(26, 'Cakes4'),
(27, 'Crepes, Gauffres, Beignets'),
(28, 'Cakes'),
(29, 'Entremets'),
(30, 'Glace et Sorbets'),
(31, 'Layers Cake'),
(32, 'Macaron, Petis Biscuits, Sablés'),
(33, 'Tartes et Tartelettes'),
(34, 'Tartes'),
(35, 'Brioches'),
(36, 'Entremets'),
(37, 'Biscuits'),
(38, 'Layer Cake'),
(39, 'Cake'),
(40, 'Tartes'),
(41, 'Brioches'),
(42, 'Entremets'),
(43, 'Biscuits'),
(44, 'Layer Cake'),
(45, 'Cake'),
(46, 'Tartes'),
(47, 'Brioches'),
(48, 'Entremets'),
(49, 'Biscuits'),
(50, 'Layer Cake'),
(51, 'Cake'),
(52, 'Tartes'),
(53, 'Brioches'),
(54, 'Entremets'),
(55, 'Biscuits'),
(56, 'Layer Cake'),
(57, 'Cake');

-- --------------------------------------------------------

--
-- Structure de la table `doctrine_migration_versions`
--

CREATE TABLE `doctrine_migration_versions` (
  `version` varchar(191) NOT NULL,
  `executed_at` datetime DEFAULT NULL,
  `execution_time` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table `doctrine_migration_versions`
--

INSERT INTO `doctrine_migration_versions` (`version`, `executed_at`, `execution_time`) VALUES
('DoctrineMigrations\\Version20230516143325', '2023-05-16 16:33:43', 42),
('DoctrineMigrations\\Version20230516144001', '2023-05-16 14:40:06', 58),
('DoctrineMigrations\\Version20230530145155', '2023-05-30 16:52:07', 43);

-- --------------------------------------------------------

--
-- Structure de la table `messenger_messages`
--

CREATE TABLE `messenger_messages` (
  `id` bigint(20) NOT NULL,
  `body` longtext NOT NULL,
  `headers` longtext NOT NULL,
  `queue_name` varchar(190) NOT NULL,
  `created_at` datetime NOT NULL,
  `available_at` datetime NOT NULL,
  `delivered_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE `produits` (
  `id` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `prix` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `image` varchar(255) NOT NULL,
  `id_categ_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `produits`
--

INSERT INTO `produits` (`id`, `nom`, `prix`, `description`, `image`, `id_categ_id`) VALUES
(32, 'BÛCHE MARRONS POIRES1', 501, 'il est parfois difficile de réaliser des recettes aux marrons qui restent équilibrées en terme de sucre.1', 'https://empreintesucree.fr/wp-content/uploads/2022/12/1-buche-marrons-poires-recette-patisserie-empreinte-sucree.jpg.webp1', 23),
(33, 'BÛCHE MARRONS POIRES2', 502, 'il est parfois difficile de réaliser des recettes aux marrons qui restent équilibrées en terme de sucre.2', 'https://empreintesucree.fr/wp-content/uploads/2022/12/1-buche-marrons-poires-recette-patisserie-empreinte-sucree.jpg.webp2', 23),
(34, 'BÛCHE MARRONS POIRES3', 503, 'il est parfois difficile de réaliser des recettes aux marrons qui restent équilibrées en terme de sucre.3', 'https://empreintesucree.fr/wp-content/uploads/2022/12/1-buche-marrons-poires-recette-patisserie-empreinte-sucree.jpg.webp3', 22),
(35, 'BÛCHE MARRONS POIRES4', 504, 'il est parfois difficile de réaliser des recettes aux marrons qui restent équilibrées en terme de sucre.4', 'https://empreintesucree.fr/wp-content/uploads/2022/12/1-buche-marrons-poires-recette-patisserie-empreinte-sucree.jpg.webp4', 25),
(36, 'GLACE AU CHOCOLAT', 15, 'Une glace onctueuse qui plaît à tout le monde, même si vous n’êtes pas amateur de chocolat noir.', 'https://empreintesucree.fr/wp-content/uploads/2022/08/1-glace-chocolat-recette-patisserie-empreinte-sucree.jpg.webp', NULL),
(37, 'CRÊPES TRADITIONNELLES', 15, 'Si vous cherchez la recette ultime pour la Chandeleur, cette recette de pâte à crêpes est faite pour vous !', 'https://empreintesucree.fr/wp-content/uploads/2022/01/1-pate-crepes-recette-empreinte-sucree.jpg.webp', 27),
(38, 'GLACE DULCEY AUX ÉCLATS DE BROWNIE', 20, 'Cette recette de glace Dulcey aux éclats de brownie est tout simplement une adaptation en crème glacée', 'https://empreintesucree.fr/wp-content/uploads/2020/08/1-glace-dulcey-brownie-patisserie-empreinte-sucree.jpg.webp', 30),
(39, 'GLACE DULCEY AUX ÉCLATS DE BROWNIE', 20, 'Cette recette de glace Dulcey aux éclats de brownie est tout simplement une adaptation en crème glacée', 'https://empreintesucree.fr/wp-content/uploads/2020/08/1-glace-dulcey-brownie-patisserie-empreinte-sucree.jpg.webp', 30);

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `email` varchar(180) NOT NULL,
  `roles` longtext NOT NULL COMMENT '(DC2Type:json)',
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`id`, `email`, `roles`, `password`) VALUES
(3, 'orel@user.com', '[\"ROLE_USER\"]', '$2y$13$aIbht9HfPKiMVoLvoftbaOSCU6dc/wTtYbvJrMOI1G1ItMg14VTQq'),
(4, 'orel@admin.com', '[\"ROLE_ADMIN\"]', '$2y$13$J73YONQp83YtkShWBILU1.z2SJdmoNILQwYg.1/nfO7JKtsy6GMoG');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `categorie`
--
ALTER TABLE `categorie`
  ADD PRIMARY KEY (`id_categ`);

--
-- Index pour la table `doctrine_migration_versions`
--
ALTER TABLE `doctrine_migration_versions`
  ADD PRIMARY KEY (`version`);

--
-- Index pour la table `messenger_messages`
--
ALTER TABLE `messenger_messages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IDX_75EA56E0FB7336F0` (`queue_name`),
  ADD KEY `IDX_75EA56E0E3BD61CE` (`available_at`),
  ADD KEY `IDX_75EA56E016BA31DB` (`delivered_at`);

--
-- Index pour la table `produits`
--
ALTER TABLE `produits`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IDX_BE2DDF8CB8CCB787` (`id_categ_id`);

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQ_8D93D649E7927C74` (`email`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `categorie`
--
ALTER TABLE `categorie`
  MODIFY `id_categ` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT pour la table `messenger_messages`
--
ALTER TABLE `messenger_messages`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `produits`
--
ALTER TABLE `produits`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `produits`
--
ALTER TABLE `produits`
  ADD CONSTRAINT `FK_BE2DDF8CB8CCB787` FOREIGN KEY (`id_categ_id`) REFERENCES `categorie` (`id_categ`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

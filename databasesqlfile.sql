-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost
-- Üretim Zamanı: 01 Ara 2021, 14:31:02
-- Sunucu sürümü: 8.0.13-4
-- PHP Sürümü: 7.2.24-0ubuntu0.18.04.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `Kk9xTnjKup`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `message`
--

CREATE TABLE `message` (
  `id` int(11) NOT NULL,
  `time` text NOT NULL,
  `fullname` text NOT NULL,
  `msg` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `message`
--

INSERT INTO `message` (`id`, `time`, `fullname`, `msg`) VALUES
(164, '10:07:24 PM', 'FrontMan', 'hi'),
(165, '11:13:03', 'gaby', 'hi'),
(166, '2:47:32 PM', 'itachi', 'yo'),
(167, '19:52:43', 'Mbsz', 'a'),
(168, '19:52:43', 'Mbsz', ''),
(169, '22:18:09', 'cenix', 'niggers'),
(170, '22:18:30', 'cenix', 'if you are not the nigga you cant be my bff'),
(171, '4:56:59 PM', 'bryxz', 'yow'),
(172, '11:09:55 PM', 'BadVibesForever', 'wsg jews'),
(173, '10:51:38 PM', 'sus', 'balls'),
(174, '2:07:43 PM', 'UsernameDFS', 'HELLO'),
(175, '12:58:55', 'Porek', 'its spoofer ud?'),
(176, '6:46:26 PM', 'magic3hole', 'hey'),
(177, '6:46:27 PM', 'magic3hole', ''),
(178, '6:00:50 PM', 'Ski', ' r rogue company cheats working');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` text NOT NULL,
  `email` varchar(255) NOT NULL,
  `fullname` text NOT NULL,
  `secretanswer` text NOT NULL,
  `lastip` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `email`, `fullname`, `secretanswer`, `lastip`, `status`) VALUES
(5, 'Username', 'Password', 'Mail', 'Banned', 'Recovery Answer', '136.158.117.10', 1),
(6, 'FrontMan', 'Sifre.12345', 'hopesar545@gmail.com', 'Admin', 'knpfsd983fesad', '82.222.99.121', 0),
(8, 'marcussai', 'Marcus12marcus', 'Marcussai@hotmail.com', 'Memember', 'really', '46.194.166.16', 0),
(9, 'yulllii', 'Emre545545', 'dasasdads@gmail.com', 'Memember', 'dsaasd', '', 0),
(10, 'manoemad', 'Manomano99!', 'manoemad563@gmail.com', 'Memember', 'whats name dog', '', 0),
(12, 'miheb', 'miheb1010.', 'thebestx121@gmail.com', 'Memember', 'loj', '178.116.100.99', 0),
(13, 'manooooooUD', 'mmmmmmmm', 'manooooooUD@gmail.com', 'Memember', 'Recovery Answerdasdasd', '', 1),
(14, 'Petii98', 'Ponilorilove0911', 'Mpeterop9812@gmail.comail', 'Memember', 'XD', '', 1),
(15, 'Motes', 'Motamota8!', 'motaalex7171@gmail.com', 'Memember', 'spoofer', '', 0),
(18, 'loxial', 'kadenA890', 'kadopotato0505@gmail.com', 'Memember', 'idk', '', 0),
(19, 'TheRealBigfoot', 'Nathana12', 'Bobsjob12@gmail.com', 'Memember', 'jaylo', '82.29.121', 0),
(20, 'leo.mkv', 'cagasburra', 'ushhvfx@gmail.com', 'Memember', 'duce', '', 0),
(21, 'gavin2008', 'mojo1111', 'gavinmojo1111@gmail.com', 'Memember', 'gay', '', 0),
(22, 'Brandonp2003', 'Brasmi045', 'brandonpsmith2003@gmail.com', 'Memember', 'Penny', '', 0),
(23, 'RootUser00', 'Danieleculpi12!', 'daniele.culp@gmail.com', 'Memember', 'gesu', '93.49.253.55', 0),
(24, 'appl', 'gioste1616', 'thegxthboy@gmail.com', 'Memember', 'dumbass43243214', '', 0),
(25, 'Mindbomb', '65086344', 'evansyx10@gmail.com', 'Premium', 'Holymond', '67.245.159.110', 0),
(26, 'Sampie', 'Sifre.12345', 'FrontMan', 'Memember', 't534f3f45g3', '', 0),
(27, 'Mondbomb', '123456', 'sdfasg@gaddsaf.com', 'Memember', 'Kingkong', '', 0),
(28, 'Tutorial', 'dasdas432das', 'turorial@gmail.com', 'Memember', 'tut423423423432', '', 1),
(29, 'hamza', 'hamza', 'hamza@gmail.com', 'Memember', 'kosom el dnya', '', 0),
(30, 'femi', '29862986Femi', 'psfcacademy@gmail.com', 'Memember', 'femianthony', '', 0),
(31, 'hackingisfun', 'hackingisfun', 'ghostyboyy222@gmail.com', 'Memember', 'hacks are cool', '', 1),
(32, 'Nezuloxx', 'Olive1961', 'rustnezu@gmail.com', 'Premium', 'Nezuloxx', '217.79.201.68', 0),
(33, 'TUMADRANGA', 'milka07', 'xluxo2021@gmail.com', 'Memember', 'fargan1234567', '', 0),
(34, 'pc1', 'lukhuber1', 'xluxo39@gmail.com', 'Memember', 'gta12', '', 0),
(35, 'ShamenGadol', 'Noamazo1203', 'noam1107a@gmail.com', 'Premium', 'GG', '84.94.191.139', 0),
(36, 'KriptonTest', '1337', 'Mail243', 'Memember', '1337', '82.222.98.142', 0),
(37, 'xboxplays122', 'jordanS1234', 'jordandaviddad@gmail.com', 'Memember', 'jennifer', '47.54.225.194', 0),
(38, 'mi4u4', 'chickenmitsenf11', 'nikitagruenstern@gmail.com', 'Memember', 'lolisshit', '87.185.44.24', 0),
(39, 'zanderthebitcc', 'Zdog2006d4210039', 'xixurx@gmail.com', 'Memember', 'ilovecheats999', '71.201.46.226', 0),
(40, 'Gob', 'Microsoft85700', 'lastyaya85@gmail.com', 'Premium', 'nig', '37.170.31.221', 0),
(41, 'Tomas', 'tavotevas', 'tmseimis@gmail.com', 'Memember', 'Arabas', '86.100.10.213', 0),
(42, 'shit00', 'poggrz69', 'aron.skrzipczyk@gmail.com', 'Memember', 'HAHA', '145.253.3.148', 0),
(43, 'CiganBakar', 'giros888', 'giro.jedac@gmail.com', 'Memember', 'peder', '109.93.10.233', 0),
(44, 'Jsternator', '(Webster123)', 'jsternator1337@hotmail.com', 'Memember', 'Bitches', '115.69.23.23', 0),
(45, 'manosayedggsggs', 'manosayedgg', 'manosayedggemad1@gmail.com', 'Memember', 'what school', '197.39.60.115', 0),
(46, 'iZI', 'zacusca90', 'hitluca397@gmail.com', 'Memember', 'What is ur mom?', '95.77.159.190', 0),
(47, 'poggers4', 'pogdude', '7g6c@web.de', 'Memember', 'sus', '92.211.125.2', 0),
(48, 'Harpo', 'hARP0net', 'chalmersb13@gmail.com', 'Premium', 'harpoishere', '82.8.249.16', 0),
(49, 'BakarCigan', 'giros888', 'jazavicarmilutinovic@gmail.com', 'Memember', 'BAKAR', '79.101.173.107', 0),
(50, 'sayfu', 'sayfulla123!', 'sayfuontop@gmail.com', 'Memember', 'What is my fav cat', '85.190.68.241', 0),
(51, 'thebestx1213', 'o5221599.org', 'hilljenny884@gmail.com', 'Memember', 'lio', '24.146.145.249', 0),
(52, 'abs2020', 'Alking12345', 'Alshaibania520@gmail.com', 'Memember', 'what is your dog name', '86.97.52.228', 0),
(53, 'stexdeezy', '199904Dj$', 'ydoihaveswag1@gmail.com', 'Memember', 'Smokedog', '104.59.134.35', 0),
(54, 'Papi_Tyler', 'DaddyTyler', 'Lolik2221110@gmail.com', 'Memember', 'Porn', '23.118.139.37', 0),
(55, 'Alertedlmao', 'Bazsix112', 'idiota@gmail.com', 'Memember', 'nemtudom', '45.14.137.81', 0),
(56, 'alq', 'Ahmed545', 'alqurashiahmed96@gmail.com', 'Memember', 'ALQ', '92.98.135.33', 0),
(57, 'loukistendre', 'Anticheat007', 'gilbert664063@v60.gpa.lu', 'Memember', 'ImHerre', '88.124.191.80', 0),
(58, 'nemtudom98', 'Bazsix112', 'freelmao@gmail.com', 'Memember', 'Bazsix112', '194.110.140.32', 0),
(59, 'hazzars', '125478', 'nzagryadka2@gmail.com', 'Memember', 'Recovery Answer', '176.105.197.100', 0),
(60, 'flpzgc', 'Random222', 'flpzgc2@gmail.com', 'Memember', 'flpzgc2@gmail.com', '146.255.145.32', 0),
(61, 'NotHere222', 'Giros888', 'dasijfdkasjdf@gmail.com', 'Memember', 'Giros!', '109.93.11.203', 0),
(62, 'XkokoX', 'Koko114514', 'kokorochhhhh@gmail.com', 'Memember', '114514', '60.90.79.183', 0),
(63, 'NOZU', 'Louis12345', 'ggezharld@outlook.de', 'Memember', '2111', '91.32.20.98', 0),
(64, 'imlogan123123', 'logan.2010.', 'imlogan123123@gmail.com', 'Memember', 'Recovery Answer', '47.205.85.172', 0),
(66, 'lmoreiraaa', 'Leclaka1', 'brielpg.znutella@gmail.com', 'Memember', 'Recovery Answer', '201.27.157.140', 0),
(67, 'Bogeta327', 'ericnico2008', 'ericmoyajii@gmail.com', 'Memember', 'Recovery Answer', '37.29.209.179', 0),
(68, 'Imaha', 'Imaha_47', 'Mailaefaef', 'Memember', 'tree', '86.108.16.247', 0),
(69, 'KriisDaBot', 'Awesome321!!', 'sarahg1617@gmail.com', 'Memember', 'idk', '104.229.89.31', 0),
(70, 'Saiko', 'mimmmoerric2', 'enzoerricboss1234@gmail.com', 'Memember', 'Enzo', '91.68.214.98', 0),
(71, 'vertelka1336', 'donatas17LTU', 'ltudoncee17@gmail.com', 'Memember', 'how many nigga are there?', '86.38.36.2', 0),
(72, 'xouxzv', '123456Fuckoff!?', 'xouxzv@gmail.com', 'Memember', 'xouxzv', '68.57.111.247', 0),
(73, 'yvngtane', 'Mokemoke711', 'KrnqrV3@gmail.com', 'Memember', '4516', '151.210.145.125', 0),
(74, 'kaashin', '5409', 'brxkenacc@gmail.com', 'Memember', 'lusi', '78.48.24.64', 0),
(75, 'Noahalsaab', 'Noahalsaab', 'gmail', 'Memember', 'Alsaabsasuke', '76.30.108.113', 0),
(76, 'loxialAlt', 'kadenA890', '8zhhp4sb7@stu.castlefieldsinfantschool.co.uk', 'Memember', 'Loxial', '121.223.134.56', 0),
(77, 'locacly', 'TheBestLoser1', 'locacly@gmail.com', 'Memember', 'fortnite', '47.154.18.20', 0),
(78, 'Alerted', 'Adem2008', 'ademberkane32@gmail.com', 'Memember', 'Woah', '138.88.85.22', 0),
(79, 'mikoxik', 'mika0108roczek', 'mikox0108@gmail.com', 'Memember', 'Mikołaj', '89.78.122.26', 0),
(80, '890', '890', 'kolax1705@gmail.com', 'Memember', '890', '103.125.38.95', 0),
(81, 'azzam', '123321', 'bozhr2hxl@gmail.com', 'Memember', 'azzam', '5.41.248.187', 0),
(82, 'esty', 'Khalaf32', 'Mailbabynecron', 'Memember', '1', '176.205.10.92', 0),
(83, 'Gheng', 'V3', 'vraidant@gmail.com', 'Memember', 'dad', '151.68.77.48', 0),
(84, 'Bufko', 'Manuelgril1', 'grilmani123@gmail.com', 'Memember', 'manuel', '89.142.88.92', 0),
(85, 'marwane', 'kabilkabil59', 'mawanekabil59@gmail.com', 'Memember', 'Recovery Answer', '93.25.66.143', 0),
(86, 'yarrox', 'Mimimomo3', 'mohamed68170@laposte.net', 'Memember', 'FVB', '103.14.26.142', 0),
(87, 'Vonex', 'mert3131', 'zonyomy@gmail.com', 'Memember', 'emre', '82.222.106.58', 0),
(88, 'Manos', 'gamias9900', 'alextsint77@gmail.com', 'Memember', 'your mother', '46.190.78.146', 0),
(89, 'Anodio', 'ppp333ppp', 'anodio1337@gmail.com', 'Memember', 'Yeti', '5.83.191.250', 0),
(90, 'demon.#9907', 'SAlem.2007', 'salemkhalid107@gmail.com', 'Memember', 'dog', '143.92.131.204', 0),
(91, 'Vz', 'Magnet777', 'tmutlow11@gmail.com', 'Memember', '0704', '81.159.113.74', 0),
(92, 'huelehuele2', 'Гнекуцй321', 'matvey21ivanov@gmail.com', 'Memember', 'cual es mi perro ??', '217.107.197.214', 0),
(93, 'MiniWaree', 'MiniWareOnTop1!', 'donthaveone@gmail.com', 'Memember', 'dick', '134.195.172.151', 0),
(94, 'sus', 'Brody5229', 'wqewqew213223@gmail.com', 'Memember', 'sus', '104.62.227.38', 0),
(95, 'jambo', 'jambo', 'utubestream1337@gmail.com', 'Memember', '123', '86.24.247.114', 0),
(96, 'AImbot', 'Adamhurt1350', 'stallingsaim@gmail.com', 'Memember', 'Middle name?', '99.7.131.192', 0),
(97, 'zuayy', '213773Om', 'yeswayforever@gmail.com', 'Memember', '123', '67.8.251.128', 0),
(98, 'Desmecito', 'Doncholito1_1', 'jositogaming@gmail.com', 'Memember', 'cat', '71.62.173.1', 0),
(99, 'R4ITH', 'Fabian48', 'Fabian.coucheron@gmail.com', 'Memember', 'bodo', '89.162.120.61', 0),
(100, 'Vrabec', 'mavelkepero', 'michalnovotnysk@seznam.cz', 'Memember', 'lupkomavprdelisperma', '85.190.76.129', 0),
(101, 'Lupko', 'lubanek', 'lubanekmarik@gmail.com', 'Memember', 'lupko', '85.190.73.220', 0),
(102, 'chadi20', 'chadichadi', 'chadi.fayek102@gmail.com', 'Memember', 'Fes', '105.154.109.146', 0),
(103, 'Javier2006', 'Kobe200123', 'tempestteam5@gmail.com', 'Memember', 'Dog', '73.0.199.187', 0),
(104, 'Aug', 'MZW33nxe', 'Augustmotaguedes@gmail.com', 'Memember', 'hej', '176.23.94.91', 0),
(105, 'h1zzy', 'h1zzy32A', 'nolove04@list.ru', 'Memember', 'h1zzy', '78.157.227.254', 0),
(106, 'rudder', 'danielmbiele123', 'danielmbielmbiele12@gmail.com', 'Memember', '2fsa', '70.115.119.130', 0),
(107, 'zounow', 'Timothe68', 'timbou71@gmail.com', 'Memember', 'Am i racist ?', '78.241.48.90', 0),
(108, 'jefta_078', 'Jefta2005', 'jeftagames@gmail.com', 'Memember', '123', '86.91.45.214', 0),
(109, 'bxzy', '25801212', 'phoenix81231@gmail.com', 'Memember', 'yes', '73.32.174.239', 0),
(110, 'Negigno', 'Sabaknoah1040', 'Jessco1040@gmail.com', 'Memember', 'Homophobe', '81.240.33.184', 0),
(111, 'Fenasi', '05061973Aa', 'turistt67@gmail.com', 'Memember', 'Fenasi', '78.48.19.63', 0),
(112, 'quibby12345', 'Password', 'quibbythegoat@gmail.com', 'Memember', 'Recovery Answer', '174.73.148.240', 0),
(113, 'Pulxi', 'LuCiferJ4Y$', 'jaymancoolslike123@gmail.com', 'Memember', 'jays', '204.111.110.159', 0),
(114, 'epichaxormans', 'Booboo01*', 'randomtylerc@gmail.com', 'Memember', 'lul', '172.223.149.250', 0),
(115, 'Errorcode1337', 'Errorcode', 'exprxss1998@gmail.com', 'Memember', 'FOG', '82.7.194.34', 0),
(116, 'zemf', 'maks335maks', 'makso7777777777@mail.com', 'Memember', 'zenf', '95.158.42.181', 0),
(117, 'Hamdan', 'Ali_moh69', 'Hamdan16820083@hotmail.com', 'Memember', 'What Your name', '92.96.133.237', 0),
(118, 'biladeren', '01012008Eren', 'biladeren@gmail.com', 'Memember', '123', '82.222.135.76', 0),
(119, 'Hewskireal', 'anan99000', 'hewskireal@gmail.com', 'Memember', 'Recovery Answer', '78.184.11.60', 0),
(120, 'alexhyper35', 'A12345678a', 'alex.smurf1@yahoo.com', 'Memember', 'mama', '109.102.244.104', 0),
(121, 'Zod', 'Shaxa1996', 'ttvpanda80@gmail.com', 'Memember', 'Ass', '69.202.246.131', 0),
(122, 'kriptonlegit', 'Bazsix112', 'orsospeter98@gmail.com', 'Memember', 'Bazsix112', '194.110.140.211', 0),
(123, 'sakpot', '**Baljeet1', 'aldairsour1@gmail.com', 'Memember', 'yes', '170.176.230.172', 0),
(124, 'IdkCircleGoBrr', 'Ghasty251', 'nougae2@gmail.com', 'Memember', 'Recovery Answer', '172.74.55.121', 0),
(125, 'sosiso4ka111', 'lolkek5656', 'antitoxichouse@mail.ru', 'Memember', 'im fucking noob', '80.70.109.66', 0),
(126, 'LetsHackYt', 'Hacking125', 'bussweilerf1@gmail.com', 'Memember', 'Nigger', '87.151.125.24', 0),
(127, 'unique', 'Azrou2014', 'bringyourmain@gmail.com', 'Memember', 'Jasmin', '188.63.135.57', 0),
(128, 'Kabian', 'Bubba1071', 'morgankabian1@gmail.com', 'Memember', '2+2', '65.123.5.137', 0),
(129, 'monix', '5152', 'monix', 'Memember', 'monix', '170.176.230.32', 0),
(130, 'hewskiloo', 'anan99000', 'hewskipm@gmail.com', 'Memember', 'Recovery Answer', '84.51.55.231', 0),
(131, 'BigNuts56', 'BigNuts56', 'billybobman142@gmail.com', 'Memember', 'Password is user', '149.167.151.81', 0),
(132, 'kaasje', 'Kaasje123', 'kaasislekker@gmail.com', 'Memember', '123', '134.19.185.116', 0),
(133, 'dwaofolae', 'Tibogu92*', 'dammiran24@mail.ru', 'Memember', 'Recovery Answer', '5.34.94.33', 0),
(134, 'Skkite', 'csscss', 'bogdanlitvin08@bk.ru', 'Memember', 'Rust', '178.68.15.177', 0),
(135, 'seny_228', 'sheshhh', 'ustyugovarsenie@yandex.ru', 'Memember', 'Recovery Answer', '89.148.243.59', 0),
(136, 'Zwartwit', 'Lol123', 'Dantevanderzwart@gmail.com', 'Memember', 'Saar', '31.187.197.172', 0),
(137, 'zwartwit1', 'saar123', 'dantevandzwart@gmail.com', 'Memember', 'saar', '173.205.82.136', 0),
(138, 'GolubevasLovesHopesar', 'loliukas2@', 'golubevasgolu@gmail.com', 'Memember', 'LOL123', '78.56.81.227', 0),
(139, 'Stokely', 'Alexpoochie1', 'skyl3git@gmail.com', 'Memember', 'poochie', '109.77.112.228', 0),
(140, 'bitxh', 'imsmokingthatandify69pack!', 'blkandrew9@gmail.com', 'Memember', 'ImKoolerMyBoy!', '73.52.58.109', 0),
(141, 'xxgodsakexx', 'Mahealani11', 'willcrd2003@gmail.com', 'Memember', 'Pineapple', '107.127.4.50', 0),
(142, 'S19', 'qqaazz112233', 'ssuullttaann45@gmail.com', 'Memember', 'S19', '31.167.11.65', 0),
(143, 'brtgala', 'mohdalb0617M@M@M&', 'use7cod74@gmail.com', 'Memember', 'brtgala', '2.51.50.157', 0),
(144, 'mercurialz', '14789632d', 'addressth01@gmail.com', 'Memember', '1234', '223.204.48.205', 0),
(145, 'Weed', 'Ibrahim2006', 'ibrahim1912v@hotmail.com', 'Memember', 'Boss', '94.128.82.32', 0),
(146, 'Zentify', 'Youaqua5151', 'hylseelias@gmail.com', 'Memember', 'Angang', '31.208.248.15', 0),
(147, 'kriptonfullyud', 'Bazsix112', 'kozodvanhozzá@gmail.com', 'Memember', 'énbuzivagyok', '45.81.108.82', 0),
(148, 'KriptonEasy', 'we-012687', 'defthebeamer@gmail.com', 'Memember', 'momma', '68.102.177.48', 0),
(149, 'Recon', 'Recon', 'myneo3879@gmail.com', 'Memember', 'Recon', '94.134.107.184', 0),
(150, 'Noshi', 'Noshi', 'leavemealone@gmail.com', 'Memember', '12345', '80.130.98.86', 0),
(151, 'nigger', 'natalie21', 'suckyourmum@outlook.com', 'Memember', 'dfgdgfdgfd', '86.184.33.113', 0),
(152, 'TheRealHitKid', 'Ronniesmith2014', 'heyguysurbaddontcry@gmail.com', 'Memember', 'kio', '84.66.25.120', 0),
(153, 'dababy69', 'dababy69420@', 'sussyimposterfromamogus@outlook.com', 'Memember', 'balls', '35.85.198.127', 0),
(154, 'Dababy68', 'Dababy69420@', 'obamaisnttoosus@outlook.com', 'Memember', 'balls', '35.85.198.127', 0),
(155, 'dltmdtls', 'dsadasdas23', 'gkdlwns001@gmail.com', 'Memember', '112', '222.238.82.16', 0),
(156, 'dammiran', 'Sveta99', 'damir.german@mail.ru', 'Memember', 'Dogs', '89.33.213.176', 0),
(157, 'Dymr', 'cattosarecool', 'dymrbuisness@gmail.com', 'Memember', 'Cats', '122.2.96.75', 0),
(158, 'noshi12', 'noshi', 'noshi', 'Memember', 'noshi', '80.130.98.86', 0),
(159, 'minino', 'huelehuele1', 'mininosalpoder1914@gmail.com', 'Memember', 'Como es tu perro?', '2.137.23.64', 0),
(160, 'KiraYoshikage', 'Kirajtm13', 'nzoozozo13@gmail.com', 'Memember', 'Recovery Answer', '93.13.78.118', 0),
(161, 'saasaa', 'BEBOBESTBRO.2011', 'ghghd579@gmail.com', 'Memember', 'lol', '139.64.3.5', 0),
(162, 'xdverynicename', 'Bazsix112', 'tenyek98@gmail.com', 'Memember', 'Bazsix112', '45.81.109.208', 0),
(163, 'recon1', 'recon', 'recon', 'Memember', 'recon', '94.134.107.174', 0),
(164, 'Noodlli', 'Mamatopa1', 'fortlol06@mail.ru', 'Memember', '123', '31.181.134.171', 0),
(165, 'Trexy908', 'Ryan34711', 'Trexy908@gmail.com', 'Memember', '9508', '184.88.0.160', 0),
(166, 'tekii', 'Haban2009', 'dobrejt6@gmail.com', 'Memember', 'ahoj', '79.141.242.135', 0),
(167, 'bolikoli1', 'Polak331', 'bolicfoli@gmail.com', 'Memember', 'Polak331', '77.161.235.219', 0),
(168, 'yonosoylion', 'Angelo1212@', 'aartuniano@gmail.com', 'Memember', 'Angelo1212', '213.194.176.43', 0),
(169, 'DIORFTW', 'Enzojetaime@12345', 'Marius75005@outlook.fr', 'Memember', 'Recovery Answer', '81.249.165.241', 0),
(170, 'kerhs', 'soflylikeXYZ2007', 'joshmatters07@gmail.com', 'Memember', 'Squiggles', '101.188.6.124', 0),
(171, 'savagely255', 'JD802511', 'savagely255@gmail.com', 'Memember', 'JD802511', '69.54.136.91', 0),
(172, '6No_', 'Maritime2008', 'danielblairwilliams@gmail.com', 'Memember', 'boys', '101.100.130.92', 0),
(173, 'Abobus', 'sultan18021402', 'popabobo3112@gmail.com', 'Memember', '123123', '37.150.26.177', 0),
(174, 'Test13371337', 'Test13371337', 'ilnegrettochenegretta@gmail.com', 'Memember', 'test1337', '62.211.234.223', 0),
(175, 'JACOLORD11122302305', '1220', 'Psychojah2@gmail.com', 'Memember', '122001', '73.110.158.87', 0),
(176, 'qufixs', 'pass', 'qufixs@gmail.com', 'Memember', 'james', '73.255.143.56', 0),
(177, 'Destiny', 'kired', 'gscgang240@gmail.com', 'Memember', 'Destiny', '206.128.71.5', 0),
(178, 'cattos', 'bruhmoment', 'cattoiscol@gmail.com', 'Memember', 'cats', '122.2.111.45', 0),
(179, 'destinyDDDD', 'ewe', 'gscgang@gmail.com', 'Memember', 'bbc', '206.128.71.1', 0),
(180, 'babynecron', 'Khalaf32', 'khalafpro19@gmail.com', 'Memember', 'khalaf', '94.59.79.145', 0),
(181, 'Kush', ':5FTCHaBAr2SCt-', 'hisag98111@incoware.com', 'Memember', 'gg', '79.40.18.244', 0),
(182, 'AloneMask', 'perolaefe@eu610', 'fegamesoficial@gmail.com', 'Memember', 'What is my mom name?', '200.148.106.206', 0),
(183, 'mt00951', 'Francais-1', 'bgb2004bgb@gmail.com', 'Memember', 'yes', '91.165.60.110', 0),
(184, 'i7amood23', 'Yyqqbbaa11', 'mohammedyaqoob08@gmail.com', 'Memember', 'LK;LK', '92.99.250.51', 0),
(185, 'burak yavuz', 'burak1456', 'cheasles_26@hotmail.com', 'Memember', 'köpeğin', '176.88.28.99', 0),
(186, 'fokoskenyer', 'Huncut11', 'playergod669@gmail.com', 'Memember', 'oszkár neve', '91.146.183.65', 0),
(187, 'dami', 'Momster2006', 'elihenry426@gmail.com', 'Memember', 'bike', '108.21.201.51', 0),
(188, 'koko', 'kokowawa', 'kokowawa@gmail.com', 'Memember', 'kokowawa', '41.142.210.105', 0),
(189, 'soldadoanonimo', 'VTOmania181', 'victorcamachoitver@gmail.com', 'Memember', 'Dobby', '187.189.40.171', 0),
(190, 'Killer', 'MaSeBoo126', 'jlogrono26@gmail.com', 'Memember', 'fav dog max', '72.229.138.199', 0),
(191, 'UpalimJardu', 'penis101', 'pelkojezid@protonmail.com', 'Memember', 'cernoch', '85.190.76.117', 0),
(192, 'kired', '1', 'gas@gmail.com', 'Memember', 'bbc', '206.128.71.5', 0),
(193, 'sadobra', 'hbck562002', 'hrnalemdar19@gmail.com', 'Memember', 'abbas', '95.112.100.99', 0),
(194, 'IlostmyDowen', '201124347Zz', 'xoxodragonmaster@gmail.com', 'Memember', 'joe', '108.26.202.60', 0),
(195, 'tfesty', 'Khalaf32', 'khalafpro9877', 'Memember', '1', '176.205.13.42', 0),
(196, 'sisavitaraymagaling', 'thatscrazy!99', 'ballsman@gmail.com', 'Memember', 'SavitarPH', '136.158.117.10', 0),
(197, 'VitaliyBudjenko', 'Qazwsxedc1', 'marshu4kala@gmail.com', 'Memember', 'Qwertyu', '195.114.148.159', 0),
(198, 'moobotsbruder', 'w1212312', 'moobotsbruder@skymail.de', 'Memember', 'julia', '80.143.238.239', 0),
(199, 'akira', 'yuh1masweat', 'hxywhatsup@gmail.com', 'Memember', 'akira is a very good player', '73.195.101.42', 0),
(200, 'Sakurathebest', 'Gaypride', 'jesuisgay@gmail.com', 'Memember', '3636', '78.231.64.121', 0),
(201, 'Abscned', 'mom1dad2.', 'plai9500@gmail.com', 'Memember', 'dog', '47.225.184.73', 0),
(202, 'aaa', 'Dwayne502', 'robert2k22god@gmail.com', 'Memember', 'banana', '113.28.175.1', 0),
(203, 'iiiLucid', '4603981Dd', 'Tariskejude@yahoo.com', 'Memember', '2+2=4', '45.50.147.166', 0),
(204, 'Yeteer_xxl', '2009+1977', 'andreistefannicu1977@gmail.com', 'Memember', 'Andrei', '79.115.190.125', 0),
(205, 'AyanRD', 'ayan.ilie_9', 'botisisiton@gmail.com', 'Memember', 'botisisiton@gmail.com', '84.232.202.251', 0),
(206, 'alexandru20', 'alexandru200910', 'alexandru.voicu.mh@gmail.com', 'Memember', 'alexandru.voicu.mh@gmail.com', '82.78.87.172', 0),
(207, 'marios', 'xtm2109950478', 'tsiamisxristos@gmail.com', 'Memember', 'marios', '195.74.225.193', 0),
(208, 'Reznik', 'Magone12345678', 'reznik56@protonmail.com', 'Memember', 'Nela', '78.80.254.179', 0),
(209, 'elkka1', 'PasswordKierto08', 'eelis.passoja@gmail.com', 'Memember', 'Recovery Answer', '62.78.141.217', 0),
(210, 'cumry', 'sultan1802', 'xuipopka427@gmail.com', 'Memember', 'sultan1802', '5.76.234.202', 0),
(211, 'Chinezu', 'Andreasgaming13', 'cuceanezu@gmail.com', 'Memember', 'MATA', '188.27.152.176', 0),
(212, 'Ryzy', 'Bernatvila10', 'bernatvb10@gmail.com', 'Memember', 'Recovery Answer', '81.34.193.136', 0),
(213, 'trippyllllll', 'Arilynn73', 'bendersson7@gmail.com', 'Memember', 'Arilynn73', '70.118.169.19', 0),
(216, 'nubbbb', 'oofer2485', 'vykizmwgovyyoofyzd@mrvpt.com', 'Memember', 'wertwrtgrt', '47.226.104.228', 0),
(217, 'jrisantosgt', '62211844', 'jrisantosgt@gmail.com', 'Memember', 'Recovery Answer', '84.17.37.248', 0),
(218, 'Somebody5', '12345678910', 'realxboxplays@gmail.com', 'Memember', 'yes', '71.217.5.5', 0),
(219, 'iloveusingcheats', 'G<v4jWXv<<=>U3.', 'fu5096870@gmail.com', 'Memember', 'ilikedicknig', '205.250.1.8', 0),
(220, 'wag1', 'Gravity6191', 'veryhigh27000@gmail.com', 'Memember', 'Karan', '84.71.45.169', 0),
(221, 'seb4', 'seba12', 'kupsontoty@gmail.com', 'Memember', 'seb4', '77.65.101.215', 0),
(222, 'lulmans1', 'lulmans1', 'apjuvkxbuwurwdjgmb@sdvft.com', 'Memember', 'lulmans1', '77.65.101.215', 0),
(223, 'LeC2FA', 'Fatterdu02500', 'lec.pro02@gmail.com', 'Memember', 'Clement', '81.220.208.251', 0),
(224, 'Bislung0', 'Ryan2008/', 'lungobis@gmail.com', 'Memember', 'Rondo', '49.236.27.158', 0),
(225, 'Bozzy', 'EmsEjs12#$', 'bozzycheats@gmail.com', 'Memember', 'Bozzy', '82.31.9.80', 0),
(226, 'Manoemad90Emademad', 'Manomano1', 'manoemad12182@gmail.com', 'Memember', 'Dont help your self', '156.195.31.255', 0),
(227, 'azzamxl', '0540521783', 'bozhr2h@gmail.com', 'Memember', '054052', '93.168.246.222', 0),
(228, 'SamuFn', 'ciao00', 'samuelecerbelli10@gmail.com', 'Memember', 'Recovery Answer', '93.146.170.228', 0),
(229, 'Fritzi28', 'Minecraft2801', 'yanfri6098@gmail.com', 'Memember', 'Recovery Answer', '194.166.92.254', 0),
(230, 'farridxbby', 'farid200888', 'rahmanifarid501@gmail.com', 'Memember', 'idk', '94.139.4.235', 0),
(231, 'samu0103', 'samu4101', 'sakusakkuri10@gmail.com', 'Memember', 'samu', '219.124.14.114', 0),
(232, 'Snaxxor', 'meginka1574', 'kikijelaska@seznam.cz', 'Memember', 'pejsek', '85.190.71.61', 0),
(233, 'Falixz', 'cyganek111', 'jakub.svacek2009@gmail.com', 'Memember', 'cigosmore', '85.190.73.220', 0),
(234, 'jusn4566', 'add12151', 'refvvmartin@gmail.com', 'Memember', 'are you gay', '68.206.204.238', 0),
(235, 'Riixo', 'Jordanb7', 'esrxction@gmail.com', 'Memember', 'Riixo', '109.219.133.197', 0),
(236, 'denis2006', 'madalinaq1', 'bestkidaz@gmail.com', 'Memember', 'denis', '92.85.145.211', 0),
(237, 'user', 'Mg661978', 'bobby4455661122@gmail.com', 'Memember', '6619', '66.176.104.28', 0),
(238, 'DevHexry', '101183ah', '15ahenry7989@gmail.com', 'Premiuim', 'Dev', '174.101.94.172', 0),
(239, 'Jaycethegoat', 'Jace1414', 'Mailrfttttttttttttt@ghfhg.ghgyh', 'Memember', 'Recovery Answer', '135.134.137.204', 0),
(240, 'guy69', 'MehmU2009', 'Mehmet.ustun000@gmail.com', 'Memember', 'Sexy gay porn', '159.196.169.192', 0),
(241, 'Januppi', 'Hakala1234@', 'januppi@hotmail.com', 'Memember', 'pc', '85.76.23.105', 0),
(242, 'SynXV', 'goroy1', 'kiddhlng@gmail.com', 'Memember', 'Yes', '142.126.134.226', 0),
(243, 'gokuonelove', 'Hekanamberone15', 'abobaboba3@mail.ru', 'Memember', 'Hekanamberone15', '192.162.36.72', 0),
(244, 'ilovehacks', 'Hill6010', 'buddyroo6@gmail.com', 'Memember', '14', '170.205.169.108', 0),
(245, 'Wulfix', 'Dircksen_45', 'noah_tre@web.de', 'Memember', 'Recovery Answer', '80.133.112.236', 0),
(246, 'acafaca123', 'acafaca123', 'lazarivanoski021@gmail.com', 'Memember', 'cat', '95.180.46.12', 0),
(247, 'Raudrev', 'Alex2016@', 'fox.mccloud433@gmail.com', 'Memember', 'Kitsune', '178.201.144.180', 0),
(248, 'draku666', 'Robert32', 'r_liviu_bau@yahoo.de', 'Memember', 'bau', '95.91.234.74', 0),
(249, 'XaFi_ziom', 'Zuzanna45a', 'Mailbarteczekfb@gmail.com', 'Memember', 'mam psa?', '83.24.190.127', 0),
(250, 'derron', 'Derron1432!', 'derronsupercool@gmail.com', 'Memember', 'poggers', '46.244.59.235', 0),
(251, 'MrSkopi', 'zaqwedcxss1', 'meznikovrash@gmail.cpm', 'Memember', 'fdfd', '85.26.165.32', 0),
(252, 'elrexihd', 'afane123', 'therexihd@gmail.com', 'Memember', 'boby', '189.173.57.156', 0),
(253, 'ariana', 'romuslikegolax', 'andreiedu29@gmail.com', 'Memember', 'edu', '82.76.31.101', 0),
(254, 'KATE', 'nigger', 'kateclubkate@protonmail.com', 'Memember', 'Whats a nigger ? YES', '93.193.132.123', 0),
(255, 'Real_NOZU', 'Louis12345', 'coolerheinz21@protonmail.com', 'Memember', 'alter?', '91.32.18.230', 0),
(256, 'Extry', 'Nehajhekati12345', 'seserko.jan@gmail.com', 'Memember', 'idk123', '86.58.83.206', 0),
(257, 'cyrr', '1349Kian05', 'kianintros@gmail.com', 'Memember', '1349Kian05', '90.217.191.191', 0),
(258, 'Miguelaw', 'Dedemiguel02', 'andreebernique@gmail.com', 'Memember', 'Dede', '91.165.139.66', 0),
(259, 'ZepMep', 'TepVepMep', 'dwadwadaw', 'Memember', 'dwadaw', '176.88.46.255', 0),
(260, 'CrazYVFX', 'Polonia101', 'btwnotcrazy@gmail.com', 'Memember', 'Badbad101', '73.212.31.3', 0),
(261, 'brenzz', 'Poopoo20098', 'brenanlloyd2009@outlook.com', 'Memember', 'brenan', '109.153.72.36', 0),
(262, 'sairenfin', '098765Aaro', 'aaro.siren@gmail.com', 'Memember', 'aaro.siren@gmail.com', '176.72.151.191', 0),
(263, 'koris', 'koris', 'recon2', 'Memember', 'recon2', '94.134.107.180', 0),
(264, 'Drax500', 'Drax500', 'drax500@gmail.com', 'Memember', 'MES', '89.39.206.85', 0),
(265, 'Teeqly', 'mischa290403', 'kanakemagaffe@gmail.com', 'Memember', 'Pabo or Pablo?', '91.50.119.227', 0),
(266, 'SoulPriya', '2232007silas', 'coolercrasch.de@gmail.com', 'Memember', 'nigger', '185.232.23.45', 0),
(267, 'adamec', 'adamec28', 'adamec.molnar@gmail.com', 'Memember', 'adamec', '178.41.192.33', 0),
(268, 'voulz', 'PasswordLogEas#1', 'vbffnj80@gmail.com', 'Memember', 'lady', '75.70.151.246', 0),
(269, 'Plazzin', 'carneiro38', 'piragibe.pedro2020@gmail.com', 'Memember', 'cachorro', '191.180.33.190', 0),
(270, 'kadsdas', 'sadfrsdgfeasd', 'asdAWsFfa@gmail.com', 'Memember', 'asfaewsd', '79.101.187.230', 0),
(271, 'S҉H҉O҉T҉', 'Shot#6037', 'melovecheeto@gmail.com', 'Memember', 'S҉H҉O҉T҉', '65.190.147.238', 0),
(272, 'marc8089', 'marc8089', 'mp147246@gmail.com', 'Memember', 'marc', '91.6.231.241', 0),
(273, 'dis4', 'ChrisTheG21', 'christian1051veloz@gmail.com', 'Memember', 'dis4', '73.204.222.251', 0),
(274, 'HASSANMAKKI', 'makmak10', 'mmak7194@gmail.com', 'Memember', 'man', '80.83.21.107', 0),
(275, 'salemkhalid', 'Salemkhalid2007', 'io2007salem@gmail.com', 'Memember', 'salem', '130.164.171.43', 0),
(276, 'ericim3', '50auto', 'bottyeater07@gmail.com', 'Memember', 'rawfaf', '1.40.227.23', 0),
(277, 'killerman', 'makmak10-', 'makpsn10mak@gmail.com', 'Memember', 'hassan', '80.83.21.105', 0),
(278, 'miheb is banned2', 'Baboucha1010.', 'amelkhouja00@gmail.com', 'Memember', 'Recovery Answer', '193.121.94.225', 0),
(279, 'Soppe', 'SoeVieLOOL2020', 'sooppssee.hd@gmail.com', 'Memember', 'Blau', '95.222.109.83', 0),
(280, 'Lukasgj', 'Lu!Free$478', 'Hakanplag@gmail.com', 'Memember', 'Meine Erste Schule', '83.135.189.233', 0),
(281, 'VideoTest', 'dsdsa3432', 'test123@gmail.com', 'Memember', 'dsadas', '82.121', 0),
(282, 'Lukashateinkleinen', 'Finn1312', 'Leon1312.1@protonmail.com', 'Memember', 'Finn1312', '89.249.65.117', 0),
(283, 'Finn', 'Finn1312', 'finnlauraja@gmail.com', 'Memember', 'Finn1312', '37.201.147.111', 0),
(284, 'Usaimbotistheername', 'dustiniscrazy2', 'iglgalaxy917@gmail.com', 'Memember', 'here', '73.39.117.96', 0),
(285, 'Tino3108', 'tutoapp1', 'tutoapp4@gmail.com', 'Memember', 'Baum', '95.223.77.71', 0),
(286, 'dzfdfdfs', 'Passwordsdfdfs', 'Maildsffds', 'Memember', 'Recovery Answerfdsdsf', '82.222.99.121', 0),
(287, 'AplixoOnTop', 'enzo1983!', 'wayzox38@gmail.com', 'Premium', 'Recovery Answer', '85.190.69.54', 0),
(288, 'Xosnipers', 'Daddy123', 'ilovesunder123@gmail.com', 'Memember', 'Daddy', '99.135.42.153', 0),
(289, 'SaikoHatePo', 'mimmmoerric2', 'enzoerricboss@gmail.com', 'Memember', 'enzo', '85.190.73.76', 0),
(290, 'Mbsz', 'Kiannmobbs10', 'Kiannmobbs10', 'Memember', 'Laila', '109.147.156.193', 0),
(291, 'Novohax', 'Mackensen1', 'felixhennemackensen@icloud.com', 'Memember', 'no', '87.168.199.147', 0),
(292, 'gaby', 'Kamilis123.', 'gabrielius908@gmail.com', 'Memember', 'brother', '92.13.89.50', 0),
(293, 'jessejay4208', 'jjmcdonald1', 'hayjesse672@gmail.com', 'Memember', 'fortnite', '104.205.178.64', 0),
(294, 'Martinhghg1', 'Martin4578', 'martinhghghty@gmail.com', 'Memember', 'Recovery Answer', '186.67.209.237', 0),
(295, 'dayrox12', 'dayrox12', 'dayrox12@gmail.com', 'Memember', 'dayrox', '104.251.47.148', 0),
(296, 'Ataraxy', 'Maria9000', 'withdrawme999@gmail.com', 'Memember', 'Gold', '212.20.157.117', 0),
(297, 'kogy619', '010101', 'ahmedkogy619@gmail.com', 'Memember', 'ahmed', '45.247.43.143', 0),
(298, 'itachi', 'itachi', 'jaicarranjoshua@gmail.com', 'Memember', 'hey', '76.69.56.96', 0),
(299, 'Sarp', 'Sarp31', 'sarpingo@protonmail.com', 'Memember', '31', '79.98.131.45', 0),
(300, 'Kixzy', 'david3pulol', 'Lookmyytchannel@gmail.com', 'Memember', '! K1xzy#1337', '65.38.85.103', 0),
(301, 'dancekk', 'danimodic33', 'dancekk31@gmail.com', 'Memember', 'xd', '89.212.91.240', 0),
(302, 'cenix', 'Alennik12', 'cenixa1r123@gmail.com', 'Memember', 'YourMom', '213.161.27.91', 0),
(303, 'bryxz', 'pomme420', 'antho.gauthier99@gmail.com', 'Memember', 'beberebi', '173.178.164.52', 0),
(304, 'CIA967', '@Hmedkhaled967', 'ninjaportsaid967@gmail.com', 'Memember', 'meow', '45.246.231.57', 0),
(305, 'BadVibesForever', 'bigpenishopesar', 'collinprice69@gmail.com', 'Memember', 'big cock', '160.3.180.90', 0),
(306, 'Mexify', 'Spncejulianis2021', 'spncejulian30@gmail.com', 'Memember', 'Casper', '71.69.113.46', 0),
(307, 'Mom', 'Mom', 'sdvcds@gmail.com', 'Memember', 'ss', '161.35.52.17', 0),
(308, 'NTGG', 'NThackers1', 'GGbro', 'Memember', 'NTbro', '27.136.182.62', 0),
(309, 'The1stKorner', 'The4Kornerz', 'coletrickle460@gmail.com', 'Memember', 'Shadow', '184.91.189.184', 0),
(310, 'Deaglezz', 'jalynJacob23', 'jalynj331@gmail.com', 'Premium', 'jalyn', '69.133.144.229', 0),
(311, 'anoyn337', 'Lane2007', 'lanemaitland07@gmail.com', 'Memember', 'Recovery', '101.167.4.76', 0),
(312, 'txny', 'MLGPEEp123', 'nxtcrxcked1@gmail.com', 'Memember', 'yeet', '73.177.146.30', 0),
(313, 'Kuii', 'Cholo0712', 'sombodisteam@gmail.com', 'Memember', 'kripton', '94.129.189.3', 0),
(314, 'steamblaze', 'steamblaze9', 'kphoush@gmail.com', 'Memember', 'meimei', '184.57.177.221', 0),
(316, 'Puma.Dev', 'Colepirrone9', 'firefoxtesting111@gmail.com', 'Memember', 'Puma.Dev', '73.160.233.204', 0),
(317, 'frank', 'Sethisfat21', 'billjn92@gmail.com', 'Premium', 'monkey', '69.14.66.107', 0),
(318, 'Crows', 'Sebas90-', 'Segsyzackyy@gmail.com', 'Memember', 'mo', '74.12.164.18', 0),
(319, 'Heizo', 'Heizo', 'Heizo', 'Memember', 'Heizo', '41.143.53.222', 0),
(320, 'UsernameDFS', 'PasswordDSF', 'MailDSF', 'Memember', 'Recovery AnswerFDS', '82.222.99.128', 0),
(321, 'Baum', 'Baum21', 'baum2103@gmail.com', 'Memember', 'Baum', '93.219.111.141', 0),
(322, 'Porek', 'Porek1Porek', 'benesfilip656@gmail.com', 'Memember', 'BOB', '78.80.228.245', 0),
(323, 'magic3hole', 'Goodwater123', 'kjcjmkiq@leadwizzer.com', 'Memember', 'juice', '73.194.164.243', 0),
(324, 'zelax3423', 'victor1020', 'vf2622173@gamail.com', 'Memember', 'Recovery Answer', '31.10.161.168', 0),
(325, 'wavy627', 'josemiko7', 'adadad@gmail.com', 'Memember', 'poto', '189.195.194.131', 0),
(326, 'QaxFamm', 'Deadass', 'jovanpreetdeol@gmail.com', 'Memember', 'Whats qax favorite food', '131.106.73.71', 0),
(327, '[BAD]ImSorry', '0766151178', 'eyenameiskhang@gmail.com', 'Memember', 'Imlove', '113.180.132.106', 0),
(328, 'keppe006', 'Wille.200', 'kokman6767@gmail.com', 'Memember', 'kok', '91.150.39.76', 0),
(329, 'LaVidaLoca', 'Vaaal0610', 'Valmir2006@icloud.com', 'Memember', 'salpd', '178.195.186.165', 0),
(330, 'h4ted', 'h4ted', 'h4ted@gmail.com', 'Memember', 'h4ted', '78.48.167.110', 0),
(331, 'blaxks', 'Que123456789', 'kingme6989', 'Memember', 'DonDon', '75.177.230.60', 0),
(332, 'Crixpie', 'Superman1', 'youngking3828@yopmail.com', 'Memember', 'YoungJd', '97.104.50.177', 0),
(333, 'Martinhghgh1', 'Martin4578', 'avvvvv@gmail.com', 'Memember', 'Milonchi3', '181.43.131.83', 0),
(334, 'Ricardo074', 'Metin1980', 'maneud123456@gmail.com', 'Memember', '123', '86.95.116.89', 0),
(335, 'westo', '1234567', 'weewesto1611@gmail.com', 'Memember', 'same', '84.64.92.86', 0),
(336, 'Ski', 'Bryan200528', 'camachobyan869@gmail.com', 'Memember', 'your mom', '66.176.19.49', 0);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`,`email`),
  ADD UNIQUE KEY `username_2` (`username`,`email`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `message`
--
ALTER TABLE `message`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=179;

--
-- Tablo için AUTO_INCREMENT değeri `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=337;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

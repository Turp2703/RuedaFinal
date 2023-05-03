-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-11-2022 a las 19:01:43
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `ruedafinal`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `ID` int(10) NOT NULL,
  `Fecha_Inicio` date NOT NULL,
  `Fecha_Ultimo_Pago` date NOT NULL,
  `Fecha_Vencimiento` date NOT NULL,
  `Meses_Antiguedad` int(3) NOT NULL,
  `Precio_Alquiler` int(12) NOT NULL,
  `Inmueble_ID` int(11) NOT NULL,
  `Inquilino_DNI` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`ID`, `Fecha_Inicio`, `Fecha_Ultimo_Pago`, `Fecha_Vencimiento`, `Meses_Antiguedad`, `Precio_Alquiler`, `Inmueble_ID`, `Inquilino_DNI`) VALUES
(1, '2017-03-16', '2019-11-07', '2019-12-07', 68, 11498, 7, '911436270'),
(2, '2016-08-01', '2022-01-27', '2022-02-27', 76, 40213, 1, '290798539'),
(3, '2018-04-04', '2022-02-25', '2022-03-25', 55, 142211, 18, '742361454'),
(4, '2018-02-18', '2022-08-16', '2022-09-16', 57, 19255, 19, '399121577'),
(5, '2016-02-24', '2019-12-27', '2020-01-27', 81, 172410, 14, '916437134'),
(6, '2018-03-23', '2021-07-05', '2021-08-05', 56, 21833, 17, '117731212'),
(7, '2018-01-28', '2022-08-19', '2022-09-19', 58, 102429, 12, '716428921'),
(8, '2017-12-23', '2019-12-30', '2020-01-30', 59, 144024, 5, '614397508'),
(9, '2016-09-21', '2020-05-05', '2020-06-05', 74, 94096, 13, '153915905'),
(10, '2018-01-30', '2021-01-09', '2021-02-09', 58, 32134, 6, '85674532'),
(11, '2015-11-14', '2022-01-15', '2022-02-15', 84, 10892, 15, '803866632'),
(12, '2017-05-29', '2022-07-29', '2022-08-29', 66, 159316, 16, '181675965'),
(13, '2017-02-02', '2021-06-07', '2021-07-07', 70, 171732, 4, '545961038'),
(14, '2018-05-22', '2022-09-05', '2022-10-05', 54, 178141, 2, '811707612'),
(15, '2018-09-04', '2020-03-28', '2020-04-28', 50, 189919, 3, '911436270');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `ID` int(10) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Clave` varchar(80) NOT NULL,
  `Tipo_ID` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cuenta`
--

INSERT INTO `cuenta` (`ID`, `Usuario`, `Clave`, `Tipo_ID`) VALUES
(1, 'admin', 'd033e22ae348aeb5660fc2140aec35850c4da997', 1),
(2, 'normal', '9c2a6e4809aeef7b7712ca4db05a681452f4f748', 2),
(3, 'rueda', '8b4e77564ffc0caac7d25c7ceea01c3c6aad9bdf', 2),
(7, 'trueda', '6ac80cf84206ab44a0c08f697f7150b68a3297ba', 2),
(8, 'ruedi', '1fa5f77cbf7c53573d8c148bfe4e5df984032158', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `dueno`
--

CREATE TABLE `dueno` (
  `DNI` varchar(9) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `Direccion_Calle` varchar(50) NOT NULL,
  `Direccion_Numero` int(5) NOT NULL,
  `Sexo` varchar(10) NOT NULL,
  `Fecha_Nacimiento` date NOT NULL,
  `Codigo_Postal` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `dueno`
--

INSERT INTO `dueno` (`DNI`, `Nombre`, `Apellido`, `Direccion_Calle`, `Direccion_Numero`, `Sexo`, `Fecha_Nacimiento`, `Codigo_Postal`) VALUES
('11111112', 'Nombre1', 'Apellido1', 'Direccion1', 1111, 'Hombre', '2001-01-01', '8000'),
('11788124', 'Gothart', 'Filyashin', 'Veith', 74, 'Hombre', '1968-09-28', '8000'),
('16464205', 'Farrah', 'Naerup', 'Hallows', 7, 'Hombre', '1987-10-22', '2'),
('25601736', 'Owen', 'Turmall', 'Browning', 38, 'Mujer', '1958-06-18', '46577'),
('25765717', 'Ottilie', 'Passie', 'Oak', 76376, 'Hombre', '1968-02-28', '3'),
('33', 'Test33', 'Test33', 'Test33', 33, 'Mujer', '2022-10-25', '8033'),
('44651657', 'Rhodia', 'Sheer', 'Lerdahl', 5, 'Mujer', '1960-07-12', '2'),
('4511895', 'Trina', 'Lauga', 'Almo', 6, 'Hombre', '2007-04-28', '5445'),
('46814512', 'Felice', 'Glasscoo', 'Meadow Valley', 473, 'Mujer', '2010-05-21', '8000'),
('47839781', 'Renate', 'Zmitrichenko', 'Charing Cross', 858, 'Hombre', '1997-03-30', '4113'),
('53760219', 'Arv', 'Follis', 'Dahle', 9091, 'Mujer', '2010-06-16', '5445'),
('59238259', 'Aurelea', 'Haggerty', 'Atwood', 207, 'Mujer', '1968-01-13', '92364'),
('66633728', 'Adrianne', 'Cridland', 'Farwell', 80075, 'Hombre', '1982-11-16', '8033'),
('74024846', 'Wells', 'Hearthfield', 'Eastwood', 37257, 'Mujer', '2009-09-11', '5445'),
('80314759', 'Creigh', 'Potticary', 'Arrowood', 53, 'Hombre', '2021-12-08', '3'),
('84301008', 'Lin', 'Arbuckel', 'Village Green', 74657, 'Mujer', '1999-11-12', '5445'),
('85141134', 'Cordie', 'Saphin', 'Weeping Birch', 58, 'Mujer', '2019-09-27', '3'),
('92574439', 'Pauly', 'Sture', 'Golf View', 2, 'Hombre', '2013-02-19', '19161'),
('93', 'Dueno93', 'Apellido93', 'Calle93', 93, 'Hombre', '2022-11-06', '92364'),
('95874918', 'Cordie', 'Saundercock', 'Magdeline', 233, 'Hombre', '1984-06-30', '41715'),
('96702104', 'Clary', 'MacMeeking', 'Kings', 21, 'Mujer', '1999-06-16', '7'),
('98478819', 'Kyla', 'Maycock', 'Anniversary', 55317, 'Hombre', '1974-04-13', '3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `duenoemail`
--

CREATE TABLE `duenoemail` (
  `Dueno_DNI` varchar(9) NOT NULL,
  `EMail` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `duenoemail`
--

INSERT INTO `duenoemail` (`Dueno_DNI`, `EMail`) VALUES
('11111112', 'elivingstonm@shutterfly.com'),
('11111112', 'email11@gmail.com'),
('11111112', 'email1@gmail.com'),
('11111112', 'fcavozzi18@nytimes.com'),
('11111112', 'hbolton0@mozilla.org'),
('11788124', 'ftaudevinn@sina.com.cn'),
('11788124', 'sgrindle1@ocn.ne.jp'),
('16464205', 'afelix2@edublogs.org'),
('16464205', 'swartnabyo@google.es'),
('25601736', 'achanders3@symantec.com'),
('25601736', 'vahrensp@economist.com'),
('25765717', 'dbende4@jimdo.com'),
('25765717', 'dgrixq@scientificamerican.com'),
('33', '3333@333'),
('33', 'cwalkingshaw5@mayoclinic.com'),
('33', 'jwittringtonr@paginegialle.it'),
('44651657', 'emconies@house.gov'),
('44651657', 'sdooney6@arizona.edu'),
('4511895', 'snorthing7@seesaa.net'),
('4511895', 'wdelislet@privacy.gov.au'),
('46814512', 'aflattu@nasa.gov'),
('46814512', 'bboyles8@soundcloud.com'),
('47839781', 'dsommerledv@wikipedia.org'),
('47839781', 'pscholler9@seattletimes.com'),
('53760219', 'cburtona@state.gov'),
('53760219', 'dpropperw@nbcnews.com'),
('59238259', 'cblackstonx@scribd.com'),
('59238259', 'kreyeb@craigslist.org'),
('66633728', 'mhottony@house.gov'),
('66633728', 'ndelacotec@fda.gov'),
('74024846', 'asinnockez@delicious.com'),
('74024846', 'dwoodnuttd@altervista.org'),
('80314759', 'adarcy10@bizjournals.com'),
('80314759', 'wcarre@bbc.co.uk'),
('84301008', 'laslam11@ca.gov'),
('84301008', 'lspinolaf@etsy.com'),
('85141134', 'keye13@typepad.com'),
('85141134', 'trueggh@fema.gov'),
('92574439', 'bkinmani@reddit.com'),
('92574439', 'pcollomosse14@samsung.com'),
('93', 'ene93@gmail.com'),
('95874918', 'mlivezleyj@addtoany.com'),
('95874918', 'raim15@geocities.jp'),
('96702104', 'mbertsonk@xrea.com'),
('96702104', 'rklauer16@live.com'),
('98478819', 'jmccurley17@marriott.com'),
('98478819', 'mgoodanewl@squarespace.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `duenotelefono`
--

CREATE TABLE `duenotelefono` (
  `Dueno_DNI` varchar(9) NOT NULL,
  `Telefono` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `duenotelefono`
--

INSERT INTO `duenotelefono` (`Dueno_DNI`, `Telefono`) VALUES
('11111112', '1111'),
('11111112', '11111'),
('11111112', '3061797266'),
('11111112', '5522004005'),
('11111112', '6735104686'),
('11788124', '390105366'),
('11788124', '3985720360'),
('16464205', '3031208060'),
('16464205', '4987080230'),
('25601736', '3612180219'),
('25601736', '4648116672'),
('25765717', '6128226696'),
('25765717', '7976927594'),
('33', '33333'),
('33', '7246631237'),
('33', '7521106400'),
('44651657', '1940702966'),
('44651657', '3790825425'),
('4511895', '4209849439'),
('4511895', '815548214'),
('46814512', '2820751217'),
('46814512', '6942894217'),
('47839781', '6076253694'),
('47839781', '8174408949'),
('53760219', '6895589646'),
('53760219', '9647583312'),
('59238259', '1367892334'),
('59238259', '3856099681'),
('66633728', '535053514'),
('66633728', '560570437'),
('74024846', '1363565591'),
('74024846', '9774086014'),
('80314759', '7485836061'),
('80314759', '831982849'),
('84301008', '1175863261'),
('84301008', '1432444271'),
('85141134', '1296829909'),
('85141134', '5370429922'),
('92574439', '3741992727'),
('92574439', '5370465430'),
('93', '9393939393'),
('93', '93939933'),
('93', '999333'),
('95874918', '3255970788'),
('95874918', '8643537648'),
('96702104', '4263118414'),
('96702104', '6725656453'),
('98478819', '3535234619'),
('98478819', '5317270826');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `ID` int(11) NOT NULL,
  `Descripcion` varchar(60) NOT NULL,
  `Numero_Partida` varchar(20) NOT NULL,
  `Direccion_Calle` varchar(50) NOT NULL,
  `Direccion_Numero` int(5) NOT NULL,
  `Precio_Venta` int(12) NOT NULL,
  `Superficie` int(4) NOT NULL,
  `Ambientes` int(2) NOT NULL,
  `Dormitorios` int(2) NOT NULL,
  `Banos` int(2) NOT NULL,
  `Patio` tinyint(1) NOT NULL,
  `Garaje` tinyint(1) NOT NULL,
  `Propietario_DNI` varchar(9) NOT NULL,
  `Codigo_Postal` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inmueble`
--

INSERT INTO `inmueble` (`ID`, `Descripcion`, `Numero_Partida`, `Direccion_Calle`, `Direccion_Numero`, `Precio_Venta`, `Superficie`, `Ambientes`, `Dormitorios`, `Banos`, `Patio`, `Garaje`, `Propietario_DNI`, `Codigo_Postal`) VALUES
(1, 'arcu libero rutrum', '555-506542-1', 'Chinook', 53, 53, 8, 17, 3, 2, 0, 0, '11111112', '3'),
(2, 'eleifend donec ut dolor', '713-930992-6', 'Darwin', 93, 594477307, 114, 1, 3, 2, 0, 0, '11788124', '3'),
(3, 'sem duis aliquam convallis', '474-944023-0', 'Melvin', 889, 400781510, 62, 8, 3, 2, 0, 0, '16464205', '7'),
(4, 'nunc proin at turpis', '896-755874-6', 'Ridgeway', 7144, 526511752, 79, 5, 2, 2, 0, 0, '25601736', '8000'),
(5, 'in hac', '242-018367-6', 'Browning', 3688, 692462114, 22, 10, 1, 4, 0, 0, '25765717', '8001'),
(6, 'morbi vestibulum velit id', '025-838644-7', 'Nelson', 85, 425687949, 110, 5, 3, 4, 0, 0, '33', '46577'),
(7, 'quis justo maecenas rhoncus', '478-313586-0', 'Morningstar', 68085, 785526352, 144, 12, 2, 3, 0, 0, '4511895', '8987'),
(8, 'ornare imperdiet sapien', '754-551220-9', 'Sheridan', 124, 710544759, 128, 19, 2, 1, 0, 0, '46814512', '46577'),
(9, 'proin interdum mauris', '954-047798-8', 'Cherokee', 11262, 530842485, 111, 14, 2, 3, 0, 0, '47839781', '3'),
(10, 'libero non mattis', '029-057859-7', 'Westerfield', 5047, 203548245, 29, 12, 1, 2, 0, 0, '53760219', '8000'),
(11, 'vulputate elementum nullam varius', '555-249002-5', 'Briar Crest', 3, 374094537, 109, 17, 4, 4, 0, 0, '59238259', '5'),
(12, 'massa id nisl', '967-813833-7', 'Truax', 3116, 355070611, 97, 18, 3, 1, 0, 0, '66633728', '2'),
(13, 'lorem integer tincidunt', '112-836199-7', 'Nevada', 7, 39877706, 40, 11, 3, 2, 0, 0, '74024846', '46577'),
(14, 'ante nulla justo aliquam', '563-495089-8', 'Mendota', 77, 816626871, 30, 19, 1, 4, 0, 0, '80314759', '8033'),
(15, 'pellentesque volutpat dui', '794-524790-1', 'Mendota', 2107, 860085991, 70, 16, 2, 4, 0, 0, '84301008', '8000'),
(16, 'dictumst morbi', '888-007806-9', 'Schmedeman', 250, 856181990, 127, 19, 2, 3, 0, 0, '85141134', '5445'),
(17, 'eu interdum', '360-698008-1', 'Moulton', 3, 902992020, 126, 13, 1, 4, 0, 0, '92574439', '8987'),
(18, 'curabitur convallis duis consequat', '337-798349-4', 'Spenser', 2, 734068316, 71, 20, 1, 3, 0, 0, '95874918', '8033'),
(19, 'magna bibendum imperdiet nullam', '059-727615-6', 'Pierstorff', 7, 257359339, 121, 11, 1, 2, 0, 0, '96702104', '3'),
(20, 'pretium iaculis', '884-395721-3', 'Petterle', 630, 411345098, 111, 5, 3, 3, 0, 0, '98478819', '4113');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `DNI` varchar(9) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `Sexo` varchar(10) NOT NULL,
  `Fecha_Nacimiento` date NOT NULL,
  `Ocupacion` varchar(50) NOT NULL,
  `Cantidad_Vehiculos` int(2) NOT NULL,
  `Codigo_Postal` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`DNI`, `Nombre`, `Apellido`, `Sexo`, `Fecha_Nacimiento`, `Ocupacion`, `Cantidad_Vehiculos`, `Codigo_Postal`) VALUES
('117731212', 'Tessa', 'Grosvenor', 'Hombre', '2017-04-18', 'Services', 5, '41715'),
('153915905', 'Monika', 'Barmby', 'Hombre', '2008-10-14', 'Research and Development', 1, '8000'),
('181675965', 'Letti', 'Cowles', 'Mujer', '2020-10-21', 'Sales', 2, '8987'),
('290798539', 'Therine', 'Maffioni', 'Hombre', '2020-08-04', 'Training', 1, '2'),
('399121577', 'Michale', 'Hauck', 'Mujer', '2009-04-11', 'Accounting', 2, '3'),
('545961038', 'Atlanta', 'Broodes', 'Mujer', '2022-03-13', 'Human Resources', 3, '95583'),
('555499105', 'Bartlett', 'Plews', 'Hombre', '2014-02-24', 'Marketing', 0, '7'),
('614397508', 'Star', 'Laughton', 'Mujer', '2017-02-12', 'Marketing', 0, '7'),
('716428921', 'Lolly', 'Cartman', 'Hombre', '2009-02-24', 'Accounting', 4, '46577'),
('742361454', 'Alica', 'Rounce', 'Mujer', '2014-03-24', 'Marketing', 4, '2'),
('803866632', 'Josselyn', 'Kelberman', 'Hombre', '2009-09-07', 'Sales', 3, '8033'),
('811707612', 'Thebault', 'Revell', 'Mujer', '2011-02-26', 'Engineering', 1, '95583'),
('85674532', 'Penny', 'Hawarden', 'Hombre', '2010-12-06', 'Product Management', 0, '8001'),
('911436270', 'Ursala', 'Scotchbrook', 'Hombre', '2013-07-23', 'Engineering', 0, '19161'),
('916437134', 'Jorey', 'Farre', 'Hombre', '2014-05-12', 'Legal', 2, '3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilinoemail`
--

CREATE TABLE `inquilinoemail` (
  `Inquilino_DNI` varchar(9) NOT NULL,
  `EMail` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilinoemail`
--

INSERT INTO `inquilinoemail` (`Inquilino_DNI`, `EMail`) VALUES
('117731212', 'tjakese@indiatimes.com'),
('153915905', 'athomson3@weebly.com'),
('153915905', 'bcroysera@globo.com'),
('153915905', 'dpiesold8@umich.edu'),
('153915905', 'kdigges9@webs.com'),
('153915905', 'tmcparlin4@hubpages.com'),
('153915905', 'traisbeckb@virginia.edu'),
('181675965', 'bblofieldd@google.co.jp'),
('181675965', 'ztwell5@army.mil'),
('290798539', 'ahanfrey2@ca.gov'),
('290798539', 'gsimioni6@macromedia.com'),
('399121577', 'cslimmon2@imgur.com'),
('399121577', 'lconeybeer4@cargocollective.com'),
('399121577', 'tjurisch1@seesaa.net'),
('545961038', 'cjewes1@mtv.com'),
('555499105', 'tmckissack7@flickr.com'),
('614397508', 'espacey3@cpanel.net'),
('614397508', 'kmerrick5@dedecms.com'),
('614397508', 'pleppingwell0@rediff.com'),
('716428921', 'rdimmacka@joomla.org'),
('716428921', 'wlincolnb@ibm.com'),
('742361454', 'cmoringc@hugedomains.com'),
('742361454', 'kmeuse@mit.edu'),
('742361454', 'ksworn0@redcross.org'),
('803866632', 'cfourmyc@trellian.com'),
('803866632', 'wscandrick0@unblog.fr'),
('811707612', 'cduckels2@fotki.com'),
('811707612', 'mrevening8@example.com'),
('85674532', 'schristoffe1@usa.gov'),
('85674532', 'vsherburn5@loc.gov'),
('85674532', 'yrountree6@jiathis.com'),
('911436270', 'lgrealish7@altervista.org'),
('911436270', 'mchrystie4@moonfruit.com'),
('911436270', 'uwadelind@angelfire.com'),
('916437134', 'afishleigh3@yahoo.co.jp'),
('916437134', 'btorrisi9@hatena.ne.jp');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilinotelefono`
--

CREATE TABLE `inquilinotelefono` (
  `Inquilino_DNI` varchar(9) NOT NULL,
  `Telefono` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilinotelefono`
--

INSERT INTO `inquilinotelefono` (`Inquilino_DNI`, `Telefono`) VALUES
('117731212', '39328349433'),
('117731212', '55735564258'),
('153915905', '60008321563'),
('153915905', '88513023146'),
('181675965', '19083715209'),
('181675965', '62781901088'),
('290798539', '47346671999'),
('290798539', '91192297755'),
('399121577', '19984046568'),
('399121577', '24944167037'),
('545961038', '16131748966'),
('545961038', '55212120096'),
('555499105', '35805105855'),
('555499105', '60311486907'),
('614397508', '30157117496'),
('614397508', '63515218698'),
('716428921', '23992942402'),
('716428921', '86236607365'),
('742361454', '72275067835'),
('742361454', '84266307563'),
('803866632', '67840900912'),
('803866632', '76236239331'),
('811707612', '81583304451'),
('811707612', '99689378686'),
('85674532', '3530848691'),
('85674532', '3680593186'),
('911436270', '4696608329'),
('911436270', '78652800153'),
('916437134', '42825608610'),
('916437134', '69167958770');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `localidad`
--

CREATE TABLE `localidad` (
  `Codigo_Postal` varchar(20) NOT NULL,
  `Nombre` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `localidad`
--

INSERT INTO `localidad` (`Codigo_Postal`, `Nombre`) VALUES
('19161', 'Tocoa'),
('2', 'Ijero-Ekiti'),
('3', 'Pando'),
('4113', 'Břeclav'),
('41715', 'Tsant'),
('46577', 'Tawangrejo'),
('5', 'Lyon'),
('5445', 'Banī Ḩassān'),
('7', 'Horodne'),
('8000', 'Bahia Blanca'),
('8001', 'Bahia Blanca 1'),
('8033', 'Bahia Blanca 33'),
('8987', 'Emar'),
('92364', 'Sammatti'),
('95583', 'Karolinka');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipocuenta`
--

CREATE TABLE `tipocuenta` (
  `ID` int(10) NOT NULL,
  `Nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipocuenta`
--

INSERT INTO `tipocuenta` (`ID`, `Nombre`) VALUES
(1, 'Admin'),
(2, 'Normal');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `contrato_ibfk_3` (`Inquilino_DNI`),
  ADD KEY `contrato_ibfk_4` (`Inmueble_ID`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Tipo_ID` (`Tipo_ID`);

--
-- Indices de la tabla `dueno`
--
ALTER TABLE `dueno`
  ADD PRIMARY KEY (`DNI`),
  ADD KEY `Codigo_Postal` (`Codigo_Postal`);

--
-- Indices de la tabla `duenoemail`
--
ALTER TABLE `duenoemail`
  ADD PRIMARY KEY (`Dueno_DNI`,`EMail`);

--
-- Indices de la tabla `duenotelefono`
--
ALTER TABLE `duenotelefono`
  ADD PRIMARY KEY (`Dueno_DNI`,`Telefono`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Codigo_Postal` (`Codigo_Postal`),
  ADD KEY `Dueño_DNI` (`Propietario_DNI`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`DNI`),
  ADD KEY `Codigo_Postal` (`Codigo_Postal`);

--
-- Indices de la tabla `inquilinoemail`
--
ALTER TABLE `inquilinoemail`
  ADD PRIMARY KEY (`Inquilino_DNI`,`EMail`);

--
-- Indices de la tabla `inquilinotelefono`
--
ALTER TABLE `inquilinotelefono`
  ADD PRIMARY KEY (`Inquilino_DNI`,`Telefono`);

--
-- Indices de la tabla `localidad`
--
ALTER TABLE `localidad`
  ADD PRIMARY KEY (`Codigo_Postal`);

--
-- Indices de la tabla `tipocuenta`
--
ALTER TABLE `tipocuenta`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `tipocuenta`
--
ALTER TABLE `tipocuenta`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_3` FOREIGN KEY (`Inquilino_DNI`) REFERENCES `inquilino` (`DNI`) ON UPDATE CASCADE,
  ADD CONSTRAINT `contrato_ibfk_4` FOREIGN KEY (`Inmueble_ID`) REFERENCES `inmueble` (`ID`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`Tipo_ID`) REFERENCES `tipocuenta` (`ID`);

--
-- Filtros para la tabla `dueno`
--
ALTER TABLE `dueno`
  ADD CONSTRAINT `dueno_ibfk_1` FOREIGN KEY (`Codigo_Postal`) REFERENCES `localidad` (`Codigo_Postal`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `duenoemail`
--
ALTER TABLE `duenoemail`
  ADD CONSTRAINT `duenoemail_ibfk_1` FOREIGN KEY (`Dueno_DNI`) REFERENCES `dueno` (`DNI`);

--
-- Filtros para la tabla `duenotelefono`
--
ALTER TABLE `duenotelefono`
  ADD CONSTRAINT `duenotelefono_ibfk_1` FOREIGN KEY (`Dueno_DNI`) REFERENCES `dueno` (`DNI`);

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`Codigo_Postal`) REFERENCES `localidad` (`Codigo_Postal`) ON UPDATE CASCADE,
  ADD CONSTRAINT `inmueble_ibfk_2` FOREIGN KEY (`Propietario_DNI`) REFERENCES `dueno` (`DNI`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD CONSTRAINT `inquilino_ibfk_1` FOREIGN KEY (`Codigo_Postal`) REFERENCES `localidad` (`Codigo_Postal`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `inquilinoemail`
--
ALTER TABLE `inquilinoemail`
  ADD CONSTRAINT `inquilinoemail_ibfk_1` FOREIGN KEY (`Inquilino_DNI`) REFERENCES `inquilino` (`DNI`);

--
-- Filtros para la tabla `inquilinotelefono`
--
ALTER TABLE `inquilinotelefono`
  ADD CONSTRAINT `inquilinotelefono_ibfk_1` FOREIGN KEY (`Inquilino_DNI`) REFERENCES `inquilino` (`DNI`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

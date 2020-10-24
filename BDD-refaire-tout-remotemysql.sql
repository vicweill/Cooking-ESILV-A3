DROP database fLaEo2rVWb;
CREATE database fLaEo2rVWb;
use fLaEo2rVWb;

drop table if exists client;
drop table if exists recette;
drop table if exists produit;
drop table if exists fournisseur;
drop table if exists commande;
drop table if exists admin;
drop table if exists compose;
drop table if exists contient;
drop table if exists peutFournir;
drop table if exists remunere;
drop table if exists gere;



CREATE TABLE `fLaEo2rVWb`.`client` (
  `idClient` VARCHAR(20) NOT NULL,
  `nom` VARCHAR(20) NOT NULL,
  `prenom` VARCHAR(20) NOT NULL,
  `numTel` VARCHAR(10) NULL,
  `ville` VARCHAR(20) NULL,
  `MDP` VARCHAR(20) NOT NULL,
 `Createur` boolean NOT NULL default 0,
  `soldePoint` INT NULL,
  PRIMARY KEY (`idClient`) );
  
  
CREATE TABLE `fLaEo2rVWb`.`produit` (
  `nomProduit` VARCHAR(20) NOT NULL,
  `categorieProduit` VARCHAR(20) NOT NULL,
  `stockActuel` int  NULL,
  `stockMin` int NULL,
  `stockMax`int NULL,
  `unite` VARCHAR(10) NOT NULL,
  `refFournisseur` VARCHAR(10) NOT NULL,
   PRIMARY KEY (`nomProduit`) );
   
     CREATE TABLE `fLaEo2rVWb`.`admin` (
  `idAdmin` VARCHAR(20) NOT NULL,
  `nomAdmin` varchar(20) NULL,
  `mdp_admin` VARCHAR(20)  NOT NULL, 
   PRIMARY KEY (`idAdmin`) );
   
   CREATE TABLE `fLaEo2rVWb`.`recette` (
  `nomRecette` VARCHAR(40) NOT NULL,
  `typeRecette` VARCHAR(20) NOT NULL,
  `descriptif` VARCHAR(256)  NULL,
  `prix` int NULL,
  `photo` VARCHAR(56) NULL,
  `idClient` varchar(20) not NULL, -- clé étrangère
  `idAdmin` varchar(20)  NULL, -- clé étrangère
   PRIMARY KEY (`nomRecette`),
   CONSTRAINT `FK_recette_client` FOREIGN KEY (`idClient`)
		REFERENCES `client` (`idClient`)
		ON DELETE no action
		ON UPDATE cascade,
	CONSTRAINT `FK_recette_admin` FOREIGN KEY (`idAdmin`)
		REFERENCES `admin` (`idAdmin`)
		ON DELETE no action
		ON UPDATE cascade );
    
   
   CREATE TABLE `fLaEo2rVWb`.`fournisseur` (
  `nomFournisseur` VARCHAR(20) NOT NULL,
  `numTelFournisseur` VARCHAR(10) NOT NULL,
  `adresseFournisseur` VARCHAR(256)  NOT NULL,
   PRIMARY KEY (`nomFournisseur`) );
   
   CREATE TABLE `fLaEo2rVWb`.`commande` (
  `numCommande` VARCHAR(4) NOT NULL,
  `dateCommande` date NOT NULL,
  `idClient` VARCHAR(20)  NOT NULL, -- clé étrangère 
   PRIMARY KEY (`numCommande`),
   CONSTRAINT `FK_commande_client` FOREIGN KEY (`idClient`)
		REFERENCES `client` (`idClient`)
		ON DELETE no action
		ON UPDATE cascade );
   

   

   
    CREATE TABLE `fLaEo2rVWb`.`compose` (
  `nomProduit` VARCHAR(20) NOT NULL,
  `nomRecette` varchar(20) NOT NULL,
  `quantiteUtilisee` int  NOT NULL, 
   PRIMARY KEY (`nomProduit`,`nomRecette`), 
   CONSTRAINT `FK_compose_produit` FOREIGN KEY (`nomProduit`)
		REFERENCES `produit` (`nomProduit`)
		ON DELETE no action
		ON UPDATE cascade ,
	CONSTRAINT `FK_compose_recette` FOREIGN KEY (`nomRecette`)
		REFERENCES `recette` (`nomRecette`)
		ON DELETE no action
		ON UPDATE cascade );
   
    CREATE TABLE `fLaEo2rVWb`.`contient` (
  `numCommande` VARCHAR(4) NOT NULL,
  `nomRecette` varchar(40) NOT NULL,
  `calculPrix` int NULL,
   PRIMARY KEY (`numCommande`,`nomRecette`),
   CONSTRAINT `FK_contient_commande` FOREIGN KEY (`numCommande`)
		REFERENCES `commande` (`numCommande`)
		ON DELETE no action
		ON UPDATE cascade,
	CONSTRAINT `FK_contient_recette` FOREIGN KEY (`nomRecette`)
		REFERENCES `recette` (`nomRecette`)
		ON DELETE no action
		ON UPDATE cascade );
   
  
   
    CREATE TABLE `fLaEo2rVWb`.`remunere` (
  `numCommande` VARCHAR(4) NOT NULL,
  `idClient` varchar(20) NOT NULL,
   PRIMARY KEY (`numCommande`, `idClient` ),
   CONSTRAINT `FK_remunere_client` FOREIGN KEY (`idClient`)
		REFERENCES `client` (`idClient`)
		ON DELETE no action
		ON UPDATE cascade,
	CONSTRAINT `FK_remunere_commande` FOREIGN KEY (`numCommande`)
		REFERENCES `commande` (`numCommande`)
		ON DELETE no action
		ON UPDATE cascade);
   
	CREATE TABLE `fLaEo2rVWb`.`gere` (
  `idClient` varchar(20) NOT NULL,
  `idAdmin` varchar(20) NOT NULL,
   PRIMARY KEY (`idClient`, `idAdmin` ),
   CONSTRAINT `FK_gere_client` FOREIGN KEY (`idClient`)
		REFERENCES `client` (`idClient`)
		ON DELETE no action
		ON UPDATE cascade,
	CONSTRAINT `FK_gere_admin` FOREIGN KEY (`idAdmin`)
		REFERENCES `admin` (`idAdmin`)
		ON DELETE no action
		ON UPDATE cascade);
   
   CREATE TABLE `fLaEo2rVWb`.`peutFournir` (
  `nomFournisseur` VARCHAR(20) NOT NULL,
  `nomProduit` varchar(20) NOT NULL,
  `prixProduit` double NULL,
   PRIMARY KEY (`nomFournisseur`,`nomProduit`),
   CONSTRAINT `FK_fournisseur_peutFournir` FOREIGN KEY (`nomFournisseur`)
		REFERENCES `fournisseur` (`nomFournisseur`)
		ON DELETE no action
		ON UPDATE cascade,
	CONSTRAINT `FK_produit_peutFournir` FOREIGN KEY (`nomProduit`)
		REFERENCES `produit` (`nomProduit`)
		ON DELETE no action
		ON UPDATE cascade );
        
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('vicweill','Weill','Victor','0631623499','Paris','motdepasse',0,0);
update client SET MDP= 'motdepasse' where idClient='vicweill';

INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('emihahu','Hahusseau','Emilien','0782112010','Neuilly','motdepasse',0,0);  
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('test','Test','Monsieur','0612345678','Paris','test',0,0); 
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('romanecl','Chaumeil','Romane','0674722415','Paris','connexion',0,0);
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('dave-azl','Azoulay','David','0654897632','Boulogne','davidbg92',0,0);
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('alexf','Forestier','Alexandre','0645458976','Paris','SecuriteM4x1MuM',0,0);
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('MR.steph','Martin-Richter','Stephane','0745789354','Vaucresson','ved1819',0,0);
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('picpic','Picot','Julie','0711458963','Courbevoie','ved1920',0,0);
INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('easter','Boisson','Francois','0664578913','Levallois','jesuisfrancois',0,0);

INSERT INTO `fLaEo2rVWb`.`admin` (`idAdmin`,`nomAdmin`,`mdp_Admin`) VALUES ('admin','Aline','connexion');

INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('vicweill','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('emihahu','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('romanecl','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('dave-azl','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('alexf','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('MR.steph','admin');
INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('picpic','admin');

INSERT INTO `fLaEo2rVWb`.`commande` (`numCommande`,`dateCommande`,`idClient`) VALUES ('1','2020/05/24','vicweill');
INSERT INTO `fLaEo2rVWb`.`commande` (`numCommande`,`dateCommande`,`idClient`) VALUES ('2','2020/05/24','emihahu');
INSERT INTO `fLaEo2rVWb`.`commande` (`numCommande`,`dateCommande`,`idClient`) VALUES ('3','2020/05/23','MR.steph');

INSERT INTO `fLaEo2rVWb`.`fournisseur` (`nomFournisseur`,`numTelFournisseur`,`adresseFournisseur`) VALUES ('Transgourmet','0175728964','Evry');
INSERT INTO `fLaEo2rVWb`.`fournisseur` (`nomFournisseur`,`numTelFournisseur`,`adresseFournisseur`) VALUES ('Rungis Fruits','0175744812','Rungis');

INSERT INTO `fLaEo2rVWb`.`produit` (`nomProduit`,`categorieProduit`,`stockActuel`,`stockMin`,`stockMax`,`unite`,`refFournisseur`) VALUES ('avocat','legume','30','5','50','piece','AV01');

#INSERT INTO `fLaEo2rVWb`.`client` (`idClient`,`nom`,`prenom`,`numTel`,`ville`,`MDP`,`Createur`,`soldePoint`) VALUES ('','','','','','',0,0);

#INSERT INTO `fLaEo2rVWb`.`admin` (`idAdmin`,`nomAdmin`,`mdp_Admin`) VALUES ('','','');

#INSERT INTO `fLaEo2rVWb`.`commande` (`numCommande`,`dateCommande`,`idClient`) VALUES ('','','');

#INSERT INTO `fLaEo2rVWb`.`compose` (`nomProduit`,`nomRecette`,`quantiteUtilisee`) VALUES ('','','');

#INSERT INTO `fLaEo2rVWb`.`contient` (`numCommande`,`nomRecette`,`calculPrix`) VALUES ('','','');

#INSERT INTO `fLaEo2rVWb`.`fournisseur` (`nomFournisseur`,`numTelFournisseur`,`adresseFournisseur`) VALUES ('','','');

#INSERT INTO `fLaEo2rVWb`.`gere` (`idClient`,`idAdmin`) VALUES ('','');

#INSERT INTO `fLaEo2rVWb`.`peutfournir` (`nomFournisseur`,`nomProduit`,`prixProduit`) VALUES ('','','');
   
#INSERT INTO `fLaEo2rVWb`.`produit` (`nomProduit`,`categorieProduit`,`stockActuel`,`stockMin`,`stockMax`,`unite`,`refFournisseur`) VALUES ('','','','','','','');
  
#INSERT INTO `fLaEo2rVWb`.`recette` (`nomRecette`,`typeRecette`,`descriptif`,`prix`,`photo`,`idClient`,`idAdmin`) VALUES ('','','','','','','');

#INSERT INTO `fLaEo2rVWb`.`remunere` (`numCommande`,`idClient`) VALUES ('','');
  
  
  
  
  
  
  
  
  



#INSERT INTO `fLaEo2rVWb`.`remunere` (`numCommande`,`idClient`) VALUES ('','');
  
  
  
  
  
  
  
  
  



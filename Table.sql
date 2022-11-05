DROP DATABASE IF EXISTS velomax;
CREATE DATABASE IF NOT EXISTS velomax;
use velomax;



CREATE TABLE fournisseur (siret varchar(64) NOT NULL, nom_f varchar(100), contact_f varchar(100), adresse_f varchar(100), libelle int);  
CREATE TABLE piece (num_p varchar(64) NOT NULL, description_p varchar(100), num_catalogue varchar(100), date_intro_p date, date_disc_p date, delai int, prix_p int,stock int);  
CREATE TABLE modele (num_b varchar(64) NOT NULL, nom varchar(100), grandeur varchar(100), prix_b  int, ligne_produit varchar(100), date_int_b date, date_disc_b date);  
CREATE TABLE commande (num_c varchar(64) NOT NULL, date_c date, adresse_c varchar(100), date_livraison date, nom_b varchar(64), nom_p varchar(64));  
CREATE TABLE boutique (nom_b varchar(64) NOT NULL, rue_b varchar(100), ville_b varchar(100), cp_b varchar(100), province_b varchar(100), tel_b varchar(100), courriel_b varchar(100), contact_b varchar(100), remise varchar(100));  
CREATE TABLE particulier (nom_p varchar(64) NOT NULL, prenom_p varchar(100), rue_p varchar(100), ville_p varchar(100), cp_p varchar(100), province_p varchar(100), tel_p varchar(100), courriel_p varchar(100));  
CREATE TABLE fidelio (num_f varchar(64) NOT NULL, description_f varchar(100), cout  int, duree int, remise_f int);  
CREATE TABLE adhere (num_f varchar(64) NOT NULL, nom_p varchar(64) NOT NULL, date_adhesion date);  
CREATE TABLE contient_b (num_c varchar(64) NOT NULL, num_b varchar(64) NOT NULL, quantite_bicyclette int);  
CREATE TABLE contient_p (num_p varchar(64) NOT NULL, num_c varchar(64) NOT NULL, quantite_piece int);  
CREATE TABLE fourni_par (siret varchar(64) NOT NULL, num_p varchar(64) NOT NULL, prix_f int, delai_f int);  
CREATE TABLE assemble (num_b varchar(64) NOT NULL, num_p varchar(64) NOT NULL, id_employee varchar(100), quantite int);  
ALTER TABLE fournisseur ADD CONSTRAINT PK_fournisseur PRIMARY KEY (siret);  ALTER TABLE piece ADD CONSTRAINT PK_piece PRIMARY KEY (num_p);  
ALTER TABLE modele ADD CONSTRAINT PK_modele PRIMARY KEY (num_b);  ALTER TABLE commande ADD CONSTRAINT PK_commande PRIMARY KEY (num_c);  
ALTER TABLE boutique ADD CONSTRAINT PK_boutique PRIMARY KEY (nom_b);  ALTER TABLE particulier ADD CONSTRAINT PK_particulier PRIMARY KEY (nom_p);  
ALTER TABLE fidelio ADD CONSTRAINT PK_fidelio PRIMARY KEY (num_f);  ALTER TABLE adhere ADD CONSTRAINT PK_adhere PRIMARY KEY (num_f, nom_p);  
ALTER TABLE contient_b ADD CONSTRAINT PK_contient_b PRIMARY KEY (num_c, num_b);  ALTER TABLE contient_p ADD CONSTRAINT PK_contient_p PRIMARY KEY (num_p, num_c);  
ALTER TABLE fourni_par ADD CONSTRAINT PK_fourni_par PRIMARY KEY (siret, num_p);  ALTER TABLE assemble ADD CONSTRAINT PK_assemble PRIMARY KEY (num_b, num_p);  
ALTER TABLE commande ADD CONSTRAINT FK_commande_nom_b FOREIGN KEY (nom_b) REFERENCES boutique (nom_b);  
ALTER TABLE commande ADD CONSTRAINT FK_commande_nom_p FOREIGN KEY (nom_p) REFERENCES particulier (nom_p);  
ALTER TABLE adhere ADD CONSTRAINT FK_adhere_num_f FOREIGN KEY (num_f) REFERENCES fidelio (num_f);  
ALTER TABLE adhere ADD CONSTRAINT FK_adhere_nom_p FOREIGN KEY (nom_p) REFERENCES particulier (nom_p);  
ALTER TABLE contient_b ADD CONSTRAINT FK_contient_b_num_c FOREIGN KEY (num_c) REFERENCES commande (num_c);  
ALTER TABLE contient_b ADD CONSTRAINT FK_contient_b_num_b FOREIGN KEY (num_b) REFERENCES modele (num_b);  
ALTER TABLE contient_p ADD CONSTRAINT FK_contient_p_num_p FOREIGN KEY (num_p) REFERENCES piece (num_p);  
ALTER TABLE contient_p ADD CONSTRAINT FK_contient_p_num_c FOREIGN KEY (num_c) REFERENCES commande (num_c);  
ALTER TABLE fourni_par ADD CONSTRAINT FK_fourni_par_siret FOREIGN KEY (siret) REFERENCES fournisseur (siret);  
ALTER TABLE fourni_par ADD CONSTRAINT FK_fourni_par_num_p FOREIGN KEY (num_p) REFERENCES piece (num_p);  
ALTER TABLE assemble ADD CONSTRAINT FK_assemble_num_b FOREIGN KEY (num_b) REFERENCES modele (num_b);  
ALTER TABLE assemble ADD CONSTRAINT FK_assemble_num_p FOREIGN KEY (num_p) REFERENCES piece (num_p);  





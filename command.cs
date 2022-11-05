using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace projet_theo_midavaine
{
    public class command
    {

        public static void Read(MySqlConnection c)
        {
            Console.WriteLine("Vous pouvez lire les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
            Console.WriteLine("Veuillez entrer la table : ");
            Console.Write("FROM : ");
            string table = Console.ReadLine();
            command.PrintColumns(table, c);
            Console.WriteLine("\nVeuillez entrer la donnée recherchée (SELECT : )");

            string donnee = Console.ReadLine();

            Console.WriteLine("Veuillez entrer les conditions");
            Console.Write($"SELECT {donnee} FROM {table} WHERE ");
            string condition = Console.ReadLine();
            string requete = "";
            if (condition == "")
            {
                requete = $"Select {donnee} From {table};";
            }
            else
            {
                requete = $"Select {donnee} From {table} Where {condition};";
            }
            string a = command.Print(requete, c);
            Console.WriteLine(a);
        }

        public static void PrintColumns(string table, MySqlConnection c)
        {
            MySqlCommand request = c.CreateCommand();
            request.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{table}'";
            MySqlDataReader reader = request.ExecuteReader();
            while (reader.Read())
            {
                string ligne = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ligne = ligne + " \t" + reader.GetValue(i).ToString();
                }
                Console.Write(ligne);
            }
            reader.Close();
        }
        public static string Print(string requete, MySqlConnection c)
        {
            MySqlCommand request = c.CreateCommand();
            request.CommandText = requete;

            MySqlDataReader reader = request.ExecuteReader();
            string tableau = "";
            while (reader.Read())
            {
                string ligne = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ligne = ligne + " \t" + reader.GetValue(i).ToString();
                }
                tableau = tableau + "\n " + ligne;
            }
            reader.Close();
            return tableau;
        }
        public static void Load_data(MySqlConnection c)
        {
            #region TABLE modele
            string modele1 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('101', 'Kilimandjaro', 'Adultes', '569', 'VTT', '2017-02-01', '2020-10-21')";
            string modele2 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('102', 'NorthPole', 'Adultes', '329', 'VTT', '2015-06-06', '2017-06-16')";
            string modele3 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('103', 'MontBlanc', 'Jeunes', '399', 'VTT', '2012-06-06', '2020-06-06')";
            string modele4 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('104', 'Hooligan', 'Jeunes', '199', 'VTT', '2001-06-13', '2015-04-07')";
            string modele5 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('105', 'Orléans', 'Hommes', '229', 'Vélo de course', '2014-12-06', '2017-06-06')";
            string modele6 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('106', 'Orléans', 'Dames', '229', 'Vélo de course', '2014-12-06', '2017-06-06')";
            string modele7 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('107', 'BlueJay', 'Hommes', '349', 'vélo de course', '2013-07-12', '2017-05-13')";
            string modele8 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('108', 'BlueJay', 'Dames', '349', 'vélo de course', '2013-07-12', '2017-05-13')";
            string modele9 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('109', 'Trail Explorer', 'Filles', '129', 'Classique', '2015-02-14', '2020-08-21')";
            string modele10 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('110', 'Trail Explorer', 'Garçons', '129', 'Classique', '2015-02-14', '2020-08-21')";
            string modele11 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('111', 'Night Hawk', 'Jeunes', '189', 'Classique', '2016-12-17', '2019-10-11')";
            string modele12 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('112', 'Tierra Verde', 'Hommes', '199', 'Classique','2017-01-03', '2021-02-14')";
            string modele13 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('113', 'Tierra Verde', 'Dames', '199', 'Classique', '2017-01-03', '2021-02-14')";
            string modele14 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('114', 'Mud Zinger I', 'Jeunes', '279', 'BMX', '2012-12-14', '2016-04-24')";
            string modele15 = $"INSERT INTO modele(num_b, nom, grandeur, prix_b, ligne_produit,date_int_b,date_disc_b) VALUES('115', 'Mud Zinger II', 'Adultes', '359', 'BMX', '2014-03-05', '2020-04-21')";

            MySqlCommand cmodele1 = new MySqlCommand(modele1, c);
            MySqlCommand cmodele2 = new MySqlCommand(modele2, c);
            MySqlCommand cmodele3 = new MySqlCommand(modele3, c);
            MySqlCommand cmodele4 = new MySqlCommand(modele4, c);
            MySqlCommand cmodele5 = new MySqlCommand(modele5, c);
            MySqlCommand cmodele6 = new MySqlCommand(modele6, c);
            MySqlCommand cmodele7 = new MySqlCommand(modele7, c);
            MySqlCommand cmodele8 = new MySqlCommand(modele8, c);
            MySqlCommand cmodele9 = new MySqlCommand(modele9, c);
            MySqlCommand cmodele10 = new MySqlCommand(modele10, c);
            MySqlCommand cmodele11 = new MySqlCommand(modele11, c);
            MySqlCommand cmodele12 = new MySqlCommand(modele12, c);
            MySqlCommand cmodele13 = new MySqlCommand(modele13, c);
            MySqlCommand cmodele14 = new MySqlCommand(modele14, c);
            MySqlCommand cmodele15 = new MySqlCommand(modele15, c);
            try
            {

                cmodele1.ExecuteNonQuery();
                cmodele2.ExecuteNonQuery();
                cmodele3.ExecuteNonQuery();
                cmodele4.ExecuteNonQuery();
                cmodele5.ExecuteNonQuery();
                cmodele6.ExecuteNonQuery();
                cmodele7.ExecuteNonQuery();
                cmodele8.ExecuteNonQuery();
                cmodele9.ExecuteNonQuery();
                cmodele10.ExecuteNonQuery();
                cmodele11.ExecuteNonQuery();
                cmodele12.ExecuteNonQuery();
                cmodele13.ExecuteNonQuery();
                cmodele14.ExecuteNonQuery();
                cmodele15.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
            #endregion

            #region TABLE piece

            string query1 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('S01','Panier','001','2016-00-28','2019-12-03','5','20','2')";
            string query2 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('F3','Freins','002','2014-07-30','2017-03-01','3','25','40')";
            string query3 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('F9','Freins','003','2014-01-30','2021-02-22','5','23','21')";
            string query4 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('C32','Cadre','004','2016-02-07','2021-09-30','10','45','1')";
            string query5 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('G7','Guidon','005','2014-06-24','2020-12-04','6','15','6')";
            string query6 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('S88','Selle','006','2014-00-00','2018-12-12','2','11','51')";
            string query7 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('DV17','Dérailleur_avant','007','2017-01-10','2020-09-02','8','22','11')";
            string query8 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('DV87','Dérailleur_arrière','008','2017-09-24','2020-11-02','8','22','2')";
            string query9 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('R45','Roue_avant','009','2014-04-29','2017-03-03','3','30','34')";
            string query10 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('R46','Roue_arrière','010','2012-11-21','2017-09-01','3','30','29')";
            string query11 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('P12','Pédalier','011','2014-04-13','2020-08-30','6','40','13')";
            string query12 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('R02','Réflecteurs','012','2016-10-29','2021-01-19','2','14','24')";
            string query13 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('O2','Ordinateur','013','2014-10-04','2021-04-30','12','120','8')";
            string query14 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('S36','Selle','014','2015-05-26','2017-12-15','2','10','26')";
            string query15 = "INSERT INTO Piece (num_P,description_p,num_catalogue,date_intro_p,date_disc_p,delai,prix_P,stock) VALUES ('C34','Cadre','015','2016-07-20','2019-01-13','10','50','9')";

            MySqlCommand command1 = new MySqlCommand(query1, c);
            MySqlCommand command2 = new MySqlCommand(query2, c);
            MySqlCommand command3 = new MySqlCommand(query3, c);
            MySqlCommand command4 = new MySqlCommand(query4, c);
            MySqlCommand command5 = new MySqlCommand(query5, c);
            MySqlCommand command6 = new MySqlCommand(query6, c);
            MySqlCommand command7 = new MySqlCommand(query7, c);
            MySqlCommand command8 = new MySqlCommand(query8, c);
            MySqlCommand command9 = new MySqlCommand(query9, c);
            MySqlCommand command10 = new MySqlCommand(query10, c);
            MySqlCommand command11 = new MySqlCommand(query11, c);
            MySqlCommand command12 = new MySqlCommand(query12, c);
            MySqlCommand command13 = new MySqlCommand(query13, c);
            MySqlCommand command14 = new MySqlCommand(query14, c);
            MySqlCommand command15 = new MySqlCommand(query15, c);
            try
            {

                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();
                command6.ExecuteNonQuery();
                command7.ExecuteNonQuery();
                command8.ExecuteNonQuery();
                command9.ExecuteNonQuery();
                command10.ExecuteNonQuery();
                command11.ExecuteNonQuery();
                command12.ExecuteNonQuery();
                command13.ExecuteNonQuery();
                command14.ExecuteNonQuery();
                command15.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }

            #endregion

            #region TABLE boutique
            string query16 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Veloactif','Rue Victor Hugo','Paris','75012','Ile-de-France','0149185268','veloactif@gmail.com','Paul','5')";
            string query17 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Cyclable','Rue Goya', 'Le mans','72000' ,'Pays de la Loire','02 47 54 50 44','cyclable@gmail.com','Jean','10')";
            string query18 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Holland Bikes','Av de Wagram','Rennes','35700','Bretagne','06 62 76 14 39','obicyle@gmail.com','Thomas','10')";
            string query19 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('GoSport','Place de la madeleine', 'Paris','75012','Ile-de-France','06 35 46 82 04','gosport@gmail.com','Pierre','5')";
            string query20 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('GoVelo','Av de Marlioz','Vannes','56000', 'Bretagne','06 75 39 58 06','govelo@gmail.com','Tom','0')";
            string query21 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Sport2000','Chemin des bateliers', 'Ajaccio', '20000','Corse','06 24 56 66 95','sport2000@gmail.com','Ferdinand','10')";
            string query22 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Intersport','Rue de la Couronne', 'Nice','06000','Provence-Alpes-Côte dAzur','06 91 39 77 51','intersport@gmail.com','John','5')";
            string query23 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('Biker','Rue des Chaligny', 'Vierzon', '18100','Centre','06 07 74 46 66','biker@gmail.com','Jean-Paul','0')";
            string query24 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('La Bicyclette','Av du Jeu de Paume','75001','Paris', 'Ile-de-France','06 74 96 97 96','labicyclette@gmail.com','Sarah','0')";
            string query25 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('InterVelo','Rue Franklin Roosevelt','Marseille', '13010', 'Provence-Alpes-Côte dAzur','06 88 90 24 91','intervelo@gmail.com','Tom','5')";
            string query26 = "INSERT INTO Boutique (nom_b, rue_b,ville_b,cp_b,province_b, tel_b, courriel_b, contact_b, remise) VALUES ('VeloMax','Rue Stalingrad', 'Thias','94320','Ile-de-France','06 78 21 50 18','velomax@gmail.com','Manuel','5')";

            MySqlCommand command16 = new MySqlCommand(query16, c);
            MySqlCommand command17 = new MySqlCommand(query17, c);
            MySqlCommand command18 = new MySqlCommand(query18, c);
            MySqlCommand command19 = new MySqlCommand(query19, c);
            MySqlCommand command20 = new MySqlCommand(query20, c);
            MySqlCommand command21 = new MySqlCommand(query21, c);
            MySqlCommand command22 = new MySqlCommand(query22, c);
            MySqlCommand command23 = new MySqlCommand(query23, c);
            MySqlCommand command24 = new MySqlCommand(query24, c);
            MySqlCommand command25 = new MySqlCommand(query25, c);
            MySqlCommand command26 = new MySqlCommand(query26, c);

            try
            {
                command16.ExecuteNonQuery();
                command17.ExecuteNonQuery();
                command18.ExecuteNonQuery();
                command19.ExecuteNonQuery();
                command20.ExecuteNonQuery();
                command21.ExecuteNonQuery();
                command22.ExecuteNonQuery();
                command23.ExecuteNonQuery();
                command24.ExecuteNonQuery();
                command25.ExecuteNonQuery();
                command26.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            #endregion

            #region TABLE Fidelio
            string query38 = "INSERT INTO Fidelio (num_f, description_f, cout, duree, remise_f) VALUES ('1','Fidélio','15','1','5')";
            string query39 = "INSERT INTO Fidelio (num_f, description_f, cout, duree, remise_f) VALUES ('2','Fidélio Or','25','2','8')";
            string query40 = "INSERT INTO Fidelio (num_f, description_f, cout, duree, remise_f) VALUES ('3','Fidélio Platine','60','3','10')";
            string query41 = "INSERT INTO Fidelio (num_f, description_f, cout, duree, remise_f) VALUES ('4','Fidélio Max','100','5','15')";
            string query42 = "INSERT INTO Fidelio (num_f, description_f, cout, duree, remise_f) VALUES ('0','Aucun','0','0','0')";

            MySqlCommand command38 = new MySqlCommand(query38, c);
            MySqlCommand command39 = new MySqlCommand(query39, c);
            MySqlCommand command40 = new MySqlCommand(query40, c);
            MySqlCommand command41 = new MySqlCommand(query41, c);
            MySqlCommand command42 = new MySqlCommand(query42, c);

            try
            {
                command38.ExecuteNonQuery();
                command39.ExecuteNonQuery();
                command40.ExecuteNonQuery();
                command41.ExecuteNonQuery();
                command42.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            #endregion

            #region TABLE particulier
            string query27 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Lebret','Maxence','Rue Demard', 'Le mans','72000' ,'Pays de la Loire','06 46 30 31 45','lebretm@gmail.com')";
            string query28 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Martin','Thomas','Rue Victor Hugo', 'Paris', '75012', 'Ile-de-France','06 61 31 14 46','martin@gmail.com')";
            string query29 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Dubois','Pierre','Av du Verdon','Rennes','35700','Bretagne','06 99 86 72 95','dubois@gmail.com')";
            string query30 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Bernard','Laurent','Place de la broche', 'Paris','75012','Ile-de-France','06 27 78 47 12','bernard@gmail.com')";
            string query31 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Petit','Max','Av de la marche','Vannes','56000', 'Bretagne','06 45 58 81 36','petitmax@gmail.com')";
            string query32 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Grand','Benoit','Chemin des rochers', 'Ajaccio', '2000','Corse','06 67 55 57 37','grandbenoit@gmail.com')";
            string query33 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Grand-Petit','Lionel','Rue des roses', 'Vierzon', '18100','Centre','06 10 81 55 59','grandpetitlionen@gmail.com')";
            string query34 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Durand','Maxime','Rue du Roi', 'Nice','06000','Provence-Alpes-Côte d Azur','06 92 26 50 57','durandmaxime@gmail.com')";
            string query35 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Lancelot','Richard','Av du Tennis','75001','Paris', 'Ile-de-France','06 52 27 40 33','lancelotrichard@gmail.com')";
            string query36 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('Moreau','Tom','Rue Franklin','Marseille', '13010','Provence-Alpes-Côte d Azur','06 50 49 91 58','moreautom@gmail.com')";
            string query37 = "INSERT INTO particulier (nom_p, prenom_p, rue_p, ville_p,cp_p,province_p,tel_p, courriel_p) VALUES ('De la motte','Henry','Av de Paris','Rennes','35700','Bretagne','06 35 78 41 67','henrydelamotte@gmail.com')";

            MySqlCommand command27 = new MySqlCommand(query27, c);
            MySqlCommand command28 = new MySqlCommand(query28, c);
            MySqlCommand command29 = new MySqlCommand(query29, c);
            MySqlCommand command30 = new MySqlCommand(query30, c);
            MySqlCommand command31 = new MySqlCommand(query31, c);
            MySqlCommand command32 = new MySqlCommand(query32, c);
            MySqlCommand command33 = new MySqlCommand(query33, c);
            MySqlCommand command34 = new MySqlCommand(query34, c);
            MySqlCommand command35 = new MySqlCommand(query35, c);
            MySqlCommand command36 = new MySqlCommand(query36, c);
            MySqlCommand command37 = new MySqlCommand(query37, c);
            try
            {
                command27.ExecuteNonQuery();
                command28.ExecuteNonQuery();
                command29.ExecuteNonQuery();
                command30.ExecuteNonQuery();
                command31.ExecuteNonQuery();
                command32.ExecuteNonQuery();
                command33.ExecuteNonQuery();
                command34.ExecuteNonQuery();
                command35.ExecuteNonQuery();
                command36.ExecuteNonQuery();
                command37.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
            #endregion


            #region TABLE fournisseur
            string query43 = "INSERT INTO Fournisseur (siret, nom_f, contact_f, adresse_F, libelle) VALUES ('552','fournisseur1','François Gregoire','Rue des Chaligny Vierzon 18100 Centre','2')";
            string query44 = "INSERT INTO Fournisseur (siret, nom_f, contact_f, adresse_F, libelle) VALUES ('553','fournisseur2','Pierre Dumas','Rue Montreau Marseille 13001 Provence-Alpes-Côte dAzur','1')";
            string query45 = "INSERT INTO Fournisseur (siret, nom_f, contact_f, adresse_F, libelle) VALUES ('554','fournisseur3','Paul Pierre','Rue du Roi Nice 06000 Provence-Alpes-Côte d Azur','4')";
            string query46 = "INSERT INTO Fournisseur (siret, nom_f, contact_f, adresse_F, libelle) VALUES ('555','fournisseur4','Moire Maxime','Rue Franklin Marseille 13010 Provence-Alpes-Côte d Azur','3')";
            string query47 = "INSERT INTO Fournisseur (siret, nom_f, contact_f, adresse_F, libelle) VALUES ('556','fournisseur5','Calter Cameron','Rue des roses Vierzon 18100 Centre','1')";

            MySqlCommand command43 = new MySqlCommand(query43, c);
            MySqlCommand command44 = new MySqlCommand(query44, c);
            MySqlCommand command45 = new MySqlCommand(query45, c);
            MySqlCommand command46 = new MySqlCommand(query46, c);
            MySqlCommand command47 = new MySqlCommand(query47, c);
            try
            {
                command43.ExecuteNonQuery();
                command44.ExecuteNonQuery();
                command45.ExecuteNonQuery();
                command46.ExecuteNonQuery();
                command47.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }

            #endregion

            #region TABLE commande
            string query48 = "INSERT INTO Commande (num_c, date_c, adresse_c, date_livraison, nom_b, nom_p) VALUES ('001','2020-02-08','Rue des Chaligny Vierzon 18100 Centre','2020-02-15','Cyclable',null)";
            string query49 = "INSERT INTO Commande (num_c, date_c, adresse_c, date_livraison, nom_b, nom_p) VALUES ('002','2020-03-08','Rue Montreau Marseille 13001 Provence-Alpes-Côte d Azur','2020-03-12','GoVelo',null)";
            string query50 = "INSERT INTO Commande (num_c, date_c, adresse_c, date_livraison, nom_b, nom_p) VALUES ('003','2020-04-08','Rue du Roi Nice 06000 Provence-Alpes-Côte d Azur','2020-04-12',null,'Lebret')";
            string query51 = "INSERT INTO Commande (num_c, date_c, adresse_c, date_livraison, nom_b, nom_p) VALUES ('004','2020-01-08','Rue Franklin Marseille 13010 Provence-Alpes-Côte d Azur','2020-01-12','GoSport',null)";
            string query52 = "INSERT INTO Commande (num_c, date_c, adresse_c, date_livraison, nom_b, nom_p) VALUES ('005','2020-12-08','Rue des roses Vierzon 18100 Centre','2020-10-12',null,'Lancelot')";

            MySqlCommand command48 = new MySqlCommand(query48, c);
            MySqlCommand command49 = new MySqlCommand(query49, c);
            MySqlCommand command50 = new MySqlCommand(query50, c);
            MySqlCommand command51 = new MySqlCommand(query51, c);
            MySqlCommand command52 = new MySqlCommand(query52, c);
            try
            {
                command48.ExecuteNonQuery();
                command49.ExecuteNonQuery();
                command50.ExecuteNonQuery();
                command51.ExecuteNonQuery();
                command52.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }

            #endregion

            #region TABLE contient_b
            string query53 = "INSERT INTO contient_b (num_c, num_b, quantite_bicyclette) VALUES ('001','101','4')";
            string query54 = "INSERT INTO contient_b (num_c, num_b, quantite_bicyclette) VALUES ('002','102', '5')";
            string query55 = "INSERT INTO contient_b (num_c, num_b, quantite_bicyclette) VALUES ('003','103', '2')";
            string query56 = "INSERT INTO contient_b (num_c, num_b, quantite_bicyclette) VALUES ('004','104','1')";
            string query57 = "INSERT INTO contient_b (num_c, num_b, quantite_bicyclette) VALUES ('005','105','10')";

            MySqlCommand command53 = new MySqlCommand(query53, c);
            MySqlCommand command54 = new MySqlCommand(query54, c);
            MySqlCommand command55 = new MySqlCommand(query55, c);
            MySqlCommand command56 = new MySqlCommand(query56, c);
            MySqlCommand command57 = new MySqlCommand(query57, c);
            try
            {
                command53.ExecuteNonQuery();
                command54.ExecuteNonQuery();
                command55.ExecuteNonQuery();
                command56.ExecuteNonQuery();
                command57.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }

            #endregion

            #region TABLE contient_p
            string query58 = "INSERT INTO contient_p (num_p, num_c, quantite_piece) VALUES ('S01','001','4')";
            string query59 = "INSERT INTO contient_p (num_p, num_c, quantite_piece) VALUES ('F3','002','3')";
            string query60 = "INSERT INTO contient_p (num_p, num_c, quantite_piece) VALUES ('O2','003','2')";
            string query61 = "INSERT INTO contient_p (num_p, num_c, quantite_piece) VALUES ('R45','004','1')";
            string query62 = "INSERT INTO contient_p (num_p, num_c, quantite_piece) VALUES ('R46','005','0')";

            MySqlCommand command58 = new MySqlCommand(query58, c);
            MySqlCommand command59 = new MySqlCommand(query59, c);
            MySqlCommand command60 = new MySqlCommand(query60, c);
            MySqlCommand command61 = new MySqlCommand(query61, c);
            MySqlCommand command62 = new MySqlCommand(query62, c);
            try
            {
                command58.ExecuteNonQuery();
                command59.ExecuteNonQuery();
                command60.ExecuteNonQuery();
                command61.ExecuteNonQuery();
                command62.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }

            #endregion

            #region TABLE assemble
            string query63 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('101','S01','001','5')";
            string query78 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('102','F3','002','1')";
            string query64 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('103','S01','003','2')";
            string query65 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('104','S01','004','4')";
            string query66 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('105','S01','005','3')";
            string query67 = "INSERT INTO assemble (num_b, num_p, id_employee, quantite) VALUES ('111','S01','006','6')";

            MySqlCommand command63 = new MySqlCommand(query63, c);
            MySqlCommand command64 = new MySqlCommand(query64, c);
            MySqlCommand command65 = new MySqlCommand(query65, c);
            MySqlCommand command66 = new MySqlCommand(query66, c);
            MySqlCommand command67 = new MySqlCommand(query67, c);
            MySqlCommand command78 = new MySqlCommand(query78, c);
            try
            {
                command63.ExecuteNonQuery();
                command64.ExecuteNonQuery();
                command65.ExecuteNonQuery();
                command66.ExecuteNonQuery();
                command67.ExecuteNonQuery();
                command78.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
            #endregion

            #region TABLE fourni_par
            string query68 = "INSERT INTO fourni_par (siret, num_p, prix_f, delai_f) VALUES ('552','S01','5','5')";
            string query69 = "INSERT INTO fourni_par (siret, num_p, prix_f, delai_f) VALUES ('553','F3','3','3')";
            string query70 = "INSERT INTO fourni_par (siret, num_p, prix_f, delai_f) VALUES ('554','O2','4','4')";
            string query71 = "INSERT INTO fourni_par (siret, num_p, prix_f, delai_f) VALUES ('555','DV17','5','5')";
            string query72 = "INSERT INTO fourni_par (siret, num_p, prix_f, delai_f) VALUES ('556','DV87','6','6')";

            MySqlCommand command68 = new MySqlCommand(query68, c);
            MySqlCommand command69 = new MySqlCommand(query69, c);
            MySqlCommand command70 = new MySqlCommand(query70, c);
            MySqlCommand command71 = new MySqlCommand(query71, c);
            MySqlCommand command72 = new MySqlCommand(query72, c);
            try
            {
                command68.ExecuteNonQuery();
                command69.ExecuteNonQuery();
                command70.ExecuteNonQuery();
                command71.ExecuteNonQuery();
                command72.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
            #endregion

            #region TABLE adhere
            string query73 = "INSERT INTO adhere (num_f, nom_p, date_adhesion) VALUES ('1','Lebret','2016-06-16')";
            string query74 = "INSERT INTO adhere (num_f, nom_p, date_adhesion) VALUES ('2','Martin','2017-07-17')";
            string query75 = "INSERT INTO adhere (num_f, nom_p, date_adhesion) VALUES ('3','Dubois','2018-08-18')";
            string query76 = "INSERT INTO adhere (num_f, nom_p, date_adhesion) VALUES ('4','Bernard','2019-09-19')";
            string query77 = "INSERT INTO adhere (num_f, nom_p, date_adhesion) VALUES ('0','Petit','2020-10-20')";

            MySqlCommand command73 = new MySqlCommand(query73, c);
            MySqlCommand command74 = new MySqlCommand(query74, c);
            MySqlCommand command75 = new MySqlCommand(query75, c);
            MySqlCommand command76 = new MySqlCommand(query76, c);
            MySqlCommand command77 = new MySqlCommand(query77, c);
            try
            {
                command73.ExecuteNonQuery();
                command74.ExecuteNonQuery();
                command75.ExecuteNonQuery();
                command76.ExecuteNonQuery();
                command77.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
            #endregion
        }

    }
}


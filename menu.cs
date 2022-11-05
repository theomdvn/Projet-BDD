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
    public class menu
    {
        public static void Affichage(MySqlConnection c)
        {
            int choix = 0;
            while (choix != 8)
            {
                Console.Clear();
                string a = "";
            Console.Write('\n' + "Menu général" + '\n' +
                "1 - Gestion des pièces de rechange et Gestion des vélos" + "\n" +
                "2 - Gestion des clients particuliers et des clients Entreprise" + "\n" +
                "3 - Gestion des fournisseurs" + "\n" +
                "4 - Gestion des commandes" + "\n" +
                "5 - Gestion du stock" + "\n" +
                "6 - Modules Statistiques" + "\n" +
                "7 - Commandes \n" +
                "8 - Quitter le menu\n"+
                "10 - Mode démo\n" +
                "20 - Charger les données\n");
            choix = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choix)
            {
                case 1:
                    {
                        Console.Write("Gestion des pièces de rechange et Gestion des vélos" + "\n" +
                            "1 - Création" + "\n" + //Erreur si existe déjà
                            "2 - Supression" + "\n" + //Affichage
                            "3 - Maj d'une pièce ou d'un vélo \n");
                        int choix1 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (choix1)
                        {
                            case 1:
                                Console.Write("Création" + "\n" +
                                        "1 - Pièces de rechanges" + "\n" + //Erreur si existe déjà
                                        "2 - Vélos \n");
                                int choix2 = Convert.ToInt32(Console.ReadLine());
                                switch (choix2)
                                {
                                    case 1:
                                        Admin.Create(c, "piece");
                                        break;

                                    case 2:
                                        Admin.Create(c, "modele");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;
                                }
                                break;
                            case 2:
                                Console.Write("Suppression" + "\n" +
                                        "1 - Pièces de rechanges" + "\n" + //Erreur si existe déjà
                                        "2 - Vélos \n");
                                int choix3 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (choix3)
                                {
                                    case 1:
                                        Admin.Delete(c, "piece");
                                        break;

                                    case 2:
                                        Admin.Delete(c, "modele");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;
                                }
                                break;
                            case 3:
                                Console.Write("Update" + "\n" +
                                        "1 - Pièces de rechanges" + "\n" + //Erreur si existe déjà
                                        "2 - Vélos \n");
                                int choix4 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (choix4)
                                {
                                    case 1:
                                        Admin.Update(c, "piece");
                                        break;

                                    case 2:
                                        Admin.Update(c, "modele");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;
                                }
                                break;
                        }
                        break;

                    }
                case 2:
                    {
                        Console.Write("Gestion des clients particuliers et des clients Entreprises" + "\n" +
                                "1 - Création" + "\n" +
                                "2 - Supression" + "\n" +
                                "3 - Maj d'un client ou d'une entreprise \n");
                        int choix5 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (choix5)
                        {
                            case 1:
                                Console.Write("Création" + "\n" +
                                        "1 - Particulier" + "\n" +
                                        "2 - Entreprise \n");
                                int choix6 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (choix6)
                                {
                                    case 1:
                                            choix6 = Convert.ToInt32(Console.ReadLine());

                                            Admin.Create(c, "particulier");
                                        break;
                                    case 2:
                                        Admin.Create(c, "boutique");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;

                                }
                                break;
                            case 2:
                                Console.Write("Suppression" + "\n" +
                                        "1 - Particulier" + "\n" +
                                        "2 - Entreprise \n");
                                int choix7 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (choix7)
                                {
                                    case 1:
                                        Admin.Delete(c, "particulier");
                                        break;
                                    case 2:
                                        Admin.Delete(c, "boutique");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;
                                }
                                break;
                            case 3:
                                Console.Write("Update" + "\n" +
                                        "1 - Particulier" + "\n" +
                                        "2 - Entreprise \n");
                                int choix8 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                switch (choix8)
                                {
                                    case 1:
                                            Console.Write("Update" + "\n" +
                                                 "1 - Fidelio" + "\n" +
                                                 "2 - autre \n");
                                            int choix15 = Convert.ToInt32(Console.ReadLine());
                                            switch(choix15)
                                            {
                                                case 1:
                                                    Admin.Create(c, "adhere");
                                                    break;
                                                default:
                                                    Console.Clear();
                                                    Admin.Update(c, "particulier");
                                                    break;
                                            }

                                        break;
                                    case 2:
                                        Admin.Update(c, "boutique");
                                        break;

                                    default:
                                        Console.WriteLine("Erreur, veuillez recommencer");
                                        break;
                                }
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("Gestion des fournisseurs" + "\n" +
                                "1 - Création" + "\n" +
                                "2 - Supression" + "\n" +
                                "3 - Maj d'un fournisseur \n");
                        int choix9 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (choix9)
                        {
                            case 1:
                                Admin.Create(c, "fournisseur");
                                break;
                            case 2:
                                Admin.Delete(c, "fournisseur");
                                break;
                            case 3:
                                Admin.Update(c, "fournisseur");
                                break;

                            default:
                                Console.WriteLine("Erreur, veuillez recommencer");
                                break;
                        }
                        break;
                    }
                case 4:
                    {
                        Console.Write("Gestion des commandes" + "\n" +
                                "1 - Création" + "\n" +
                                "2 - Supression" + "\n" +
                                "3 - Maj d'un client ou d'une entreprise \n");
                        int choix10 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (choix10)
                        {
                            case 1:
                                Admin.Create(c, "commande");
                                Admin.Create(c, "contient_b");
                                Admin.Create(c, "contient_p");
                                    break;
                            case 2:
                                Admin.Delete(c, "commande");
                                break;
                            case 3:
                                Admin.Update(c, "commande");
                                break;

                            default:
                                Console.WriteLine("Erreur, veuillez recommencer");
                                break;
                        }
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Gestion des stocks" + "\n" +
                        "1 - par pièce" + "\n" +
                        "2 - par fournisseur" + "\n" +
                        "3 - par vélo" + "\n");
                        int choix11 = Convert.ToInt32(Console.ReadLine());

                        switch (choix11)
                        {
                            //Gestion des stocks : par pièce
                            case 1:
                                Console.WriteLine("Voici le stock des pieces disponibles");
                                a = command.Print("select description_p,stock from piece", c);
                                Console.WriteLine(a);

                                Admin.Update(c, "piece");
                                break;

                            //Gestion des stocks : par fournisseur
                            case 2:
                                Console.WriteLine("Voici les pieces fournies par les fournisseurs et leur délai de livraison");
                                a = command.Print("select nom_f, description_p,delai, stock from fourni_par natural join fournisseur natural join piece", c);
                                    Console.WriteLine(a);
                                    Admin.Update(c, "fournisseur");
                                break;

                            case 3:
                                Console.WriteLine("Voici les stocks actuels de velos : ");

                                a = command.Print("select nom,quantite from modele natural join assemble", c);
                                    Console.WriteLine(a);
                                    Console.WriteLine("\nVoici les quantites vélos commandés");

                                a = command.Print("select nom,quantite_bicyclette from modele natural join contient_p natural join contient_b", c);
                                    Console.WriteLine(a);

                                    Admin.Update(c, "assemble");
                                break;

                            default:
                                Console.WriteLine("Erreur, veuillez recommencer");
                                break;

                        }
                        break;
                    }
                case 6:
                    {
                        Console.Write("Module statistique" + "\n");

                        Console.ReadKey();

                        Console.WriteLine("\nQuantite vendues de chaque pieces du catalogue velomax");
                        string quantite_P = command.Print("select description_p, sum(quantite_piece) from contient_p natural join commande natural join piece group by num_p order by num_p;", c);
                        Console.WriteLine(quantite_P);

                        Console.WriteLine("\nQuantite vendues de chaque velo du catalogue velomax");
                        string ventesM = command.Print("select nom, sum(quantite_bicyclette) from contient_b natural join commande natural join modele group by num_b order by num_b ;", c);

                        Console.WriteLine(ventesM);
                            Console.ReadKey();

                        Console.WriteLine("\n Liste des non-adherants à Fidelio ");
                        a = command.Print("select particulier .*from adhere natural join particulier natural join fidelio where num_F = 0; ", c);
                            Console.WriteLine(a);
                        Console.WriteLine("\n Liste des adherants à Fidelio || Date d'expiration");
                        a = command.Print("select particulier .*, date_add(date_adhesion, interval duree year) from adhere natural join particulier natural join fidelio where num_F = 1;", c);
                            Console.WriteLine(a);
                        Console.WriteLine("\n Liste des adherants à Fidelio Or || Date d'expiration");
                        a = command.Print("select particulier .*, date_add(date_adhesion, interval duree year) from adhere natural join particulier natural join fidelio where num_F = 2;", c) ;
                            Console.WriteLine(a);
                        Console.WriteLine("\n Liste des adherants à Fidelio Platine || Date d'expiration");
                        a = command.Print("select particulier .*, date_add(date_adhesion, interval duree year) from adhere natural join particulier natural join fidelio where num_F = 3;", c);
                            Console.WriteLine(a);
                        Console.WriteLine("\n Liste des non-adherant a Fidelio Max || Date d'expiration");
                        a = command.Print("select particulier .*, date_add(date_adhesion, interval duree year) from adhere natural join particulier natural join fidelio where num_F = 4;", c);
                            Console.WriteLine(a);
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("\n Prix moyen d'une commande : ");
                        a = command.Print("select (avg(prix_p*quantite_piece)+avg(prix_b*quantite_bicyclette))/2 from contient_P natural join contient_b natural join piece natural join modele ;", c);
                            Console.WriteLine(a);
                            Console.WriteLine("\nNombre moyen de pieces par commandes : ");
                        a = command.Print("select avg(quantite_piece) from contient_P ;", c);
                            Console.WriteLine(a);
                            Console.WriteLine("\nNombre moyen de velos par commandes : ");
                        a = command.Print("select avg(quantite_bicyclette) from contient_b ;", c);
                            Console.WriteLine(a);

                            Console.WriteLine("\n\n Fin du Module Statistiques");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Choisissez \n -1 Create \n -2 Delete \n -3 Update \n -4 Read");
                        int choix12 = Convert.ToInt32(Console.ReadLine());
                        switch(choix12)
                        {
                            case 1:
                                Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
                                Console.WriteLine("Veuillez entrer la table : ");
                                string table = Console.ReadLine();
                                Admin.Create(c, table);
                                break;
                            case 2:
                                Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
                                Console.WriteLine("Veuillez entrer la table : ");
                                string table2 = Console.ReadLine();
                                Admin.Delete(c, table2);
                                break;
                            case 3:
                                Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
                                Console.WriteLine("Veuillez entrer la table : ");
                                string table3 = Console.ReadLine();
                                Admin.Update(c, table3);
                                break;
                            case 4:
                                    Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
                                    Console.WriteLine("Veuillez entrer la table : ");
                                    string table4 = Console.ReadLine();
                                    a = command.Print($"select * from {table4};",c);
                                    Console.WriteLine(a);
                                    Console.ReadKey();
                                    break;
                           default:
                                    Console.WriteLine("Erreur, veuillez recommencer");
                                break;

                        }

                    
                            
                        break;
                    }
                    case 8:
                        break;
                    case 10:
                        Console.WriteLine("Bienvenu dans la démo :");

                        Console.WriteLine("Nombre de clients particuliers : ");
                        a = command.Print("select count(*) from particulier;",c);
                        Console.WriteLine(a);

                        Console.WriteLine("Nombre de clients Entreprises : ");
                        a = command.Print("select count(*) from boutique;", c);
                        Console.WriteLine(a);

                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Nom des clients particuliers avec leur commande : ");
                        a = command.Print("select nom_p, description_p,contient_p.quantite_piece,nom, contient_b.quantite_bicyclette from particulier natural join piece natural join commande natural join modele natural join contient_b natural join contient_p;", c);
                        Console.WriteLine(a);

                        Console.WriteLine("Nom des clients Entreprise avec leurs commandes : ");
                        a = command.Print("select nom_b, description_p,contient_p.quantite_piece,nom, contient_b.quantite_bicyclette from boutique natural join piece natural join commande natural join modele natural join contient_b natural join contient_p;", c);
                        Console.WriteLine(a);

                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Pieces avec un stock de 2 ou plus");
                        a = command.Print("select distinct piece.description_p,stock from piece where stock >= 2;",c);
                        Console.WriteLine(a);

                        Console.WriteLine("Velos avec un stock de 2 ou plus");
                        a = command.Print("select distinct nom,quantite from modele natural join assemble where quantite >= 2;", c);
                        Console.WriteLine(a);

                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Nombre de pieces fournis par fournisseur");
                        a = command.Print("select nom_f,fourni_par.num_p,quantite from fournisseur natural join fourni_par, assemble; ", c);
                        Console.WriteLine(a);

                        Console.WriteLine("Fin du mode démo");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 20:

                        command.Load_data(c);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                default:
                    Console.WriteLine("\nErreur. Entrez (1) - (2) - (3) - (4) - (5) - (6) - (7)");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}

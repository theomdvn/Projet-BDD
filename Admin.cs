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
    public class Admin
    {
        public static void Create(MySqlConnection c,string table)
        {
            //Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
            //Console.WriteLine("Veuillez choisir la table");
            //string table = Console.ReadLine();
            string colonnes = $"SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{table}'";
            Console.WriteLine("Les données a remplir sont : ");
            Console.WriteLine("(Si les données sont vides, veuillez indiquer null)");
            string col = command.Print(colonnes, c);
            Console.WriteLine(col);
            Console.WriteLine("Format demandé : ('donnée1','donnée2',...'donnéeN')");
            Console.Write($"INSERT INTO {table} VALUES ");
            string donnees = Console.ReadLine();
            string creation = $"INSERT INTO {table} VALUES {donnees};";
            MySqlCommand commande = new MySqlCommand(creation, c);
            try
            {
                commande.ExecuteNonQuery();
                Console.WriteLine("Command executed successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
        }
        public static void Delete(MySqlConnection c,string table)
        {
            //Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
            //Console.WriteLine("Veuillez entrer la table");
            //string table = Console.ReadLine();
            string fulltable = $"SELECT * FROM {table};";
            string full_table = command.Print(fulltable, c);
            Console.WriteLine("Voici les données :");
            command.PrintColumns(table, c);
            Console.WriteLine(full_table);
            Console.WriteLine("Veuillez entrer la condition pour supprimer des données: ");

            Console.Write($"DELETE FROM {table} WHERE ");
            string valeurs = Console.ReadLine();
            string del = $"DELETE FROM {table} WHERE {valeurs};";
            MySqlCommand commande = new MySqlCommand(del, c);
            try
            {
                commande.ExecuteNonQuery();
                Console.WriteLine("Command executed successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
        }
        public static void Update(MySqlConnection c,string table)
        {
            //Console.WriteLine("Vous pouvez utiliser les tables suivantes : \n modele, \n piece,\n assemble,\n fournisseur,\n fourni_par,\n commande,\n boutique,\n particulier,\n fidelio,\n adhere,\n contient_b,\n contient_p");
            //string table = Console.ReadLine();
            string fulltable = $"SELECT * FROM {table};";
            string full_table = command.Print(fulltable, c);
            Console.WriteLine("Voici les données :");
            command.PrintColumns(table, c);
            Console.WriteLine(full_table);
            Console.WriteLine("Veuillez entrer la valeur a changer :");
            Console.Write($"UPDATE {table} SET ");
            string valeurs = Console.ReadLine();
            Console.WriteLine("Veuillez entrer la condition");
            Console.Write($"UPDATE {table} SET {valeurs} WHERE ");
            string cond = Console.ReadLine();
            string maj = "UPDATE " + table + " Set " + valeurs + " Where " + cond + ";";
            MySqlCommand commande = new MySqlCommand(maj, c);
            try
            {
                commande.ExecuteNonQuery();
                Console.WriteLine("Command executed successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("An error as occured : " + e.ToString());
            }
        }
    }
}

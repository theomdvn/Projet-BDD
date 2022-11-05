using System;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace projet_theo_midavaine
{
    class Program
    {
        static MySqlConnection bozo()
        {
            MySqlConnection c = null;
            try
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=velomax;UID=bozo;PASSWORD=bozo;Convert Zero Datetime=True";
                c = new MySqlConnection(connectionString);
                c.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur :" + e.ToString());
               
            }
            return c;
        }
        static void Main(string[] args)
        {
            MySqlConnection c = null;
            try
            {
                string connectionString = "SERVER=localhost;PORT=3306;DATABASE=velomax;UID=root;PASSWORD=456Qsdxw123;Convert Zero Datetime=True";
                c = new MySqlConnection(connectionString);
                c.Open();
                
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Erreur :" + e.ToString());
                return;
            }

            menu.Affichage(c);

            c.Close();
        }

    }
}

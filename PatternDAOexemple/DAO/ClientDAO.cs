using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDAOexemple
{


    class ClientDAO
    {
        SqlConnection con;

        public ClientDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=hotel; Trusted_Connection=true");
        }

        public void Insert(Client cli)
        {
            
            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "insert into client (cli_nom, cli_prenom) values (@p1, @p2)";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p1", cli.Nom );
            requete.Parameters.AddWithValue("@p2", cli.Prenom );

            requete.ExecuteNonQuery();
            con.Close();
        }

        public List<Client>  List()
        {
            List<Client> liste = new List<Client>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from client";
            requete.Connection = con;

            SqlDataReader resultat = requete.ExecuteReader();

            while(resultat.Read())
            {
                Client c = new Client();
                c.Id = Convert.ToInt32(resultat["cli_id"]);
                c.Nom = Convert.ToString(resultat["cli_nom"]);
                c.Prenom = Convert.ToString(resultat["cli_prenom"]);

                liste.Add(c);
            }
            resultat.Close();
            con.Close();
            return liste;
        }
    }
}

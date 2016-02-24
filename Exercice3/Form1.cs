using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercice3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.; database=PAPYRUS; integrated security=true");
            con.Open();

            SqlCommand requete = new SqlCommand("select * from fournis", con);

            SqlDataReader resultat = requete.ExecuteReader();

            comboBox1.Items.Add("Tous");
            while (resultat.Read())
            {
                comboBox1.Items.Add(resultat["NOMFOU"].ToString());
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                listBox1.Items.Clear();
                SqlConnection con = new SqlConnection("server=.; database=PAPYRUS; integrated security=true");
                con.Open();

                SqlDataReader resultat = null;

                if (comboBox1.SelectedIndex == 0)
                {
                    SqlCommand requete = new SqlCommand(@"select * from fournis 
                                                join entcom on entcom.numfou=fournis.numfou 
                                                ", con);
                    resultat = requete.ExecuteReader();
                }
                else
                {
                    SqlCommand requete = new SqlCommand(@"GetEntCom @nomfou", con);
                    requete.Parameters.AddWithValue("@nomfou", comboBox1.SelectedItem);
                    resultat = requete.ExecuteReader();
                }
                
                while (resultat.Read())
                {
                    string d = Convert.ToDateTime(resultat["DATCOM"]).ToShortDateString();
                    listBox1.Items.Add(resultat["NUMCOM"].ToString() + " " + d);

                }
            }
        }
    }
}

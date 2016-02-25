using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exercice2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.; database=PAPYRUS; integrated security=true");
            con.Open();
            try { 
                SqlCommand requete = new SqlCommand("select * from fournis where nomfou=@nomfou", con);
                requete.Parameters.AddWithValue("@nomfou", textBox1.Text);

                SqlDataReader resultat = requete.ExecuteReader();

                if (resultat.Read())
                {
                    textBox2.Text = resultat["nomfou"].ToString();
                    textBox3.Text = resultat["POSFOU"].ToString();
                }
                else
                {
                    MessageBox.Show("Le code fournisseur n'existe pas !!!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ARGHHH !!!");
            }
        }
    }
}

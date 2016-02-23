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

            SqlCommand requete = new SqlCommand("select * from fournis where numfou=" + textBox1.Text, con);

            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                textBox2.Text = resultat["nomfou"].ToString();
            }
        }
    }
}

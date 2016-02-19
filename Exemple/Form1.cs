using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exemple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlConnection con = new SqlConnection("server=.; database=hotel; integrated security=true");

            con.Open();

            SqlCommand req = new SqlCommand("select * from client", con);

            SqlDataReader resultat = req.ExecuteReader();

            while (resultat.Read())
            {

                listBox1.Items.Add(resultat["cli_nom"].ToString());
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.; database=hotel; integrated security=true");

            con.Open();

            SqlCommand req = new SqlCommand("insert into client (cli_nom, cli_prenom) values (@nom, @prenom)", con);
            req.Parameters.AddWithValue("@nom", textBox1.Text);
            req.Parameters.AddWithValue("@prenom", textBox2.Text);

            req.ExecuteNonQuery();


            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Exercice4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.; initial catalog=PAPYRUS; Trusted_Connection=true");


            SqlCommand req1 = new SqlCommand("select max(numfou) from fournis", con);

            int numfou = (int)req1.ExecuteScalar();
            numfou++;

            //SqlDataReader res1 = req1.ExecuteReader();
            //res1.Read();
            //int numfou = Convert.ToInt32(res1[0]);
            //res1.Close();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "insert into FOURNIS (NOMFOU, POSFOU, VILFOU, RUEFOU, CONFOU, SATISF) values (@p1, @p2, @p3, @p4, @p5, @p6)";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p1", textBox1.Text);
            requete.Parameters.AddWithValue("@p2", textBox2.Text);
            requete.Parameters.AddWithValue("@p3", textBox3.Text);
            requete.Parameters.AddWithValue("@p4", textBox4.Text);
            requete.Parameters.AddWithValue("@p5", textBox5.Text);
            requete.Parameters.AddWithValue("@p6", trackBar1.Value);

            requete.ExecuteNonQuery();


        }
    }
}

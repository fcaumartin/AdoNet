using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternDAOexemple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c.Nom = "Toto";
            c.Prenom = "Titi";

            ClientDAO database = new ClientDAO();

            database.Insert(c);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientDAO database = new ClientDAO();

            listBox1.DisplayMember = "NomComplet";
            listBox1.DataSource = database.List();

            comboBox1.DisplayMember = "Nom";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = database.List();

            //listBox1.SelectedIndex = -1;
            //comboBox1.SelectedIndex = -1;

            //dataGridView1.DataSource = database.List();

            //dataGridView1.ReadOnly = true;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedValue);
            Client c = (Client)comboBox1.SelectedItem;
            Console.WriteLine(c.Nom);
            Console.WriteLine(c.Prenom);
        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace HospitalManagementFinal
{
    public partial class Form3OutP : Form
    {
        public Form3OutP()
        {
            InitializeComponent();
            load_table();
        }

        DataTable dbdataset;
        void load_table()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=1070";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select* from patientinfo.patientdetails ;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;
                dataGridView1.AllowUserToAddRows = false;

                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                //  dataGridView1.Columns["Image"].Visible = false;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[13];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3OutP_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cases")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Cases LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }


             if (comboBox1.Text == "Name")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Name LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "Contact_number")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("Contact_number LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "AppWith")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("AppWith LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "AppRoom")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("AppRoom LIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

            if (comboBox1.Text == "DOE")
            {
                DataView DV = new DataView(dbdataset);
                DV.RowFilter = String.Format("DOELIKE '%{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
            }

           
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_table();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
    }


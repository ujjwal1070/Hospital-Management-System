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
    public partial class Form6BloodSearch : Form
    {
        public Form6BloodSearch()
        {
            InitializeComponent();
            load_table();
        }


        DataTable dbdataset;
        void load_table()
        {
            String constring = "datasource=localhost;port=3306;username=root;password=1070";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select* from bloodbank.bloodgrpinfo ;", conDataBase);
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
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[7];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = String.Format("Blood_grp LIKE '%{0}%'", comboBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form6BloodSearch_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "select * from bloodbank.bloodgrpinfo where ID='" + textBox1.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sID = myReader.GetInt32("ID").ToString();
                    string sname = myReader.GetString("Name");
                    string sContact = myReader.GetString("Contact");
                    string sAddress = myReader.GetString("Address");
                    string semail = myReader.GetString("email");


                    textBox1.Text = sID;
                    textBox2.Text = sname;
                    textBox4.Text = sContact;
                    textBox3.Text = sAddress;
                    textBox5.Text = semail;
                    


                    byte[] imgg = (byte[])(myReader["Image"]);
                    if (imgg == null)
                        pictureBox1.Image = null;
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

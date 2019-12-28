using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HospitalManagementFinal
{
    public partial class Form4OutPatientBill : Form
    {
        public Form4OutPatientBill()
        {
            InitializeComponent();
            FillCombo();
        }


        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "select * from patientinfo.patientdetails ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("ID");
                    comboBox1.Items.Add(sname);


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        


        private void Form4OutPatientBill_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "select * from patientinfo.patientdetails where ID='" + comboBox1.Text + "' ; ";
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
                    //string sDOB = myReader.GetString("DOB");
                    string sAge = myReader.GetInt32("Age").ToString();
                    // string sGender = myReader.GetString("Gender");
                    //string sMarried = myReader.GetString("Married");
                    string sContact = myReader.GetString("Contact_number");
                    //string sCase = myReader.GetString("Cases");
                    string sDOE = myReader.GetString("DOE");
                    //string sTOE = myReader.GetString("TOE");
                    string sAppDr = myReader.GetString("AppWith");
                   


                    textBox1.Text = sname;
                    //DOB_txt.Text = sDOB;
                    textBox2.Text = sAge;
                    //Gender_txt.Text = sGender;
                    // Married_txt.Text = sMarried;
                    textBox4.Text = sContact;
                    //Case_txt.Text = sCase;
                    textBox5.Text = sDOE;
                    // TOE_txt.Text = sTOE;
                    textBox6.Text = sAppDr;
                   




                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}

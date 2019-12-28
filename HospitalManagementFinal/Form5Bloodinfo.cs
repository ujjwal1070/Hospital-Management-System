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
    public partial class Form5Bloodinfo : Form
    {
        public Form5Bloodinfo()
        {
            InitializeComponent();
        }


        void auto_increment()
        {
            String s1 = "SELECT MAX(ID) FROM bloodbank.bloodgrpinfo";
            int a;
            String constringv1 = "datasource=localhost;port=3306;username=root;password=1070";
            MySqlConnection conDataBasev1 = new MySqlConnection(constringv1);
            conDataBasev1.Open();

            MySqlCommand cmdv1 = new MySqlCommand(s1, conDataBasev1);
            MySqlDataReader dr = cmdv1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
            }
        }

        private void Form5Bloodinfo_Load(object sender, EventArgs e)
        {
            auto_increment();
            DateTime datetime = DateTime.Today;
            this.textBox8.Text = datetime.ToString("yyyy-MM-dd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox7.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "insert into bloodbank.bloodgrpinfo (ID,Name,Address,Contact,Blood_grp,email,DOE,Image)  values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox8.Text + "',@IMG) ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Form5Bloodinfo_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to close the application?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
                Application.Exit();
            else if (dialog == DialogResult.No)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                textBox7.Text = PicPath;
                pictureBox1.ImageLocation = PicPath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox7.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "update bloodbank.bloodgrpinfo set ID ='" + this.textBox1.Text + "',Name='" + this.textBox2.Text + "',Address='" + this.textBox3.Text + "', Contact='" + this.textBox4.Text + "', Blood_grp='" + this.textBox5.Text + "',email='" + this.textBox6.Text + "',DOE='" + this.textBox8.Text + "',Image=@IMG where ID='" + this.textBox1.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();

                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG", imageBt));

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Updated");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            Form6BloodSearch f6 = new Form6BloodSearch();
            f6.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "delete from bloodbank.bloodgrpinfo where ID='" + this.textBox1.Text + "' ; ";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {


                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "ID")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from bloodbank.bloodgrpinfo where ID='" + textBox9.Text + "' ; ";
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
                        
                        string sAddress = myReader.GetString("Address");
                        string sContact = myReader.GetString("Contact");
                        
                        string sBlood = myReader.GetString("Blood_grp");
                        string semail = myReader.GetString("email");
                        string sDOE = myReader.GetString("DOE");
                       
                        textBox1.Text = sID;
                        textBox2.Text = sname;
                        textBox3.Text = sAddress;
                        textBox4.Text = sContact;
                        textBox5.Text = sBlood;
                        textBox6.Text = semail;
                        textBox8.Text = sDOE;
                        


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

            if (comboBox1.Text == "Name")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from bloodbank.bloodgrpinfo where Name='" + textBox9.Text + "' ; ";
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

                        string sAddress = myReader.GetString("Address");
                        string sContact = myReader.GetString("Contact");

                        string sBlood = myReader.GetString("Blood_grp");
                        string semail = myReader.GetString("email");
                        string sDOE = myReader.GetString("DOE");

                        textBox1.Text = sID;
                        textBox2.Text = sname;
                        textBox3.Text = sAddress;
                        textBox4.Text = sContact;
                        textBox5.Text = sBlood;
                        textBox6.Text = semail;
                        textBox8.Text = sDOE;


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

            if (comboBox1.Text == "Address")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from bloodbank.bloodgrpinfo where Address='" + textBox9.Text + "' ; ";
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

                        string sAddress = myReader.GetString("Address");
                        string sContact = myReader.GetString("Contact");

                        string sBlood = myReader.GetString("Blood_grp");
                        string semail = myReader.GetString("email");
                        string sDOE = myReader.GetString("DOE");

                        textBox1.Text = sID;
                        textBox2.Text = sname;
                        textBox3.Text = sAddress;
                        textBox4.Text = sContact;
                        textBox5.Text = sBlood;
                        textBox6.Text = semail;
                        textBox8.Text = sDOE;

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
        }
    }
}
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
    public partial class Form2OutP : Form
    {
        public Form2OutP()
        {
            InitializeComponent();
            timer1.Start();
            //FillCombo();
        }

        void auto_increment()
        {
            String s1 = "SELECT MAX(ID) FROM patientinfo.patientdetails";
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
                    ID_txt.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    ID_txt.Text = a.ToString();
                }
            }
        }



        /*void FillCombo()
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
                    string sname = myReader.GetString("Name");
                    comboBox1.Items.Add(sname);


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }*/

        private void Form2OutP_Load(object sender, EventArgs e)
        {
            auto_increment();
            DateTime datetime = DateTime.Today;
            this.DOE_txt.Text = datetime.ToString("yyyy-MM-dd");
           
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_imagepath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "insert into patientinfo.patientdetails (ID,Name,DOB,Age,Gender,Married,Contact_number,Cases,DOE,TOE,AppCharge,AppRoom,AppWith,Image)  values('" + this.ID_txt.Text + "','" + this.Name_txt.Text + "','" + this.DOB_txt.Text + "','" + this.Age_txt.Text + "','" + this.Gender_txt.Text + "','" + this.Married_txt.Text + "','" + this.Contact_number_txt.Text + "','" + this.Case_txt.Text + "','" + this.DOE_txt.Text + "','" + this.TOE_txt.Text + "','" + this.AppCh_txt.Text + "','" + this.comboBox2.Text + "','" + comboBox3.Text + "',@IMG) ; ";
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

        private void button1_Click(object sender, EventArgs e)
        {

            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_imagepath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);


            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "update patientinfo.patientdetails set ID ='" + this.ID_txt.Text + "',Name='" + this.Name_txt.Text + "',DOB='" + this.DOB_txt.Text + "',Age='" + this.Age_txt.Text + "',Gender='" + this.Gender_txt.Text + "',Married='" + this.Married_txt.Text + "', Contact_number='" + this.Contact_number_txt.Text + "', Cases='" + this.Case_txt.Text + "',DOE='" + this.DOE_txt.Text + "',TOE='" + this.TOE_txt.Text + "',AppCharge='" + this.AppCh_txt.Text + "',AppRoom='" + this.comboBox2.Text + "',AppWith='" + this.comboBox3.Text + "',Image=@IMG where ID='" + this.ID_txt.Text + "' ; ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "delete from patientinfo.patientdetails where ID='" + this.ID_txt.Text + "' ; ";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
            string Query = "select * from patientinfo.patientdetails where Name='" + comboBox1.Text + "' ; ";
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
                    string sDOB = myReader.GetString("DOB");
                    string sAge = myReader.GetInt32("Age").ToString();
                    string sGender = myReader.GetString("Gender");
                    string sMarried = myReader.GetString("Married");
                    string sContact_number = myReader.GetString("Contact_number");
                    string sCase = myReader.GetString("Cases");
                    string sDOE = myReader.GetString("DOE");
                    string sTOE = myReader.GetString("TOE");
                    string sAppCharge = myReader.GetString("AppCharge");
                    string sAppRoom = myReader.GetString("AppRoom");
                    string sAppWith = myReader.GetString("AppWith");

                    ID_txt.Text = sID;
                    Name_txt.Text = sname;
                    DOB_txt.Text = sDOB;
                    Age_txt.Text = sAge;
                    Gender_txt.Text = sGender;
                    Married_txt.Text = sMarried;
                    Contact_number_txt.Text = sContact_number;
                    Case_txt.Text = sCase;
                    DOE_txt.Text = sDOE;
                    TOE_txt.Text = sTOE;
                    AppCh_txt.Text = sAppCharge;
                    AppRn_txt.Text = sAppRoom;
                    AppDr_txt.Text = sAppWith;


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

            }*/
             
        }

        private void Form2OutP_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to close the application?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
                Application.Exit();
            else if (dialog == DialogResult.No)
                e.Cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                textBox_imagepath.Text = PicPath;
                pictureBox1.ImageLocation = PicPath;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.Time_lbl.Text = dateTime.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "ID")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from patientinfo.patientdetails where ID='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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
                string Query = "select * from patientinfo.patientdetails where Name='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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


            if (comboBox1.Text == "AppWith")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from patientinfo.patientdetails where AppWith='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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


            if (comboBox1.Text == "AppRoom")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from patientinfo.patientdetails where AppRoom='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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


            if (comboBox1.Text == "Contact_number")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from patientinfo.patientdetails where Contact_number='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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


            if (comboBox1.Text == "DOE")
            {
                string constring = "datasource=localhost;port=3306;username=root;password=1070   ";
                string Query = "select * from patientinfo.patientdetails where DOE='" + textBox1.Text + "' ; ";
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
                        string sDOB = myReader.GetString("DOB");
                        string sAge = myReader.GetInt32("Age").ToString();
                        string sGender = myReader.GetString("Gender");
                        string sMarried = myReader.GetString("Married");
                        string sContact_number = myReader.GetString("Contact_number");
                        string sCase = myReader.GetString("Cases");
                        string sDOE = myReader.GetString("DOE");
                        string sTOE = myReader.GetString("TOE");
                        string sAppCharge = myReader.GetString("AppCharge");
                        string sAppRoom = myReader.GetString("AppRoom");
                        string sAppWith = myReader.GetString("AppWith");

                        ID_txt.Text = sID;
                        Name_txt.Text = sname;
                        DOB_txt.Text = sDOB;
                        Age_txt.Text = sAge;
                        Gender_txt.Text = sGender;
                        Married_txt.Text = sMarried;
                        Contact_number_txt.Text = sContact_number;
                        Case_txt.Text = sCase;
                        DOE_txt.Text = sDOE;
                        TOE_txt.Text = sTOE;
                        AppCh_txt.Text = sAppCharge;
                        comboBox2.Text = sAppRoom;
                        comboBox3.Text = sAppWith;


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

        private void button4_Click(object sender, EventArgs e)
        {
            Form3OutP f3 = new Form3OutP();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4OutPatientBill f4=new Form4OutPatientBill();
            f4.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            String comboval2 = comboBox2.Text;
            this.comboBox2.Text = comboval2;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String comboval3 = comboBox3.Text;
            this.comboBox3.Text = comboval3;
        }

        private void AppDr_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            this.DOB_txt.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            DateTime endDate = DateTime.Today.Date;
            DateTime StartDate = dateTimePicker1.Value;
            var totalDays = (endDate - StartDate).TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            // var totalMonths = Math.Truncate(totalDays / 30);
            // var remainingDays = Math.Truncate((totalDays % 365) % 30);
            Age_txt.Text = totalYears.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AppRn_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_imagepath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

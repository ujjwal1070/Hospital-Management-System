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
    public partial class Form1OutP : Form
    {
        public Form1OutP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                this.Hide();
                Form2OutP f2 = new Form2OutP();
                f2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5Bloodinfo f5 = new Form5Bloodinfo();
            f5.ShowDialog();
        }
    }
}

               
            


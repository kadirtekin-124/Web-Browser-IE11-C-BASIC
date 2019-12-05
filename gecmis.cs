using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Gecmis : Form
    {
        public Gecmis()
        {
            InitializeComponent();
        }

        


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        public void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void gecmis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("Silmek icin lutfen bir Url seciniz");
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter dosya = new StreamWriter("Gecmis.txt");
                dosya.WriteLine("");
                dosya.Close();
                listBox2.Items.Clear();
            }
            catch
            {
                StreamWriter dosya = new StreamWriter("Gecmis.txt");
                dosya.WriteLine("");
                dosya.Close();
                MessageBox.Show("Silmek icin lutfen bir Url seciniz");
            }
        }
    }
}

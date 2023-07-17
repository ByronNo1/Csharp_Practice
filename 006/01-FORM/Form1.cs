using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_FORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World");
            MessageBox.Show("Hello World");
            Console.WriteLine("------- Hello World ------");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           textBox1.Text =  "Hello World";
            button2.Text = textBox1.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           // this.Close();
           // this.Hide();

        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form1_Load : Hello World");
         
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show(" Form1_FormClosing : Hello World");

        }

        private void btnHideOPEN_Click(object sender, EventArgs e)
        {
            this.Hide();
            //this.Visible = false;
            Application.DoEvents();
            Thread.Sleep(100);
            this.Show();
            //this.Visible = true;

        }


        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                MessageBox.Show(" Form1_VisibleChanged to True ");
            }
           
        }


    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _02_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MessageBox.Show("comboBox1_SelectedIndexChanged");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add((comboBox1.Items.Count + 1).ToString("00"));
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            string _str = "";
            if (comboBox1.SelectedItem != null)
            {
                _str = "comboBox1.Text:" + comboBox1.Text;
                _str = "comboBox1.SelectedItem:" + comboBox1.SelectedItem.ToString();
                _str = "Index: " + comboBox1.SelectedIndex.ToString();
                _str = " comboBox1.Items[comboBox1.SelectedIndex]:" + comboBox1.Items[comboBox1.SelectedIndex].ToString();
                MessageBox.Show(_str);

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {

                }
                _str = " comboBox1.Items[comboBox1.SelectedIndex]:" + comboBox1.Items[comboBox1.SelectedIndex].ToString();
                MessageBox.Show(_str);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add((listBox1.Items.Count + 1).ToString("00"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 99)
            {
                listBox1.Items.Clear();
            }
            List<string> list = new List<string>();
            for (int i = listBox1.Items.Count; i < listBox1.Items.Count +10; i++)
            {
                list.Add(i.ToString("00"));
            }
            listBox1.Items.AddRange(list.ToArray());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string _str = "";
            if (listBox1.SelectedItem != null && listBox1.SelectedIndex != 0)
            {
                _str = "comboBox1.Text:" + listBox1.Text;
                _str = "comboBox1.SelectedItem:" + listBox1.SelectedItem.ToString();
                _str = "Index: " + listBox1.SelectedIndex.ToString();
                _str = " comboBox1.Items[comboBox1.SelectedIndex]:" + listBox1.Items[listBox1.SelectedIndex].ToString();
                MessageBox.Show(_str);

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                else
                {

                }
                _str = " comboBox1.Items[comboBox1.SelectedIndex]:" + listBox1.Items[listBox1.SelectedIndex].ToString();
                MessageBox.Show(_str);
            }
        }

    }
}

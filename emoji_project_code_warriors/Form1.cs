﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace emoji_project_code_warriors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                MessageBox.Show("Please enter a name."); 
            }
            else 
            {
                string name = textBox1.Text;
                Form2 frm2 = new Form2(name);
                frm2.ShowDialog();
                frm2.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);    
        }
    }
}

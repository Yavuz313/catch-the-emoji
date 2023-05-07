using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace emoji_project_code_warriors
{
    public partial class Form2 : Form
    {
        private int score = 0;
        private Random rand = new Random();
        private List<PictureBox> items = new List<PictureBox>();
        private int countdown;

        public Form2(string Nname)//linking the name from form1 to form2
        {
            InitializeComponent();
            label1.Text = Nname;
            this.FormClosing += Form2_FormClosing; //closing of form1
        }

        private void MakePictureBox()
        {
            PictureBox newpic = new PictureBox();//adding picture to the second form
            newpic.Image = Properties.Resources.p1;
            newpic.SizeMode = PictureBoxSizeMode.StretchImage;
            newpic.Width = 100;//setting the size of the picture
            newpic.Height = 100;

            int x = rand.Next(10, this.ClientSize.Width - newpic.Width);
            int y = rand.Next(10, this.ClientSize.Height - newpic.Height);

            newpic.Location = new Point(x, y);
            newpic.Click += Newpic_Click;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(new Rectangle(0, 0, newpic.Width, newpic.Height));
            Region region = new Region(path);
            newpic.Region = region;

            items.Add(newpic);
            this.Controls.Add(newpic);

            newpic.Width -= 20;
            newpic.Height -= 20;
        }



        private void Newpic_Click(object sender, EventArgs e)
        {//the old picture being removed when clicked and a new image showing up
            PictureBox temPic = sender as PictureBox;
            items.Remove(temPic);
            this.Controls.Remove(temPic);
            score++;

            if (score % 10 == 0)
            {
                countdown += 5;
                this.Size = new Size(this.Width + 25, this.Height + 25);
            }
            label3.Text = "Items: " + items.Count();
            label5.Text = "Score:" + score;
        }



        private void timerevent(object sender, EventArgs e)
        {
            MakePictureBox();
            label3.Text = "Items:" + items.Count();

            countdown--;
            if (countdown <= 0)
            {
                timer1.Enabled = false;
                MessageBox.Show($"GAME OVER. your score is {score}", "GAME OVER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 foreach (PictureBox pic in items)
                {
                    this.Controls.Remove(pic);
                }
                items.Clear();
            }
            else
            {
                label4.Text = "Time Left: " + countdown + "s";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {//showing an error if user does not select the difficulty level
            //setting the timer according to the difficulty levels
            if (radioButton1.Checked)
            {
                countdown = 20;
            }
            else if (radioButton2.Checked)
            {
                countdown = 17;
            }
            else if (radioButton3.Checked)
            {
                countdown = 15;
            }
            else
            {
                MessageBox.Show("Please choose difficulty.");
                return;
            }

            MakePictureBox();
            label3.Text = "Items: " + items.Count();

            label4.Text = "Time left: " + countdown + "s";
            timer1.Enabled = true;

        }


        private void button2_Click(object sender, EventArgs e)
        {//exiting the program
            Environment.Exit(0);
        }

        private void label5_Click(object sender, EventArgs e)
        {//displaying the score
            label5.Text = "your score is" + score;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
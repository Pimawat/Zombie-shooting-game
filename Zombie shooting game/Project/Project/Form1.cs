using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class balls
        {
            public int v_x;
            public int v_y;
            public int b_x;
            public int b_y;
            public int use;
        }

        class zombies
        {
            public int type;
            public int v_x;
            public int v_y;
            public int b_x;
            public int b_y;
            public int life;
        }
        
        List<balls> list_balls = new List<balls>();
        Random rd = new Random();
        List<zombies> list_zombies = new List<zombies>();
        List<int> score = new List<int>();
        int score1 = 0;
        int mylife = 3;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            


            Graphics g = e.Graphics;
            Bitmap bt = new Bitmap("tower3.png");
            Bitmap bt2 = new Bitmap(bt, pictureBox7.Width, pictureBox7.Height);
            g.DrawImage(bt2, -20, 95);
            for (int i = 0; i < list_balls.Count; i++)
            {
                if (list_balls[i].use == 1)
                {
                    g.FillEllipse(Brushes.Black, list_balls[i].b_x - 3, list_balls[i].b_y - 3, 6, 6);
                }
            }
            
            for (int j = 0; j < list_zombies.Count; j++)
            {
                if (list_zombies[j].type==1&list_zombies[j].life==0)
                {
                    Bitmap bt3 = new Bitmap("Zombie1.gif");
                    Bitmap bt4 = new Bitmap(bt3, pictureBox3.Width, pictureBox3.Height);

                    g.DrawImage(bt4, list_zombies[j].b_x, list_zombies[j].b_y);

                }
                else if (list_zombies[j].type == 2 & list_zombies[j].life == 0)
                {
                    Bitmap bt3 = new Bitmap("zombieflying.png");
                    Bitmap bt4 = new Bitmap(bt3, pictureBox3.Width, pictureBox3.Height);

                    g.DrawImage(bt4, list_zombies[j].b_x, list_zombies[j].b_y);

                }
                else if (list_zombies[j].type == 3 & list_zombies[j].life == 0)
                {
                    Bitmap bt3 = new Bitmap("zombiejet.png");
                    Bitmap bt4 = new Bitmap(bt3, pictureBox3.Width, pictureBox3.Height);

                    g.DrawImage(bt4, list_zombies[j].b_x, list_zombies[j].b_y);

                }
            }

        }
    
        public void button1_Click(object sender, EventArgs e)
        {

            
        }
        int time = 0;
        int zt = 50;
        int b = -1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for (int m = 0; m < list_balls.Count; m++)
            {
                for (int n = 0; n < list_zombies.Count; n++)
                {
                    if (list_balls[m].use==1 & b != n & list_zombies[n].life == 0 & list_balls[m].b_x >= list_zombies[n].b_x & list_balls[m].b_x <= list_zombies[n].b_x + 63 & list_balls[m].b_y > list_zombies[n].b_y & list_balls[m].b_y <= list_zombies[n].b_y + 72)
                    {
                        list_zombies[n].life = -1;
                        score1++;
                        b = n;
                        list_zombies[n].v_x = 0;
                        list_zombies[n].v_y = 0;
                        list_balls[m].use = 0;

                    }

                }
            }

            

            if (time % zt == 0)
            {
                zombies tmp = new zombies();
                int a = rd.Next(1, 4);
                tmp.type = a;
                if (a == 1)
                {

                    tmp.b_x = pictureBox1.Width;
                    tmp.b_y = pictureBox1.Height - 150;
                    tmp.v_x = -5;
                    tmp.v_y = 0;
                    tmp.life = 0;
                }
                else if (a == 2)
                {

                    tmp.b_x = pictureBox1.Width;
                    tmp.b_y = pictureBox1.Height - 225;
                    tmp.v_x = -4;
                    tmp.v_y = 0;
                    tmp.life = 0;
                }
                else
                {
                    tmp.b_x = pictureBox1.Width;
                    tmp.b_y = pictureBox1.Height - 400;
                    tmp.v_x = -5;
                    tmp.v_y = -1;
                    tmp.life = 0;
                }
                list_zombies.Add(tmp);

            }
            if (mylife == 0)
            {
                timer1.Stop();
                MessageBox.Show("GAME OVER !!!");
                this.Dispose();
            }
            else
            {
                for (int i = 0; i < list_balls.Count; i++)
                {
                    list_balls[i].b_x += list_balls[i].v_x;
                    list_balls[i].b_y -= list_balls[i].v_y;
                }
                
                for (int j = 0; j < list_zombies.Count; j++)
                {
                    list_zombies[j].b_x += list_zombies[j].v_x;
                    list_zombies[j].b_y -= list_zombies[j].v_y;
                }
                Refresh();
                time++;

            }
            for (int z = 0; z < list_zombies.Count; z++)
            {
                if (list_zombies[z].b_x <= 0 & list_zombies[z].b_x >= -5)
                {
                    mylife--;
                }
            }
            
            if (zt >= 15)
            {
                if (time%10==0)
                {
                    zt--;
                }
            }
            label4.Text = ": " + score1;
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = pictureBox1.Height - e.Y-275;
            balls tmp = new balls();
            tmp.b_x = 20;
            tmp.b_y = pictureBox1.Height - 275;
            tmp.v_x = 0;
            tmp.v_y = 0;
            tmp.use = 1;
            list_balls.Add(tmp);
            
            timer1.Start();

            tmp.v_x = 20 ;
            tmp.v_y = (20 * y) / x;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bt = new Bitmap("bg.png");
            Bitmap bt2 = new Bitmap(bt, pictureBox1.Width, pictureBox1.Height);
            this.BackgroundImage = bt2;
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(mylife>=1)
            {
                Bitmap bt = new Bitmap("ph.png");
                Bitmap bt2 = new Bitmap(bt, pictureBox4.Width, pictureBox4.Height);
                g.DrawImage(bt2, 0, 0);
            }
        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (mylife >= 2)
            {
                Bitmap bt = new Bitmap("ph.png");
                Bitmap bt2 = new Bitmap(bt, pictureBox5.Width, pictureBox5.Height);
                g.DrawImage(bt2, 0, 0);
            }
        }

        private void pictureBox6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (mylife >= 3)
            {
                Bitmap bt = new Bitmap("ph.png");
                Bitmap bt2 = new Bitmap(bt, pictureBox6.Width, pictureBox6.Height);
                g.DrawImage(bt2, 0, 0);
            }
        }

        private void pictureBox7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x.Text = e.X.ToString();
            y.Text = e.Y.ToString();
        }
    }
}

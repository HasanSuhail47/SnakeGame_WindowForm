using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoredAF2
{
    public partial class Form1 : Form
    {
        bool left,right, top, bottom;
        List<PictureBox> body=new List<PictureBox>();
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            body.Add(pictureBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (pictureBox1.Right < this.Width-40&&right==true)
            {
                
                Point p= new Point(pictureBox1.Bounds.X + 40, pictureBox1.Bounds.Y);
                Point p2 = new Point();
                for (int i = 0; i < body.Count; i++)
                {
                    p2 = body[i].Location;
                    body[i].Location=p;
                    p= p2;
                }
               
            }
            if (pictureBox1.Left >3  && left == true)
            {

                Point p = new Point(pictureBox1.Bounds.X - 40, pictureBox1.Bounds.Y);
                Point p2 = new Point();
                for (int i = 0; i < body.Count; i++)
                {
                    p2 = body[i].Location;
                    body[i].Location = p;
                    p = p2;
                }
            }
            if (pictureBox1.Bottom<this.Height-50&&bottom==true)
            {
                Point p = new Point(pictureBox1.Bounds.X, pictureBox1.Bounds.Y+40);
                Point p2 = new Point();
                for (int i = 0; i < body.Count; i++)
                {
                    p2 = body[i].Location;
                    body[i].Location = p;
                    p = p2;
                }
            }
            if (pictureBox1.Top >3 && top == true)
            {
                Point p = new Point(pictureBox1.Bounds.X, pictureBox1.Bounds.Y-40);
                Point p2 = new Point();
                for (int i = 0; i < body.Count; i++)
                {
                    p2 = body[i].Location;
                    body[i].Location = p;
                    p = p2;
                }
            }

            if (food.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                Random r=new Random();
                Random r2=new Random();
                food.Location= new Point(r.Next()%800, r2.Next()%450);
                PictureBox bodypart = new PictureBox()
                {
                    Location = body.Last().Location,
                    BackColor = Color.Black,
                    Size = pictureBox1.Size
                };
                this.Controls.Add(bodypart);
                body.Add(bodypart);
                label1.Text = body.Count().ToString();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                right = false;
                left = true;
                top = false;
                bottom = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                left = false;
                top= false;
                bottom = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                right = false;
                left = false;
                top = true;
                bottom = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                right = false;
                left = false;
                top = false;
                bottom = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Фрактальные_множества
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Pen p;
        int x;
        int y;
        public int x_MouseDown_1, y_MouseDown_1;
        Color Col = Color.Black;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0 
                && textBox5.Text.Length > 0&& numericUpDown1.Text.Length>0)
            {
                g = pictureBox1.CreateGraphics();
                p = new Pen(Col, 3);
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);
                float l = Convert.ToInt32(textBox4.Text);
                float u = int.Parse(numericUpDown1.Text);
                int r = Convert.ToInt32(textBox5.Text);
                u = (u / 360) * (float)(2 * Math.PI);
                int a = listBox1.SelectedIndex;
                switch (a)
                {
                    case 0:
                        KrivaKoxa(x, y, l, u, r);
                        break;
                    case 1:
                        RezanniList(x, y, l, u, r);
                        break;
                    case 2:
                        ObezianeDerevo(x, y, l, u, r);
                        break;
                    case 3:
                        LedanoiFraktal(x, y, l, u);
                        break;
                    case 4:
                        KrivaDrakona(x, y, l);
                        break;
                    case 5:
                        KrivaGospera(x, y, l, u, r);
                        break;
                    case 6:
                        Vetka(x, y, l);
                        break;
                    case 7:
                        DerevoPifagora(x, y, l);
                        break;
                    case 8:
                        DvoicnoeDerevo(x, y, l);
                        break;
                    case 9:
                        ShechinkaKoxa(x, y, l, u);
                        break;
                    default:
                        MessageBox.Show("Выберите Фрактал");
                        break;
                }
            }
            else
            { MessageBox.Show("Вводимые поля не должны быть пустыми"); }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Update();
            pictureBox1.Refresh();
            textBox1.Text = Convert.ToString(pictureBox1.Size.Width / 2);
            textBox2.Text = Convert.ToString(pictureBox1.Size.Height / 2);
            textBox5.Text = Convert.ToString(4);
            textBox4.Text = Convert.ToString(239);
            numericUpDown1.Text= Convert.ToString(0);
        }
        //
        private void KrivaKoxa(int x, int y, float l, float u, int r)
        {
            A1(x, y, l, u, r);
        }
        private void A1(float x, float y, float l, float u, int r)
        {
            g = pictureBox1.CreateGraphics();
            if (r > 0)
            {
                l = l / 3;
                A2(ref x, ref y, l, u, r - 1);
                A2(ref x, ref y, l, u + (float)Math.PI / 3, r - 1);
                A2(ref x, ref y, l, u - (float)Math.PI / 3, r - 1);
                A2(ref x, ref y, l, u, r - 1);
            }
            else
            {
                g.DrawLine(p, x, y, (x + (float)Math.Cos(u) * l), (y - (float)Math.Sin(u) * l));
            }
        }
        private void A2(ref float x, ref float y, float l, float u, int t)
        {
            A1(x, y, l, u, t);
            x = x + l * (float)Math.Cos(u);
            y = y - l * (float)Math.Sin(u);
        }
        private void ShechinkaKoxa(float x, float y, float l, float u)
        {
            float b = (float)Math.Sqrt(Math.Pow(l, 2) - Math.Pow(l / 2, 2));
            A1(x, y - b, l, -2 * (float)Math.PI / 3 + u, 3);
            A1(x - l / 2, y, l, 0 + u, 3);
            A1(x + l / 2, y, l, 2 * (float)Math.PI / 3 + u, 3);
        }

        //
        private void RezanniList(float x, float y,float l,float u,  int r)
        {
            B1(x, y, l, (float)(-Math.PI)+u, r);
            B1(x-l, y+l, l, 0+u, r);
            B1(x-l, y, l, (float)(-Math.PI) / 2+u, r);
            B1(x, y+l, l, (float)Math.PI / 2+u, r);
        }   
        private void B1(float x, float y, float l, float u, int t)
        {
            g = pictureBox1.CreateGraphics();
            if (t > 0)
            {
                l = l * (float)0.453;
                B2(ref x, ref y, l, u, t - 1);
                B2(ref x, ref y, l, u + 7 * (float)Math.PI / 15, t - 1);
                B2(ref x, ref y, l, u - 7 * (float)Math.PI / 15, t - 1);
                B2(ref x, ref y, l, u, t - 1);
            }
            else
            {
                g.DrawLine(p,x, y, (x + (float)Math.Cos(u) * l), (y - (float)Math.Sin(u) * l));
            }
        }
        private void B2(ref float x, ref float y, float l, float u, int t)
        {
            B1(x, y, l, u, t);
            x = x + l * (float)Math.Cos(u);
            y = y - l * (float)Math.Sin(u);
        }
        //
         private void ObezianeDerevo(float x, float y, float l,float u, int r)
        {
            C1(x, y, l, u, r, 0, 1);
        }
        private void C1(float x, float y, float l, float u, int t, int q, int s)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (t > 0)
            {
                if (q == 1)
                {
                    x = x + l * (float)Math.Cos(u);
                    y = y - l * (float)Math.Sin(u);
                    s = -s;
                    u = u + (float)Math.PI;
                }
                else if (q == 3)
                {
                    x = x + l * (float)Math.Cos(u);
                    y = y - l * (float)Math.Sin(u);
                    s = s;
                    u = u + (float)Math.PI;
                }
                else if (q == 2)
                {
                    s = -s;
                }
                else if (q == 0)
                {
                    s = s;
                }
                l = l / 3;
                C2(ref x, ref y, l, u + s * (float)Math.PI / 3, t - 1, 2, s);
                C2(ref x, ref y, l, u + s * (float)Math.PI / 3, t - 1, 1, s);
                C2(ref x, ref y, l, u, t - 1, 0, s);
                C2(ref x, ref y, l, u - s * (float)Math.PI / 3, t - 1, 1, s);
                C2(ref x, ref y, l * (float)Math.Sqrt(3) / 3, u - s * 7 * (float)Math.PI / 6, t - 1, 1, s);
                C2(ref x, ref y, l * (float)Math.Sqrt(3) / 3, u - s * 7 * (float)Math.PI / 6, t - 1, 2, s);
                C2(ref x, ref y, l * (float)Math.Sqrt(3) / 3, u - s * 5 * (float)Math.PI / 6, t - 1, 3, s);
                C2(ref x, ref y, l * (float)Math.Sqrt(3) / 3, u - s * (float)Math.PI / 2, t - 1, 3, s);
                C2(ref x, ref y, l * (float)Math.Sqrt(3) / 3, u - s * (float)Math.PI / 2, t - 1, 0, s);
                C2(ref x, ref y, l, u, t - 1, 3, s);
                C2(ref x, ref y, l, u, t - 1, 0, s);
            }
            else
            {
                g.DrawLine(p,x, y, (x + (float)Math.Cos(u) * l), (y - (float)Math.Sin(u) * l));
            }
        }
        private void C2(ref float x, ref float y, float l, float u, int t, int q, int s)
        {
            C1(x, y, l, u, t, q, s);
            x = x + l * (float)Math.Cos(u);
            y = y - l * (float)Math.Sin(u);
        }
        //
        private void LedanoiFraktal(float x, float y, float l, float u)
        {
            float b = (float)Math.Sqrt(Math.Pow(l, 2) - Math.Pow(l / 2, 2));
            D1(x, y-b, l, -2 * (float)Math.PI / 3+u, 3);
            D1(x-l/2, y, l, 0+u, 3);
            D1(x+l/2, y, l, 2 * (float)Math.PI / 3+u, 3);

        } 
        private void D1(float x, float y, float l, float u, int t)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (t > 0)
            {
                l = l * (float)0.5;
                D2(ref x, ref y, l, u, t - 1);
                D2(ref x, ref y, l * -(float)0.45, u + 2 * (float)Math.PI / 3, t - 1);
                D2(ref x, ref y, l * -(float)0.45, u - (float)Math.PI / 3, t - 1);
                D2(ref x, ref y, l * -(float)0.45, u + (float)Math.PI / 3, t - 1);
                D2(ref x, ref y, l * -(float)0.45, u - 2 * (float)Math.PI / 3, t - 1);
                D2(ref x, ref y, l, u, t - 1);
            }
            else
            {
                g.DrawLine(p,x, y, (x + (float)Math.Cos(u) * l), (y - (float)Math.Sin(u) * l));
            }
        }
        private void D2(ref float x, ref float y, float l, float u, int t)
        {
            D1(x, y, l, u, t);
            x = x + l * (float)Math.Cos(u);
            y = y - l * (float)Math.Sin(u);
        }
        //
        private void KrivaDrakona(float x, float y,float l)
        {
            Graphics g = pictureBox1.CreateGraphics();
            const int s = 10000;
            double t, x1, y1, q;
            int rad;
            rad = (int)l/2;
            Random r = new Random();
            x1 = 1.0;
            y1 = 0.0;
            for (int i = 0; i < s; i++)
            {
                q = r.NextDouble();
                t = x1;
                if (q <= 0.5)
                {
                    x1 = -0.5 * x1 + 0.5 * y1 + 1.5;
                    y1 = -0.5 * t - 0.5 * y1 + 0.5;
                }
                else
                {
                    x1 = 0.5 * x1 - 0.5 * y1;
                    y1 = 0.5 * t + 0.5 * y1;
                }

                g.DrawEllipse(p,x + (float)Math.Round(rad * x1, 0), y - (float)Math.Round(rad * y1, 0),3,3);
            }
        }
        //
        private void KrivaGospera(float x, float y,float l, float u, int r)
        {
            F1(x, y, l, u, r, 0);
        }
        private void F1(float x, float y, float l, float u, int t, int q)
        {
            Graphics g = pictureBox1.CreateGraphics();

            if (t > 0)
            {
                if (q == 1)
                {
                    x = x + l * (float)Math.Cos(u);
                    y = y - l * (float)Math.Sin(u);
                    u = u + (float)Math.PI;
                }
                u = u - 2 * (float)Math.PI / 19;
                l = l / (float)Math.Sqrt(7);
                F2(ref x, ref y, l, u, t - 1, 0);
                F2(ref x, ref y, l, u + (float)Math.PI / 3, t - 1, 1);
                F2(ref x, ref y, l, u + (float)Math.PI, t - 1, 1);
                F2(ref x, ref y, l, u + 2 * (float)Math.PI / 3, t - 1, 0);
                F2(ref x, ref y, l, u, t - 1, 0);
                F2(ref x, ref y, l, u, t - 1, 0);
                F2(ref x, ref y, l, u - (float)Math.PI / 3, t - 1, 1);

            }
            else
            {
                g.DrawLine(p,x, y, (x + (float)Math.Cos(u) * l), (y - (float)Math.Sin(u) * l));
            }
        }
        private void F2(ref float x, ref float y, float l, float u, int t, int q)
        {
            F1(x, y, l, u, t, q);
            x = x + l * (float)Math.Cos(u);
            y = y - l * (float)Math.Sin(u);
        }
        //
        private void Vetka(float x, float y, float l)
        {
            Graphics g = pictureBox1.CreateGraphics();
            const int s = 5000;
            double t, x1, y1, q;
            int rad;
            rad = (int)l;
            Random r = new Random();
            x1 = 1.0;
            y1 = 0.0;
            for (int i = 0; i < s; i++)
            {
                q = r.NextDouble();
                t = x1;
                if (q <= 0.710544)
                {
                    x1 = 0.724800 * x1 + 0.033700 * y1 + 0.206000;
                    y1 = -0.025300 * t + 0.742600 * y1 + 0.253800;
                }
                else if (q <= 0.84793)
                {
                    x1 = 0.158300 * x1 - 0.129700 * y1 + 0.138300;
                    y1 = 0.355000 * t + 0.367600 * y1 + 0.175000;
                }
                else if (q <= 0.990099)
                {
                    x1 = 0.338600 * x1 + 0.369400 * y1 + 0.067900;
                    y1 = 0.222700 * t - 0.075600 * y1 + 0.082600;
                }
                else
                {
                    x1 = 0.243900 * y1;
                    y1 = 0.305300 * y1;
                }

                g.DrawEllipse(p,x + (float)Math.Round(rad * x1, 0), y - (float)Math.Round(rad * y1, 0),3,3);
            }
        }
        //
        private void DerevoPifagora(float x, float y,float l)
        {
            H(x, y, l, 0);
        }
        private void H(float x, float y, float l, float a)
        {
            if (l > 4)
            {
                H1((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(l), a);
                H(x - l * (float)Math.Sin(a), y - l * (float)Math.Cos(a), l / (float)Math.Sqrt(2), a + (float)Math.PI / 4);
                H(x - l * (float)Math.Sin(a) + l / (float)Math.Sqrt(2) * (float)Math.Cos(a + Math.PI / 4),
                    y - l * (float)Math.Cos(a) - l / (float)Math.Sqrt(2) * (float)Math.Sin(a + Math.PI / 4),
                    l / (float)Math.Sqrt(2),
                    a - (float)Math.PI / 4);
            }
        }
        private void H1(int x1, int y1, int l, double a1)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(p,x1, y1, x1 + (float)Math.Round(l * Math.Cos(a1)), y1 - (float)Math.Round(l * Math.Sin(a1)));
            g.DrawLine(p,x1 + (float)Math.Round(l * Math.Cos(a1)),
                y1 - (float)Math.Round(l * Math.Sin(a1)),
                x1 + (float)Math.Round(l * Math.Sqrt(2) * Math.Cos(a1 + Math.PI / 4)),
                y1 - (float)Math.Round(l * Math.Sqrt(2) * Math.Sin(a1 + Math.PI / 4)));
            g.DrawLine(p,x1 + (float)Math.Round(l * Math.Sqrt(2) * Math.Cos(a1 + Math.PI / 4)),
                y1 - (float)Math.Round(l * Math.Sqrt(2) * Math.Sin(a1 + Math.PI / 4)),
                x1 + (float)Math.Round(l * Math.Cos(a1 + Math.PI / 2)),
                y1 - (float)Math.Round(l * Math.Sin(a1 + Math.PI / 2)));
            g.DrawLine(p,x1 + (float)Math.Round(l * Math.Cos(a1 + Math.PI / 2)),
                y1 - (float)Math.Round(l * Math.Sin(a1 + Math.PI / 2)), x1, y1);
        }
        //
        private void DvoicnoeDerevo(float x, float y, float l)
        {
            I(5, 8, 0.8, (int)l,(int)x,(int)y);
        }
        private void I(int n, int d, double r, int s,int x,int y)
        {
            double r1, r2, a1, a2;
            for (int i = 1; i < n; i++)
            {
                r1 = radius(s, r, i);
                r2 = radius(s, r, i - 1);
                for (int j = 0; j < Math.Round(pow(d, i)); j++)
                {
                    a1 = angle(d, i, j);
                    a2 = angle(d, i - 1, j / d);
                    LinePolar(r1, a1, r2, a2,x,y);
                }
            }
        }
        double angle(int d, int i, int j)
        {
            return (2 * Math.PI / pow(d, i) * (j - (pow(d, i) - 1) / 2));
        }
        double radius(double s, double r, int i)
        {
            return (s * (1 - pow(r, i)) / (1 - r));
        }
        double pow(double d, int n)
        {
            double result;
            result = 1.0;
            for (int i = 1; i < n; i++)
            {
                result = result * d;
            }
            return result;
        }
        private void LinePolar(double r1, double a1, double r2, double a2, int x, int y)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(p,
            (float)Math.Round(x + r1 * Math.Cos(a1)),
            (float)Math.Round(y - r1 * Math.Sin(a1)),
            (float)Math.Round(x + r2 * Math.Cos(a2)),
            (float)Math.Round(y - r2 * Math.Sin(a2)));
        }
        //
        private void FormColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Col = colorDialog1.Color;
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x_MouseDown_1 = e.X;
            y_MouseDown_1 = e.Y;
            textBox1.Text = Convert.ToString(x_MouseDown_1);
            textBox2.Text = Convert.ToString(y_MouseDown_1);
        }        
    }
}

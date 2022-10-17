using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
namespace TEST_1
{
    public partial class Form1 : Form
    {
        private Graphics gr;
        private List<Figure> rectangles = new List<Figure>();
        int t;
        const int deletefig = 3;
        private Color[] penColors = new Color[] {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Orange,
            Color.Yellow,
            Color.Gold,
            Color.Brown};

        public Form1()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            Timer timer1 = new Timer
            {
                Interval = 1000
            };
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(Timer1_Tick);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            t = 0;
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            removeRectangel();
            AddFigure();
            checkRectangel();
        }
        static Random ranGen = new Random();
        RectangleF rf;
        private void removeRectangel()
        {
            for (int i = 0; i<rectangles.Count; i++)
            {
                if (rectangles[i].delete == t && rectangles[i].delete != 0)
                {            
                    rectangles.Remove(rectangles[i]);
                    t--;
                    pictureBox1.Image = null;
                }
                else
                {
                    rectangles[i].Draw(gr);
                }
            }
        }

        private void checkRectangel()
        {
            if (rectangles.Count > 1)
            {
                for (int i = 0; i < rectangles.Count - 1; i++)
                {
                    if (compareRectangle(rf, rectangles[i].Rectangle))
                    {
                        rectangles[i].delete = rectangles.Count + deletefig;

                    }
                }
            }
        }

        private void AddFigure()
        {
            t++;
            var c = penColors[ranGen.Next(penColors.Length)];
            c = penColors[ranGen.Next(penColors.Length)];
            var brush = new SolidBrush(Color.FromArgb(140, c));

            var x = ranGen.Next(0, 500);
            var y = ranGen.Next(20, 300);
            var w = ranGen.Next(10, 40);
            var h = ranGen.Next(20, 50);

            rf = new RectangleF(x, y, w, h);

            rectangles.Add(new Figure()
            {
                Rectangle = rf,
                Fill = brush
            });

            rectangles[rectangles.Count - 1].Draw(gr);
            
        }
        

        public static bool compareRectangle(RectangleF r1, RectangleF r2) => r1.Top > r2.Bottom || r1.Left > r2.Right || r2.Top > r1.Bottom || r2.Left > r1.Right ? false : true;
    }
    public class Figure
    {
        private readonly Pen Pen1 = new Pen(Color.Black, 1);
        public RectangleF Rectangle { get; set; }
        public SolidBrush Fill { get; set; }
        public int delete { get; set; }
        public void Draw(Graphics g)
        {
            g.FillRectangle(Fill, Rectangle);
            g.DrawRectangle(Pen1, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geometrische_Figuren
{
    public partial class Form1 : Form
    {
        private int xRect = 30, yRect = 30;

        List<IGeometrischeFigur> objekte = new List<IGeometrischeFigur>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "GeoFigur";
            Rechteck r1 = new Rechteck(50, 50, 80, 60, Brushes.Red);
            Quadrat q1 = new Quadrat(150,50,60,Brushes.Black);
            Kreis k1 = new Kreis(50,150, 50, Brushes.Green);

            objekte.Add(r1);
            objekte.Add(q1);
            objekte.Add(k1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Button Start {xRect} {yRect}");
            //Graphics g = this.panelCanvas.CreateGraphics();
            Graphics g = this.panelCanvas.CreateGraphics();
            xRect += 10;
            yRect += 10;
            Random rand = new Random();
            g.FillRectangle(Brushes.Blue, new Rectangle(rand.Next(0, 300), rand.Next(0, 300), 30, 30));
            

        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.panelCanvas.Invalidate();
        }

        private void MoveToRight_Click(object sender, EventArgs e)
        {
        //    this.panelCanvas.
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            foreach (IGeometrischeFigur objekt in objekte)
            {
                objekt.Paint(e.Graphics);

                //e.Graphics.FillRectangle(Brushes.Red, new Rectangle(xRect, yRect, 300, 150));
            }
        }
    }
}

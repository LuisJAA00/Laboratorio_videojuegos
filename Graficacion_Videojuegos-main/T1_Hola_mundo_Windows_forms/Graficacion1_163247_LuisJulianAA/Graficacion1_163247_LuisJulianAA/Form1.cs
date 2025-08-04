using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graficacion1_163247_LuisJulianAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap("C:\\Users\\user\\Pictures\\a.png");
            Canvas.Image = bitmap;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Canvas.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Canvas.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}

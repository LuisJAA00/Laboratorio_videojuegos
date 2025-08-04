using CanvasBased.MeshTriangVert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasBased
{
    public partial class Form1 : Form
    {
        Canvas canvas;

        Triangle triangle;
        Scene scene;
        Render render;

        public Form1()
        {
            InitializeComponent();
            MainLoad();

            scene = new Scene("C:\\Users\\user\\Desktop\\Obj.obj");
            render = new Render(canvas);

            



        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.models[0].transform.Scale = 1;
            scene.models[0].transform.Traslation = new Vertex(250, 250, 0);
            scene.models[0].transform.Rotation += new Vertex(0.017, 0, 0);

            

            render.RenderScene(scene);

   

            pictureBox1.Invalidate();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos.Text = e.Location.ToString() + canvas.bitmap.Size;
        }

        private void MainLoad()
        {
            canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = canvas.bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformaciones
{
    public partial class Form1 : Form
    {


        int indexOfSelectedFigure = -1;
        int numberSquares;
        int numberTriangles;
        Canvas canvas; 
        Cuadrado cuadrado2 = new Cuadrado(1, new Point(100, 200));
        Triangulo triangulo = new Triangulo(1, new Point(100, 100));

        private Boolean isRecording = false;
        private int timerCounter = 0;
     
        private Boolean reproduce = false;

        List<Figura> figuras = new List<Figura>();
        List<Frame> frames = new List<Frame>();

        

        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(pictureBox);
            pictureBox.Image = Canvas.bitmap;
           
        }
        
        public void Render()
        {
            ClearPictureBox();
            if(reproduce)
            {
                if(timerCounter >= frames.Count)
                {
                    timerCounter = 0;
                }

                for(int i = 0; i < figuras.Count; i++)
                {
                    canvas.Render(frames[timerCounter].getFigure(i));
                }
              


            }
            else
            {
                for (int i = 0; i < figuras.Count; i++)
                {
                    canvas.Render(figuras[i]);
                 
                    
                }
            }
            
            pictureBox.Invalidate();
            

        }

        private void ClearPictureBox()
        {
            Canvas.graphics.Clear(Color.Black);
        }
    



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            Cuadrado cuadrado = new Cuadrado(1,new Point(pictureBox.Width/2,pictureBox.Height/2));
            figuras.Add(cuadrado );
            numberSquares++;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(isRecording)
            {
                if(timerCounter > 200) // tiempo de grabacion...
                {
                    isRecording = false;
                    timerCounter = 0;
                    Debug.WriteLine("gravacion tomada");
                }
                timerCounter++;

                frames.Add(new Frame(figuras));
            }
            timerCounter++;

            Render();

            pictureBox.Invalidate();

        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if(indexOfSelectedFigure>=0)
            {
                figuras[indexOfSelectedFigure].Translate(0, -20);
                ClearPictureBox();
            }
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            Triangulo triangulo = new Triangulo(1,new Point(pictureBox.Width/2, pictureBox.Height/2));  
            figuras.Add(triangulo);
            numberTriangles++;
        }

        private void pictureBoxClickM(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            Debug.WriteLine($"You clicked on {x} {y}!");

            indexOfSelectedFigure = MouseInFigure(new Point(x, y));
            if(indexOfSelectedFigure >= 0 )
            {
                messagesLabel.Text = "Figura seleccionada!";
                foreach (Figura f in figuras)
                {
                    f.isSelected(false);
                }
                figuras[indexOfSelectedFigure].isSelected(true);
            }
            else
            {
                foreach(Figura f in figuras)
                {
                    f.isSelected(false);
                }
                messagesLabel.Text = "No figure selected";
            }
            

        }

        private int MouseInFigure(Point mousePos)//return which figure is clicked, last figure is consider to be top front
        {
             
            for(int i = figuras.Count-1; i>=0; i --)
            {
                //if (isInFigureArea(mousePos, figuras[i]))
                //{
                //    return i;
                //}

                if (figuras[i].isPointInFigure(mousePos))
                {
                    return i;
                }
                
            }
            

            return -1;
        }
        

        private void angleLeft_Click(object sender, EventArgs e)
        {
            
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Rotate(-10 * Math.PI / 180);
                ClearPictureBox();
            }
        }

        private void angleRight_Click(object sender, EventArgs e)
        {
            
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Rotate(10 * Math.PI / 180);
                ClearPictureBox();
            }
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Translate(-20, 0);
                ClearPictureBox();
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Translate(0, 20);
                ClearPictureBox();
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Translate(20, 0);
                ClearPictureBox();
            }
        }

        private void bigButton_Click(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Scale(0.1);
                ClearPictureBox();
            }
        }

        private void smallButton_Click(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                figuras[indexOfSelectedFigure].Scale(-0.1);
                ClearPictureBox();
            }
        }

        private void recButt_Click(object sender, EventArgs e)
        {
            
            isRecording = true;
            timerCounter = 0;
        }

        private void repButt_Click(object sender, EventArgs e)
        {
            if(frames.Count == 0)
            {
                return;
            }
            timerCounter = 0;
            reproduce = !reproduce;

        }
    }
}

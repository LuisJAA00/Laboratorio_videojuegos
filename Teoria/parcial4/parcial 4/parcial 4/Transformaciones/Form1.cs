using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        int numberStars;
        


        Canvas canvas; 
        Cuadrado cuadrado2 = new Cuadrado(1, new Point(100, 200));
        Triangulo triangulo = new Triangulo(1, new Point(100, 100));
        Estrella estrella = new Estrella(2, new Point(400, 100));

        private Boolean isRecording = false;
        private int timerCounter = 0;
        private Boolean reproduce = false;
        private int previousTrackBarValue = 0;
        private int previousTrackBar2Value = 5;
        private Point posicionInicialGroupBox;
        private Point posicionInicialGroupBox2;
        private Point posicionInicialGroupBox3;
        private Point posicionInicialPictureBox;



        List<Figura> figuras = new List<Figura>();
        List<Frame> frames = new List<Frame>();


        

        public Form1()
        {

            
            
            InitializeComponent();
            canvas = new Canvas(pictureBox);
            pictureBox.Image = Canvas.bitmap;
            

            this.AutoScaleMode = AutoScaleMode.Font;
            posicionInicialGroupBox = groupBox1.Location;
            posicionInicialGroupBox2 = groupBox2.Location;
            posicionInicialGroupBox3 = groupBox3.Location;
            posicionInicialPictureBox = pictureBox.Location;
            // Asocia el evento Resize al manejador correspondiente
            this.Resize += Form1_Resize;

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            
            if (this.WindowState == FormWindowState.Maximized)
            {
                MoverGroupBoxAMaximizado();
               
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                
                RestaurarGroupBox();
            }


        }
       

        private void MoverGroupBoxAMaximizado()
        {
            int x = (this.ClientSize.Width - pictureBox.Width) / 2;
            int y = (this.ClientSize.Height - pictureBox.Height) / 2;

            pictureBox.Location = new Point(x, y);
            groupBox2.Location = new Point(x, y+400);
            
            groupBox1.Location = new Point(x+700, y);
            groupBox3.Location = new Point(x-150, y);
        }

        private void RestaurarGroupBox()
        {
            
            groupBox1.Location = posicionInicialGroupBox;
            groupBox2.Location = posicionInicialGroupBox2;
            groupBox3.Location = posicionInicialGroupBox3;
            pictureBox.Location = posicionInicialPictureBox;

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
            if(isRecording)
            {
                messagesLabel.Text = "No figures while recording";
                return;
            }
            
            Cuadrado cuadrado = new Cuadrado(1,new Point(pictureBox.Width/2,pictureBox.Height/2));
            figuras.Add(cuadrado );
            numberSquares++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Crear e instanciar un objeto de la clase Estrella
            if (isRecording)
            {
                messagesLabel.Text = "No figures while recording";
                return;
            }
            Estrella estrella = new Estrella(1, new Point(pictureBox.Width / 2, pictureBox.Height / 2));
            figuras.Add(estrella);
            numberStars++;

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if(isRecording)
            {
                if(timerCounter > 2000 || reproduce) // tiempo de grabacion...
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
            if (isRecording)
            {
                messagesLabel.Text = "No figures while recording";
                return;
            }
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

       
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
         
            int angleChange = trackBar1.Value - previousTrackBarValue;

            figuras[indexOfSelectedFigure].Rotate(angleChange * Math.PI / 180);

            ClearPictureBox();
            previousTrackBarValue = trackBar1.Value;

            if (trackBar1.Value == trackBar1.Maximum || trackBar1.Value == trackBar1.Minimum)
            {
                int remainingAngle = (trackBar1.Value == trackBar1.Maximum) ? (360 - trackBar1.Maximum) : -trackBar1.Minimum;

                figuras[indexOfSelectedFigure].Rotate(remainingAngle * Math.PI / 180);
                ClearPictureBox();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (indexOfSelectedFigure >= 0)
            {
                double scaleFactor = (trackBar2.Value - previousTrackBar2Value) * 0.1;

                if (scaleFactor != 0)
                {
                    figuras[indexOfSelectedFigure].Scale(scaleFactor);
                    ClearPictureBox();
                }

                previousTrackBar2Value = trackBar2.Value;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 nuevaVentana = new Form2();
            nuevaVentana.Show();
        }
    }
}

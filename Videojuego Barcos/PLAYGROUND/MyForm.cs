using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public partial class MyForm : Form
    {
        Scene scene;
        Canvas canvas;
        float delta;
        Ball ball;
        Plataforma barco1;
        Plataforma barco2;

        private static Random random = new Random();

        int counter10s1 = 0;
        int counter10s2 = 0;

        public MyForm()
        {   
            InitializeComponent();
        }

        
        private void Init()
        {
            canvas = new Canvas(PCT_CANVAS);
            scene = new Scene();
            delta = 0;
        }

        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void ReiniciarJuego()
        {

            Vec2 posicionBarco1 = barco1.position;
            Vec2 posicionBarco2 = barco2.position;
            int anchoBarco1 = barco1.anchoBarco;
            int anchoBarco2 = barco2.anchoBarco;

            // Reinicia las variables y objetos relevantes
            barco1 = new Plataforma(90, PCT_CANVAS.Width / 2 - 100, true, posicionBarco1); // Usa las coordenadas anteriores para reiniciar el barco 1
            barco2 = new Plataforma(90, PCT_CANVAS.Width / 2 + 100, false, posicionBarco2); // Usa las coordenadas anteriores para reiniciar el barco 2

            // Restaura el tamaño de los barcos
            barco1.anchoBarco = anchoBarco1;
            barco2.anchoBarco = anchoBarco2;

            scene.Clear(); // Elimina todos los elementos de la escena

            scene.AddBarquito(barco1);
            scene.AddBarquito(barco2);

            scene.AddPlane(barco1.plane);
            scene.AddPlane(barco2.plane);

        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            canvas.Render(scene, delta);
            barco1.ProjectileCollision(barco2.projectiles);
            barco2.ProjectileCollision(barco1.projectiles);

            if (barco2.plane.isOnScreen) { barco1.ProjectileCollision(barco2.plane.projectiles); }
            if (barco1.plane.isOnScreen) { barco2.ProjectileCollision(barco1.plane.projectiles); }

            //vida de barco

            plat1HPLabel.Text = barco1.hp.ToString();
            plat2HpLabel.Text = barco2.hp.ToString();

            if (barco1.hp <= 0 || barco2.hp <= 0)
            {
                ReiniciarJuego();
                MessageBox.Show("¡Game Over!", "Game Over", MessageBoxButtons.OK);
            }

            if (barco1.hp < 7 && !barco2.plane.isOnScreen && counter10s2 > (1000))
            { barco2.CallAirSupport(); counter10s2 = 0; }

            if (barco2.hp < 7 && !barco1.plane.isOnScreen && counter10s1 > (1000))
            { barco1.CallAirSupport(); counter10s1 = 0; }

            counter10s1++;
            counter10s2++;

            counter10s1 -= random.Next(-20, 20);
            counter10s2 -= random.Next(-20, 20);

            delta += 0.001f;
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            Init();


            barco1 = new Plataforma(90, PCT_CANVAS.Width / 2 - 100, true, new Vec2(250, 250));
            barco2 = new Plataforma(90, PCT_CANVAS.Width / 2 + 100, false, new Vec2(350, 250));


            scene.AddBarquito(barco1);
            scene.AddBarquito(barco2);

            scene.AddPlane(barco1.plane);
            scene.AddPlane(barco2.plane);
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;
            
          
           
            switch(keyPressed)
            {
                case 'a':
                    barco1.isMovingLeft = true;
                    barco1.isMovingRight = false;
                    break;
                case 'd':
                    barco1.isMovingRight = true;
                    barco1.isMovingLeft = false;
                    break;
                case 'w':
                    barco1.Shoot();
                    break;

           

                case 'g':
                    barco2.isMovingLeft = true;
                    barco2.isMovingRight = false;
                    break;
                case 'j':
                    barco2.isMovingRight = true;
                    barco2.isMovingLeft = false;
                    break;

                case 'y':
                    barco2.Shoot();
                    break;


            }
        }

        public Boolean isMul3(int num)
        {
            if(num%3 == 0)
            {
                return true;
            }
            return false;
        }

        private void PNL_HEADER_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

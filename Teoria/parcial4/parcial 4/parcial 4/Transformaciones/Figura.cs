using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Transformaciones
{

    abstract internal class Figura
    {

        protected int size = 0;
        protected Pen pen = Pens.Yellow;

        protected List<Point> figurePoints { get; } = new List<Point>();
        public List<Point> renderPoints = new List<Point>();

        public void AddPoint(Point point)
        {
            figurePoints.Add(point);
            renderPoints.Add(point);
        }
        public Point ceontroide;
        //public List<Point> figurePoints = new List<Point>();
        protected Double currentRotation = 0;
        protected int currentX = 0;
        protected int currentY = 0;
        protected double currentScale = 1;


    
        public void Rener(Graphics g)
        {
            for(int i = 0; i < renderPoints.Count-1; i++)
            {
                g.DrawLine(pen, renderPoints[i], renderPoints[i+1]);
            }
            g.DrawLine(pen, renderPoints[0], renderPoints[renderPoints.Count-1]);
        }
        abstract public Point getCentroid();
        abstract public void CalculatePoints(int size, Point location);

        public void Rotate(double degree) // for one point
        {
            
            this.currentRotation += degree;

            this.Transform();
            
        }
        public void Transform()
        {
            
            Point pictureBoxPoint;
            Point pointRespectCentroid;
            double a;
            double b;
            double c;
            double d;
            double e;
            double f;

            
            for (int i = 0; i < this.figurePoints.Count; i++)
            {

                this.renderPoints[i] = new Point(this.figurePoints[i].X + currentX, this.figurePoints[i].Y + currentY);
            }

            Point centro = GetCentroid();

            for (int i = 0; i < this.figurePoints.Count; i++)
            {
                pictureBoxPoint = this.renderPoints[i]; // this points are obtained with respect to PictureBox

                pointRespectCentroid = new Point(pictureBoxPoint.X - centro.X, pictureBoxPoint.Y - centro.Y);


                a = (pointRespectCentroid.X * Math.Cos(currentRotation));
                b = (pointRespectCentroid.X * Math.Sin(currentRotation));
                c = (pointRespectCentroid.Y * Math.Sin(currentRotation));
                d = (pointRespectCentroid.Y * Math.Cos(currentRotation));
                e = a - c;
                f = b + d;


                this.renderPoints[i] = new Point(centro.X + (int)e, centro.Y + (int)f);
            }

            for (int i = 0; i < this.renderPoints.Count; i++)
            {
                pictureBoxPoint = this.renderPoints[i]; // this points are obtained with respect to PictureBox

                pointRespectCentroid = new Point(pictureBoxPoint.X - centro.X, pictureBoxPoint.Y - centro.Y);

                this.renderPoints[i] = new Point((int)(pointRespectCentroid.X * currentScale) + centro.X, (int)(pointRespectCentroid.Y * currentScale) + centro.Y);

            }


        }
        public void Translate(int x, int y)
        {
            this.currentX += x;
            this.currentY += y;

            this.Transform();
        }

        public void Scale(double factor)
        {
            
            this.currentScale += factor;

            this.Transform();
        }
        
        public Point GetCentroid()
        {
            Point point;

            double x = 0.0;
            double y = 0.0;

            for (int i = 0; i < this.figurePoints.Count; i++)
            {
                x += this.renderPoints[i].X;
                y += this.renderPoints[i].Y;
               
            }

            x /= this.renderPoints.Count;
            y /= this.renderPoints.Count;
         
            point = new Point((int)x, (int)y);

            return point;
        }

        public void isSelected(Boolean selected)
        {
            if(selected)
            {
                pen = Pens.Green;
            }
            else
            {
                pen = Pens.Yellow;
            }
        }

        public Boolean isPointInFigure(Point point)
        {
            if(inYRange(point))
            {
                if(Xintersection(point) ==1)
                {
                    Debug.WriteLine($"Figure selected!");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Figure not selected!");
                    return false;
                }
            }
            else
            {
                return false;
            }
           
            
        }
        private Boolean inYRange(Point point) // if pointY is inside a and b range, it is at the same height
        {
            
            if ((point.Y < renderPoints[0].Y) && (point.Y > renderPoints[renderPoints.Count - 1].Y))
            {
                return true;
            }
            else if ((point.Y > renderPoints[0].Y) && (point.Y < renderPoints[renderPoints.Count - 1].Y))
            {
                return true;
            }
            for (int i = 0; i < renderPoints.Count - 1; i++)
            {
                if ((point.Y < renderPoints[i].Y) && (point.Y > renderPoints[i + 1].Y) || (point.Y > renderPoints[i].Y) && (point.Y < renderPoints[i + 1].Y))
                {
                    return true;
                }

            }
            return false;
        }
        private Boolean inYRagne(Point point, Point a, Point b)
        {
            if ((point.Y < a.Y) && (point.Y > b.Y))
            {
                return true;
            }
            else if ((point.Y > a.Y) && (point.Y < b.Y))
            {
                return true;
            }
            return false;
        }
        private int Xintersection(Point point) // returns the number of times the point intersect a line of figure
        {
            int countInterseccionIzq = 0; //how many are on left?
            int countInterseccionDer = 0; //how many are on right?

            for (int i = 0; i < renderPoints.Count - 1; i++)
            {
                if(inYRagne(point, renderPoints[i], renderPoints[i + 1]))
                {
                    Debug.WriteLine($"%%%%%%%%%");
                    if (renderPoints[i].X > point.X && renderPoints[i + 1].X > point.X)
                    {
                        countInterseccionIzq++;
                        Debug.WriteLine($"interseccion izq!");
                    }
                    else if(renderPoints[i].X < point.X && renderPoints[i + 1].X < point.X)
                    {
                        countInterseccionDer++;
                        Debug.WriteLine($"interseccion Der!");
                    }

                    else if( (renderPoints[i].X < point.X && renderPoints[i + 1].X > point.X) || (renderPoints[i].X > point.X && renderPoints[i + 1].X < point.X) )
                    {
                        Point centro = GetCentroid();



                        if (CrossProduct(renderPoints[i], renderPoints[i + 1],point))//punto arriba de linea
                        {
                            Debug.WriteLine("punto arriba");
                        }
                        else//punto abajo de linea
                        {
                            Debug.WriteLine("punto abajo");
                            countInterseccionDer++;
                            countInterseccionIzq++;
                        }

                    }
                }
                
            }
            
            if (inYRagne(point, renderPoints[0], renderPoints[renderPoints.Count-1]))
            {
                if (renderPoints[0].X > point.X && renderPoints[renderPoints.Count - 1].X > point.X)
                {
                    countInterseccionIzq++;
                    Debug.WriteLine($"interseccion izq!");
                }
                else if (renderPoints[0].X < point.X && renderPoints[renderPoints.Count - 1].X < point.X)
                {
                    countInterseccionDer++;
                    Debug.WriteLine($"interseccion der!");
                }

                else if ((renderPoints[0].X < point.X && renderPoints[renderPoints.Count - 1].X > point.X) || (renderPoints[0].X > point.X && renderPoints[renderPoints.Count - 1].X < point.X))
                {
                    Point centro = GetCentroid();

                    if (CrossProduct(renderPoints[renderPoints.Count - 1], renderPoints[0], point))//punto arriba de linea
                    {
                        Debug.WriteLine("punto arriba");
                    }
                    else//punto abajo de linea
                    {
                        Debug.WriteLine("punto abajo");
                        countInterseccionDer++;
                        countInterseccionIzq++;
                    }


                }
            }
            if (countInterseccionDer > 1 || countInterseccionIzq > 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }


           
        }

        private Boolean CrossProduct(Point a, Point b, Point p)//true is positive result
        {
            double res = (b.X - a.X) * (p.Y - a.Y) - ((b.Y - a.Y) * (p.X - a.X));
            if (res < 0)
            {
                return false;
            }
            else if(res > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }


    }

    
}

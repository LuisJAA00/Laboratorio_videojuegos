using CanvasBased.MeshTriangVert;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    
    
    internal class Render
    {
        private Canvas canvas;
        Translacion translacion = new Translacion();
        Rotation rotation = new Rotation();
        Scale scale = new Scale();
        Perspective perspective = new Perspective();

        public Render(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public void RenderScene(Scene scene)
        {
            canvas.FastClear();

            Model model;
         

            for (int i = 0; i < scene.models.Count; i++)
            {
                model = scene.models[i];

                // transformations
                
                model = scale.ScaleModel(model);
                
                model = rotation.RotateModel(model);
                //model = perspective.PerspectiveModel(model);

                model = translacion.TranslateModel(model);



                if (model != null)
                {
                    RenderObject(model);
                }


            }
        }

        public void RenderObject(Model model)
        {
            Color c = Color.Red;
            Point p1;
            Point p2;
            Point p3;

            Mesh mesh = model.mesh;

            for(int i = 0; i < mesh.triangles.Count; i++)
            {

                p1 = new Point((int)mesh.triangles[i].vertices[0][0],(int)mesh.triangles[i].vertices[0][1]);
                p2 = new Point((int)mesh.triangles[i].vertices[1][0], (int)mesh.triangles[i].vertices[1][1]);
                p3 = new Point((int)mesh.triangles[i].vertices[2][0], (int)mesh.triangles[i].vertices[2][1]);
                
                canvas.DrawLine(p1,p2,c);
                canvas.DrawLine(p2, p3, c);
                canvas.DrawLine(p3, p1, c);

            }

            
        }

      

    }
}

using CanvasBased.MeshTriangVert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Translacion
    {

        public Model TranslateModel(Model model)
        {
            Model resModel = model;
          

            for ( int i = 0; i < model.mesh.triangles.Count; i++ )
            {
                for (int j = 0; j < model.mesh.triangles[i].vertices.Count; j++)
                {
                    resModel.mesh.triangles[i].vertices[j] = model.mesh.triangles[i].vertices[j].TranslateThisVertex((int)model.transform.Traslation[0], (int)model.transform.Traslation[1],(int) model.transform.Traslation[2]);
                    
                }
               
            }
 
            return resModel;
        }
    }
}

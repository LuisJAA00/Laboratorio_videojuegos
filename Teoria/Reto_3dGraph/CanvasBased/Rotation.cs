using CanvasBased.MeshTriangVert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Rotation
    {

        public Model RotateModel(Model model)
        {
            Model resModel = new Model(model.path);
            resModel.transform = model.transform;

            for (int i = 0; i < model.mesh.triangles.Count; i++)
            {
                for (int j = 0; j < model.mesh.triangles[i].vertices.Count; j++)
                {
                    resModel.mesh.triangles[i].vertices[j] = model.mesh.triangles[i].vertices[j].RotX(model.transform.Rotation[0]);
                    resModel.mesh.triangles[i].vertices[j] = resModel.mesh.triangles[i].vertices[j].RotY(model.transform.Rotation[1]);
                    resModel.mesh.triangles[i].vertices[j] = resModel.mesh.triangles[i].vertices[j].RotZ(model.transform.Rotation[2]);
                }

            }
           
            return resModel;
        }
    }
}
